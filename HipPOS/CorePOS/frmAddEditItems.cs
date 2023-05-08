using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.CommonForms;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace CorePOS;

public class frmAddEditItems : frmMasterForm
{
	private int int_0;

	private string string_0;

	private string string_1;

	private bool bool_0;

	private decimal decimal_0;

	private DateTime? nullable_0;

	private DateTime? nullable_1;

	private DateTime? nullable_2;

	private DateTime? nullable_3;

	private bool bool_1;

	private string string_2;

	private Dictionary<string, string> dictionary_0;

	private string string_3;

	private decimal decimal_1;

	private decimal decimal_2;

	private List<CustomFieldValueDisplay> list_2;

	protected GClass6 context;

	private List<ItemsInItemsField> list_3;

	private List<GroupsInItemsField> list_4;

	private List<MaterialsInItem> list_5;

	private List<int> list_6;

	private bool bool_2;

	private RadTextBoxControl radTextBoxControl_0;

	private IContainer icontainer_1;

	internal Button btnCancel;

	private Class20 ddlColors;

	internal Button btnSave;

	private Label label8;

	private Class20 comboGroup;

	private Label label9;

	private Label label6;

	private Label label5;

	private Label label4;

	private Label label3;

	private Label label2;

	private Label label1;

	private Label label10;

	private Label label11;

	private Class20 ddlUOM;

	private Label lblInvCount;

	private Label label13;

	internal Button btnShowKeyboard_InventoryQTY;

	internal Button btnShowKeyboard_ItemPrice;

	internal Button btnShowKeyboard_Name;

	private Label label15;

	internal Button btnShowKeyboard_ItemCost;

	private Label label17;

	private Class20 ddlTaxRules;

	private Class20 ddlItemTypes;

	private Label label16;

	private Panel pnlGroups;

	private Label label19;

	private Label pvcUvEahoB;

	private Panel panel1;

	private Label lblMargin;

	private Label label20;

	private Button btnShowCustomField;

	private Label lblInvDisable;

	private Label labelSuggestedPrice;

	private Label label21;

	private Button btnMaterials;

	private Button btnSearch;

	private Label label7;

	private Button btnShowItemAuditLogs;

	private Label lblSubTitle;

	private Panel pnlItemInfo;

	private RadTextBoxControl txtName;

	private RadToggleSwitch chkOnSale;

	private Button btnChangeDateAndPercentOff;

	private RadToggleSwitch chkActive;

	private RadToggleSwitch chkTrackInventory;

	private RadToggleSwitch chkDisableIfSoldOut;

	private RadToggleSwitch chkIsPackage;

	private Button suggestedPrice;

	private Button btnConfigurePackage;

	private RadTextBoxControl txtItemPrice;

	private RadTextBoxControl txtItemCost;

	private RadTextBoxControl txtInventoryQTY;

	internal Button btnCopy;

	private RadTextBoxControl txtDescription;

	internal Button btnShowKeyboard_Description;

	private Label label25;

	private RadTextBoxControl txtSortOrder;

	internal Button btnNew;

	private RadTextBoxControl txtNotes;

	private Label label14;

	internal Button btnShowKeyboard_Notes;

	private Class20 ddlItemCourses;

	private Label label22;

	private RadTextBoxControl txtBarcode;

	private Label label23;

	internal Button btnShowKeyboard_Barcode;

	private Class20 comboItems;

	private Panel panel2;

	private RadTextBoxControl txtMaxFreeOptions;

	private Label label24;

	private RadToggleSwitch chkTrackExpiry;

	private Label label26;

	internal Button btnInventoryBatches;

	private RadTextBoxControl txtMinFreeOptions;

	private Label label28;

	private Button btnAsssignSupplier;

	private RadToggleSwitch chkAutoResetInv;

	private Label label29;

	internal Button btnShowKeyboard_ResetQty;

	private RadTextBoxControl txtResetQty;

	private Label elDrnuVvBK;

	private Button btnSelectStations;

	private RadTextBoxControl txtStations;

	private Label lblHideLoyalty;

	private RadToggleSwitch chkAllowLoyaltyRedemp;

	private Label label27;

	private Label label30;

	private RadToggleSwitch chkSmartBarcode;

	private Label label32;

	private Label label33;

	private RadToggleSwitch chkAutoPromptOption;

	private Label lblSuggestedPriceByIngredients;

	private Label label12;

	private RadTextBoxControl txtBatchQty;

	internal Button btnShowKeyboard_BatchQty;

	private Label label31;

	private RadToggleSwitch chkTaxesIncluded;

	private Label eIfrjFraQI;

	private Label label35;

	private Label label38;

	private RadTextBoxControl txtReorderQty;

	private Label label37;

	private RadTextBoxControl txtReorderLimit;

	private Label label36;

