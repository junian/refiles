using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmItemsInItem : frmMasterForm
{
	private decimal decimal_0;

	private GClass6 gclass6_0;

	private string CoBmEuurJF;

	private string string_0;

	private List<ItemsInItemsField> list_2;

	private List<GroupsInItemsField> list_3;

	private decimal decimal_1;

	[CompilerGenerated]
	private List<ItemsInItemsField> YlHmQejNw4;

	[CompilerGenerated]
	private List<GroupsInItemsField> list_4;

	[CompilerGenerated]
	private decimal decimal_2;

	private IContainer icontainer_1;

	private Label lowerLabelAddItem;

	private Label labelQty;

	private Class19 comboListOfItems;

	internal Button btnAddItemToPackage;

	private Label label19;

	private ListView uaKmiyeIhC;

	private ColumnHeader columnHeader_0;

	private ColumnHeader columnHeader_1;

	private Label label1;

	private Label lblItemName;

	internal Button btnExit;

	internal Button btnSave;

	internal Button btnReset;

	internal Button btnDeleteItem;

	private Label labelSuggestedPrice;

	private Label lblSuggestedPrice;

	internal Button btnClearAll;

	internal Button btnShowKeyboard_itemToAddQuantity;

	private RadTextBoxControl itemToAddQuantity;

	private ListView groupsAddedToPackage;

	private ColumnHeader columnHeader_2;

	private ColumnHeader columnHeader_3;

	private Label label2;

	private Class19 ComboListOfGroups;

	private Label label3;

	private RadTextBoxControl groupToAddQuantity;

	internal Button btnShowKeyboard_groupToAddQuantity;

	internal Button btnAddGroupToPackage;

	private ColumnHeader columnHeader_4;

	private Label label4;

	private RadToggleSwitch chkUseItemSettings;

	public List<ItemsInItemsField> returnItemsList
	{
		[CompilerGenerated]
		get
		{
			return YlHmQejNw4;
		}
		[CompilerGenerated]
		set
		{
			YlHmQejNw4 = value;
		}
	}

	public List<GroupsInItemsField> returnGroupsList
	{
		[CompilerGenerated]
		get
		{
			return list_4;
		}
		[CompilerGenerated]
		set
		{
			list_4 = value;
		}
	}

	public decimal returnSuggestedPrice
	{
		[CompilerGenerated]
		get
		{
			return decimal_2;
		}
		[CompilerGenerated]
		set
		{
			decimal_2 = value;
		}
	}

	public frmItemsInItem(string _itemName, string _actionType, List<ItemsInItemsField> _itemsListInItem, List<GroupsInItemsField> _groupsListInItem, decimal _suggestedPrice)
	{
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		base._002Ector();
		CoBmEuurJF = _itemName;
		string_0 = _actionType;
		list_2 = _itemsListInItem;
		list_3 = _groupsListInItem;
		decimal_1 = _suggestedPrice;
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		if (Thread.CurrentThread.CurrentCulture.Name.Equals("fr-CA"))
		{
			btnDeleteItem.Font = new Font(btnDeleteItem.Font.FontFamily, btnDeleteItem.Font.Size - 1.75f);
			btnSave.Font = new Font(btnSave.Font.FontFamily, btnSave.Font.Size - 1f);
		}
	}

	private void btnAddItemToPackage_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass20_0();
		CS_0024_003C_003E8__locals0.itemName = comboListOfItems.SelectedItem.ToString();
		string text = (chkUseItemSettings.Value ? "YES" : "NO");
		string text2 = itemToAddQuantity.Text;
		if (text2 == "0")
		{
			new frmMessageBox(Resources.Quantity_must_be_greater_then_).ShowDialog(this);
			base.DialogResult = DialogResult.None;
			return;
		}
		ListViewItem value = new ListViewItem(new string[3] { CS_0024_003C_003E8__locals0.itemName, text2, text });
		Item item = gclass6_0.Items.Where((Item i) => i.ItemName == CS_0024_003C_003E8__locals0.itemName).FirstOrDefault();
		if (!item.UOM.isFractional && Convert.ToDecimal(text2) % 1m != 0m)
		{
			new frmMessageBox(item.ItemName + Resources._has_a_UOM_of + item.UOM.Name + Resources._Please_add_a_whole_number_for).ShowDialog(this);
			base.DialogResult = DialogResult.None;
			return;
		}
		uaKmiyeIhC.Items.Add(value);
		decimal_0 += item.ItemPrice * Convert.ToDecimal(text2);
		lblSuggestedPrice.Text = decimal_0.ToString("0.00");
		base.DialogResult = DialogResult.None;
	}

	private void btnDeleteItem_Click(object sender, EventArgs e)
	{
		if (uaKmiyeIhC.SelectedItems.Count > 0)
		{
			{
				IEnumerator enumerator = uaKmiyeIhC.SelectedItems.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass21_0();
						CS_0024_003C_003E8__locals0.eachItem = (ListViewItem)enumerator.Current;
						Item item = gclass6_0.Items.Where((Item i) => i.ItemName == CS_0024_003C_003E8__locals0.eachItem.SubItems[0].Text).FirstOrDefault();
						decimal_0 -= item.ItemPrice * Convert.ToDecimal(CS_0024_003C_003E8__locals0.eachItem.SubItems[1].Text);
						lblSuggestedPrice.Text = decimal_0.ToString("0.00");
						uaKmiyeIhC.Items.Remove(CS_0024_003C_003E8__locals0.eachItem);
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
		}
		if (groupsAddedToPackage.SelectedItems.Count > 0)
		{
			foreach (ListViewItem selectedItem in groupsAddedToPackage.SelectedItems)
			{
				groupsAddedToPackage.Items.Remove(selectedItem);
			}
		}
		base.DialogResult = DialogResult.None;
	}

	private void frmItemsInItem_Load(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass22_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.itemIDs = gclass6_0.ItemsInItems.Select((ItemsInItem i) => i.ParentItemID.Value).ToList();
		foreach (Item item in (from i in AdminMethods.getAllItems(ItemClassifications.Product)
			where !CS_0024_003C_003E8__locals0.itemIDs.Contains(i.ItemID)
			select i into a
			where a.ItemName != CS_0024_003C_003E8__locals0._003C_003E4__this.CoBmEuurJF && a.Active
			select a).ToList())
		{
			comboListOfItems.Items.Add(item.ItemName);
		}
		comboListOfItems.SelectedIndex = 0;
		decimal_0 = default(decimal);
		lblItemName.Text = CoBmEuurJF;
		foreach (Group item2 in AdminMethods.GetAllGroup(ItemClassifications.Product))
		{
			ComboListOfGroups.Items.Add(item2.GroupName);
		}
		ComboListOfGroups.SelectedIndex = 0;
		if (string_0 == "AddItem")
		{
			btnSave.Location = new Point(btnReset.Location.X, btnReset.Location.Y);
		}
		else if (string_0 == "EditItem")
		{
			btnReset.Visible = true;
			btnSave.Text = Resources.DONE_SAVE;
		}
		uaKmiyeIhC.Items.Clear();
		if (list_2 != null)
		{
			foreach (ItemsInItemsField item3 in list_2)
			{
				ListViewItem value = new ListViewItem(new string[3]
				{
					item3.ItemName,
					item3.qty.ToString(),
					item3.useItemSettings ? "YES" : "NO"
				});
				uaKmiyeIhC.Items.Add(value);
			}
			decimal_0 = decimal_1;
			lblSuggestedPrice.Text = decimal_1.ToString("0.00");
		}
		groupsAddedToPackage.Items.Clear();
		if (list_3 == null)
		{
			return;
		}
		foreach (GroupsInItemsField item4 in list_3)
		{
			ListViewItem value2 = new ListViewItem(new string[2]
			{
				item4.GroupName,
				item4.qty.ToString()
			});
			groupsAddedToPackage.Items.Add(value2);
		}
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		List<ItemsInItemsField> list = new List<ItemsInItemsField>();
		foreach (ListViewItem item2 in uaKmiyeIhC.Items)
		{
			ItemsInItemsField itemsInItemsField = new ItemsInItemsField
			{
				ItemName = item2.SubItems[0].Text,
				qty = Convert.ToDecimal(item2.SubItems[1].Text),
				useItemSettings = ((item2.SubItems[2].Text == "YES") ? true : false)
			};
			if (!(itemsInItemsField.qty > 1000m))
			{
				list.Add(itemsInItemsField);
				continue;
			}
			new NotificationLabel(this, string.Concat("Quantity for Item ", itemsInItemsField, " is too large."), NotificationTypes.Warning).Show();
			return;
		}
		List<GroupsInItemsField> list2 = new List<GroupsInItemsField>();
		foreach (ListViewItem item3 in groupsAddedToPackage.Items)
		{
			GroupsInItemsField groupsInItemsField = new GroupsInItemsField
			{
				GroupName = item3.SubItems[0].Text,
				qty = Convert.ToDecimal(item3.SubItems[1].Text)
			};
			if (!(groupsInItemsField.qty > 1000m))
			{
				list2.Add(groupsInItemsField);
				continue;
			}
			new NotificationLabel(this, string.Concat("Quantity for Group ", groupsInItemsField, " is too large."), NotificationTypes.Warning).Show();
			return;
		}
		if (string_0 == "EditItem")
		{
			Item item = gclass6_0.Items.Where((Item tblItems) => tblItems.ItemName == CoBmEuurJF && tblItems.isDeleted == false).FirstOrDefault();
			if (item != null)
			{
				AdminMethods.UpdateItemsInItems(list, item.ItemID);
				AdminMethods.UpdateGroupsInItems(list2, item.ItemID);
			}
		}
		base.DialogResult = DialogResult.OK;
		returnGroupsList = list2;
		returnItemsList = list;
		returnSuggestedPrice = decimal_0;
		Close();
	}

	private void btnReset_Click(object sender, EventArgs e)
	{
		uaKmiyeIhC.Items.Clear();
		if (list_2 != null)
		{
			foreach (ItemsInItemsField item in list_2)
			{
				ListViewItem value = new ListViewItem(new string[2]
				{
					item.ItemName,
					item.qty.ToString()
				});
				uaKmiyeIhC.Items.Add(value);
			}
			decimal_0 = decimal_1;
			lblSuggestedPrice.Text = decimal_1.ToString("0.00");
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnExit_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
	}

	private void btnClearAll_Click(object sender, EventArgs e)
	{
		uaKmiyeIhC.Items.Clear();
		groupsAddedToPackage.Items.Clear();
		decimal_0 = default(decimal);
		lblSuggestedPrice.Text = decimal_0.ToString("0.00");
		base.DialogResult = DialogResult.None;
	}

	private void itemToAddQuantity_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private void btnShowKeyboard_itemToAddQuantity_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_a_quantity, 3, 3, itemToAddQuantity.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			if (MemoryLoadedObjects.Numpad.numberEntered == 0m)
			{
				new frmMessageBox(Resources.Quantity_must_be_greater_then_).ShowDialog(this);
			}
			else
			{
				itemToAddQuantity.Text = MemoryLoadedObjects.Numpad.valueEntered;
			}
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnAddGroupToPackage_Click(object sender, EventArgs e)
	{
		string text = ComboListOfGroups.SelectedItem.ToString();
		string text2 = groupToAddQuantity.Text;
		if (text2 == "0")
		{
			new frmMessageBox(Resources.Quantity_must_be_greater_then_).ShowDialog(this);
			base.DialogResult = DialogResult.None;
			return;
		}
		ListViewItem value = new ListViewItem(new string[2] { text, text2 });
		groupsAddedToPackage.Items.Add(value);
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_groupToAddQuantity_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_a_quantity, 3, 3, groupToAddQuantity.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			if (MemoryLoadedObjects.Numpad.numberEntered == 0m)
			{
				new frmMessageBox(Resources.Quantity_must_be_greater_then_).ShowDialog(this);
			}
			else
			{
				groupToAddQuantity.Text = MemoryLoadedObjects.Numpad.valueEntered;
			}
		}
		base.DialogResult = DialogResult.None;
	}

	private void uaKmiyeIhC_SelectedIndexChanged(object sender, EventArgs e)
	{
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmItemsInItem));
		lowerLabelAddItem = new Label();
		labelQty = new Label();
		comboListOfItems = new Class19();
		btnAddItemToPackage = new Button();
		label19 = new Label();
		uaKmiyeIhC = new ListView();
		columnHeader_0 = new ColumnHeader();
		columnHeader_1 = new ColumnHeader();
		columnHeader_4 = new ColumnHeader();
		label1 = new Label();
		lblItemName = new Label();
		btnExit = new Button();
		btnSave = new Button();
		btnReset = new Button();
		btnDeleteItem = new Button();
		labelSuggestedPrice = new Label();
		lblSuggestedPrice = new Label();
		btnClearAll = new Button();
		btnShowKeyboard_itemToAddQuantity = new Button();
		itemToAddQuantity = new RadTextBoxControl();
		groupsAddedToPackage = new ListView();
		columnHeader_2 = new ColumnHeader();
		columnHeader_3 = new ColumnHeader();
		label2 = new Label();
		ComboListOfGroups = new Class19();
		label3 = new Label();
		groupToAddQuantity = new RadTextBoxControl();
		btnShowKeyboard_groupToAddQuantity = new Button();
		btnAddGroupToPackage = new Button();
		label4 = new Label();
		chkUseItemSettings = new RadToggleSwitch();
		((ISupportInitialize)itemToAddQuantity).BeginInit();
		((ISupportInitialize)groupToAddQuantity).BeginInit();
		((ISupportInitialize)chkUseItemSettings).BeginInit();
		SuspendLayout();
		componentResourceManager.ApplyResources(lowerLabelAddItem, "lowerLabelAddItem");
		lowerLabelAddItem.BackColor = Color.FromArgb(156, 89, 184);
		lowerLabelAddItem.ForeColor = SystemColors.Control;
		lowerLabelAddItem.Name = "lowerLabelAddItem";
		labelQty.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(labelQty, "labelQty");
		labelQty.ForeColor = Color.White;
		labelQty.Name = "labelQty";
		comboListOfItems.DrawMode = DrawMode.OwnerDrawVariable;
		comboListOfItems.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(comboListOfItems, "comboListOfItems");
		comboListOfItems.FormattingEnabled = true;
		comboListOfItems.Name = "comboListOfItems";
		comboListOfItems.TabStop = false;
		btnAddItemToPackage.BackColor = Color.Transparent;
		btnAddItemToPackage.DialogResult = DialogResult.OK;
		btnAddItemToPackage.FlatAppearance.BorderColor = Color.Black;
		btnAddItemToPackage.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnAddItemToPackage, "btnAddItemToPackage");
		btnAddItemToPackage.ForeColor = Color.White;
		btnAddItemToPackage.Name = "btnAddItemToPackage";
		btnAddItemToPackage.UseVisualStyleBackColor = false;
		btnAddItemToPackage.Click += btnAddItemToPackage_Click;
		label19.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label19, "label19");
		label19.ForeColor = Color.White;
		label19.Name = "label19";
		uaKmiyeIhC.BackColor = Color.White;
		uaKmiyeIhC.BorderStyle = BorderStyle.None;
		uaKmiyeIhC.Columns.AddRange(new ColumnHeader[3] { columnHeader_0, columnHeader_1, columnHeader_4 });
		componentResourceManager.ApplyResources(uaKmiyeIhC, "itemsAddedToPackage");
		uaKmiyeIhC.ForeColor = Color.FromArgb(40, 40, 40);
		uaKmiyeIhC.FullRowSelect = true;
		uaKmiyeIhC.GridLines = true;
		uaKmiyeIhC.HideSelection = false;
		uaKmiyeIhC.Name = "itemsAddedToPackage";
		uaKmiyeIhC.UseCompatibleStateImageBehavior = false;
		uaKmiyeIhC.View = View.Details;
		uaKmiyeIhC.SelectedIndexChanged += uaKmiyeIhC_SelectedIndexChanged;
		componentResourceManager.ApplyResources(columnHeader_0, "LVItemName");
		componentResourceManager.ApplyResources(columnHeader_1, "LVQuantity");
		componentResourceManager.ApplyResources(columnHeader_4, "LVUseItemPrice");
		label1.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		lblItemName.BackColor = SystemColors.AppWorkspace;
		componentResourceManager.ApplyResources(lblItemName, "lblItemName");
		lblItemName.Name = "lblItemName";
		componentResourceManager.ApplyResources(btnExit, "btnExit");
		btnExit.BackColor = Color.FromArgb(235, 107, 86);
		btnExit.FlatAppearance.BorderColor = Color.White;
		btnExit.FlatAppearance.BorderSize = 0;
		btnExit.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnExit.ForeColor = Color.White;
		btnExit.Name = "btnExit";
		btnExit.UseVisualStyleBackColor = false;
		btnExit.Click += btnExit_Click;
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderColor = Color.White;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnSave.ForeColor = Color.White;
		btnSave.Name = "btnSave";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		componentResourceManager.ApplyResources(btnReset, "btnReset");
		btnReset.BackColor = Color.SandyBrown;
		btnReset.FlatAppearance.BorderColor = Color.Black;
		btnReset.FlatAppearance.BorderSize = 0;
		btnReset.FlatAppearance.MouseDownBackColor = Color.White;
		btnReset.ForeColor = Color.White;
		btnReset.Name = "btnReset";
		btnReset.UseVisualStyleBackColor = false;
		btnReset.Click += btnReset_Click;
		componentResourceManager.ApplyResources(btnDeleteItem, "btnDeleteItem");
		btnDeleteItem.BackColor = Color.FromArgb(214, 142, 81);
		btnDeleteItem.FlatAppearance.BorderColor = Color.White;
		btnDeleteItem.FlatAppearance.BorderSize = 0;
		btnDeleteItem.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnDeleteItem.ForeColor = Color.White;
		btnDeleteItem.Name = "btnDeleteItem";
		btnDeleteItem.UseVisualStyleBackColor = false;
		btnDeleteItem.Click += btnDeleteItem_Click;
		labelSuggestedPrice.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(labelSuggestedPrice, "labelSuggestedPrice");
		labelSuggestedPrice.ForeColor = Color.White;
		labelSuggestedPrice.Name = "labelSuggestedPrice";
		lblSuggestedPrice.BackColor = SystemColors.AppWorkspace;
		componentResourceManager.ApplyResources(lblSuggestedPrice, "lblSuggestedPrice");
		lblSuggestedPrice.ForeColor = Color.Black;
		lblSuggestedPrice.Name = "lblSuggestedPrice";
		componentResourceManager.ApplyResources(btnClearAll, "btnClearAll");
		btnClearAll.BackColor = Color.FromArgb(61, 142, 185);
		btnClearAll.FlatAppearance.BorderColor = Color.Black;
		btnClearAll.FlatAppearance.BorderSize = 0;
		btnClearAll.FlatAppearance.MouseDownBackColor = Color.White;
		btnClearAll.ForeColor = Color.White;
		btnClearAll.Name = "btnClearAll";
		btnClearAll.UseVisualStyleBackColor = false;
		btnClearAll.Click += btnClearAll_Click;
		btnShowKeyboard_itemToAddQuantity.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_itemToAddQuantity.DialogResult = DialogResult.OK;
		btnShowKeyboard_itemToAddQuantity.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_itemToAddQuantity.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_itemToAddQuantity, "btnShowKeyboard_itemToAddQuantity");
		btnShowKeyboard_itemToAddQuantity.ForeColor = Color.White;
		btnShowKeyboard_itemToAddQuantity.Name = "btnShowKeyboard_itemToAddQuantity";
		btnShowKeyboard_itemToAddQuantity.UseVisualStyleBackColor = false;
		btnShowKeyboard_itemToAddQuantity.Click += btnShowKeyboard_itemToAddQuantity_Click;
		componentResourceManager.ApplyResources(itemToAddQuantity, "itemToAddQuantity");
		itemToAddQuantity.Name = "itemToAddQuantity";
		itemToAddQuantity.RootElement.PositionOffset = new SizeF(0f, 0f);
		itemToAddQuantity.Tag = "product";
		itemToAddQuantity.TextAlign = HorizontalAlignment.Center;
		itemToAddQuantity.Click += itemToAddQuantity_Click;
		((RadTextBoxControlElement)itemToAddQuantity.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)itemToAddQuantity.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(0f, 5f);
		groupsAddedToPackage.BackColor = Color.White;
		groupsAddedToPackage.BorderStyle = BorderStyle.None;
		groupsAddedToPackage.Columns.AddRange(new ColumnHeader[2] { columnHeader_2, columnHeader_3 });
		componentResourceManager.ApplyResources(groupsAddedToPackage, "groupsAddedToPackage");
		groupsAddedToPackage.ForeColor = Color.FromArgb(40, 40, 40);
		groupsAddedToPackage.FullRowSelect = true;
		groupsAddedToPackage.GridLines = true;
		groupsAddedToPackage.HideSelection = false;
		groupsAddedToPackage.Name = "groupsAddedToPackage";
		groupsAddedToPackage.UseCompatibleStateImageBehavior = false;
		groupsAddedToPackage.View = View.Details;
		componentResourceManager.ApplyResources(columnHeader_2, "columnHeader1");
		componentResourceManager.ApplyResources(columnHeader_3, "columnHeader2");
		label2.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		ComboListOfGroups.DrawMode = DrawMode.OwnerDrawVariable;
		ComboListOfGroups.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(ComboListOfGroups, "ComboListOfGroups");
		ComboListOfGroups.FormattingEnabled = true;
		ComboListOfGroups.Name = "ComboListOfGroups";
		ComboListOfGroups.TabStop = false;
		label3.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		componentResourceManager.ApplyResources(groupToAddQuantity, "groupToAddQuantity");
		groupToAddQuantity.Name = "groupToAddQuantity";
		groupToAddQuantity.RootElement.PositionOffset = new SizeF(0f, 0f);
		groupToAddQuantity.Tag = "product";
		groupToAddQuantity.TextAlign = HorizontalAlignment.Center;
		((RadTextBoxControlElement)groupToAddQuantity.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)groupToAddQuantity.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(0f, 5f);
		btnShowKeyboard_groupToAddQuantity.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_groupToAddQuantity.DialogResult = DialogResult.OK;
		btnShowKeyboard_groupToAddQuantity.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_groupToAddQuantity.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_groupToAddQuantity, "btnShowKeyboard_groupToAddQuantity");
		btnShowKeyboard_groupToAddQuantity.ForeColor = Color.White;
		btnShowKeyboard_groupToAddQuantity.Name = "btnShowKeyboard_groupToAddQuantity";
		btnShowKeyboard_groupToAddQuantity.UseVisualStyleBackColor = false;
		btnShowKeyboard_groupToAddQuantity.Click += btnShowKeyboard_groupToAddQuantity_Click;
		btnAddGroupToPackage.BackColor = Color.Transparent;
		btnAddGroupToPackage.DialogResult = DialogResult.OK;
		btnAddGroupToPackage.FlatAppearance.BorderColor = Color.Black;
		btnAddGroupToPackage.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnAddGroupToPackage, "btnAddGroupToPackage");
		btnAddGroupToPackage.ForeColor = Color.White;
		btnAddGroupToPackage.Name = "btnAddGroupToPackage";
		btnAddGroupToPackage.UseVisualStyleBackColor = false;
		btnAddGroupToPackage.Click += btnAddGroupToPackage_Click;
		label4.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		componentResourceManager.ApplyResources(chkUseItemSettings, "chkUseItemSettings");
		chkUseItemSettings.Name = "chkUseItemSettings";
		chkUseItemSettings.OffText = "NO";
		chkUseItemSettings.OnText = "YES";
		chkUseItemSettings.Tag = "product";
		chkUseItemSettings.ToggleStateMode = ToggleStateMode.Click;
		chkUseItemSettings.Value = false;
		((RadToggleSwitchElement)chkUseItemSettings.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkUseItemSettings.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkUseItemSettings.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkUseItemSettings.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkUseItemSettings.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkUseItemSettings.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkUseItemSettings.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text");
		((ToggleSwitchPartElement)chkUseItemSettings.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(chkUseItemSettings);
		base.Controls.Add(label4);
		base.Controls.Add(btnAddGroupToPackage);
		base.Controls.Add(btnShowKeyboard_groupToAddQuantity);
		base.Controls.Add(groupToAddQuantity);
		base.Controls.Add(label3);
		base.Controls.Add(ComboListOfGroups);
		base.Controls.Add(label2);
		base.Controls.Add(groupsAddedToPackage);
		base.Controls.Add(itemToAddQuantity);
		base.Controls.Add(btnShowKeyboard_itemToAddQuantity);
		base.Controls.Add(btnClearAll);
		base.Controls.Add(lblSuggestedPrice);
		base.Controls.Add(labelSuggestedPrice);
		base.Controls.Add(btnDeleteItem);
		base.Controls.Add(btnReset);
		base.Controls.Add(btnSave);
		base.Controls.Add(btnExit);
		base.Controls.Add(lblItemName);
		base.Controls.Add(label1);
		base.Controls.Add(uaKmiyeIhC);
		base.Controls.Add(label19);
		base.Controls.Add(labelQty);
		base.Controls.Add(comboListOfItems);
		base.Controls.Add(btnAddItemToPackage);
		base.Controls.Add(lowerLabelAddItem);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmItemsInItem";
		base.Opacity = 1.0;
		base.Load += frmItemsInItem_Load;
		((ISupportInitialize)itemToAddQuantity).EndInit();
		((ISupportInitialize)groupToAddQuantity).EndInit();
		((ISupportInitialize)chkUseItemSettings).EndInit();
		ResumeLayout(performLayout: false);
	}
}
