using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using CorePOS.AdminPanel;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.CommonForms;
using CorePOS.CustomControls;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmAddEditOptions : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public frmAddEditOptions _003C_003E4__this;

		public Dictionary<string, string> items;

		public bool search;

		public string selectItem;

		public _003C_003Ec__DisplayClass9_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal Dictionary<string, string> _003CpopulateAllItems_003Eb__0()
		{
			return _003C_003E4__this.method_6(items, search, selectItem);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public frmAddEditOptions _003C_003E4__this;

		public Dictionary<string, string> items;

		public bool search;

		public string selectItem;

		public _003C_003Ec__DisplayClass13_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal Dictionary<string, string> _003CpopulateItemOptionControls_003Eb__0()
		{
			return _003C_003E4__this.method_6(items, search, selectItem);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public int selectedItemID;

		public frmAddEditOptions _003C_003E4__this;

		public _003C_003Ec__DisplayClass15_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CpopulateItems_003Eb__4(usp_ItemOptionsResult x)
		{
			if (x.ItemID == selectedItemID)
			{
				return !x.ToBeDeleted;
			}
			return false;
		}

		internal bool _003CpopulateItems_003Eb__0(Item tblItems)
		{
			if ((tblItems.ItemClassification == ItemClassifications.Product || tblItems.ItemClassification == ItemClassifications.Option) && !tblItems.isDeleted && tblItems.Active)
			{
				return tblItems.ItemID != selectedItemID;
			}
			return false;
		}

		internal bool _003CpopulateItems_003Eb__2(usp_ItemOptionsResult x)
		{
			if (x.ItemID == selectedItemID && x.Tab.ToUpper() == _003C_003E4__this.string_0.ToUpper() && !x.ToBeDeleted && x.GroupID != 0)
			{
				return x.GroupID == Convert.ToInt16(((KeyValuePair<string, string>)_003C_003E4__this.ddlOptionGroups.SelectedItem).Key);
			}
			return false;
		}

		internal bool _003CpopulateItems_003Eb__3(usp_ItemOptionsResult x)
		{
			if (x.Preselect && x.ItemID == selectedItemID && x.Tab.ToUpper() == _003C_003E4__this.string_0.ToUpper() && !x.ToBeDeleted && x.GroupID != 0)
			{
				return x.GroupID == Convert.ToInt16(((KeyValuePair<string, string>)_003C_003E4__this.ddlOptionGroups.SelectedItem).Key);
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_1
	{
		public List<int> existingOptionItemIDs;

		public _003C_003Ec__DisplayClass15_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_2
	{
		public List<int> associatedItemIDs;

		public _003C_003Ec__DisplayClass15_2()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CpopulateItems_003Eb__8(Item x)
		{
			return !associatedItemIDs.Contains(x.ItemID);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public int selectedItemID;

		public frmAddEditOptions _003C_003E4__this;

		public _003C_003Ec__DisplayClass21_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass36_0
	{
		public int selectedItemID;

		public frmAddEditOptions _003C_003E4__this;

		public _003C_003Ec__DisplayClass36_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CbtnEditSortOrder_Click_003Eb__0(usp_ItemOptionsResult a)
		{
			if (a.ItemID == selectedItemID && a.Tab.ToUpper() == _003C_003E4__this.string_0.ToUpper())
			{
				return !a.ToBeDeleted;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass40_0
	{
		public int selectedItemID;

		public frmAddEditOptions _003C_003E4__this;

		public int selectedGroupId;

		public List<short> groupIds;

		public GForm0 frmSelect;

		public _003C_003Ec__DisplayClass40_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003Cbutton1_Click_003Eb__1(usp_ItemOptionsResult x)
		{
			if (x.ItemID == selectedItemID && x.Tab.ToUpper() == _003C_003E4__this.string_0.ToUpper() && !x.ToBeDeleted && x.GroupID != 0 && x.GroupID != selectedGroupId)
			{
				return x.GroupDependency != selectedGroupId;
			}
			return false;
		}

		internal void _003Cbutton1_Click_003Eb__10(ItemsWithOption a)
		{
			a.GroupDependency = Convert.ToInt16(frmSelect.SelectedDependentGroup);
			a.OptionDependency = string.Join(",", frmSelect.chklistValue);
		}
	}

	private bool bool_0;

	private string string_0;

	private int int_0;

	private string string_1;

	private string string_2;

	private IContainer icontainer_1;

	private Label label10;

	private FlowLayoutPanel pnlTabs;

	private Panel pnlAllControls;

	private Class19 ddlGroups;

	private Label label1;

	private Class19 ddlItems;

	private Label label9;

	private Class19 ddlGroupFilter;

	private Label label2;

	private Class17 chkIncludeAll;

	private Class19 ddlOptionGroups;

	private Label label3;

	private Label label4;

	private Class17 chkAllowAdditionalAll;

	private RadTextBoxControl txtPrice;

	private Label lblOptionName;

	private Label label5;

	private Label label6;

	private FlowLayoutPanel TabsRyLoFp;

	internal Button btnSave;

	internal Button btnAddTag;

	internal Button btnEditTag;

	private Label label7;

	private Class19 ddlOptionGroup;

	private RadTextBoxControl txtOptionQty;

	private Label label8;

	private Class17 chkExistingOptionsOnly;

	private Label label11;

	private VerticalScrollControl verticalScrollControl2;

	private VerticalScrollControl fjylSbkHv9;

	internal Button btnMoveCopy;

	private RadTextBoxControl txtMaxGroupOptions;

	private Label label24;

	private RadTextBoxControl txtMinGroupOptions;

	private Label label12;

	private Label label13;

	internal Button btnEditSortOrder;

	private Class17 chkPreselectAll;

	private Label label14;

	internal Button btnGroupOrderTypes;

	internal Button btnSetGroupDependency;

	private Label label15;

	private Label label16;

	private RadToggleSwitch chkExcludeFreeOpt;

	internal Button btnEditTabSortOrder;

	private RadTextBoxControl txtMaxFreeGroupOpt;

	private Label label17;

	private Label lblDisableMaxGroupOpt;

	public frmAddEditOptions()
	{
		Class26.Ggkj0JxzN9YmC();
		bool_0 = true;
		string_0 = string.Empty;
		string_1 = string.Empty;
		string_2 = string.Join(",", OrderTypes.DineIn, OrderTypes.Delivery, OrderTypes.ToGo, OrderTypes.PickUp, OrderTypes.DeliveryOnline, OrderTypes.PickUpOnline);
		base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		fjylSbkHv9.ConnectedPanel = TabsRyLoFp;
	}

	private void frmAddEditOptions_Load(object sender, EventArgs e)
	{
		Dictionary<string, string> groups = AdminMethods.getGroups(ItemClassifications.Product, withShowItems: false, onlyActive: true);
		groups.Remove(0.ToString());
		groups.Add(0.ToString(), "** " + Resources.Show_All_Items + " **");
		ddlGroups.DisplayMember = "Value";
		ddlGroups.ValueMember = "Key";
		ddlGroups.DataSource = new BindingSource(groups, null);
		ddlGroups.SelectedIndex = 0;
		groups.Remove(0.ToString());
		groups.Add(0.ToString(), "** " + Resources.Unassociated_Items + " **");
		ddlGroupFilter.DataSource = new BindingSource(groups, null);
		ddlGroupFilter.SelectedIndex = 0;
		Dictionary<string, string> groups2 = AdminMethods.getGroups(ItemClassifications.Option, withShowItems: false, onlyActive: true);
		groups2.Remove(0.ToString());
		groups2.Add(0.ToString(), "** " + Resources.No_Option_Groups + " **");
		ddlOptionGroups.DisplayMember = "Value";
		ddlOptionGroups.ValueMember = "Key";
		ddlOptionGroups.DataSource = new BindingSource(groups2, null);
		groups2.Remove(0.ToString());
		groups2.Add(0.ToString(), "** " + Resources.No_Option_Group + " **");
		ddlOptionGroup.DisplayMember = "Value";
		ddlOptionGroup.ValueMember = "Key";
		ddlOptionGroup.DataSource = new BindingSource(groups2, null);
		method_3();
	}

	private void method_3()
	{
		pnlTabs.Controls.Clear();
		List<Reason> list = (from x in new GClass6().Reasons
			where x.ReasonType == ReasonTypes.option_tab && x.Value != null && x.Value != string.Empty
			select x into a
			orderby a.isDefault descending, (a.SortOrder == 0) ? short.MaxValue : a.SortOrder, a.Value
			select a).ToList();
		foreach (Reason item in list)
		{
			Button button = method_4(item.Value);
			if (string_0 == item.Value)
			{
				button.BackColor = Color.SandyBrown;
			}
			else if (item.isDefault && string_0 == string.Empty)
			{
				button.BackColor = Color.SandyBrown;
				string_0 = item.Value;
			}
			else
			{
				button.BackColor = Color.Gray;
			}
			pnlTabs.Controls.Add(button);
		}
		if (string_0 == string.Empty)
		{
			string_0 = list.FirstOrDefault().Value;
		}
		if (!string.IsNullOrEmpty(string_0))
		{
			string_0 = string_0.ToUpper();
		}
	}

	private Button method_4(string string_3)
	{
		Button button = new Button();
		button.BackColor = Color.LightGray;
		button.FlatAppearance.BorderColor = Color.White;
		button.FlatAppearance.BorderSize = 0;
		button.FlatStyle = FlatStyle.Flat;
		button.ForeColor = Color.White;
		button.Name = "btn" + string_3;
		button.Text = string_3.ToUpper();
		button.Font = new Font(button.Font.FontFamily, 8f);
		button.UseVisualStyleBackColor = false;
		button.Size = new Size(113, 47);
		button.Margin = new Padding(1, 1, 0, 0);
		button.Padding = new Padding(0, 0, 0, 0);
		button.Tag = string_3;
		button.Click += method_10;
		return button;
	}

	private async void method_5(Dictionary<string, string> dictionary_0, bool bool_1 = false)
	{
		_003C_003Ec__DisplayClass9_0 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_0();
		_003C_003Ec__DisplayClass9_._003C_003E4__this = this;
		_003C_003Ec__DisplayClass9_.items = dictionary_0;
		_003C_003Ec__DisplayClass9_.search = bool_1;
		bool_0 = true;
		_003C_003Ec__DisplayClass9_.selectItem = "** " + Resources.Select_An_Item + "**";
		Dictionary<string, string> dataSource = await Task.Run(() => _003C_003Ec__DisplayClass9_._003C_003E4__this.method_6(_003C_003Ec__DisplayClass9_.items, _003C_003Ec__DisplayClass9_.search, _003C_003Ec__DisplayClass9_.selectItem));
		ddlItems.DisplayMember = "Value";
		ddlItems.ValueMember = "Key";
		ddlItems.DataSource = new BindingSource(dataSource, null);
		bool_0 = false;
	}

	private Dictionary<string, string> method_6(Dictionary<string, string> dictionary_0, bool bool_1, string string_3)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("0", string_3);
		foreach (KeyValuePair<string, string> item in dictionary_0)
		{
			dictionary.Add(item.Key, item.Value);
		}
		return dictionary;
	}

	private void method_7()
	{
		KeyValuePair<string, string> keyValuePair = (KeyValuePair<string, string>)ddlGroups.SelectedItem;
		List<Item> list = ((!(keyValuePair.Key == "0")) ? (from a in AdminMethods.getItemsFromGroup(Convert.ToInt16(keyValuePair.Key))
			where a.Active
			select a).ToList() : AdminMethods.getAllItems(ItemClassifications.Product, onlyActive: true).ToList());
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (Item item in list)
		{
			dictionary.Add(item.ItemID.ToString(), item.ItemName);
		}
		method_5(dictionary);
	}

	private void ddlGroups_SelectedIndexChanged(object sender, EventArgs e)
	{
		KeyValuePair<string, string> keyValuePair = (KeyValuePair<string, string>)ddlGroups.SelectedItem;
		if (!(keyValuePair.Key == "0") && !(keyValuePair.Key == "-1"))
		{
			method_7();
		}
		else
		{
			method_5(AdminMethods.getAllItemsDictionary(ItemClassifications.Product));
		}
	}

	private async void method_8(Dictionary<string, string> dictionary_0, bool bool_1 = false)
	{
		_003C_003Ec__DisplayClass13_0 _003C_003Ec__DisplayClass13_ = new _003C_003Ec__DisplayClass13_0();
		_003C_003Ec__DisplayClass13_._003C_003E4__this = this;
		_003C_003Ec__DisplayClass13_.items = dictionary_0;
		_003C_003Ec__DisplayClass13_.search = bool_1;
		_003C_003Ec__DisplayClass13_.selectItem = "** Select An Item **";
		Dictionary<string, string> dataSource = await Task.Run(() => _003C_003Ec__DisplayClass13_._003C_003E4__this.method_6(_003C_003Ec__DisplayClass13_.items, _003C_003Ec__DisplayClass13_.search, _003C_003Ec__DisplayClass13_.selectItem));
		ddlItems.DisplayMember = "Value";
		ddlItems.ValueMember = "Key";
		ddlItems.DataSource = new BindingSource(dataSource, null);
	}

	private void ddlGroupFilter_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			method_9(Convert.ToInt32(((KeyValuePair<string, string>)ddlGroupFilter.SelectedItem).Key));
		}
	}

	private void method_9(int int_1 = -1, bool bool_1 = false)
	{
		_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass15_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		if (bool_0)
		{
			return;
		}
		for (int num = TabsRyLoFp.Controls.Count - 1; num >= 0; num--)
		{
			TabsRyLoFp.Controls[num].Dispose();
		}
		GC.Collect();
		CS_0024_003C_003E8__locals0.selectedItemID = Convert.ToInt32(((KeyValuePair<string, string>)ddlItems.SelectedItem).Key);
		if (CS_0024_003C_003E8__locals0.selectedItemID == 0)
		{
			if (!bool_1)
			{
				new NotificationLabel(this, "Please select the main item.", NotificationTypes.Notification).Show();
			}
			return;
		}
		GClass6 gClass = new GClass6();
		List<Item> source2;
		if (chkExistingOptionsOnly.Checked)
		{
			_003C_003Ec__DisplayClass15_1 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass15_1();
			IEnumerable<usp_ItemOptionsResult> source = from x in gClass.usp_ItemOptions()
				where x.ItemID == CS_0024_003C_003E8__locals0.selectedItemID && !x.ToBeDeleted
				select x;
			CS_0024_003C_003E8__locals2.existingOptionItemIDs = source.Select((usp_ItemOptionsResult y) => y.Option_ItemID).ToList();
			source2 = gClass.Items.Where((Item x) => CS_0024_003C_003E8__locals2.existingOptionItemIDs.Contains(x.ItemID)).ToList();
		}
		else if (int_1 == 0)
		{
			_003C_003Ec__DisplayClass15_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass15_2();
			CS_0024_003C_003E8__locals1.associatedItemIDs = gClass.ItemsInGroups.Select((ItemsInGroup y) => y.ItemID.Value).Distinct().ToList();
			source2 = (from x in AdminMethods.getAllItems(ItemClassifications.Product, onlyActive: true)
				where !CS_0024_003C_003E8__locals1.associatedItemIDs.Contains(x.ItemID)
				select x).ToList();
		}
		else
		{
			source2 = AdminMethods.getItemsFromGroup(Convert.ToInt16(int_1)).ToList();
		}
		source2 = (from tblItems in source2
			where (tblItems.ItemClassification == ItemClassifications.Product || tblItems.ItemClassification == ItemClassifications.Option) && !tblItems.isDeleted && tblItems.Active && tblItems.ItemID != CS_0024_003C_003E8__locals0.selectedItemID
			orderby tblItems.ItemName
			select tblItems).ToList();
		short optionGroupID = Convert.ToInt16(((KeyValuePair<string, string>)ddlOptionGroups.SelectedItem).Key);
		if (source2.Count() > 99)
		{
			new NotificationLabel(this, "Too many records, please change your filter selection.", NotificationTypes.Notification).Show();
			return;
		}
		foreach (Item item in source2)
		{
			ItemOptionControl itemOptionControl = new ItemOptionControl(item.ItemID, CS_0024_003C_003E8__locals0.selectedItemID, string_0, optionGroupID, gClass);
			itemOptionControl.chkPreselectOption_CheckedChanged = (EventHandler)Delegate.Combine(itemOptionControl.chkPreselectOption_CheckedChanged, new EventHandler(method_13));
			TabsRyLoFp.Controls.Add(itemOptionControl);
		}
		usp_ItemOptionsResult usp_ItemOptionsResult = (from x in gClass.usp_ItemOptions()
			where x.ItemID == CS_0024_003C_003E8__locals0.selectedItemID && x.Tab.ToUpper() == CS_0024_003C_003E8__locals0._003C_003E4__this.string_0.ToUpper() && !x.ToBeDeleted && x.GroupID != 0 && x.GroupID == Convert.ToInt16(((KeyValuePair<string, string>)CS_0024_003C_003E8__locals0._003C_003E4__this.ddlOptionGroups.SelectedItem).Key)
			select x).FirstOrDefault();
		int_0 = (from x in gClass.usp_ItemOptions()
			where x.Preselect && x.ItemID == CS_0024_003C_003E8__locals0.selectedItemID && x.Tab.ToUpper() == CS_0024_003C_003E8__locals0._003C_003E4__this.string_0.ToUpper() && !x.ToBeDeleted && x.GroupID != 0 && x.GroupID == Convert.ToInt16(((KeyValuePair<string, string>)CS_0024_003C_003E8__locals0._003C_003E4__this.ddlOptionGroups.SelectedItem).Key)
			select x).Count();
		if (usp_ItemOptionsResult != null)
		{
			txtMaxGroupOptions.Text = usp_ItemOptionsResult.MaxGroupOptions.ToString();
			txtMinGroupOptions.Text = usp_ItemOptionsResult.MinGroupOptions.ToString();
			string_1 = usp_ItemOptionsResult.GroupOrderTypes;
			chkExcludeFreeOpt.Value = usp_ItemOptionsResult.ExcludeFromFreeOption;
			txtMaxFreeGroupOpt.Text = usp_ItemOptionsResult.MaxFreeOptionPerGroup.ToString();
		}
		else
		{
			txtMaxGroupOptions.Text = "0";
			txtMinGroupOptions.Text = "0";
			string_1 = string_2;
			chkExcludeFreeOpt.Value = false;
			txtMaxFreeGroupOpt.Text = "-1";
		}
		method_12(Convert.ToDecimal(txtMaxGroupOptions.Text));
		GC.Collect();
	}

	private void chkIncludeAll_CheckedChanged(object sender, EventArgs e)
	{
		Class17 @class = (Class17)sender;
		foreach (ItemOptionControl control in TabsRyLoFp.Controls)
		{
			control.Included = @class.Checked;
		}
	}

	private void chkAllowAdditionalAll_CheckedChanged(object sender, EventArgs e)
	{
		Class17 @class = (Class17)sender;
		foreach (ItemOptionControl control in TabsRyLoFp.Controls)
		{
			control.AllowAdditional = @class.Checked;
		}
	}

	private void txtPrice_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Option_Price, 2, 8, txtPrice.Text, "", allowNegative: false, useNotifLabel: true);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		txtPrice.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString("0.00");
		foreach (ItemOptionControl control in TabsRyLoFp.Controls)
		{
			control.Price = MemoryLoadedObjects.Numpad.numberEntered;
		}
	}

	private void txtOptionQty_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Option Qty, Enter 0 For Unlimited", 1, 3, txtOptionQty.Text, "", allowNegative: false, useNotifLabel: true);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		txtOptionQty.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString("0.0");
		foreach (ItemOptionControl control in TabsRyLoFp.Controls)
		{
			control.Qty = MemoryLoadedObjects.Numpad.numberEntered;
		}
	}

	private void ddlItems_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			method_9(Convert.ToInt32(((KeyValuePair<string, string>)ddlGroupFilter.SelectedItem).Key));
		}
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass21_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		bool flag = false;
		short num = Convert.ToInt16(string.IsNullOrEmpty(txtMaxGroupOptions.Text) ? "0" : txtMaxGroupOptions.Text);
		short num2 = Convert.ToInt16(string.IsNullOrEmpty(txtMinGroupOptions.Text) ? "0" : txtMinGroupOptions.Text);
		short num3 = Convert.ToInt16(string.IsNullOrEmpty(txtMaxFreeGroupOpt.Text) ? "-1" : txtMaxFreeGroupOpt.Text);
		if (num3 < -1)
		{
			new NotificationLabel(this, "Minimum group options cannot be less than -1. -1 is for any free group option. 0 for no free group option.", NotificationTypes.Warning).Show();
			return;
		}
		if (num2 > num)
		{
			new NotificationLabel(this, "Minimum group options cannot be greater than maximum group options.", NotificationTypes.Warning).Show();
			return;
		}
		if (num2 < 0)
		{
			new NotificationLabel(this, "Minimum group options cannot be negative value.", NotificationTypes.Warning).Show();
			return;
		}
		if (string.IsNullOrEmpty(string_0))
		{
			new NotificationLabel(this, "Please select a tab.", NotificationTypes.Warning).Show();
			return;
		}
		int num4 = 0;
		int num5 = 0;
		bool flag2 = false;
		foreach (ItemOptionControl control in TabsRyLoFp.Controls)
		{
			if (control.PreSelect)
			{
				num5 += (int)control.Qty;
			}
			num4 += (int)control.Qty;
			if (!flag2)
			{
				flag2 = control.AllowAdditional;
			}
		}
		if (num5 > num && num > 0)
		{
			new NotificationLabel(this, "Max group options cannot be less than pre-selected option's quantity.", NotificationTypes.Notification).Show();
			return;
		}
		if (num2 > 0 && num4 < num2 && !flag2)
		{
			new NotificationLabel(this, "Min Group Option cannot be greater than the total number of option.", NotificationTypes.Notification).Show();
			return;
		}
		int num6 = 0;
		foreach (ItemOptionControl control2 in TabsRyLoFp.Controls)
		{
			if (control2.ItemOptionID != 0 && !control2.Included)
			{
				control2.Delete(string_0);
				flag = true;
			}
			else if (control2.Included)
			{
				num6++;
				control2.GroupOrderTypes = string_1;
				control2.Save(string_0);
				flag = true;
			}
		}
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals0.selectedItemID = Convert.ToInt32(((KeyValuePair<string, string>)ddlItems.SelectedItem).Key);
		List<ItemsWithOption> list = gClass.ItemsWithOptions.Where((ItemsWithOption x) => x.ItemID == (int?)CS_0024_003C_003E8__locals0.selectedItemID && x.Tab.ToUpper() == string_0.ToUpper() && x.ToBeDeleted == false && x.GroupID != 0 && x.GroupID == Convert.ToInt16(((KeyValuePair<string, string>)ddlOptionGroups.SelectedItem).Key)).ToList();
		if (list.Count > 0)
		{
			foreach (ItemsWithOption item in list)
			{
				item.MaxGroupOptions = num;
				item.MinGroupOptions = num2;
				item.GroupOrderTypes = string_1;
				item.ExcludeFromFreeOption = chkExcludeFreeOpt.Value;
				item.MaxFreeOptionPerGroup = num3;
			}
			Helper.SubmitChangesWithCatch(gClass);
		}
		if (flag)
		{
			method_11();
			new NotificationLabel(this, "Item Options Saved.", NotificationTypes.Success).Show();
		}
		else
		{
			new NotificationLabel(this, "Nothing To Save.", NotificationTypes.Notification).Show();
		}
		try
		{
			ItemAuditLog itemAuditLog = new ItemAuditLog();
			itemAuditLog.ItemID = CS_0024_003C_003E8__locals0.selectedItemID;
			itemAuditLog.Changelog = "Item Options Updated. Options Count: " + num6 + ",  Max Group Opt: " + num + ", Min Group Opt: " + num2 + ", Max Free Group Opt: " + num3;
			itemAuditLog.DateCreated = DateTime.Now;
			itemAuditLog.Synced = false;
			ItemAuditLog entity = itemAuditLog;
			gClass.ItemAuditLogs.InsertOnSubmit(entity);
			Helper.SubmitChangesWithCatch(gClass);
		}
		catch
		{
		}
		MemoryLoadedObjects.RefreshItemOptions = true;
		MemoryLoadedObjects.ItemsAndGroupsStationsRefresh();
	}

	private void method_10(object sender, EventArgs e)
	{
		string_0 = ((Button)sender).Tag.ToString();
		string text = ((Button)sender).Text;
		foreach (Button control in pnlTabs.Controls)
		{
			if (control.Text == text)
			{
				control.BackColor = Color.SandyBrown;
			}
			else
			{
				control.BackColor = Color.Gray;
			}
		}
		method_9(Convert.ToInt32(((KeyValuePair<string, string>)ddlGroupFilter.SelectedItem).Key), bool_1: true);
	}

	private void btnAddTag_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Please_enter_a_tab, 0, 50);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		if (MemoryLoadedObjects.Keyboard.textEntered.Trim().Length == 0)
		{
			new NotificationLabel(this, Resources.Unable_to_add_blank_tab, NotificationTypes.Notification).Show();
			return;
		}
		MemoryLoadedObjects.Keyboard.textEntered = MemoryLoadedObjects.Keyboard.textEntered.Trim().ToLower();
		GClass6 gClass = new GClass6();
		Reason reason = gClass.Reasons.Where((Reason x) => x.ReasonType == ReasonTypes.option_tab && x.Value == MemoryLoadedObjects.Keyboard.textEntered.Trim()).FirstOrDefault();
		if (reason == null)
		{
			reason = new Reason();
			reason.Value = MemoryLoadedObjects.Keyboard.textEntered;
			reason.ReasonType = ReasonTypes.option_tab;
			reason.isDefault = false;
			if (string.IsNullOrEmpty(reason.Value))
			{
				new NotificationLabel(this, Resources.Unable_to_add_blank_tab, NotificationTypes.Warning).Show();
				return;
			}
			if (new frmMessageBox(Resources.Do_you_want_to_make_this_tab_the_default_selection, Resources.Make_Default, CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
			{
				reason.isDefault = true;
			}
			gClass.Reasons.InsertOnSubmit(reason);
			Helper.SubmitChangesWithCatch(gClass);
			method_3();
		}
		else
		{
			new NotificationLabel(this, Resources.Tab_is_already_in_use, NotificationTypes.Notification).Show();
		}
	}

	private void pnlAllControls_Paint(object sender, PaintEventArgs e)
	{
	}

	private void ddlOptionGroup_SelectedIndexChanged(object sender, EventArgs e)
	{
		foreach (ItemOptionControl control in TabsRyLoFp.Controls)
		{
			control.GroupID = Convert.ToInt16(((KeyValuePair<string, string>)ddlOptionGroup.SelectedItem).Key);
		}
	}

	private void ddlOptionGroups_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			method_9(Convert.ToInt32(((KeyValuePair<string, string>)ddlGroupFilter.SelectedItem).Key));
		}
	}

	private void btnEditTag_Click(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		if (string.IsNullOrEmpty(string_0))
		{
			new NotificationLabel(this, Resources.Please_select_a_tab_to_edit, NotificationTypes.Notification).Show();
			return;
		}
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Please_enter_a_new_tab_or_leave_blank_to_delete, 0, 50, string_0);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		MemoryLoadedObjects.Keyboard.textEntered = MemoryLoadedObjects.Keyboard.textEntered.Trim().ToLower();
		Reason reason = gClass.Reasons.Where((Reason x) => x.ReasonType == ReasonTypes.option_tab && x.Value.ToUpper() == string_0.ToUpper()).FirstOrDefault();
		if (string_0 == MemoryLoadedObjects.Keyboard.textEntered.Trim())
		{
			if (!reason.isDefault && new frmMessageBox(Resources.Do_you_want_to_make_this_tab_the_default_selection, Resources.Make_Default, CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
			{
				reason.isDefault = true;
				Helper.SubmitChangesWithCatch(gClass);
			}
			return;
		}
		if (string.IsNullOrEmpty(MemoryLoadedObjects.Keyboard.textEntered.Trim()))
		{
			if (gClass.Reasons.Where((Reason x) => x.ReasonType == ReasonTypes.option_tab && x.Value.ToUpper() != string_0.ToUpper()).Count() > 0)
			{
				if (new frmMessageBox(Resources.Are_you_sure_you_want_to_delete_this_tab, Resources.Are_you_sure, CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
				{
					foreach (ItemsWithOption item in gClass.ItemsWithOptions.Where((ItemsWithOption x) => x.Tab.ToUpper() == string_0.ToUpper()).ToList())
					{
						item.Synced = false;
						item.ToBeDeleted = true;
					}
					gClass.Reasons.DeleteOnSubmit(reason);
					Helper.SubmitChangesWithCatch(gClass);
					new NotificationLabel(this, Resources.Tab_has_been_deleted, NotificationTypes.Success).Show();
					gClass.Reasons.Where((Reason a) => a.ReasonType == ReasonTypes.option_tab).FirstOrDefault().Synced = false;
					Helper.SubmitChangesWithCatch(gClass);
					string_0 = string.Empty;
				}
			}
			else
			{
				new NotificationLabel(this, Resources.There_must_be_at_least_one_tab, NotificationTypes.Warning).Show();
			}
		}
		else
		{
			if (gClass.Reasons.Where((Reason x) => x.ReasonType == ReasonTypes.option_tab && x.Value == MemoryLoadedObjects.Keyboard.textEntered.Trim()).FirstOrDefault() != null)
			{
				new NotificationLabel(this, Resources.Tab_is_already_in_use, NotificationTypes.Notification).Show();
				return;
			}
			foreach (ItemsWithOption item2 in gClass.ItemsWithOptions.Where((ItemsWithOption x) => x.Tab.ToUpper() == string_0.ToUpper()).ToList())
			{
				item2.Tab = MemoryLoadedObjects.Keyboard.textEntered.Trim();
				item2.Synced = false;
			}
			reason.Value = MemoryLoadedObjects.Keyboard.textEntered.Trim();
			if (!reason.isDefault && new frmMessageBox(Resources.Do_you_want_to_make_this_tab_the_default_selection, Resources.Make_Default, CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
			{
				reason.isDefault = true;
			}
			Helper.SubmitChangesWithCatch(gClass);
			string_0 = MemoryLoadedObjects.Keyboard.textEntered.Trim();
			method_9(Convert.ToInt32(((KeyValuePair<string, string>)ddlGroupFilter.SelectedItem).Key));
			new NotificationLabel(this, Resources.Tab_has_been_updated, NotificationTypes.Success).Show();
		}
		method_3();
	}

	private void btnEditTag_EnabledChanged(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (!button.Enabled)
		{
			button.Tag = button.BackColor;
			button.BackColor = Color.Gray;
		}
		else if (button.Tag != null)
		{
			button.BackColor = (Color)button.Tag;
		}
	}

	private void chkExistingOptionsOnly_CheckedChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			Class19 @class = ddlGroupFilter;
			bool enabled = (ddlOptionGroups.Enabled = !chkExistingOptionsOnly.Checked);
			@class.Enabled = enabled;
			method_9(Convert.ToInt32(((KeyValuePair<string, string>)ddlGroupFilter.SelectedItem).Key));
		}
	}

	private void method_11()
	{
		RadTextBoxControl radTextBoxControl = txtOptionQty;
		string text = (txtPrice.Text = string.Empty);
		radTextBoxControl.Text = text;
	}

	private void btnMoveCopy_Click(object sender, EventArgs e)
	{
		new frmCopyMoveOptions().ShowDialog(this);
	}

	private void txtMaxGroupOptions_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Max Group Options", 0, 3, txtMaxGroupOptions.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtMaxGroupOptions.Text = MemoryLoadedObjects.Numpad.valueEntered;
			method_12(MemoryLoadedObjects.Numpad.numberEntered);
		}
	}

	private void txtMinGroupOptions_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Min Group Options", 0, 3, txtMinGroupOptions.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtMinGroupOptions.Text = MemoryLoadedObjects.Numpad.valueEntered;
		}
	}

	private void txtMaxFreeGroupOpt_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Max FREE Group Options", 0, 3, txtMaxFreeGroupOpt.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtMaxFreeGroupOpt.Text = MemoryLoadedObjects.Numpad.valueEntered;
		}
	}

	private void method_12(decimal decimal_0)
	{
		if (!(decimal_0 > 1m) && !(decimal_0 == 0m))
		{
			chkAllowAdditionalAll.Enabled = false;
			{
				foreach (ItemOptionControl control in TabsRyLoFp.Controls)
				{
					control.EnableAllowAdditional(enable: false);
				}
				return;
			}
		}
		chkAllowAdditionalAll.Enabled = true;
		foreach (ItemOptionControl control2 in TabsRyLoFp.Controls)
		{
			control2.EnableAllowAdditional(enable: true);
		}
	}

	private void btnEditSortOrder_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass36_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass36_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.selectedItemID = Convert.ToInt32(((KeyValuePair<string, string>)ddlItems.SelectedItem).Key);
		if (CS_0024_003C_003E8__locals0.selectedItemID == 0)
		{
			new NotificationLabel(this, "Please select the main item.", NotificationTypes.Notification).Show();
		}
		else if ((from a in new GClass6().usp_ItemOptions()
			where a.ItemID == CS_0024_003C_003E8__locals0.selectedItemID && a.Tab.ToUpper() == CS_0024_003C_003E8__locals0._003C_003E4__this.string_0.ToUpper() && !a.ToBeDeleted
			select a.GroupID.ToString()).ToList().Count == 0)
		{
			new NotificationLabel(this, "This item has no options.", NotificationTypes.Notification).Show();
		}
		else
		{
			new frmEditOptionSortOrder(CS_0024_003C_003E8__locals0.selectedItemID, ((KeyValuePair<string, string>)ddlItems.SelectedItem).Value, string_0).ShowDialog(this);
		}
	}

	private void chkPreselectAll_CheckedChanged(object sender, EventArgs e)
	{
		Class17 @class = (Class17)sender;
		foreach (ItemOptionControl control in TabsRyLoFp.Controls)
		{
			control.EnablePreselect(@class.Checked);
		}
	}

	private void method_13(object sender, EventArgs e)
	{
		Class17 @class = (Class17)sender;
		if (@class.Checked)
		{
			if (int_0 == Convert.ToInt32(txtMaxGroupOptions.Text) && Convert.ToInt32(txtMaxGroupOptions.Text) > 0)
			{
				@class.Checked = !@class.Checked;
				new NotificationLabel(this, "Max group options cannot be less than pre-selected options.", NotificationTypes.Notification).Show();
			}
			int_0++;
		}
		else if (int_0 > 0)
		{
			int_0--;
		}
	}

	private void wyBsKuJpcR(object sender, EventArgs e)
	{
		frmChecklistSelector frmChecklistSelector = new frmChecklistSelector("SELECT APPLICABLE ORDER TYPES", OrderTypesDictionary.OrderTypes, string_1);
		if (frmChecklistSelector.ShowDialog() == DialogResult.OK)
		{
			string_1 = frmChecklistSelector.returnValue;
		}
	}

	private void RxpssewFrn(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass40_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass40_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.selectedItemID = Convert.ToInt32(((KeyValuePair<string, string>)ddlItems.SelectedItem).Key);
		CS_0024_003C_003E8__locals0.selectedGroupId = Convert.ToInt16(((KeyValuePair<string, string>)ddlOptionGroups.SelectedItem).Key);
		if (CS_0024_003C_003E8__locals0.selectedItemID == 0)
		{
			new NotificationLabel(this, "Please select the main item.", NotificationTypes.Notification).Show();
			return;
		}
		GClass6 gClass = new GClass6();
		List<ItemsWithOption> list = gClass.ItemsWithOptions.Where((ItemsWithOption x) => x.ItemID == (int?)CS_0024_003C_003E8__locals0.selectedItemID && x.Tab.ToUpper() == string_0.ToUpper() && x.ToBeDeleted == false && x.GroupID == CS_0024_003C_003E8__locals0.selectedGroupId).ToList();
		List<usp_ItemOptionsResult> source = (from x in gClass.usp_ItemOptions()
			where x.ItemID == CS_0024_003C_003E8__locals0.selectedItemID && x.Tab.ToUpper() == CS_0024_003C_003E8__locals0._003C_003E4__this.string_0.ToUpper() && !x.ToBeDeleted && x.GroupID != 0 && x.GroupID != CS_0024_003C_003E8__locals0.selectedGroupId && x.GroupDependency != CS_0024_003C_003E8__locals0.selectedGroupId
			select x).ToList();
		CS_0024_003C_003E8__locals0.groupIds = (from a in source
			group a by a.GroupID into a
			select a.Key).ToList();
		Dictionary<string, string> dictionary = gClass.Groups.Where((Group a) => CS_0024_003C_003E8__locals0.groupIds.Contains(a.GroupID)).ToDictionary((Group a) => a.GroupID.ToString(), (Group b) => b.GroupName);
		dictionary.Add("0", "No Group Dependent");
		dictionary = dictionary.OrderBy((KeyValuePair<string, string> a) => a.Key).ToDictionary((KeyValuePair<string, string> a) => a.Key, (KeyValuePair<string, string> b) => b.Value);
		if (list != null && list.Count() != 0)
		{
			string[] existingOptList = list.FirstOrDefault().OptionDependency.Split(',');
			CS_0024_003C_003E8__locals0.frmSelect = new GForm0("Select Option Group Dependency", existingOptList, dictionary, list.FirstOrDefault().GroupDependency, CS_0024_003C_003E8__locals0.selectedItemID, string_0);
			CS_0024_003C_003E8__locals0.frmSelect.DDLTitle = "Groups";
			CS_0024_003C_003E8__locals0.frmSelect.ChecklistTitle = "Options";
			if (CS_0024_003C_003E8__locals0.frmSelect.ShowDialog(this) == DialogResult.OK)
			{
				list.ToList().ForEach(delegate(ItemsWithOption a)
				{
					a.GroupDependency = Convert.ToInt16(CS_0024_003C_003E8__locals0.frmSelect.SelectedDependentGroup);
					a.OptionDependency = string.Join(",", CS_0024_003C_003E8__locals0.frmSelect.chklistValue);
				});
				Helper.SubmitChangesWithCatch(gClass);
				new NotificationLabel(this, "Group Dependency successfully saved.", NotificationTypes.Success).Show();
			}
		}
		else
		{
			new NotificationLabel(this, "There are no options to set dependencies for.  Please include some options first.", NotificationTypes.Notification).Show();
		}
	}

	private void btnEditTabSortOrder_Click(object sender, EventArgs e)
	{
		new frmEditTabSortOrder().ShowDialog(this);
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmAddEditOptions));
		verticalScrollControl2 = new VerticalScrollControl();
		pnlTabs = new FlowLayoutPanel();
		btnEditTag = new Button();
		btnAddTag = new Button();
		label10 = new Label();
		pnlAllControls = new Panel();
		txtMaxFreeGroupOpt = new RadTextBoxControl();
		label17 = new Label();
		label16 = new Label();
		chkExcludeFreeOpt = new RadToggleSwitch();
		label15 = new Label();
		btnSetGroupDependency = new Button();
		btnGroupOrderTypes = new Button();
		chkPreselectAll = new Class17();
		label14 = new Label();
		btnEditSortOrder = new Button();
		label13 = new Label();
		lblDisableMaxGroupOpt = new Label();
		label12 = new Label();
		txtMinGroupOptions = new RadTextBoxControl();
		txtMaxGroupOptions = new RadTextBoxControl();
		label24 = new Label();
		btnMoveCopy = new Button();
		fjylSbkHv9 = new VerticalScrollControl();
		chkExistingOptionsOnly = new Class17();
		label11 = new Label();
		txtOptionQty = new RadTextBoxControl();
		label8 = new Label();
		ddlOptionGroup = new Class19();
		label3 = new Label();
		btnSave = new Button();
		ddlOptionGroups = new Class19();
		label7 = new Label();
		TabsRyLoFp = new FlowLayoutPanel();
		chkAllowAdditionalAll = new Class17();
		txtPrice = new RadTextBoxControl();
		lblOptionName = new Label();
		chkIncludeAll = new Class17();
		ddlGroupFilter = new Class19();
		label2 = new Label();
		ddlGroups = new Class19();
		label1 = new Label();
		ddlItems = new Class19();
		label9 = new Label();
		label4 = new Label();
		label5 = new Label();
		label6 = new Label();
		btnEditTabSortOrder = new Button();
		pnlAllControls.SuspendLayout();
		((ISupportInitialize)txtMaxFreeGroupOpt).BeginInit();
		((ISupportInitialize)chkExcludeFreeOpt).BeginInit();
		((ISupportInitialize)txtMinGroupOptions).BeginInit();
		((ISupportInitialize)txtMaxGroupOptions).BeginInit();
		((ISupportInitialize)txtOptionQty).BeginInit();
		((ISupportInitialize)txtPrice).BeginInit();
		SuspendLayout();
		verticalScrollControl2.BackColor = Color.Transparent;
		verticalScrollControl2.ButtonDownEventOverride = null;
		verticalScrollControl2.ButtonLastEventOverride = null;
		verticalScrollControl2.ButtonStyle = "twobuttons";
		verticalScrollControl2.ConnectedPanel = pnlTabs;
		verticalScrollControl2.ConnectedRadListView = null;
		verticalScrollControl2.inputedHeight = 0;
		verticalScrollControl2.inputedWidth = 0;
		componentResourceManager.ApplyResources(verticalScrollControl2, "verticalScrollControl2");
		verticalScrollControl2.Name = "verticalScrollControl2";
		pnlTabs.AllowDrop = true;
		componentResourceManager.ApplyResources(pnlTabs, "pnlTabs");
		pnlTabs.BackColor = Color.Transparent;
		pnlTabs.Name = "pnlTabs";
		btnEditTag.BackColor = Color.FromArgb(255, 192, 128);
		btnEditTag.FlatAppearance.BorderColor = Color.White;
		btnEditTag.FlatAppearance.BorderSize = 0;
		btnEditTag.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnEditTag, "btnEditTag");
		btnEditTag.ForeColor = Color.White;
		btnEditTag.Name = "btnEditTag";
		btnEditTag.UseVisualStyleBackColor = false;
		btnEditTag.EnabledChanged += btnEditTag_EnabledChanged;
		btnEditTag.Click += btnEditTag_Click;
		btnAddTag.BackColor = Color.FromArgb(1, 110, 211);
		btnAddTag.FlatAppearance.BorderColor = Color.White;
		btnAddTag.FlatAppearance.BorderSize = 0;
		btnAddTag.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnAddTag, "btnAddTag");
		btnAddTag.ForeColor = Color.White;
		btnAddTag.Name = "btnAddTag";
		btnAddTag.UseVisualStyleBackColor = false;
		btnAddTag.Click += btnAddTag_Click;
		componentResourceManager.ApplyResources(label10, "label10");
		label10.BackColor = Color.FromArgb(147, 101, 184);
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		pnlAllControls.Controls.Add(txtMaxFreeGroupOpt);
		pnlAllControls.Controls.Add(label17);
		pnlAllControls.Controls.Add(label16);
		pnlAllControls.Controls.Add(chkExcludeFreeOpt);
		pnlAllControls.Controls.Add(label15);
		pnlAllControls.Controls.Add(btnSetGroupDependency);
		pnlAllControls.Controls.Add(btnGroupOrderTypes);
		pnlAllControls.Controls.Add(chkPreselectAll);
		pnlAllControls.Controls.Add(label14);
		pnlAllControls.Controls.Add(btnEditSortOrder);
		pnlAllControls.Controls.Add(label13);
		pnlAllControls.Controls.Add(lblDisableMaxGroupOpt);
		pnlAllControls.Controls.Add(label12);
		pnlAllControls.Controls.Add(txtMinGroupOptions);
		pnlAllControls.Controls.Add(txtMaxGroupOptions);
		pnlAllControls.Controls.Add(label24);
		pnlAllControls.Controls.Add(btnMoveCopy);
		pnlAllControls.Controls.Add(fjylSbkHv9);
		pnlAllControls.Controls.Add(chkExistingOptionsOnly);
		pnlAllControls.Controls.Add(label11);
		pnlAllControls.Controls.Add(txtOptionQty);
		pnlAllControls.Controls.Add(label8);
		pnlAllControls.Controls.Add(ddlOptionGroup);
		pnlAllControls.Controls.Add(label3);
		pnlAllControls.Controls.Add(btnSave);
		pnlAllControls.Controls.Add(ddlOptionGroups);
		pnlAllControls.Controls.Add(label7);
		pnlAllControls.Controls.Add(TabsRyLoFp);
		pnlAllControls.Controls.Add(chkAllowAdditionalAll);
		pnlAllControls.Controls.Add(txtPrice);
		pnlAllControls.Controls.Add(lblOptionName);
		pnlAllControls.Controls.Add(chkIncludeAll);
		pnlAllControls.Controls.Add(ddlGroupFilter);
		pnlAllControls.Controls.Add(label2);
		pnlAllControls.Controls.Add(ddlGroups);
		pnlAllControls.Controls.Add(label1);
		pnlAllControls.Controls.Add(ddlItems);
		pnlAllControls.Controls.Add(label9);
		pnlAllControls.Controls.Add(label4);
		pnlAllControls.Controls.Add(label5);
		pnlAllControls.Controls.Add(label6);
		componentResourceManager.ApplyResources(pnlAllControls, "pnlAllControls");
		pnlAllControls.Name = "pnlAllControls";
		pnlAllControls.Paint += pnlAllControls_Paint;
		componentResourceManager.ApplyResources(txtMaxFreeGroupOpt, "txtMaxFreeGroupOpt");
		txtMaxFreeGroupOpt.Name = "txtMaxFreeGroupOpt";
		txtMaxFreeGroupOpt.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtMaxFreeGroupOpt.Tag = "product";
		txtMaxFreeGroupOpt.Click += txtMaxFreeGroupOpt_Click;
		((RadTextBoxControlElement)txtMaxFreeGroupOpt.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtMaxFreeGroupOpt.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		label17.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label17, "label17");
		label17.ForeColor = Color.White;
		label17.Name = "label17";
		label17.Tag = "product";
		label16.BackColor = Color.FromArgb(132, 146, 146);
		label16.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label16, "label16");
		label16.ForeColor = Color.White;
		label16.Name = "label16";
		componentResourceManager.ApplyResources(chkExcludeFreeOpt, "chkExcludeFreeOpt");
		chkExcludeFreeOpt.Name = "chkExcludeFreeOpt";
		chkExcludeFreeOpt.OffText = "NO";
		chkExcludeFreeOpt.OnText = "YES";
		chkExcludeFreeOpt.Tag = "product";
		chkExcludeFreeOpt.ToggleStateMode = ToggleStateMode.Click;
		chkExcludeFreeOpt.Value = false;
		((RadToggleSwitchElement)chkExcludeFreeOpt.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkExcludeFreeOpt.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkExcludeFreeOpt.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkExcludeFreeOpt.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkExcludeFreeOpt.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkExcludeFreeOpt.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkExcludeFreeOpt.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text");
		((ToggleSwitchPartElement)chkExcludeFreeOpt.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		label15.BackColor = Color.FromArgb(132, 146, 146);
		label15.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label15, "label15");
		label15.ForeColor = Color.White;
		label15.Name = "label15";
		btnSetGroupDependency.BackColor = Color.FromArgb(61, 142, 185);
		btnSetGroupDependency.FlatAppearance.BorderColor = Color.White;
		btnSetGroupDependency.FlatAppearance.BorderSize = 0;
		btnSetGroupDependency.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnSetGroupDependency, "btnSetGroupDependency");
		btnSetGroupDependency.ForeColor = Color.White;
		btnSetGroupDependency.Name = "btnSetGroupDependency";
		btnSetGroupDependency.UseVisualStyleBackColor = false;
		btnSetGroupDependency.Click += RxpssewFrn;
		btnGroupOrderTypes.BackColor = Color.FromArgb(1, 110, 211);
		btnGroupOrderTypes.FlatAppearance.BorderColor = Color.White;
		btnGroupOrderTypes.FlatAppearance.BorderSize = 0;
		btnGroupOrderTypes.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnGroupOrderTypes, "btnGroupOrderTypes");
		btnGroupOrderTypes.ForeColor = Color.White;
		btnGroupOrderTypes.Name = "btnGroupOrderTypes";
		btnGroupOrderTypes.UseVisualStyleBackColor = false;
		btnGroupOrderTypes.Click += wyBsKuJpcR;
		componentResourceManager.ApplyResources(chkPreselectAll, "chkPreselectAll");
		chkPreselectAll.Name = "chkPreselectAll";
		chkPreselectAll.UseVisualStyleBackColor = true;
		chkPreselectAll.CheckedChanged += chkPreselectAll_CheckedChanged;
		label14.BackColor = Color.FromArgb(50, 119, 155);
		componentResourceManager.ApplyResources(label14, "label14");
		label14.ForeColor = Color.White;
		label14.Name = "label14";
		btnEditSortOrder.BackColor = Color.FromArgb(77, 174, 225);
		btnEditSortOrder.FlatAppearance.BorderColor = Color.White;
		btnEditSortOrder.FlatAppearance.BorderSize = 0;
		btnEditSortOrder.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnEditSortOrder, "btnEditSortOrder");
		btnEditSortOrder.ForeColor = Color.White;
		btnEditSortOrder.Name = "btnEditSortOrder";
		btnEditSortOrder.UseVisualStyleBackColor = false;
		btnEditSortOrder.Click += btnEditSortOrder_Click;
		label13.BackColor = Color.FromArgb(50, 119, 155);
		componentResourceManager.ApplyResources(label13, "label13");
		label13.ForeColor = Color.White;
		label13.Name = "label13";
		lblDisableMaxGroupOpt.BackColor = Color.FromArgb(132, 146, 146);
		lblDisableMaxGroupOpt.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(lblDisableMaxGroupOpt, "lblDisableMaxGroupOpt");
		lblDisableMaxGroupOpt.ForeColor = Color.White;
		lblDisableMaxGroupOpt.Name = "lblDisableMaxGroupOpt";
		label12.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label12, "label12");
		label12.ForeColor = Color.White;
		label12.Name = "label12";
		label12.Tag = "product";
		componentResourceManager.ApplyResources(txtMinGroupOptions, "txtMinGroupOptions");
		txtMinGroupOptions.Name = "txtMinGroupOptions";
		txtMinGroupOptions.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtMinGroupOptions.Tag = "product";
		txtMinGroupOptions.Click += txtMinGroupOptions_Click;
		((RadTextBoxControlElement)txtMinGroupOptions.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtMinGroupOptions.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		componentResourceManager.ApplyResources(txtMaxGroupOptions, "txtMaxGroupOptions");
		txtMaxGroupOptions.Name = "txtMaxGroupOptions";
		txtMaxGroupOptions.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtMaxGroupOptions.Tag = "product";
		txtMaxGroupOptions.Click += txtMaxGroupOptions_Click;
		((RadTextBoxControlElement)txtMaxGroupOptions.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtMaxGroupOptions.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		label24.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label24, "label24");
		label24.ForeColor = Color.White;
		label24.Name = "label24";
		label24.Tag = "product";
		btnMoveCopy.BackColor = Color.FromArgb(1, 110, 211);
		btnMoveCopy.FlatAppearance.BorderColor = Color.White;
		btnMoveCopy.FlatAppearance.BorderSize = 0;
		btnMoveCopy.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnMoveCopy, "btnMoveCopy");
		btnMoveCopy.ForeColor = Color.White;
		btnMoveCopy.Name = "btnMoveCopy";
		btnMoveCopy.UseVisualStyleBackColor = false;
		btnMoveCopy.Click += btnMoveCopy_Click;
		fjylSbkHv9.BackColor = Color.Transparent;
		fjylSbkHv9.ButtonDownEventOverride = null;
		fjylSbkHv9.ButtonLastEventOverride = null;
		fjylSbkHv9.ButtonStyle = "fourbuttons";
		fjylSbkHv9.ConnectedPanel = null;
		fjylSbkHv9.ConnectedRadListView = null;
		fjylSbkHv9.inputedHeight = 0;
		fjylSbkHv9.inputedWidth = 0;
		componentResourceManager.ApplyResources(fjylSbkHv9, "verticalScrollControl1");
		fjylSbkHv9.Name = "verticalScrollControl1";
		componentResourceManager.ApplyResources(chkExistingOptionsOnly, "chkExistingOptionsOnly");
		chkExistingOptionsOnly.Name = "chkExistingOptionsOnly";
		chkExistingOptionsOnly.UseVisualStyleBackColor = true;
		chkExistingOptionsOnly.CheckedChanged += chkExistingOptionsOnly_CheckedChanged;
		label11.BackColor = Color.FromArgb(132, 146, 146);
		label11.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label11, "label11");
		label11.ForeColor = Color.White;
		label11.Name = "label11";
		txtOptionQty.BackColor = Color.FromArgb(255, 255, 192);
		componentResourceManager.ApplyResources(txtOptionQty, "txtOptionQty");
		txtOptionQty.ForeColor = Color.FromArgb(40, 40, 40);
		txtOptionQty.Name = "txtOptionQty";
		txtOptionQty.RootElement.MinSize = new Size(40, 29);
		txtOptionQty.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtOptionQty.TextAlign = HorizontalAlignment.Center;
		txtOptionQty.Click += txtOptionQty_Click;
		((RadTextBoxControlElement)txtOptionQty.GetChildAt(0)).BorderWidth = 0f;
		((RadTextBoxControlElement)txtOptionQty.GetChildAt(0)).Padding = (Padding)componentResourceManager.GetObject("resource.Padding");
		((TextBoxViewElement)txtOptionQty.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		label8.BackColor = Color.FromArgb(50, 119, 155);
		componentResourceManager.ApplyResources(label8, "label8");
		label8.ForeColor = Color.White;
		label8.Name = "label8";
		ddlOptionGroup.BackColor = Color.White;
		ddlOptionGroup.DrawMode = DrawMode.OwnerDrawVariable;
		ddlOptionGroup.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(ddlOptionGroup, "ddlOptionGroup");
		ddlOptionGroup.FormattingEnabled = true;
		ddlOptionGroup.Name = "ddlOptionGroup";
		ddlOptionGroup.SelectedIndexChanged += ddlOptionGroup_SelectedIndexChanged;
		label3.BackColor = Color.FromArgb(132, 146, 146);
		label3.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderColor = Color.White;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.ForeColor = Color.White;
		btnSave.Name = "btnSave";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		ddlOptionGroups.BackColor = Color.White;
		ddlOptionGroups.DrawMode = DrawMode.OwnerDrawVariable;
		ddlOptionGroups.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(ddlOptionGroups, "ddlOptionGroups");
		ddlOptionGroups.FormattingEnabled = true;
		ddlOptionGroups.Name = "ddlOptionGroups";
		ddlOptionGroups.SelectedIndexChanged += ddlOptionGroups_SelectedIndexChanged;
		label7.BackColor = Color.FromArgb(50, 119, 155);
		componentResourceManager.ApplyResources(label7, "label7");
		label7.ForeColor = Color.White;
		label7.Name = "label7";
		componentResourceManager.ApplyResources(TabsRyLoFp, "pnlOptionControls");
		TabsRyLoFp.BackColor = Color.FromArgb(44, 44, 44);
		TabsRyLoFp.Name = "pnlOptionControls";
		componentResourceManager.ApplyResources(chkAllowAdditionalAll, "chkAllowAdditionalAll");
		chkAllowAdditionalAll.Name = "chkAllowAdditionalAll";
		chkAllowAdditionalAll.UseVisualStyleBackColor = true;
		chkAllowAdditionalAll.CheckedChanged += chkAllowAdditionalAll_CheckedChanged;
		txtPrice.BackColor = Color.FromArgb(255, 255, 192);
		componentResourceManager.ApplyResources(txtPrice, "txtPrice");
		txtPrice.ForeColor = Color.FromArgb(40, 40, 40);
		txtPrice.Name = "txtPrice";
		txtPrice.RootElement.MinSize = new Size(65, 29);
		txtPrice.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtPrice.TextAlign = HorizontalAlignment.Center;
		txtPrice.Click += txtPrice_Click;
		((RadTextBoxControlElement)txtPrice.GetChildAt(0)).BorderWidth = 0f;
		((RadTextBoxControlElement)txtPrice.GetChildAt(0)).Padding = (Padding)componentResourceManager.GetObject("resource.Padding1");
		((TextBoxViewElement)txtPrice.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		lblOptionName.BackColor = Color.FromArgb(50, 119, 155);
		componentResourceManager.ApplyResources(lblOptionName, "lblOptionName");
		lblOptionName.ForeColor = Color.White;
		lblOptionName.Name = "lblOptionName";
		componentResourceManager.ApplyResources(chkIncludeAll, "chkIncludeAll");
		chkIncludeAll.Name = "chkIncludeAll";
		chkIncludeAll.UseVisualStyleBackColor = true;
		chkIncludeAll.CheckedChanged += chkIncludeAll_CheckedChanged;
		ddlGroupFilter.BackColor = Color.White;
		ddlGroupFilter.DrawMode = DrawMode.OwnerDrawVariable;
		ddlGroupFilter.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(ddlGroupFilter, "ddlGroupFilter");
		ddlGroupFilter.FormattingEnabled = true;
		ddlGroupFilter.Name = "ddlGroupFilter";
		ddlGroupFilter.SelectedIndexChanged += ddlGroupFilter_SelectedIndexChanged;
		label2.BackColor = Color.FromArgb(132, 146, 146);
		label2.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		ddlGroups.BackColor = Color.White;
		ddlGroups.DrawMode = DrawMode.OwnerDrawVariable;
		ddlGroups.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(ddlGroups, "ddlGroups");
		ddlGroups.FormattingEnabled = true;
		ddlGroups.Name = "ddlGroups";
		ddlGroups.SelectedIndexChanged += ddlGroups_SelectedIndexChanged;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		label1.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		ddlItems.BackColor = Color.White;
		ddlItems.DrawMode = DrawMode.OwnerDrawVariable;
		ddlItems.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(ddlItems, "ddlItems");
		ddlItems.FormattingEnabled = true;
		ddlItems.Name = "ddlItems";
		ddlItems.SelectedIndexChanged += ddlItems_SelectedIndexChanged;
		label9.BackColor = Color.FromArgb(132, 146, 146);
		label9.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label9, "label9");
		label9.ForeColor = Color.White;
		label9.Name = "label9";
		label4.BackColor = Color.FromArgb(50, 119, 155);
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		label5.BackColor = Color.FromArgb(50, 119, 155);
		componentResourceManager.ApplyResources(label5, "label5");
		label5.ForeColor = Color.White;
		label5.Name = "label5";
		label6.BackColor = Color.FromArgb(50, 119, 155);
		componentResourceManager.ApplyResources(label6, "label6");
		label6.ForeColor = Color.White;
		label6.Name = "label6";
		btnEditTabSortOrder.BackColor = Color.FromArgb(77, 174, 225);
		btnEditTabSortOrder.FlatAppearance.BorderColor = Color.White;
		btnEditTabSortOrder.FlatAppearance.BorderSize = 0;
		btnEditTabSortOrder.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnEditTabSortOrder, "btnEditTabSortOrder");
		btnEditTabSortOrder.ForeColor = Color.White;
		btnEditTabSortOrder.Name = "btnEditTabSortOrder";
		btnEditTabSortOrder.UseVisualStyleBackColor = false;
		btnEditTabSortOrder.Click += btnEditTabSortOrder_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(btnEditTabSortOrder);
		base.Controls.Add(verticalScrollControl2);
		base.Controls.Add(btnEditTag);
		base.Controls.Add(btnAddTag);
		base.Controls.Add(label10);
		base.Controls.Add(pnlAllControls);
		base.Controls.Add(pnlTabs);
		base.Name = "frmAddEditOptions";
		base.Opacity = 1.0;
		base.ShowIcon = false;
		base.Load += frmAddEditOptions_Load;
		pnlAllControls.ResumeLayout(performLayout: false);
		((ISupportInitialize)txtMaxFreeGroupOpt).EndInit();
		((ISupportInitialize)chkExcludeFreeOpt).EndInit();
		((ISupportInitialize)txtMinGroupOptions).EndInit();
		((ISupportInitialize)txtMaxGroupOptions).EndInit();
		((ISupportInitialize)txtOptionQty).EndInit();
		((ISupportInitialize)txtPrice).EndInit();
		ResumeLayout(performLayout: false);
	}
}