	public frmAddEditItems(int itemID = -1, string _itemClassification = "product")
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Class26.Ggkj0JxzN9YmC();
		string_1 = Resources.Item;
		string_2 = string.Empty;
		context = new GClass6();
		radTextBoxControl_0 = new RadTextBoxControl();
		base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		int_0 = itemID;
		if (itemID != -1)
		{
			bool_0 = true;
			btnCancel.Text = Resources.CLOSE;
		}
		string_0 = _itemClassification;
		decimal_0 = default(decimal);
	}

	private void frmAddEditItems_Load(object sender, EventArgs e)
	{
		if (string_0 == ItemClassifications.Material)
		{
			string_1 = Resources.Ingredient;
			label9.Text = Resources.Ingredient_Name;
			btnCopy.Text = Resources.COPY_INGREDIENT;
			label9.Font = new Font(label9.Font.FontFamily, 10f, FontStyle.Regular);
			label10.Text = Resources.EDIT_INGREDIENTS;
			foreach (Control control in pnlItemInfo.Controls)
			{
				if (control.Tag != null && control.Tag.ToString() == "product")
				{
					control.Visible = false;
				}
				control.Text = control.Text.Replace(Resources.Item, Resources.Ingredient);
			}
			label1.Font = new Font(label1.Font.FontFamily, 10f, FontStyle.Regular);
			label17.Location = new Point(label17.Location.X, ((Control)(object)txtName).Bottom + 1);
			((Control)(object)txtItemCost).Location = new Point(((Control)(object)txtItemCost).Location.X, ((Control)(object)txtName).Bottom + 1);
			btnShowKeyboard_ItemCost.Location = new Point(btnShowKeyboard_ItemCost.Location.X, ((Control)(object)txtName).Bottom + 1);
			label12.Location = new Point(label12.Location.X, ((Control)(object)txtName).Bottom + 1);
			label11.Location = new Point(label11.Location.X, label17.Bottom + 1);
			((Control)(object)chkActive).Location = new Point(((Control)(object)chkActive).Location.X, label17.Bottom + 1);
			lblInvCount.Location = new Point(lblInvCount.Location.X, label17.Bottom + 1);
			((Control)(object)txtInventoryQTY).Location = new Point(((Control)(object)txtInventoryQTY).Location.X, label17.Bottom + 1);
			((Control)(object)txtInventoryQTY).Visible = true;
			btnShowKeyboard_InventoryQTY.Location = new Point(btnShowKeyboard_InventoryQTY.Location.X, label17.Bottom + 1);
			pvcUvEahoB.Location = new Point(pvcUvEahoB.Location.X, ((Control)(object)chkActive).Bottom + 1);
			((Control)(object)ddlUOM).Location = new Point(((Control)(object)ddlUOM).Location.X, ((Control)(object)chkActive).Bottom + 1);
			label25.Location = new Point(pvcUvEahoB.Location.X, ((Control)(object)ddlUOM).Bottom + 1);
			((Control)(object)txtDescription).Location = new Point(((Control)(object)ddlUOM).Location.X, ((Control)(object)ddlUOM).Bottom + 1);
			btnShowKeyboard_Description.Location = new Point(((Control)(object)txtDescription).Location.X + 399, ((Control)(object)ddlUOM).Bottom + 1);
			label5.Location = new Point(label5.Location.X, label25.Bottom + 1);
			label5.Visible = true;
			((Control)(object)txtSortOrder).Location = new Point(((Control)(object)txtSortOrder).Location.X, label25.Bottom + 1);
			btnSave.Location = new Point(btnSave.Location.X, ((Control)(object)txtName).Location.Y);
			btnCancel.Location = new Point(btnCancel.Location.X, btnSave.Bottom + 1);
			btnCopy.Location = new Point(btnCancel.Location.X, btnCancel.Bottom + 1);
			label12.Location = new Point(btnShowKeyboard_ItemCost.Right + 1, label12.Location.Y);
			label12.Width = btnSave.Left - btnShowKeyboard_ItemCost.Right - 2;
			Label label = new Label();
			label.Visible = true;
			label.BackColor = label12.BackColor;
			label.ForeColor = label12.ForeColor;
			label.Size = label12.Size;
			label.Location = new Point(btnShowKeyboard_InventoryQTY.Right + 1, ((Control)(object)txtItemCost).Bottom + 1);
			label.Width = btnSave.Left - btnShowKeyboard_InventoryQTY.Right - 2;
			pnlItemInfo.Controls.Add(label);
		}
		if (Thread.CurrentThread.CurrentCulture.Name.Equals("es-US"))
		{
			btnConfigurePackage.Padding = new Padding(130, 0, 130, 0);
		}
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
			pnlGroups.Visible = false;
		}
		if (SettingsHelper.GetSettingValueByKey("loyalty_card_payment") == "ON")
		{
			lblHideLoyalty.Visible = false;
		}
		else
		{
			lblHideLoyalty.Visible = true;
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add(ItemCourses.Uncategorized, Resources.Uncategorized);
		dictionary.Add(ItemCourses.Appetizer, Resources.Appetizer);
		dictionary.Add(ItemCourses.Beverage, Resources.Beverage);
		dictionary.Add(ItemCourses.Dessert, Resources.Dessert);
		dictionary.Add(ItemCourses.Entree, Resources.Entree);
		dictionary.Add(ItemCourses.Side, Resources.Side);
		((RadDropDownList)ddlItemCourses).set_DisplayMember("Value");
		((RadDropDownList)ddlItemCourses).set_ValueMember("Key");
		((RadDropDownList)ddlItemCourses).set_DataSource((object)new BindingSource(dictionary, null));
		((RadDropDownList)ddlItemCourses).set_SelectedIndex(0);
		Dictionary<string, string> taxRules = TaxMethods.getTaxRules();
		((RadDropDownList)ddlTaxRules).set_DisplayMember("Value");
		((RadDropDownList)ddlTaxRules).set_ValueMember("Key");
		((RadDropDownList)ddlTaxRules).set_DataSource((object)new BindingSource(taxRules, null));
		((RadDropDownList)ddlTaxRules).set_SelectedIndex(0);
		Dictionary<string, string> itemTypes = AdminMethods.getItemTypes(Thread.CurrentThread.CurrentCulture.Name);
		((RadDropDownList)ddlItemTypes).set_DisplayMember("Value");
		((RadDropDownList)ddlItemTypes).set_ValueMember("Key");
		((RadDropDownList)ddlItemTypes).set_DataSource((object)new BindingSource(itemTypes, null));
		((RadDropDownList)ddlItemTypes).set_SelectedIndex(0);
		Dictionary<string, string> dictionary2 = HelperMethods.ButtonColors(Thread.CurrentThread.CurrentCulture.Name);
		dictionary2.Remove("Red");
		((RadDropDownList)ddlColors).set_DisplayMember("Key");
		((RadDropDownList)ddlColors).set_ValueMember("Value");
		((RadDropDownList)ddlColors).set_DataSource((object)new BindingSource(dictionary2, null));
		((RadDropDownList)ddlColors).set_SelectedValue((object)dictionary2.FirstOrDefault((KeyValuePair<string, string> x) => x.Value == "150,166,166"));
		StationMethods stationMethods = new StationMethods();
		dictionary_0 = new Dictionary<string, string>();
		foreach (Station station in stationMethods.GetStations(null, Thread.CurrentThread.CurrentCulture.Name))
		{
			dictionary_0.Add(station.StationID.ToString(), station.StationName);
		}
		method_3();
		if (int_0 != -1)
		{
			method_9(bool_3: true);
		}
		btnShowItemAuditLogs.Visible = false;
		btnChangeDateAndPercentOff.Visible = false;
		btnCopy.Visible = false;
		if (chkAutoResetInv.get_Value())
		{
			Label label2 = elDrnuVvBK;
			RadTextBoxControl obj = txtResetQty;
			btnShowKeyboard_ResetQty.Visible = true;
			((Control)(object)obj).Visible = true;
			label2.Visible = true;
		}
		else
		{
			Label label3 = elDrnuVvBK;
			RadTextBoxControl obj2 = txtResetQty;
			btnShowKeyboard_ResetQty.Visible = false;
			((Control)(object)obj2).Visible = false;
			label3.Visible = false;
		}
	}

	private void method_3(int int_1 = 0)
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

	private void txtItemPrice_KeyPress(object sender, KeyPressEventArgs e)
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
		else if (method_7())
		{
			((RadDropDownList)comboGroup).set_SelectedIndex(0);
			method_19();
		}
		else
		{
			method_9();
		}
	}

	private async void method_4(Dictionary<string, string> dictionary_1, bool bool_3 = false)
	{
		_003C_003Ec__DisplayClass28_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass28_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.items = dictionary_1;
		CS_0024_003C_003E8__locals0.search = bool_3;
		CS_0024_003C_003E8__locals0.selectItem = Resources._Select_An_Item_To_Edit;
		Dictionary<string, string> dataSource = await Task.Run(() => CS_0024_003C_003E8__locals0._003C_003E4__this.method_5(CS_0024_003C_003E8__locals0.items, CS_0024_003C_003E8__locals0.search, CS_0024_003C_003E8__locals0.selectItem));
		((RadDropDownList)comboItems).set_DisplayMember("Value");
		((RadDropDownList)comboItems).set_ValueMember("Key");
		((RadDropDownList)comboItems).set_DataSource((object)new BindingSource(dataSource, null));
		if (CS_0024_003C_003E8__locals0.items.Count == 1)
		{
			((RadDropDownList)comboItems).set_SelectedIndex(1);
		}
	}

	private Dictionary<string, string> method_5(Dictionary<string, string> dictionary_1, bool bool_3, string string_4)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("0", string_4);
		foreach (KeyValuePair<string, string> item in dictionary_1)
		{
			dictionary.Add(item.Key, item.Value);
		}
		return dictionary;
	}

	private void method_6()
	{
		KeyValuePair<string, string> keyValuePair = (KeyValuePair<string, string>)((RadDropDownList)comboGroup).get_SelectedItem().get_DataBoundItem();
		List<Item> list = ((!(keyValuePair.Key == "0")) ? AdminMethods.getItemsFromGroup(Convert.ToInt16(keyValuePair.Key)).ToList() : AdminMethods.getAllItems(string_0).ToList());
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (Item item in list)
		{
			dictionary.Add(item.ItemID.ToString(), item.ItemName);
		}
		method_4(dictionary);
	}

	private bool method_7()
	{
		if (int_0 > 0)
		{
			return false;
		}
		if (((KeyValuePair<string, string>)((RadDropDownList)comboItems).get_SelectedItem().get_DataBoundItem()).Key == "0")
		{
			return true;
		}
		if (int_0 == -2)
		{
			return true;
		}
		return false;
	}

	private bool method_8()
	{
		List<string> list = new List<string>();
		if (((Control)(object)txtName).Text.Replace(" ", "") == string.Empty)
		{
			list.Add("Name");
		}
		if (((Control)(object)txtItemPrice).Text.Replace(" ", "") == string.Empty)
		{
			list.Add("Price");
		}
		if (((Control)(object)txtItemCost).Text.Replace(" ", "") == string.Empty)
		{
			list.Add("Cost");
		}
		if (((Control)(object)txtInventoryQTY).Text.Replace(" ", "") == string.Empty)
		{
			list.Add("Inventory Count");
		}
		if (((Control)(object)txtMinFreeOptions).Text.Replace(" ", "") == string.Empty)
		{
			list.Add("Min Free Options");
		}
		if (((Control)(object)txtMaxFreeOptions).Text.Replace(" ", "") == string.Empty)
		{
			list.Add("Max Free Options");
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
			new NotificationLabel(this, Resources.Item0 + text, NotificationTypes.Warning).Show();
			return false;
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
		if (((Control)(object)txtItemPrice).Text.Trim() == string.Empty)
		{
			((Control)(object)txtItemPrice).Text = "0";
		}
		if (Convert.ToInt32(((Control)(object)txtMinFreeOptions).Text) < 0)
		{
			new NotificationLabel(this, "Minimum options cannot be a negative value.", NotificationTypes.Warning).Show();
			return false;
		}
		if (Convert.ToInt32(((Control)(object)txtMinFreeOptions).Text) > Convert.ToInt32(((Control)(object)txtMaxFreeOptions).Text) && ((Control)(object)txtMaxFreeOptions).Text != "-1")
		{
			new NotificationLabel(this, "Minimum options cannot be greater than maximum free options.", NotificationTypes.Warning).Show();
			return false;
		}
		return true;
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		if (!method_8())
		{
			return;
		}
		if (method_7())
		{
			try
			{
				_003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass33_0();
				if (AdminMethods.itemNameExistCheck(((Control)(object)txtName).Text.Trim()))
				{
					new NotificationLabel(this, string_1 + Resources._name_already_exists_Please_en, NotificationTypes.Warning).Show();
					return;
				}
				string upc = (string.IsNullOrEmpty(((Control)(object)txtBarcode).Text.Trim()) ? null : ((Control)(object)txtBarcode).Text.Trim());
				if (AdminMethods.itemUPCExistCheck(((Control)(object)txtName).Text.Trim(), upc))
				{
					new NotificationLabel(this, Resources.Item_UPC_barcode_already_exist, NotificationTypes.Warning).Show();
					return;
				}
				AdminMethods.addNewItem(((Control)(object)txtBarcode).Text.Trim(), ((Control)(object)txtName).Text.Trim(), Convert.ToDecimal(((Control)(object)txtItemCost).Text), Convert.ToDecimal(((Control)(object)txtItemPrice).Text), decimal_1, chkOnSale.get_Value(), nullable_0, nullable_1, nullable_2, nullable_3, string_3, Convert.ToInt32(((RadDropDownList)ddlItemTypes).get_SelectedValue()), Convert.ToInt32(((RadDropDownList)ddlTaxRules).get_SelectedValue()), string_2, (((Control)(object)txtSortOrder).Text == string.Empty) ? null : new short?(short.Parse(((Control)(object)txtSortOrder).Text)), ((RadDropDownList)ddlColors).get_SelectedValue().ToString(), chkActive.get_Value(), Convert.ToDecimal(((Control)(object)txtInventoryQTY).Text), chkDisableIfSoldOut.get_Value(), Convert.ToInt16(((RadDropDownList)ddlUOM).get_SelectedValue()), chkTrackInventory.get_Value(), string_0, ((Control)(object)txtDescription).Text, ((Control)(object)txtNotes).Text, ((RadDropDownList)ddlItemCourses).get_SelectedValue().ToString(), Convert.ToInt32(((Control)(object)txtMaxFreeOptions).Text), Convert.ToInt32(((Control)(object)txtMinFreeOptions).Text), chkTrackExpiry.get_Value(), bool_1, chkAutoResetInv.get_Value(), Convert.ToDecimal(((Control)(object)txtResetQty).Text), chkAllowLoyaltyRedemp.get_Value(), chkSmartBarcode.get_Value(), chkAutoPromptOption.get_Value(), Convert.ToDecimal(((Control)(object)txtBatchQty).Text), chkTaxesIncluded.get_Value(), Convert.ToDecimal(((Control)(object)txtReorderLimit).Text), Convert.ToDecimal(((Control)(object)txtReorderQty).Text));
				CS_0024_003C_003E8__locals0.currentNewItem = context.Items.Where((Item tblItems) => tblItems.ItemName == ((Control)(object)txtName).Text).FirstOrDefault();
				if (list_2 != null)
				{
					AdminMethods.UpdateItemCustomField(CS_0024_003C_003E8__locals0.currentNewItem.ItemID, list_2);
				}
				if (chkIsPackage.get_Value() && list_3 != null)
				{
					AdminMethods.UpdateItemsInItems(list_3, CS_0024_003C_003E8__locals0.currentNewItem.ItemID);
				}
				if (chkIsPackage.get_Value() && list_4 != null)
				{
					AdminMethods.UpdateGroupsInItems(list_4, CS_0024_003C_003E8__locals0.currentNewItem.ItemID);
				}
				if (list_5 != null)
				{
					AdminMethods.UpdateMaterialsInItems(list_5, CS_0024_003C_003E8__locals0.currentNewItem.ItemID);
				}
				if (chkTrackInventory.get_Value() && chkTrackExpiry.get_Value() && Convert.ToDecimal(((Control)(object)txtInventoryQTY).Text) > 0m)
				{
					frmAddInventoryBatches frmAddInventoryBatches2 = new frmAddInventoryBatches(CS_0024_003C_003E8__locals0.currentNewItem.ItemID, Convert.ToDecimal(((Control)(object)txtInventoryQTY).Text));
					if (frmAddInventoryBatches2.ShowDialog(this) == DialogResult.OK)
					{
						context = new GClass6();
						string text = ", Batch/Lot #: " + frmAddInventoryBatches2.BatchNumber;
						InventoryAudit inventoryAudit = context.InventoryAudits.Where((InventoryAudit a) => a.ItemID == CS_0024_003C_003E8__locals0.currentNewItem.ItemID).FirstOrDefault();
						if (inventoryAudit != null)
						{
							inventoryAudit.Comment += text;
							Helper.SubmitChangesWithCatch(context);
						}
					}
					else
					{
						AdminMethods.updateItem(int_0, ((Control)(object)txtBarcode).Text.Trim(), ((Control)(object)txtName).Text.Trim(), Convert.ToDecimal(((Control)(object)txtItemCost).Text), Convert.ToDecimal(((Control)(object)txtItemPrice).Text), decimal_1, chkOnSale.get_Value(), nullable_0, nullable_1, nullable_2, nullable_3, string_3, Convert.ToInt32(((RadDropDownList)ddlItemTypes).get_SelectedValue()), Convert.ToInt32(((RadDropDownList)ddlTaxRules).get_SelectedValue()), string_2, (((Control)(object)txtSortOrder).Text == string.Empty) ? null : new short?(short.Parse(((Control)(object)txtSortOrder).Text)), ((RadDropDownList)ddlColors).get_SelectedValue().ToString(), chkActive.get_Value(), 0m, chkDisableIfSoldOut.get_Value(), Convert.ToInt16(((RadDropDownList)ddlUOM).get_SelectedValue()), chkTrackInventory.get_Value(), string_0, ((Control)(object)txtDescription).Text, ((Control)(object)txtNotes).Text, ((RadDropDownList)ddlItemCourses).get_SelectedValue().ToString(), Convert.ToInt32(((Control)(object)txtMaxFreeOptions).Text), Convert.ToInt32(((Control)(object)txtMinFreeOptions).Text), chkTrackExpiry.get_Value(), bool_1, 0, chkAutoResetInv.get_Value(), Convert.ToDecimal(((Control)(object)txtResetQty).Text), chkAllowLoyaltyRedemp.get_Value(), chkSmartBarcode.get_Value(), chkAutoPromptOption.get_Value(), Convert.ToDecimal(((Control)(object)txtBatchQty).Text), chkTaxesIncluded.get_Value(), Convert.ToDecimal(((Control)(object)txtReorderLimit).Text), Convert.ToDecimal(((Control)(object)txtReorderQty).Text), "Inventory Update Cancelled During Add Of Item.");
					}
				}
				if (bool_2)
				{
					AdminMethods.UpdateItemsSupplier(CS_0024_003C_003E8__locals0.currentNewItem.ItemID, list_6);
				}
				method_20(CS_0024_003C_003E8__locals0.currentNewItem.ItemName, CS_0024_003C_003E8__locals0.currentNewItem.ItemID);
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
			try
			{
				if (AdminMethods.itemNameExistCheck(((Control)(object)txtName).Text.Trim(), int_0))
				{
					new NotificationLabel(this, string_1 + Resources._name_already_exists_Please_en, NotificationTypes.Warning).Show();
					return;
				}
				string upc2 = (string.IsNullOrEmpty(((Control)(object)txtBarcode).Text.Trim()) ? null : ((Control)(object)txtBarcode).Text.Trim());
				if (AdminMethods.itemUPCExistCheck(((Control)(object)txtName).Text.Trim(), upc2, int_0))
				{
					new NotificationLabel(this, Resources.Item_UPC_barcode_already_exist, NotificationTypes.Warning).Show();
					return;
				}
				Item item = context.Items.Where((Item i) => i.ItemID == int_0).FirstOrDefault();
				context.Refresh(RefreshMode.OverwriteCurrentValues, item);
				if (item.UOMID != Convert.ToInt16(((RadDropDownList)ddlUOM).get_SelectedValue()) && AdminMethods.uomBatchExistCheck(item.ItemID))
				{
					new NotificationLabel(this, "Please clear out all existing inventory batches before changing the UOM.", NotificationTypes.Warning).Show();
					return;
				}
				string text2 = Resources.Update_Item;
				decimal num = Convert.ToDecimal(((Control)(object)txtInventoryQTY).Text);
				decimal inventoryCount = item.InventoryCount;
				if (num != inventoryCount)
				{
					MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
					MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Add_a_Note_for_the_Inventory_U);
					if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
					{
						text2 = MemoryLoadedObjects.Keyboard.textEntered;
					}
				}
				if (chkTrackInventory.get_Value() && chkTrackExpiry.get_Value() && num > inventoryCount)
				{
					frmAddInventoryBatches frmAddInventoryBatches3 = new frmAddInventoryBatches(int_0, num - inventoryCount);
					if (frmAddInventoryBatches3.ShowDialog(this) != DialogResult.OK)
					{
						new NotificationLabel(this, "Item Not Saved", NotificationTypes.Notification).Show();
						return;
					}
					text2 = text2 + ", Batch/Lot #: " + frmAddInventoryBatches3.BatchNumber;
				}
				else if (chkTrackInventory.get_Value() && chkTrackExpiry.get_Value() && num < inventoryCount)
				{
					frmReduceInventoryBatch frmReduceInventoryBatch2 = new frmReduceInventoryBatch(int_0, inventoryCount - num);
					if (frmReduceInventoryBatch2.ShowDialog(this) != DialogResult.OK)
					{
						new NotificationLabel(this, "Item Not Saved", NotificationTypes.Notification).Show();
						return;
					}
					text2 = text2 + ", Batch/Lot #: " + frmReduceInventoryBatch2.BatchNumbers;
				}
				if (bool_2)
				{
					AdminMethods.UpdateItemsSupplier(int_0, list_6);
				}
				int supplierId = 0;
				if (num > inventoryCount)
				{
					List<Supplier> itemsSuppliers = AdminMethods.GetItemsSuppliers(int_0);
					if (itemsSuppliers.Count > 0)
					{
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						foreach (Supplier item2 in itemsSuppliers)
						{
							dictionary.Add(item2.Id.ToString(), item2.Name);
						}
						frmDDLSelector frmDDLSelector2 = new frmDDLSelector("Select Supplier", dictionary);
						if (frmDDLSelector2.ShowDialog(this) == DialogResult.OK)
						{
							supplierId = Convert.ToInt32(frmDDLSelector2.SelectedValue);
						}
					}
				}
				AdminMethods.updateItem(int_0, ((Control)(object)txtBarcode).Text.Trim(), ((Control)(object)txtName).Text.Trim(), Convert.ToDecimal(((Control)(object)txtItemCost).Text), Convert.ToDecimal(((Control)(object)txtItemPrice).Text), decimal_1, chkOnSale.get_Value(), nullable_0, nullable_1, nullable_2, nullable_3, string_3, Convert.ToInt32(((RadDropDownList)ddlItemTypes).get_SelectedValue()), Convert.ToInt32(((RadDropDownList)ddlTaxRules).get_SelectedValue()), string_2, (((Control)(object)txtSortOrder).Text == string.Empty) ? null : new short?(short.Parse(((Control)(object)txtSortOrder).Text)), ((RadDropDownList)ddlColors).get_SelectedValue().ToString(), chkActive.get_Value(), num, chkDisableIfSoldOut.get_Value(), Convert.ToInt16(((RadDropDownList)ddlUOM).get_SelectedValue()), chkTrackInventory.get_Value(), string_0, ((Control)(object)txtDescription).Text, ((Control)(object)txtNotes).Text, ((RadDropDownList)ddlItemCourses).get_SelectedValue().ToString(), Convert.ToInt32(((Control)(object)txtMaxFreeOptions).Text), Convert.ToInt32(((Control)(object)txtMinFreeOptions).Text), chkTrackExpiry.get_Value(), bool_1, supplierId, chkAutoResetInv.get_Value(), Convert.ToDecimal(((Control)(object)txtResetQty).Text), chkAllowLoyaltyRedemp.get_Value(), chkSmartBarcode.get_Value(), chkAutoPromptOption.get_Value(), Convert.ToDecimal(((Control)(object)txtBatchQty).Text), chkTaxesIncluded.get_Value(), Convert.ToDecimal(((Control)(object)txtReorderLimit).Text), Convert.ToDecimal(((Control)(object)txtReorderQty).Text), text2);
				new NotificationLabel(this, Resources.The_record_has_been_updated, NotificationTypes.Success).Show();
				if (list_2 != null)
				{
					AdminMethods.UpdateItemCustomField(int_0, list_2);
				}
				if (chkIsPackage.get_Value() && list_4 != null)
				{
					AdminMethods.UpdateGroupsInItems(list_4, int_0);
				}
				if (chkIsPackage.get_Value() && list_3 != null)
				{
					AdminMethods.UpdateItemsInItems(list_3, int_0);
				}
				else if (!chkIsPackage.get_Value())
				{
					AdminMethods.UpdateItemsInItems(null, int_0);
					AdminMethods.UpdateGroupsInItems(null, int_0);
				}
				if (list_5 != null)
				{
					AdminMethods.UpdateMaterialsInItems(list_5, int_0);
				}
				method_20(((Control)(object)txtName).Text.Trim(), item.ItemID);
				if (!bool_0)
				{
					int_0 = -1;
					string selectedValue = ((RadDropDownList)comboItems).get_SelectedValue().ToString();
					((RadDropDownList)comboItems).set_SelectedValue((object)selectedValue);
					method_9();
				}
			}
			catch (Exception)
			{
				new NotificationLabel(this, Resources.Please_make_sure_all_fields_ar, NotificationTypes.Notification).Show();
				return;
			}
		}
		method_4(AdminMethods.getAllItemsDictionary(string_0));
		comboGroup_SelectedIndexChanged(null, null);
		MemoryLoadedObjects.ItemsAndGroupsStationsRefresh();
	}

	private void method_9(bool bool_3 = false)
	{
		string_1 = Resources.Item;
		if (!bool_3)
		{
			KeyValuePair<string, string> keyValuePair;
			if (((RadDropDownList)comboItems).get_SelectedItem() != null)
			{
				keyValuePair = (KeyValuePair<string, string>)((RadDropDownList)comboItems).get_SelectedItem().get_DataBoundItem();
			}
			else
			{
				((RadDropDownList)comboItems).set_SelectedValue((object)"0");
				keyValuePair = (KeyValuePair<string, string>)((RadDropDownList)comboItems).get_SelectedItem().get_DataBoundItem();
			}
			int_0 = int.Parse(keyValuePair.Key);
		}
		if (int_0 == 0)
		{
			method_19();
			return;
		}
		btnShowItemAuditLogs.Visible = true;
		Button button = btnMaterials;
		Button button2 = btnChangeDateAndPercentOff;
		btnCopy.Visible = true;
		button2.Visible = true;
		button.Visible = true;
		Item oneItem = AdminMethods.getOneItem(int_0);
		method_3(oneItem.ItemID);
		if (oneItem != null)
		{
			method_10(oneItem);
		}
	}

	private void method_10(Item item_0)
	{
		try
		{
			((Control)(object)txtBarcode).Text = item_0.Barcode;
			((Control)(object)txtName).Text = item_0.ItemName;
			((Control)(object)txtItemCost).Text = item_0.ItemCost.ToString();
			((Control)(object)txtItemPrice).Text = item_0.ItemPrice.ToString();
			decimal_1 = ((!item_0.ItemSalePrice.HasValue) ? 0m : item_0.ItemSalePrice.Value);
			chkOnSale.set_Value(item_0.OnSale);
			nullable_0 = item_0.StartDateOnSale;
			nullable_1 = item_0.EndDateOnSale;
			nullable_2 = item_0.StartTimeOnSale;
			nullable_3 = item_0.EndTimeOnSale;
			string_3 = item_0.DaysSaleList;
			((RadDropDownList)ddlItemTypes).set_SelectedValue((object)item_0.ItemTypeID.ToString());
			((RadDropDownList)ddlTaxRules).set_SelectedValue((object)item_0.TaxRuleID.ToString());
			string_2 = item_0.StationID;
			((Control)(object)txtStations).Text = ((!string.IsNullOrEmpty(string_2)) ? StationMethods.GetStationNamesFromStationIds(string_2) : "No Station");
			((RadDropDownList)ddlItemCourses).set_SelectedValue((object)item_0.ItemCourse.ToString());
			((Control)(object)txtSortOrder).Text = item_0.SortOrder.ToString();
			((RadDropDownList)ddlColors).set_SelectedValue((object)item_0.ItemColor.ToString());
			chkActive.set_Value(item_0.Active);
			((Control)(object)txtInventoryQTY).Text = ((!(item_0.InventoryCount % 1m == 0m) || item_0.UOM.isFractional) ? item_0.InventoryCount.ToString("0.##") : MathHelper.RemoveTrailingZeros(item_0.InventoryCount.ToString("0.##")));
			if (!item_0.UOM.isFractional)
			{
				((Control)(object)txtInventoryQTY).Text = Math.Round(item_0.InventoryCount, 0).ToString();
			}
			chkDisableIfSoldOut.set_Value(item_0.DisableSoldOutItems);
			((RadDropDownList)ddlUOM).set_SelectedValue((object)item_0.UOMID.ToString());
			chkTrackInventory.set_Value(item_0.TrackInventory);
			chkAllowLoyaltyRedemp.set_Value(item_0.LoyaltyRedemption);
			list_2 = null;
			btnSave.Enabled = true;
			((Control)(object)txtDescription).Text = item_0.Description;
			((Control)(object)txtNotes).Text = item_0.Notes;
			((Control)(object)txtMinFreeOptions).Text = item_0.MinFreeOptions.ToString();
			((Control)(object)txtMaxFreeOptions).Text = item_0.MaxFreeOptions.ToString();
			chkTrackExpiry.set_Value(item_0.TrackExpiryDate);
			chkAutoResetInv.set_Value(item_0.AutoResetQty);
			((Control)(object)txtResetQty).Text = item_0.ResetQty.ToString("0.00");
			chkSmartBarcode.set_Value(item_0.UseSmartBarcode);
			chkAutoPromptOption.set_Value(item_0.AutoPromptOptions);
			((Control)(object)txtBatchQty).Text = item_0.BatchStockQty.ToString("0.00");
			chkTaxesIncluded.set_Value(item_0.TaxesIncluded);
			((Control)(object)txtReorderLimit).Text = item_0.ReOrderLimit.ToString();
			((Control)(object)txtReorderQty).Text = (item_0.ReorderQty.HasValue ? item_0.ReorderQty.Value.ToString() : "0");
			if (!item_0.OnSale)
			{
				btnChangeDateAndPercentOff.Visible = false;
			}
			List<ItemsInItem> list = context.ItemsInItems.Where((ItemsInItem tblItemsInItems) => tblItemsInItems.ParentItemID == (int?)int_0).ToList();
			List<GroupsInItem> list2 = context.GroupsInItems.Where((GroupsInItem tblGroupsInItems) => tblGroupsInItems.ItemID == int_0).ToList();
			decimal_0 = default(decimal);
			if (list.Count == 0 && list2.Count == 0)
			{
				decimal_0 = default(decimal);
				suggestedPrice.Text = decimal_0.ToString("0.00");
				list_3 = null;
				list_4 = null;
				chkIsPackage.set_Value(false);
			}
			else
			{
				chkIsPackage.set_Value(true);
				List<ItemsInItemsField> list3 = new List<ItemsInItemsField>();
				foreach (ItemsInItem item3 in list)
				{
					Item oneItem = AdminMethods.getOneItem(item3.ItemID.Value);
					_ = item3.Quantity.Value;
					decimal_0 += oneItem.ItemPrice * item3.Quantity.Value;
					suggestedPrice.Text = decimal_0.ToString("0.00");
					ItemsInItemsField item = new ItemsInItemsField
					{
						ItemName = oneItem.ItemName,
						qty = item3.Quantity.Value,
						useItemSettings = item3.UseChildItemPriceAndTax
					};
					list3.Add(item);
				}
				list_3 = list3;
				List<GroupsInItemsField> list4 = new List<GroupsInItemsField>();
				foreach (GroupsInItem item4 in list2)
				{
					GroupsInItemsField item2 = new GroupsInItemsField
					{
						GroupName = item4.Group.GroupName,
						qty = item4.Quantity
					};
					list4.Add(item2);
				}
				list_4 = list4;
			}
			lblSuggestedPriceByIngredients.Text = "0.00";
			List<MaterialsInItem> list5 = context.MaterialsInItems.Where((MaterialsInItem i) => i.ItemID == int_0).ToList();
			if (list5.Count > 0)
			{
				list_5 = list5;
				method_11();
			}
			else
			{
				list_5 = new List<MaterialsInItem>();
			}
			bool_2 = false;
			list_6 = item_0.ItemsSuppliers.Select((ItemsSupplier a) => a.SupplierId).ToList();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			int_0 = 0;
			((Control)(object)txtName).Text = string.Empty;
			((Control)(object)txtItemCost).Text = "0";
			((Control)(object)txtItemPrice).Text = "0";
			chkOnSale.set_Value(false);
			((RadDropDownList)ddlItemTypes).set_SelectedIndex(-1);
			((RadDropDownList)ddlTaxRules).set_SelectedIndex(-1);
			((Control)(object)txtStations).Text = "No Station";
			((Control)(object)txtSortOrder).Text = string.Empty;
			((RadDropDownList)ddlColors).set_SelectedValue((object)string.Empty);
			chkActive.set_Value(false);
			chkAutoResetInv.set_Value(false);
			((Control)(object)txtResetQty).Text = "0";
			((Control)(object)txtInventoryQTY).Text = string.Empty;
			((RadDropDownList)ddlUOM).set_SelectedValue((object)string.Empty);
			list_2 = null;
			btnSave.Enabled = false;
			bool_2 = false;
			list_6 = new List<int>();
			chkSmartBarcode.set_Value(false);
		}
	}

	private void method_11()
	{
		try
		{
			List<Item> source = context.Items.Where((Item x) => list_5.Select((MaterialsInItem y) => y.ItemMaterialID).Contains(x.ItemID)).ToList();
			if (source.Any())
			{
				decimal num = default(decimal);
				using (List<MaterialsInItem>.Enumerator enumerator = list_5.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass36_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass36_0();
						CS_0024_003C_003E8__locals0.mat = enumerator.Current;
						Item item = source.Where((Item x) => x.ItemID == CS_0024_003C_003E8__locals0.mat.ItemMaterialID).FirstOrDefault();
						if (item != null)
						{
							if (item.UOMID != CS_0024_003C_003E8__locals0.mat.UOMID)
							{
								num += item.ItemCost * UOMMethods.ConvertByUOMID(item.ItemID, CS_0024_003C_003E8__locals0.mat.Quantity.Value, item.UOMID, CS_0024_003C_003E8__locals0.mat.UOMID);
							}
							else
							{
								num += item.ItemCost * CS_0024_003C_003E8__locals0.mat.Quantity.Value;
							}
						}
					}
				}
				lblSuggestedPriceByIngredients.Text = num.ToString("0.00##");
			}
			else
			{
				lblSuggestedPriceByIngredients.Text = "0.00";
			}
		}
		catch
		{
			lblSuggestedPriceByIngredients.Text = "0.00";
			new NotificationLabel(this, "There was a problem calculating ingredient cost, please check UOM conversions.", NotificationTypes.Warning).Show();
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
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter + string_1 + Resources._Name, 0, 256, ((Control)(object)txtName).Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtName).Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_ItemPrice_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Item_Price, 4, 12, ((Control)(object)txtItemPrice).Text, "", allowNegative: false, useNotifLabel: true);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtItemPrice).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_InventoryQTY_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Inventory_Count, 2, 6, ((Control)(object)txtInventoryQTY).Text, "", allowNegative: false, useNotifLabel: true);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtInventoryQTY).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void method_12(object sender, EventArgs e)
	{
	}

	private void btnShowKeyboard_ItemCost_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter + string_1 + Resources._Cost_Price, 4, 12, ((Control)(object)txtItemCost).Text, "", allowNegative: false, useNotifLabel: true);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtItemCost).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void method_13()
	{
		decimal num = default(decimal);
		try
		{
			decimal num2 = Convert.ToDecimal(((Control)(object)txtItemCost).Text.Trim());
			num = (chkOnSale.get_Value() ? decimal_1 : Convert.ToDecimal(((Control)(object)txtItemPrice).Text.Trim()));
			decimal num3 = Math.Round((num - num2) / num * 100m, 0);
			lblMargin.Text = num3 + " %";
		}
		catch
		{
			lblMargin.Text = "0 %";
		}
	}

	private void txtItemCost_TextChanged(object sender, EventArgs e)
	{
		method_13();
	}

	private void txtItemCost_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
		{
			e.Handled = true;
		}
	}

	private void txtItemPrice_TextChanged(object sender, EventArgs e)
	{
		method_13();
	}

	private void method_14(object sender, EventArgs e)
	{
		method_13();
	}

	private void chkOnSale_ValueChanged(object sender, EventArgs e)
	{
		btnChangeDateAndPercentOff.Visible = chkOnSale.get_Value();
	}

	private void method_15(object sender, EventArgs e)
	{
		if (chkIsPackage.get_Value())
		{
			btnConfigurePackage.Visible = true;
		}
		else
		{
			btnConfigurePackage.Visible = false;
		}
	}

	private void method_16(object sender, EventArgs e)
	{
	}

	private void btnConfigurePackage_Click(object sender, EventArgs e)
	{
		frmItemsInItem frmItemsInItem2 = new frmItemsInItem(((Control)(object)txtName).Text, "EditItem", list_3, list_4, decimal_0);
		frmItemsInItem2.ShowDialog(this);
		if (frmItemsInItem2.DialogResult == DialogResult.OK)
		{
			list_3 = frmItemsInItem2.returnItemsList;
			list_4 = frmItemsInItem2.returnGroupsList;
			decimal_0 = frmItemsInItem2.returnSuggestedPrice;
			suggestedPrice.Text = decimal_0.ToString("0.00");
		}
	}

	private void btnMaterials_Click(object sender, EventArgs e)
	{
		frmMaterialsInItem frmMaterialsInItem2 = new frmMaterialsInItem(int_0, list_5);
		frmMaterialsInItem2.ShowDialog(this);
		if (frmMaterialsInItem2.DialogResult == DialogResult.OK)
		{
			list_5 = frmMaterialsInItem2.returnMaterialsInItemList;
			lblSuggestedPriceByIngredients.Text = "0.00";
			method_11();
			new NotificationLabel(this, Resources.Ingredients_not_yet_saved_Plea, NotificationTypes.Notification).Show();
		}
	}

	private void btnChangeDateAndPercentOff_Click(object sender, EventArgs e)
	{
		Promotion promotion = new GClass6().Promotions.Where((Promotion i) => i.String_0 == int_0.ToString() && i.GetDiscountUOM == "@").FirstOrDefault();
		DateTime? itemStartDate = null;
		DateTime? itemEndDate = null;
		string_3 = "";
		if (promotion != null)
		{
			itemStartDate = ((!nullable_0.HasValue) ? promotion.StartDate : nullable_0);
			itemEndDate = ((!nullable_1.HasValue) ? promotion.EndDate : nullable_1);
			string_3 = promotion.DayTimeOfWeek;
			decimal_2 = promotion.GetDiscountAmount.Value;
		}
		frmSelectDateOnSale frmSelectDateOnSale2 = new frmSelectDateOnSale(itemStartDate, itemEndDate, string_3, Convert.ToDecimal(((Control)(object)txtItemPrice).Text), decimal_2);
		if (frmSelectDateOnSale2.ShowDialog(this) == DialogResult.OK)
		{
			decimal_2 = frmSelectDateOnSale2.returnSalePrice;
			string_3 = frmSelectDateOnSale2.returnDaysSaleList;
			nullable_0 = frmSelectDateOnSale2.returnStartDate;
			nullable_1 = frmSelectDateOnSale2.returnEndDate;
			new NotificationLabel(this, "Please save the Item for the SALES to take effect.", NotificationTypes.Notification, 4);
		}
	}

	private void btnShowCustomField_Click(object sender, EventArgs e)
	{
		if (Enumerable.Count(new GClass6().CustomFields.Select((CustomField tblCustomFields) => tblCustomFields)) != 0)
		{
			frmCustomField frmCustomField2 = new frmCustomField(int_0, list_2);
			if (frmCustomField2.ShowDialog(this) == DialogResult.OK)
			{
				list_2 = frmCustomField2.itemCustomFieldValuesDisplay;
				new NotificationLabel(this, "Please click SAVE to save the custom fields added.", NotificationTypes.Warning).Show();
			}
		}
		else
		{
			new frmMessageBox(Resources.Please_add_first_a_Custom_Fiel, Resources.Error_Custom_Field_s_is_Empty).ShowDialog(this);
		}
	}

	private void method_17(object sender, EventArgs e)
	{
	}

	private void acSlRyyRdg(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Search + string_1, 2);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		new GClass6();
		List<Item> list = new List<Item>();
		list = SearchMethods.FindItems(MemoryLoadedObjects.Keyboard.textEntered.Trim().ToLower().Split(' '));
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		if (list.Count() > 0)
		{
			foreach (Item item in list)
			{
				dictionary.Add(item.ItemID.ToString(), item.ItemName);
			}
			method_4(dictionary, bool_3: true);
		}
		else
		{
			new NotificationLabel(this, Resources.No_item_could_be_found_with_yo, NotificationTypes.Warning).Show();
		}
	}

	private void btnShowItemAuditLogs_Click(object sender, EventArgs e)
	{
		new frmItemAuditView(int_0).ShowDialog(this);
	}

	private void chkTrackInventory_ValueChanged(object sender, EventArgs e)
	{
		method_18();
	}

	private void method_18()
	{
		Label label = lblInvCount;
		Label label2 = lblInvDisable;
		RadTextBoxControl obj = txtInventoryQTY;
		RadToggleSwitch obj2 = chkDisableIfSoldOut;
		bool flag = (btnShowKeyboard_InventoryQTY.Visible = chkTrackInventory.get_Value());
		bool flag3 = (((Control)(object)obj2).Visible = flag);
		bool flag5 = (((Control)(object)obj).Visible = flag3);
		bool visible = (label2.Visible = flag5);
		label.Visible = visible;
		label35.Visible = !lblInvCount.Visible;
		if (!chkTrackInventory.get_Value())
		{
			chkDisableIfSoldOut.set_Value(chkTrackInventory.get_Value());
		}
	}

	private void chkIsPackage_ValueChanged(object sender, EventArgs e)
	{
		btnConfigurePackage.Visible = chkIsPackage.get_Value();
		suggestedPrice.Visible = chkIsPackage.get_Value();
		labelSuggestedPrice.Visible = chkIsPackage.get_Value();
	}

	private void txtSortOrder_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
		{
			e.Handled = true;
		}
	}

	private void txtBarcode_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private void btnCopy_Click(object sender, EventArgs e)
	{
		int_0 = -2;
		((Control)(object)txtName).Focus();
		string_1 = Resources.New_item;
		txtBarcode_Click(txtName, e);
	}

	public void refreshPage(object sender, FormClosingEventArgs e)
	{
		method_6();
	}

	private void ddolzMvJeH(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter + string_1 + Resources._Description1, 0, 256, ((Control)(object)txtDescription).Text, multiline: true);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtDescription).Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void method_19()
	{
		((Control)(object)txtBarcode).Text = string.Empty;
		((Control)(object)txtName).Text = string.Empty;
		((Control)(object)txtDescription).Text = string.Empty;
		((Control)(object)txtNotes).Text = string.Empty;
		chkOnSale.set_Value(false);
		if (((RadDropDownList)ddlItemTypes).get_Items().get_Count() > 0)
		{
			((RadDropDownList)ddlItemTypes).set_SelectedIndex(0);
		}
		if (((RadDropDownList)ddlTaxRules).get_Items().get_Count() > 0)
		{
			((RadDropDownList)ddlTaxRules).set_SelectedIndex(0);
		}
		string_2 = "";
		((Control)(object)txtStations).Text = "No Station";
		if (((RadDropDownList)ddlColors).get_Items().get_Count() > 0)
		{
			((RadDropDownList)ddlColors).set_SelectedValue((object)HelperMethods.ButtonColors()["Gray"]);
		}
		if (((RadDropDownList)ddlItemCourses).get_Items().get_Count() > 0)
		{
			((RadDropDownList)ddlItemCourses).set_SelectedIndex(0);
		}
		chkActive.set_Value(true);
		chkTrackInventory.set_Value(true);
		method_18();
		chkDisableIfSoldOut.set_Value(false);
		chkAllowLoyaltyRedemp.set_Value(true);
		chkIsPackage.set_Value(false);
		suggestedPrice.Text = "0.00";
		lblSuggestedPriceByIngredients.Text = "0.00";
		((Control)(object)txtSortOrder).Text = "0";
		chkIsPackage.set_Value(false);
		((Control)(object)txtItemCost).Text = "0";
		((Control)(object)txtItemPrice).Text = "0";
		((Control)(object)txtInventoryQTY).Text = "0";
		((Control)(object)txtMaxFreeOptions).Text = "0";
		((Control)(object)txtMinFreeOptions).Text = "0";
		list_6 = new List<int>();
		bool_2 = false;
		chkAutoResetInv.set_Value(false);
		chkSmartBarcode.set_Value(false);
		((Control)(object)txtResetQty).Text = "0";
		((Control)(object)txtBatchQty).Text = "1.00";
		chkTaxesIncluded.set_Value(false);
		((Control)(object)txtReorderLimit).Text = "-1";
		((Control)(object)txtReorderQty).Text = "0";
		if (((RadDropDownList)ddlUOM).get_Items().get_Count() > 0)
		{
			((RadDropDownList)ddlUOM).set_SelectedIndex(0);
		}
		list_3 = null;
		list_4 = null;
		btnShowItemAuditLogs.Visible = false;
		Button button = btnMaterials;
		Button button2 = btnChangeDateAndPercentOff;
		btnCopy.Visible = false;
		button2.Visible = false;
		button.Visible = false;
	}

	private void btnNew_Click(object sender, EventArgs e)
	{
		((RadDropDownList)comboGroup).set_SelectedIndex(0);
		method_4(AdminMethods.getAllItemsDictionary(string_0));
		string_1 = Resources.New_item;
		method_19();
	}

	private void ddlColors_MouseHover(object sender, EventArgs e)
	{
	}

	private void yorxnKqOxN(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter + string_1 + Resources._Note, 0, 256, ((Control)(object)txtNotes).Text, multiline: true);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtNotes).Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void comboItems_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
	{
		if (((Control)(object)comboItems).Visible)
		{
			method_9();
		}
	}

	private void comboGroup_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
	{
		if (((Control)(object)comboGroup).Visible)
		{
			KeyValuePair<string, string> keyValuePair = (KeyValuePair<string, string>)((RadDropDownList)comboGroup).get_SelectedItem().get_DataBoundItem();
			if (!(keyValuePair.Key == "0") && !(keyValuePair.Key == "-1"))
			{
				method_6();
			}
			else
			{
				method_4(AdminMethods.getAllItemsDictionary(string_0));
			}
		}
	}

	private void btnShowKeyboard_Barcode_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		if (Thread.CurrentThread.CurrentCulture.Name.Equals("fr-CA"))
		{
			MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter.Trim() + " le " + Resources.Barcode.ToLower() + " d'" + string_1.ToLower(), 0, 256, ((Control)(object)txtBarcode).Text);
		}
		else
		{
			MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter.Trim() + " " + string_1 + " " + Resources.Barcode, 0, 256, ((Control)(object)txtBarcode).Text);
		}
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtBarcode).Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void txtMaxFreeOptions_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Maximum Qty of Free Options, Enter -1 For Unlimited.", 0, 3, ((Control)(object)txtMaxFreeOptions).Text, string.Empty, allowNegative: true);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtMaxFreeOptions).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
	}

	private void txtMaxFreeOptions_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtMinFreeOptions_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Min Qty of Free Options.", 0, 3, ((Control)(object)txtMinFreeOptions).Text, string.Empty, allowNegative: true);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtMinFreeOptions).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
	}

	private void chkTrackExpiry_ValueChanged(object sender, EventArgs e)
	{
	}

	private void btnInventoryBatches_Click(object sender, EventArgs e)
	{
		if (int_0 <= 0)
		{
			new NotificationLabel(this, "Please Save the item first.", NotificationTypes.Notification, 3);
		}
		else
		{
			new frmAdminViewInventoryBatches(int_0).Show(this);
		}
	}

	private void btnAsssignSupplier_Click(object sender, EventArgs e)
	{
		frmAssignSupplier frmAssignSupplier2 = new frmAssignSupplier(((Control)(object)txtName).Text, list_6);
		if (frmAssignSupplier2.ShowDialog(this) == DialogResult.OK)
		{
			list_6 = frmAssignSupplier2.supplierIds;
			bool_2 = true;
			new NotificationLabel(this, "Please click SAVE to save added suppliers to the item", NotificationTypes.Warning).Show();
		}
	}

	private void chkAutoResetInv_ValueChanged(object sender, EventArgs e)
	{
		if (chkAutoResetInv.get_Value())
		{
			Label label = elDrnuVvBK;
			RadTextBoxControl obj = txtResetQty;
			btnShowKeyboard_ResetQty.Visible = true;
			((Control)(object)obj).Visible = true;
			label.Visible = true;
		}
		else
		{
			Label label2 = elDrnuVvBK;
			RadTextBoxControl obj2 = txtResetQty;
			btnShowKeyboard_ResetQty.Visible = false;
			((Control)(object)obj2).Visible = false;
			label2.Visible = false;
		}
	}

	private void txtResetQty_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Reset Qty", 2, 6, ((Control)(object)txtResetQty).Text, "", allowNegative: false, useNotifLabel: true);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtResetQty).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnSelectStations_Click(object sender, EventArgs e)
	{
		frmChecklistSelector frmChecklistSelector = new frmChecklistSelector("SELECT APPLICABLE STATIONS", dictionary_0, string_2);
		if (frmChecklistSelector.ShowDialog() == DialogResult.OK)
		{
			string_2 = frmChecklistSelector.returnValue;
			((Control)(object)txtStations).Text = ((!string.IsNullOrEmpty(string_2)) ? StationMethods.GetStationNamesFromStationIds(string_2) : "No Station");
		}
	}

	private void ddlTaxRules_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
	{
		if (((Control)(object)ddlTaxRules).Text.Equals("Prepared Foods & Beverages"))
		{
			((RadDropDownList)ddlItemTypes).set_SelectedIndex(((RadDropDownList)ddlItemTypes).get_Items().IndexOf("Prepared Food & Beverages"));
			((Control)(object)ddlItemTypes).Enabled = false;
		}
		else
		{
			((Control)(object)ddlItemTypes).Enabled = true;
		}
	}

	private void btnShowKeyboard_BatchQty_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Batch Qty (Make To Stock)", 4, 12, ((Control)(object)txtBatchQty).Text, "", allowNegative: false, useNotifLabel: true);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtBatchQty).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void method_20(string string_4, int int_1)
	{
		_003C_003Ec__DisplayClass84_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass84_0();
		CS_0024_003C_003E8__locals0.itemId = int_1;
		GClass6 gClass = new GClass6();
		Promotion promotion = gClass.Promotions.Where((Promotion i) => i.String_0 == CS_0024_003C_003E8__locals0.itemId.ToString() && i.GetDiscountUOM == "@").FirstOrDefault();
		if (promotion != null)
		{
			promotion.GetDiscountAmount = decimal_2;
			promotion.DayTimeOfWeek = string_3;
			promotion.StartDate = nullable_0;
			promotion.EndDate = nullable_1;
			promotion.Active = chkOnSale.get_Value();
			promotion.Synced = false;
			gClass.SubmitChanges();
		}
		else if (chkOnSale.get_Value())
		{
			Promotion entity = new Promotion
			{
				PromoName = string_4 + " PROMO SALE",
				PromoCode = string_4 + " SALE ITEM",
				DateCreated = DateTime.Now,
				GetDiscountAmount = decimal_2,
				GetDiscountUOM = "@",
				GetQtyString = "IT",
				BuyQty = 1,
				String_0 = CS_0024_003C_003E8__locals0.itemId.ToString(),
				String_1 = "",
				DayTimeOfWeek = string_3,
				StartDate = nullable_0,
				EndDate = nullable_1,
				DateModified = DateTime.Now,
				UserCreated = Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString()),
				UserModified = Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString()),
				OrderTypes = "Dine In,To-Go,Pick-Up,Delivery",
				IsDeleted = false,
				Synced = false,
				Active = true
			};
			gClass.Promotions.InsertOnSubmit(entity);
			gClass.SubmitChanges();
		}
		MemoryLoadedObjects.RefreshPromotions();
	}

	private void txtReorderLimit_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Re-Order Limit", 2, 6, ((Control)(object)txtReorderLimit).Text, "", allowNegative: true, useNotifLabel: true);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtReorderLimit).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void txtReorderQty_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Re-Order Qty", 2, 6, ((Control)(object)txtReorderQty).Text, "", allowNegative: false, useNotifLabel: true);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtReorderQty).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
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
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Expected O, but got Unknown
		//IL_048a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0494: Expected O, but got Unknown
		//IL_0eb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe0: Unknown result type (might be due to invalid IL or missing references)
		//IL_111e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1136: Unknown result type (might be due to invalid IL or missing references)
		//IL_114d: Unknown result type (might be due to invalid IL or missing references)
		//IL_116e: Unknown result type (might be due to invalid IL or missing references)
		//IL_119b: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_121c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1316: Unknown result type (might be due to invalid IL or missing references)
		//IL_1337: Unknown result type (might be due to invalid IL or missing references)
		//IL_14bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_14eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_150c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1539: Unknown result type (might be due to invalid IL or missing references)
		//IL_1566: Unknown result type (might be due to invalid IL or missing references)
		//IL_1593: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_175a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1772: Unknown result type (might be due to invalid IL or missing references)
		//IL_1789: Unknown result type (might be due to invalid IL or missing references)
		//IL_17aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_17d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1804: Unknown result type (might be due to invalid IL or missing references)
		//IL_1831: Unknown result type (might be due to invalid IL or missing references)
		//IL_1858: Unknown result type (might be due to invalid IL or missing references)
		//IL_19a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a87: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1abf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aec: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b19: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b46: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cca: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ee1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f02: Unknown result type (might be due to invalid IL or missing references)
		//IL_2052: Unknown result type (might be due to invalid IL or missing references)
		//IL_206a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2081: Unknown result type (might be due to invalid IL or missing references)
		//IL_20a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_20cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_20fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2129: Unknown result type (might be due to invalid IL or missing references)
		//IL_2150: Unknown result type (might be due to invalid IL or missing references)
		//IL_2245: Unknown result type (might be due to invalid IL or missing references)
		//IL_2266: Unknown result type (might be due to invalid IL or missing references)
		//IL_2416: Unknown result type (might be due to invalid IL or missing references)
		//IL_2437: Unknown result type (might be due to invalid IL or missing references)
		//IL_25d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_25f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_27a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_27bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_27d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_27f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2822: Unknown result type (might be due to invalid IL or missing references)
		//IL_284f: Unknown result type (might be due to invalid IL or missing references)
		//IL_287c: Unknown result type (might be due to invalid IL or missing references)
		//IL_28a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a54: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a75: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e83: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ea4: Unknown result type (might be due to invalid IL or missing references)
		//IL_304b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3063: Unknown result type (might be due to invalid IL or missing references)
		//IL_307a: Unknown result type (might be due to invalid IL or missing references)
		//IL_309b: Unknown result type (might be due to invalid IL or missing references)
		//IL_30c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_30f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_3122: Unknown result type (might be due to invalid IL or missing references)
		//IL_3149: Unknown result type (might be due to invalid IL or missing references)
		//IL_31d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_31f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_3208: Unknown result type (might be due to invalid IL or missing references)
		//IL_3229: Unknown result type (might be due to invalid IL or missing references)
		//IL_3256: Unknown result type (might be due to invalid IL or missing references)
		//IL_3283: Unknown result type (might be due to invalid IL or missing references)
		//IL_32b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_32d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_337e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3396: Unknown result type (might be due to invalid IL or missing references)
		//IL_33ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_33ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_33fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_3428: Unknown result type (might be due to invalid IL or missing references)
		//IL_3455: Unknown result type (might be due to invalid IL or missing references)
		//IL_347c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3500: Unknown result type (might be due to invalid IL or missing references)
		//IL_3518: Unknown result type (might be due to invalid IL or missing references)
		//IL_3530: Unknown result type (might be due to invalid IL or missing references)
		//IL_3551: Unknown result type (might be due to invalid IL or missing references)
		//IL_357e: Unknown result type (might be due to invalid IL or missing references)
		//IL_35ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_35d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_35ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_370e: Unknown result type (might be due to invalid IL or missing references)
		//IL_372f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4164: Unknown result type (might be due to invalid IL or missing references)
		//IL_416e: Expected O, but got Unknown
		//IL_469a: Unknown result type (might be due to invalid IL or missing references)
		//IL_46a4: Expected O, but got Unknown
		//IL_48c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_48cd: Expected O, but got Unknown
		//IL_497d: Unknown result type (might be due to invalid IL or missing references)
		//IL_499e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4bad: Unknown result type (might be due to invalid IL or missing references)
		//IL_4bc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_4bdc: Unknown result type (might be due to invalid IL or missing references)
		//IL_4bfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c57: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c84: Unknown result type (might be due to invalid IL or missing references)
		//IL_4cab: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmAddEditItems));
		pnlItemInfo = new Panel();
		label38 = new Label();
		txtReorderQty = new RadTextBoxControl();
		label37 = new Label();
		txtReorderLimit = new RadTextBoxControl();
		label36 = new Label();
		label35 = new Label();
		chkTaxesIncluded = new RadToggleSwitch();
		eIfrjFraQI = new Label();
		txtBatchQty = new RadTextBoxControl();
		btnShowKeyboard_BatchQty = new Button();
		label31 = new Label();
		chkAutoPromptOption = new RadToggleSwitch();
		label33 = new Label();
		lblSuggestedPriceByIngredients = new Label();
		lblHideLoyalty = new Label();
		chkAllowLoyaltyRedemp = new RadToggleSwitch();
		label27 = new Label();
		btnSelectStations = new Button();
		txtStations = new RadTextBoxControl();
		chkAutoResetInv = new RadToggleSwitch();
		btnShowKeyboard_ResetQty = new Button();
		txtResetQty = new RadTextBoxControl();
		elDrnuVvBK = new Label();
		label29 = new Label();
		btnAsssignSupplier = new Button();
		label28 = new Label();
		txtMinFreeOptions = new RadTextBoxControl();
		btnInventoryBatches = new Button();
		chkTrackExpiry = new RadToggleSwitch();
		label26 = new Label();
		txtMaxFreeOptions = new RadTextBoxControl();
		label24 = new Label();
		ddlItemCourses = new Class20();
		label22 = new Label();
		txtNotes = new RadTextBoxControl();
		label14 = new Label();
		btnShowKeyboard_Notes = new Button();
		txtSortOrder = new RadTextBoxControl();
		label12 = new Label();
		btnNew = new Button();
		chkOnSale = new RadToggleSwitch();
		label13 = new Label();
		btnCopy = new Button();
		txtDescription = new RadTextBoxControl();
		btnShowKeyboard_Description = new Button();
		label25 = new Label();
		btnCancel = new Button();
		txtInventoryQTY = new RadTextBoxControl();
		txtItemPrice = new RadTextBoxControl();
		txtItemCost = new RadTextBoxControl();
		btnConfigurePackage = new Button();
		suggestedPrice = new Button();
		chkIsPackage = new RadToggleSwitch();
		chkDisableIfSoldOut = new RadToggleSwitch();
		chkTrackInventory = new RadToggleSwitch();
		chkActive = new RadToggleSwitch();
		btnChangeDateAndPercentOff = new Button();
		txtName = new RadTextBoxControl();
		btnShowItemAuditLogs = new Button();
		btnMaterials = new Button();
		labelSuggestedPrice = new Label();
		label21 = new Label();
		ddlColors = new Class20();
		lblInvDisable = new Label();
		label1 = new Label();
		btnShowCustomField = new Button();
		label2 = new Label();
		label3 = new Label();
		label4 = new Label();
		label5 = new Label();
		panel1 = new Panel();
		lblMargin = new Label();
		label20 = new Label();
		label6 = new Label();
		label11 = new Label();
		label19 = new Label();
		pvcUvEahoB = new Label();
		btnSave = new Button();
		ddlItemTypes = new Class20();
		label16 = new Label();
		lblInvCount = new Label();
		ddlTaxRules = new Class20();
		ddlUOM = new Class20();
		btnShowKeyboard_ItemCost = new Button();
		label17 = new Label();
		btnShowKeyboard_InventoryQTY = new Button();
		btnShowKeyboard_Name = new Button();
		btnShowKeyboard_ItemPrice = new Button();
		label30 = new Label();
		lblSubTitle = new Label();
		pnlGroups = new Panel();
		comboItems = new Class20();
		label7 = new Label();
		btnSearch = new Button();
		label9 = new Label();
		label15 = new Label();
		label8 = new Label();
		comboGroup = new Class20();
		label10 = new Label();
		txtBarcode = new RadTextBoxControl();
		label23 = new Label();
		btnShowKeyboard_Barcode = new Button();
		panel2 = new Panel();
		chkSmartBarcode = new RadToggleSwitch();
		label32 = new Label();
		pnlItemInfo.SuspendLayout();
		((ISupportInitialize)txtReorderQty).BeginInit();
		((ISupportInitialize)txtReorderLimit).BeginInit();
		((ISupportInitialize)chkTaxesIncluded).BeginInit();
		((ISupportInitialize)txtBatchQty).BeginInit();
		((ISupportInitialize)chkAutoPromptOption).BeginInit();
		((ISupportInitialize)chkAllowLoyaltyRedemp).BeginInit();
		((ISupportInitialize)txtStations).BeginInit();
		((ISupportInitialize)chkAutoResetInv).BeginInit();
		((ISupportInitialize)txtResetQty).BeginInit();
		((ISupportInitialize)txtMinFreeOptions).BeginInit();
		((ISupportInitialize)chkTrackExpiry).BeginInit();
		((ISupportInitialize)txtMaxFreeOptions).BeginInit();
		((ISupportInitialize)ddlItemCourses).BeginInit();
		((ISupportInitialize)txtNotes).BeginInit();
		((ISupportInitialize)txtSortOrder).BeginInit();
		((ISupportInitialize)chkOnSale).BeginInit();
		((ISupportInitialize)txtDescription).BeginInit();
		((ISupportInitialize)txtInventoryQTY).BeginInit();
		((ISupportInitialize)txtItemPrice).BeginInit();
		((ISupportInitialize)txtItemCost).BeginInit();
		((ISupportInitialize)chkIsPackage).BeginInit();
		((ISupportInitialize)chkDisableIfSoldOut).BeginInit();
		((ISupportInitialize)chkTrackInventory).BeginInit();
		((ISupportInitialize)chkActive).BeginInit();
		((ISupportInitialize)txtName).BeginInit();
		((ISupportInitialize)ddlColors).BeginInit();
		panel1.SuspendLayout();
		((ISupportInitialize)ddlItemTypes).BeginInit();
		((ISupportInitialize)ddlTaxRules).BeginInit();
		((ISupportInitialize)ddlUOM).BeginInit();
		pnlGroups.SuspendLayout();
		((ISupportInitialize)comboItems).BeginInit();
		((ISupportInitialize)comboGroup).BeginInit();
		((ISupportInitialize)txtBarcode).BeginInit();
		panel2.SuspendLayout();
		((ISupportInitialize)chkSmartBarcode).BeginInit();
		SuspendLayout();
		componentResourceManager.ApplyResources(pnlItemInfo, "pnlItemInfo");
		pnlItemInfo.Controls.Add(label38);
		pnlItemInfo.Controls.Add((Control)(object)txtReorderQty);
		pnlItemInfo.Controls.Add(label37);
		pnlItemInfo.Controls.Add((Control)(object)txtReorderLimit);
		pnlItemInfo.Controls.Add(label36);
		pnlItemInfo.Controls.Add(label35);
		pnlItemInfo.Controls.Add((Control)(object)chkTaxesIncluded);
		pnlItemInfo.Controls.Add(eIfrjFraQI);
		pnlItemInfo.Controls.Add((Control)(object)txtBatchQty);
		pnlItemInfo.Controls.Add(btnShowKeyboard_BatchQty);
		pnlItemInfo.Controls.Add(label31);
		pnlItemInfo.Controls.Add((Control)(object)chkAutoPromptOption);
		pnlItemInfo.Controls.Add(label33);
		pnlItemInfo.Controls.Add(lblSuggestedPriceByIngredients);
		pnlItemInfo.Controls.Add(lblHideLoyalty);
		pnlItemInfo.Controls.Add((Control)(object)chkAllowLoyaltyRedemp);
		pnlItemInfo.Controls.Add(label27);
		pnlItemInfo.Controls.Add(btnSelectStations);
		pnlItemInfo.Controls.Add((Control)(object)txtStations);
		pnlItemInfo.Controls.Add((Control)(object)chkAutoResetInv);
		pnlItemInfo.Controls.Add(btnShowKeyboard_ResetQty);
		pnlItemInfo.Controls.Add((Control)(object)txtResetQty);
		pnlItemInfo.Controls.Add(elDrnuVvBK);
		pnlItemInfo.Controls.Add(label29);
		pnlItemInfo.Controls.Add(btnAsssignSupplier);
		pnlItemInfo.Controls.Add(label28);
		pnlItemInfo.Controls.Add((Control)(object)txtMinFreeOptions);
		pnlItemInfo.Controls.Add(btnInventoryBatches);
		pnlItemInfo.Controls.Add((Control)(object)chkTrackExpiry);
		pnlItemInfo.Controls.Add(label26);
		pnlItemInfo.Controls.Add((Control)(object)txtMaxFreeOptions);
		pnlItemInfo.Controls.Add(label24);
		pnlItemInfo.Controls.Add((Control)(object)ddlItemCourses);
		pnlItemInfo.Controls.Add(label22);
		pnlItemInfo.Controls.Add((Control)(object)txtNotes);
		pnlItemInfo.Controls.Add(label14);
		pnlItemInfo.Controls.Add(btnShowKeyboard_Notes);
		pnlItemInfo.Controls.Add((Control)(object)txtSortOrder);
		pnlItemInfo.Controls.Add(label12);
		pnlItemInfo.Controls.Add(btnNew);
		pnlItemInfo.Controls.Add((Control)(object)chkOnSale);
		pnlItemInfo.Controls.Add(label13);
		pnlItemInfo.Controls.Add(btnCopy);
		pnlItemInfo.Controls.Add((Control)(object)txtDescription);
		pnlItemInfo.Controls.Add(btnShowKeyboard_Description);
		pnlItemInfo.Controls.Add(label25);
		pnlItemInfo.Controls.Add(btnCancel);
		pnlItemInfo.Controls.Add((Control)(object)txtInventoryQTY);
		pnlItemInfo.Controls.Add((Control)(object)txtItemPrice);
		pnlItemInfo.Controls.Add((Control)(object)txtItemCost);
		pnlItemInfo.Controls.Add(btnConfigurePackage);
		pnlItemInfo.Controls.Add(suggestedPrice);
		pnlItemInfo.Controls.Add((Control)(object)chkIsPackage);
		pnlItemInfo.Controls.Add((Control)(object)chkDisableIfSoldOut);
		pnlItemInfo.Controls.Add((Control)(object)chkTrackInventory);
		pnlItemInfo.Controls.Add((Control)(object)chkActive);
		pnlItemInfo.Controls.Add(btnChangeDateAndPercentOff);
		pnlItemInfo.Controls.Add((Control)(object)txtName);
		pnlItemInfo.Controls.Add(btnShowItemAuditLogs);
		pnlItemInfo.Controls.Add(btnMaterials);
		pnlItemInfo.Controls.Add(labelSuggestedPrice);
		pnlItemInfo.Controls.Add(label21);
		pnlItemInfo.Controls.Add((Control)(object)ddlColors);
		pnlItemInfo.Controls.Add(lblInvDisable);
		pnlItemInfo.Controls.Add(label1);
		pnlItemInfo.Controls.Add(btnShowCustomField);
		pnlItemInfo.Controls.Add(label2);
		pnlItemInfo.Controls.Add(label3);
		pnlItemInfo.Controls.Add(label4);
		pnlItemInfo.Controls.Add(label5);
		pnlItemInfo.Controls.Add(panel1);
		pnlItemInfo.Controls.Add(label6);
		pnlItemInfo.Controls.Add(label11);
		pnlItemInfo.Controls.Add(label19);
		pnlItemInfo.Controls.Add(pvcUvEahoB);
		pnlItemInfo.Controls.Add(btnSave);
		pnlItemInfo.Controls.Add((Control)(object)ddlItemTypes);
		pnlItemInfo.Controls.Add(label16);
		pnlItemInfo.Controls.Add(lblInvCount);
		pnlItemInfo.Controls.Add((Control)(object)ddlTaxRules);
		pnlItemInfo.Controls.Add((Control)(object)ddlUOM);
		pnlItemInfo.Controls.Add(btnShowKeyboard_ItemCost);
		pnlItemInfo.Controls.Add(label17);
		pnlItemInfo.Controls.Add(btnShowKeyboard_InventoryQTY);
		pnlItemInfo.Controls.Add(btnShowKeyboard_Name);
		pnlItemInfo.Controls.Add(btnShowKeyboard_ItemPrice);
		pnlItemInfo.Controls.Add(label30);
		pnlItemInfo.Name = "pnlItemInfo";
		label38.BackColor = Color.FromArgb(164, 181, 181);
		componentResourceManager.ApplyResources(label38, "label38");
		label38.ForeColor = Color.White;
		label38.Name = "label38";
		label38.Tag = "";
		componentResourceManager.ApplyResources(txtReorderQty, "txtReorderQty");
		((Control)(object)txtReorderQty).Name = "txtReorderQty";
		((RadElement)((RadControl)txtReorderQty).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtReorderQty).Tag = "product";
		txtReorderQty.set_TextAlign(HorizontalAlignment.Center);
		((Control)(object)txtReorderQty).Click += txtReorderQty_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtReorderQty).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtReorderQty).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(0f, 5f));
		label37.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label37, "label37");
		label37.ForeColor = Color.White;
		label37.Name = "label37";
		componentResourceManager.ApplyResources(txtReorderLimit, "txtReorderLimit");
		((Control)(object)txtReorderLimit).Name = "txtReorderLimit";
		((RadElement)((RadControl)txtReorderLimit).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtReorderLimit).Tag = "product";
		txtReorderLimit.set_TextAlign(HorizontalAlignment.Center);
		((Control)(object)txtReorderLimit).Click += txtReorderLimit_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtReorderLimit).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtReorderLimit).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(0f, 5f));
		label36.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label36, "label36");
		label36.ForeColor = Color.White;
		label36.Name = "label36";
		label35.BackColor = Color.FromArgb(164, 181, 181);
		componentResourceManager.ApplyResources(label35, "label35");
		label35.ForeColor = Color.White;
		label35.Name = "label35";
		label35.Tag = "";
		componentResourceManager.ApplyResources(chkTaxesIncluded, "chkTaxesIncluded");
		((Control)(object)chkTaxesIncluded).Name = "chkTaxesIncluded";
		chkTaxesIncluded.set_OffText("NO");
		chkTaxesIncluded.set_OnText("YES");
		((Control)(object)chkTaxesIncluded).Tag = "product";
		chkTaxesIncluded.set_ToggleStateMode((ToggleStateMode)1);
		chkTaxesIncluded.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkTaxesIncluded).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkTaxesIncluded).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkTaxesIncluded).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTaxesIncluded).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTaxesIncluded).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTaxesIncluded).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkTaxesIncluded).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkTaxesIncluded).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		eIfrjFraQI.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(eIfrjFraQI, "label34");
		eIfrjFraQI.ForeColor = Color.White;
		eIfrjFraQI.Name = "label34";
		eIfrjFraQI.Tag = "product";
		componentResourceManager.ApplyResources(txtBatchQty, "txtBatchQty");
		((Control)(object)txtBatchQty).Name = "txtBatchQty";
		((RadElement)((RadControl)txtBatchQty).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtBatchQty).Tag = "product";
		txtBatchQty.set_TextAlign(HorizontalAlignment.Center);
		((Control)(object)txtBatchQty).Click += btnShowKeyboard_BatchQty_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtBatchQty).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtBatchQty).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(0f, 5f));
		btnShowKeyboard_BatchQty.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_BatchQty.DialogResult = DialogResult.OK;
		btnShowKeyboard_BatchQty.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_BatchQty.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_BatchQty, "btnShowKeyboard_BatchQty");
		btnShowKeyboard_BatchQty.ForeColor = Color.White;
		btnShowKeyboard_BatchQty.Name = "btnShowKeyboard_BatchQty";
		btnShowKeyboard_BatchQty.Tag = "product";
		btnShowKeyboard_BatchQty.UseVisualStyleBackColor = false;
		btnShowKeyboard_BatchQty.Click += btnShowKeyboard_BatchQty_Click;
		label31.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label31, "label31");
		label31.ForeColor = Color.White;
		label31.Name = "label31";
		componentResourceManager.ApplyResources(chkAutoPromptOption, "chkAutoPromptOption");
		((Control)(object)chkAutoPromptOption).Name = "chkAutoPromptOption";
		chkAutoPromptOption.set_OffText("NO");
		chkAutoPromptOption.set_OnText("YES");
		((Control)(object)chkAutoPromptOption).Tag = "product";
		chkAutoPromptOption.set_ToggleStateMode((ToggleStateMode)1);
		((RadToggleSwitchElement)((RadControl)chkAutoPromptOption).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkAutoPromptOption).GetChildAt(0)).set_ThumbOffset(52);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkAutoPromptOption).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkAutoPromptOption).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkAutoPromptOption).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkAutoPromptOption).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkAutoPromptOption).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text1"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkAutoPromptOption).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		label33.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label33, "label33");
		label33.ForeColor = Color.White;
		label33.Name = "label33";
		lblSuggestedPriceByIngredients.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(lblSuggestedPriceByIngredients, "lblSuggestedPriceByIngredients");
		lblSuggestedPriceByIngredients.ForeColor = Color.White;
		lblSuggestedPriceByIngredients.Name = "lblSuggestedPriceByIngredients";
		lblSuggestedPriceByIngredients.Tag = "";
		lblHideLoyalty.BackColor = Color.FromArgb(164, 181, 181);
		componentResourceManager.ApplyResources(lblHideLoyalty, "lblHideLoyalty");
		lblHideLoyalty.ForeColor = Color.White;
		lblHideLoyalty.Name = "lblHideLoyalty";
		lblHideLoyalty.Tag = "";
		componentResourceManager.ApplyResources(chkAllowLoyaltyRedemp, "chkAllowLoyaltyRedemp");
		((Control)(object)chkAllowLoyaltyRedemp).Name = "chkAllowLoyaltyRedemp";
		chkAllowLoyaltyRedemp.set_OffText("NO");
		chkAllowLoyaltyRedemp.set_OnText("YES");
		((Control)(object)chkAllowLoyaltyRedemp).Tag = "product";
		chkAllowLoyaltyRedemp.set_ToggleStateMode((ToggleStateMode)1);
		chkAllowLoyaltyRedemp.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkAllowLoyaltyRedemp).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkAllowLoyaltyRedemp).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkAllowLoyaltyRedemp).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkAllowLoyaltyRedemp).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkAllowLoyaltyRedemp).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkAllowLoyaltyRedemp).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkAllowLoyaltyRedemp).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text2"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkAllowLoyaltyRedemp).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		label27.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label27, "label27");
		label27.ForeColor = Color.White;
		label27.Name = "label27";
		btnSelectStations.BackColor = Color.FromArgb(50, 119, 155);
		btnSelectStations.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnSelectStations, "btnSelectStations");
		btnSelectStations.ForeColor = SystemColors.Control;
		btnSelectStations.Name = "btnSelectStations";
		btnSelectStations.Tag = "product";
		btnSelectStations.UseVisualStyleBackColor = false;
		btnSelectStations.Click += btnSelectStations_Click;
		componentResourceManager.ApplyResources(txtStations, "txtStations");
		txtStations.set_IsReadOnly(true);
		((Control)(object)txtStations).Name = "txtStations";
		((RadElement)((RadControl)txtStations).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtStations).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtStations).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		componentResourceManager.ApplyResources(chkAutoResetInv, "chkAutoResetInv");
		((Control)(object)chkAutoResetInv).Name = "chkAutoResetInv";
		chkAutoResetInv.set_OffText("NO");
		chkAutoResetInv.set_OnText("YES");
		((Control)(object)chkAutoResetInv).Tag = "product";
		chkAutoResetInv.set_ToggleStateMode((ToggleStateMode)1);
		chkAutoResetInv.set_Value(false);
		chkAutoResetInv.add_ValueChanged((EventHandler)chkAutoResetInv_ValueChanged);
		((RadToggleSwitchElement)((RadControl)chkAutoResetInv).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkAutoResetInv).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkAutoResetInv).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkAutoResetInv).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkAutoResetInv).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkAutoResetInv).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkAutoResetInv).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text3"));
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
		elDrnuVvBK.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(elDrnuVvBK, "lblResetQty");
		elDrnuVvBK.ForeColor = Color.White;
		elDrnuVvBK.Name = "lblResetQty";
		label29.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label29, "label29");
		label29.ForeColor = Color.White;
		label29.Name = "label29";
		btnAsssignSupplier.BackColor = Color.FromArgb(25, 74, 114);
		btnAsssignSupplier.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnAsssignSupplier, "btnAsssignSupplier");
		btnAsssignSupplier.ForeColor = SystemColors.Control;
		btnAsssignSupplier.Name = "btnAsssignSupplier";
		btnAsssignSupplier.Tag = "product";
		btnAsssignSupplier.UseVisualStyleBackColor = false;
		btnAsssignSupplier.Click += btnAsssignSupplier_Click;
		label28.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label28, "label28");
		label28.ForeColor = Color.White;
		label28.Name = "label28";
		label28.Tag = "product";
		componentResourceManager.ApplyResources(txtMinFreeOptions, "txtMinFreeOptions");
		((Control)(object)txtMinFreeOptions).Name = "txtMinFreeOptions";
		((RadElement)((RadControl)txtMinFreeOptions).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtMinFreeOptions).Tag = "product";
		((Control)(object)txtMinFreeOptions).Click += txtMinFreeOptions_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtMinFreeOptions).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtMinFreeOptions).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		btnInventoryBatches.BackColor = Color.FromArgb(77, 174, 225);
		btnInventoryBatches.FlatAppearance.BorderColor = Color.White;
		btnInventoryBatches.FlatAppearance.BorderSize = 0;
		btnInventoryBatches.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnInventoryBatches, "btnInventoryBatches");
		btnInventoryBatches.ForeColor = Color.White;
		btnInventoryBatches.Name = "btnInventoryBatches";
		btnInventoryBatches.UseVisualStyleBackColor = false;
		btnInventoryBatches.Click += btnInventoryBatches_Click;
		componentResourceManager.ApplyResources(chkTrackExpiry, "chkTrackExpiry");
		((Control)(object)chkTrackExpiry).Name = "chkTrackExpiry";
		chkTrackExpiry.set_OffText("NO");
		chkTrackExpiry.set_OnText("YES");
		((Control)(object)chkTrackExpiry).Tag = "product";
		chkTrackExpiry.set_ToggleStateMode((ToggleStateMode)1);
		chkTrackExpiry.set_Value(false);
		chkTrackExpiry.add_ValueChanged((EventHandler)chkTrackExpiry_ValueChanged);
		((RadToggleSwitchElement)((RadControl)chkTrackExpiry).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkTrackExpiry).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkTrackExpiry).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTrackExpiry).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTrackExpiry).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTrackExpiry).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkTrackExpiry).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text4"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkTrackExpiry).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		label26.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label26, "label26");
		label26.ForeColor = Color.White;
		label26.Name = "label26";
		componentResourceManager.ApplyResources(txtMaxFreeOptions, "txtMaxFreeOptions");
		((Control)(object)txtMaxFreeOptions).Name = "txtMaxFreeOptions";
		((RadElement)((RadControl)txtMaxFreeOptions).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtMaxFreeOptions).Tag = "product";
		((Control)(object)txtMaxFreeOptions).TextChanged += txtMaxFreeOptions_TextChanged;
		((Control)(object)txtMaxFreeOptions).Click += txtMaxFreeOptions_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtMaxFreeOptions).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtMaxFreeOptions).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		label24.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label24, "label24");
		label24.ForeColor = Color.White;
		label24.Name = "label24";
		label24.Tag = "product";
		componentResourceManager.ApplyResources(ddlItemCourses, "ddlItemCourses");
		((Control)(object)ddlItemCourses).BackColor = Color.White;
		((RadDropDownList)ddlItemCourses).set_DropDownStyle((RadDropDownStyle)2);
		((RadDropDownList)ddlItemCourses).set_EnableKineticScrolling(true);
		((Control)(object)ddlItemCourses).Name = "ddlItemCourses";
		((RadElement)((RadControl)ddlItemCourses).get_RootElement()).set_MinSize(new Size(150, 0));
		((Control)(object)ddlItemCourses).Tag = "product";
		((RadControl)ddlItemCourses).set_ThemeName("Windows8");
		label22.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label22, "label22");
		label22.ForeColor = Color.White;
		label22.Name = "label22";
		componentResourceManager.ApplyResources(txtNotes, "txtNotes");
		((Control)(object)txtNotes).Name = "txtNotes";
		((RadElement)((RadControl)txtNotes).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtNotes).Click += txtBarcode_Click;
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
		btnShowKeyboard_Notes.Click += yorxnKqOxN;
		componentResourceManager.ApplyResources(txtSortOrder, "txtSortOrder");
		((Control)(object)txtSortOrder).Name = "txtSortOrder";
		((RadElement)((RadControl)txtSortOrder).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtSortOrder).Tag = "";
		txtSortOrder.set_TextAlign(HorizontalAlignment.Center);
		((Control)(object)txtSortOrder).Click += txtBarcode_Click;
		((Control)(object)txtSortOrder).KeyPress += txtSortOrder_KeyPress;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtSortOrder).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtSortOrder).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(0f, 5f));
		label12.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label12, "label12");
		label12.ForeColor = Color.White;
		label12.Name = "label12";
		label12.Tag = "";
		btnNew.BackColor = Color.FromArgb(1, 110, 211);
		btnNew.FlatAppearance.BorderColor = Color.White;
		btnNew.FlatAppearance.BorderSize = 0;
		btnNew.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnNew, "btnNew");
		btnNew.ForeColor = Color.White;
		btnNew.Name = "btnNew";
		btnNew.UseVisualStyleBackColor = false;
		btnNew.Click += btnNew_Click;
		componentResourceManager.ApplyResources(chkOnSale, "chkOnSale");
		((Control)(object)chkOnSale).Name = "chkOnSale";
		chkOnSale.set_OffText("NO");
		chkOnSale.set_OnText("YES");
		((Control)(object)chkOnSale).Tag = "product";
		chkOnSale.set_ToggleStateMode((ToggleStateMode)1);
		chkOnSale.set_Value(false);
		chkOnSale.add_ValueChanged((EventHandler)chkOnSale_ValueChanged);
		((RadToggleSwitchElement)((RadControl)chkOnSale).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkOnSale).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkOnSale).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkOnSale).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkOnSale).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkOnSale).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkOnSale).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text5"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkOnSale).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		label13.BackColor = Color.FromArgb(164, 181, 181);
		label13.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label13, "label13");
		label13.ForeColor = Color.White;
		label13.Name = "label13";
		label13.Tag = "product";
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
		((Control)(object)txtDescription).Click += txtBarcode_Click;
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
		btnShowKeyboard_Description.Click += ddolzMvJeH;
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
		((Control)(object)txtInventoryQTY).Click += txtBarcode_Click;
		((Control)(object)txtInventoryQTY).KeyPress += txtInventoryQTY_KeyPress;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtInventoryQTY).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtInventoryQTY).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(0f, 5f));
		componentResourceManager.ApplyResources(txtItemPrice, "txtItemPrice");
		((Control)(object)txtItemPrice).Name = "txtItemPrice";
		((RadElement)((RadControl)txtItemPrice).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtItemPrice).Tag = "product";
		txtItemPrice.set_TextAlign(HorizontalAlignment.Center);
		((Control)(object)txtItemPrice).TextChanged += txtItemPrice_TextChanged;
		((Control)(object)txtItemPrice).Click += txtBarcode_Click;
		((Control)(object)txtItemPrice).KeyPress += txtItemPrice_KeyPress;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtItemPrice).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtItemPrice).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(0f, 5f));
		componentResourceManager.ApplyResources(txtItemCost, "txtItemCost");
		((Control)(object)txtItemCost).Name = "txtItemCost";
		((RadElement)((RadControl)txtItemCost).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtItemCost).Tag = "";
		txtItemCost.set_TextAlign(HorizontalAlignment.Center);
		((Control)(object)txtItemCost).TextChanged += txtItemCost_TextChanged;
		((Control)(object)txtItemCost).Click += txtBarcode_Click;
		((Control)(object)txtItemCost).KeyPress += txtItemCost_KeyPress;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtItemCost).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtItemCost).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(0f, 5f));
		btnConfigurePackage.BackColor = Color.FromArgb(50, 119, 155);
		btnConfigurePackage.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnConfigurePackage, "btnConfigurePackage");
		btnConfigurePackage.ForeColor = SystemColors.Control;
		btnConfigurePackage.Name = "btnConfigurePackage";
		btnConfigurePackage.Tag = "product";
		btnConfigurePackage.UseVisualStyleBackColor = false;
		btnConfigurePackage.Click += btnConfigurePackage_Click;
		suggestedPrice.BackColor = Color.LightGray;
		componentResourceManager.ApplyResources(suggestedPrice, "suggestedPrice");
		suggestedPrice.FlatAppearance.BorderSize = 0;
		suggestedPrice.ForeColor = Color.FromArgb(40, 40, 40);
		suggestedPrice.Name = "suggestedPrice";
		suggestedPrice.Tag = "product";
		suggestedPrice.UseVisualStyleBackColor = false;
		componentResourceManager.ApplyResources(chkIsPackage, "chkIsPackage");
		((Control)(object)chkIsPackage).Name = "chkIsPackage";
		chkIsPackage.set_OffText("NO");
		chkIsPackage.set_OnText("YES");
		((Control)(object)chkIsPackage).Tag = "product";
		chkIsPackage.set_ToggleStateMode((ToggleStateMode)1);
		chkIsPackage.set_Value(false);
		chkIsPackage.add_ValueChanged((EventHandler)chkIsPackage_ValueChanged);
		((RadToggleSwitchElement)((RadControl)chkIsPackage).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkIsPackage).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkIsPackage).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkIsPackage).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkIsPackage).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkIsPackage).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkIsPackage).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text6"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkIsPackage).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
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
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkDisableIfSoldOut).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text7"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkDisableIfSoldOut).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		componentResourceManager.ApplyResources(chkTrackInventory, "chkTrackInventory");
		((Control)(object)chkTrackInventory).Name = "chkTrackInventory";
		chkTrackInventory.set_OffText("NO");
		chkTrackInventory.set_OnText("YES");
		((Control)(object)chkTrackInventory).Tag = "product";
		chkTrackInventory.set_ToggleStateMode((ToggleStateMode)1);
		chkTrackInventory.set_Value(false);
		chkTrackInventory.add_ValueChanged((EventHandler)chkTrackInventory_ValueChanged);
		((RadToggleSwitchElement)((RadControl)chkTrackInventory).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkTrackInventory).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkTrackInventory).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTrackInventory).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTrackInventory).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTrackInventory).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkTrackInventory).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text8"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkTrackInventory).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		componentResourceManager.ApplyResources(chkActive, "chkActive");
		((Control)(object)chkActive).Name = "chkActive";
		chkActive.set_OffText("NO");
		chkActive.set_OnText("YES");
		((Control)(object)chkActive).Tag = "";
		chkActive.set_ToggleStateMode((ToggleStateMode)1);
		((RadToggleSwitchElement)((RadControl)chkActive).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkActive).GetChildAt(0)).set_ThumbOffset(52);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkActive).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text9"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		btnChangeDateAndPercentOff.BackColor = Color.FromArgb(77, 174, 225);
		componentResourceManager.ApplyResources(btnChangeDateAndPercentOff, "btnChangeDateAndPercentOff");
		btnChangeDateAndPercentOff.FlatAppearance.BorderSize = 0;
		btnChangeDateAndPercentOff.ForeColor = SystemColors.ButtonFace;
		btnChangeDateAndPercentOff.Name = "btnChangeDateAndPercentOff";
		btnChangeDateAndPercentOff.Tag = "product";
		btnChangeDateAndPercentOff.UseVisualStyleBackColor = false;
		btnChangeDateAndPercentOff.Click += btnChangeDateAndPercentOff_Click;
		componentResourceManager.ApplyResources(txtName, "txtName");
		((Control)(object)txtName).Name = "txtName";
		((RadElement)((RadControl)txtName).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtName).Click += txtBarcode_Click;
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
		btnMaterials.BackColor = Color.FromArgb(61, 142, 185);
		btnMaterials.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnMaterials, "btnMaterials");
		btnMaterials.ForeColor = SystemColors.Control;
		btnMaterials.Name = "btnMaterials";
		btnMaterials.Tag = "product";
		btnMaterials.UseVisualStyleBackColor = false;
		btnMaterials.Click += btnMaterials_Click;
		labelSuggestedPrice.BackColor = Color.FromArgb(118, 130, 130);
		componentResourceManager.ApplyResources(labelSuggestedPrice, "labelSuggestedPrice");
		labelSuggestedPrice.ForeColor = Color.White;
		labelSuggestedPrice.Name = "labelSuggestedPrice";
		labelSuggestedPrice.Tag = "product";
		label21.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label21, "label21");
		label21.ForeColor = Color.White;
		label21.Name = "label21";
		label21.Tag = "product";
		componentResourceManager.ApplyResources(ddlColors, "ddlColors");
		((Control)(object)ddlColors).BackColor = Color.White;
		((RadDropDownList)ddlColors).set_DropDownStyle((RadDropDownStyle)2);
		((RadDropDownList)ddlColors).set_EnableKineticScrolling(true);
		((Control)(object)ddlColors).Name = "ddlColors";
		((RadElement)((RadControl)ddlColors).get_RootElement()).set_MinSize(new Size(150, 0));
		((Control)(object)ddlColors).Tag = "product";
		((RadControl)ddlColors).set_ThemeName("Windows8");
		((Control)(object)ddlColors).MouseHover += ddlColors_MouseHover;
		lblInvDisable.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(lblInvDisable, "lblInvDisable");
		lblInvDisable.ForeColor = Color.White;
		lblInvDisable.Name = "lblInvDisable";
		lblInvDisable.Tag = "product";
		label1.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		btnShowCustomField.BackColor = Color.FromArgb(50, 119, 155);
		btnShowCustomField.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowCustomField, "btnShowCustomField");
		btnShowCustomField.ForeColor = SystemColors.Control;
		btnShowCustomField.Name = "btnShowCustomField";
		btnShowCustomField.Tag = "product";
		btnShowCustomField.UseVisualStyleBackColor = false;
		btnShowCustomField.Click += btnShowCustomField_Click;
		label2.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		label2.Tag = "product";
		label3.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		label3.Tag = "product";
		label4.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		label4.Tag = "product";
		label5.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label5, "label5");
		label5.ForeColor = Color.White;
		label5.Name = "label5";
		label5.Tag = "product";
		panel1.BackColor = Color.FromArgb(255, 255, 192);
		panel1.Controls.Add(lblMargin);
		panel1.Controls.Add(label20);
		componentResourceManager.ApplyResources(panel1, "panel1");
		panel1.Name = "panel1";
		panel1.Tag = "product";
		lblMargin.BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblMargin, "lblMargin");
		lblMargin.ForeColor = Color.Black;
		lblMargin.Name = "lblMargin";
		label20.BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(label20, "label20");
		label20.ForeColor = Color.Black;
		label20.Name = "label20";
		label6.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label6, "label6");
		label6.ForeColor = Color.White;
		label6.Name = "label6";
		label6.Tag = "product";
		label11.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label11, "label11");
		label11.ForeColor = Color.White;
		label11.Name = "label11";
		label19.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label19, "label19");
		label19.ForeColor = Color.White;
		label19.Name = "label19";
		label19.Tag = "product";
		pvcUvEahoB.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(pvcUvEahoB, "label18");
		pvcUvEahoB.ForeColor = Color.White;
		pvcUvEahoB.Name = "label18";
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderColor = Color.White;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.ForeColor = Color.White;
		btnSave.Name = "btnSave";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		componentResourceManager.ApplyResources(ddlItemTypes, "ddlItemTypes");
		((Control)(object)ddlItemTypes).BackColor = Color.White;
		((RadDropDownList)ddlItemTypes).set_DropDownStyle((RadDropDownStyle)2);
		((RadDropDownList)ddlItemTypes).set_EnableKineticScrolling(true);
		((Control)(object)ddlItemTypes).ForeColor = SystemColors.ControlText;
		((Control)(object)ddlItemTypes).Name = "ddlItemTypes";
		((RadElement)((RadControl)ddlItemTypes).get_RootElement()).set_MinSize(new Size(250, 0));
		((RadDropDownList)ddlItemTypes).set_SelectNextOnDoubleClick(true);
		((Control)(object)ddlItemTypes).Tag = "product";
		((RadControl)ddlItemTypes).set_ThemeName("Windows8");
		label16.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label16, "label16");
		label16.ForeColor = Color.White;
		label16.Name = "label16";
		label16.Tag = "product";
		lblInvCount.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(lblInvCount, "lblInvCount");
		lblInvCount.ForeColor = Color.White;
		lblInvCount.Name = "lblInvCount";
		componentResourceManager.ApplyResources(ddlTaxRules, "ddlTaxRules");
		((Control)(object)ddlTaxRules).BackColor = Color.White;
		((RadDropDownList)ddlTaxRules).set_DropDownStyle((RadDropDownStyle)2);
		((RadDropDownList)ddlTaxRules).set_EnableKineticScrolling(true);
		((Control)(object)ddlTaxRules).Name = "ddlTaxRules";
		((RadElement)((RadControl)ddlTaxRules).get_RootElement()).set_MinSize(new Size(250, 0));
		((Control)(object)ddlTaxRules).Tag = "product";
		((RadControl)ddlTaxRules).set_ThemeName("Windows8");
		((RadDropDownList)ddlTaxRules).add_SelectedIndexChanged(new PositionChangedEventHandler(ddlTaxRules_SelectedIndexChanged));
		componentResourceManager.ApplyResources(ddlUOM, "ddlUOM");
		((Control)(object)ddlUOM).BackColor = Color.White;
		((RadDropDownList)ddlUOM).set_DropDownStyle((RadDropDownStyle)2);
		((RadDropDownList)ddlUOM).set_EnableKineticScrolling(true);
		((Control)(object)ddlUOM).Name = "ddlUOM";
		((RadControl)ddlUOM).set_ThemeName("Windows8");
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
		btnShowKeyboard_ItemPrice.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_ItemPrice.DialogResult = DialogResult.OK;
		btnShowKeyboard_ItemPrice.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_ItemPrice.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_ItemPrice, "btnShowKeyboard_ItemPrice");
		btnShowKeyboard_ItemPrice.ForeColor = Color.White;
		btnShowKeyboard_ItemPrice.Name = "btnShowKeyboard_ItemPrice";
		btnShowKeyboard_ItemPrice.Tag = "product";
		btnShowKeyboard_ItemPrice.UseVisualStyleBackColor = false;
		btnShowKeyboard_ItemPrice.Click += btnShowKeyboard_ItemPrice_Click;
		label30.BackColor = Color.FromArgb(164, 181, 181);
		componentResourceManager.ApplyResources(label30, "label30");
		label30.ForeColor = Color.White;
		label30.Name = "label30";
		label30.Tag = "";
		lblSubTitle.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(lblSubTitle, "lblSubTitle");
		lblSubTitle.ForeColor = Color.White;
		lblSubTitle.Name = "lblSubTitle";
		pnlGroups.BackColor = Color.Transparent;
		pnlGroups.Controls.Add((Control)(object)comboItems);
		pnlGroups.Controls.Add(label7);
		pnlGroups.Controls.Add(btnSearch);
		pnlGroups.Controls.Add(label9);
		pnlGroups.Controls.Add(label15);
		pnlGroups.Controls.Add(label8);
		pnlGroups.Controls.Add((Control)(object)comboGroup);
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
		btnSearch.Click += acSlRyyRdg;
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
		componentResourceManager.ApplyResources(comboGroup, "comboGroup");
		((Control)(object)comboGroup).BackColor = Color.White;
		((RadDropDownList)comboGroup).set_DropDownStyle((RadDropDownStyle)2);
		((RadDropDownList)comboGroup).set_EnableKineticScrolling(true);
		((Control)(object)comboGroup).ForeColor = SystemColors.WindowText;
		((Control)(object)comboGroup).Name = "comboGroup";
		((RadControl)comboGroup).set_ThemeName("Windows8");
		((RadDropDownList)comboGroup).add_SelectedIndexChanged(new PositionChangedEventHandler(comboGroup_SelectedIndexChanged));
		label10.BackColor = Color.FromArgb(156, 89, 184);
		componentResourceManager.ApplyResources(label10, "label10");
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		componentResourceManager.ApplyResources(txtBarcode, "txtBarcode");
		((Control)(object)txtBarcode).Name = "txtBarcode";
		((RadElement)((RadControl)txtBarcode).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtBarcode).Click += txtBarcode_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtBarcode).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtBarcode).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		label23.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label23, "label23");
		label23.ForeColor = Color.White;
		label23.Name = "label23";
		btnShowKeyboard_Barcode.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Barcode.DialogResult = DialogResult.OK;
		btnShowKeyboard_Barcode.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Barcode.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Barcode, "btnShowKeyboard_Barcode");
		btnShowKeyboard_Barcode.ForeColor = Color.White;
		btnShowKeyboard_Barcode.Name = "btnShowKeyboard_Barcode";
		btnShowKeyboard_Barcode.UseVisualStyleBackColor = false;
		btnShowKeyboard_Barcode.Click += btnShowKeyboard_Barcode_Click;
		panel2.Controls.Add((Control)(object)chkSmartBarcode);
		panel2.Controls.Add(label32);
		panel2.Controls.Add((Control)(object)txtBarcode);
		panel2.Controls.Add(btnShowKeyboard_Barcode);
		panel2.Controls.Add(label23);
		componentResourceManager.ApplyResources(panel2, "panel2");
		panel2.Name = "panel2";
		componentResourceManager.ApplyResources(chkSmartBarcode, "chkSmartBarcode");
		((Control)(object)chkSmartBarcode).Name = "chkSmartBarcode";
		chkSmartBarcode.set_OffText("NO");
		chkSmartBarcode.set_OnText("YES");
		((Control)(object)chkSmartBarcode).Tag = "";
		chkSmartBarcode.set_ToggleStateMode((ToggleStateMode)1);
		chkSmartBarcode.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkSmartBarcode).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkSmartBarcode).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkSmartBarcode).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkSmartBarcode).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkSmartBarcode).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkSmartBarcode).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkSmartBarcode).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text10"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkSmartBarcode).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		label32.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label32, "label32");
		label32.ForeColor = Color.White;
		label32.Name = "label32";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(panel2);
		base.Controls.Add(pnlItemInfo);
		base.Controls.Add(lblSubTitle);
		base.Controls.Add(pnlGroups);
		base.Controls.Add(label10);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmAddEditItems";
		base.Opacity = 1.0;
		base.Load += frmAddEditItems_Load;
		base.Controls.SetChildIndex(label10, 0);
		base.Controls.SetChildIndex(pnlGroups, 0);
		base.Controls.SetChildIndex(lblSubTitle, 0);
		base.Controls.SetChildIndex(pnlItemInfo, 0);
		base.Controls.SetChildIndex(panel2, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		pnlItemInfo.ResumeLayout(performLayout: false);
		((ISupportInitialize)txtReorderQty).EndInit();
		((ISupportInitialize)txtReorderLimit).EndInit();
		((ISupportInitialize)chkTaxesIncluded).EndInit();
		((ISupportInitialize)txtBatchQty).EndInit();
		((ISupportInitialize)chkAutoPromptOption).EndInit();
		((ISupportInitialize)chkAllowLoyaltyRedemp).EndInit();
		((ISupportInitialize)txtStations).EndInit();
		((ISupportInitialize)chkAutoResetInv).EndInit();
		((ISupportInitialize)txtResetQty).EndInit();
		((ISupportInitialize)txtMinFreeOptions).EndInit();
		((ISupportInitialize)chkTrackExpiry).EndInit();
		((ISupportInitialize)txtMaxFreeOptions).EndInit();
		((ISupportInitialize)ddlItemCourses).EndInit();
		((ISupportInitialize)txtNotes).EndInit();
		((ISupportInitialize)txtSortOrder).EndInit();
		((ISupportInitialize)chkOnSale).EndInit();
		((ISupportInitialize)txtDescription).EndInit();
		((ISupportInitialize)txtInventoryQTY).EndInit();
		((ISupportInitialize)txtItemPrice).EndInit();
		((ISupportInitialize)txtItemCost).EndInit();
		((ISupportInitialize)chkIsPackage).EndInit();
		((ISupportInitialize)chkDisableIfSoldOut).EndInit();
		((ISupportInitialize)chkTrackInventory).EndInit();
		((ISupportInitialize)chkActive).EndInit();
		((ISupportInitialize)txtName).EndInit();
		((ISupportInitialize)ddlColors).EndInit();
		panel1.ResumeLayout(performLayout: false);
		((ISupportInitialize)ddlItemTypes).EndInit();
		((ISupportInitialize)ddlTaxRules).EndInit();
		((ISupportInitialize)ddlUOM).EndInit();
		pnlGroups.ResumeLayout(performLayout: false);
		((ISupportInitialize)comboItems).EndInit();
		((ISupportInitialize)comboGroup).EndInit();
		((ISupportInitialize)txtBarcode).EndInit();
		panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)chkSmartBarcode).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
