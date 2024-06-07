using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmInventoryView : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public string query;

		public _003C_003Ec__DisplayClass10_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_1
	{
		public short gID;

		public Func<ItemsInGroup, bool> _003C_003E9__4;

		public _003C_003Ec__DisplayClass10_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CsearchInventory_003Eb__3(Item i)
		{
			if (i.ItemClassification == ItemClassifications.Product && !i.isDeleted)
			{
				return i.ItemsInGroups.Where((ItemsInGroup it) => it.GroupID == gID || it.Group.ParentGroupID == gID).Count() > 0;
			}
			return false;
		}

		internal bool _003CsearchInventory_003Eb__4(ItemsInGroup it)
		{
			if (it.GroupID != gID)
			{
				return it.Group.ParentGroupID == gID;
			}
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public short gID;

		public Func<ItemsInGroup, bool> _003C_003E9__7;

		public _003C_003Ec__DisplayClass11_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CLoadInventoryItems_003Eb__4(Item t)
		{
			if (t.ItemClassification == ItemClassifications.Product && t.TrackInventory)
			{
				return t.ItemsInGroups.Where((ItemsInGroup it) => it.GroupID == gID || it.Group.ParentGroupID == gID).Count() > 0;
			}
			return false;
		}

		internal bool _003CLoadInventoryItems_003Eb__7(ItemsInGroup it)
		{
			if (it.GroupID != gID)
			{
				return it.Group.ParentGroupID == gID;
			}
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public string query;

		public _003C_003Ec__DisplayClass20_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass20_1
	{
		public short gID;

		public Func<ItemsInGroup, bool> _003C_003E9__4;

		public _003C_003Ec__DisplayClass20_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CoutOfStockCB_CheckedChanged_003Eb__3(Item i)
		{
			if (i.ItemClassification == ItemClassifications.Product)
			{
				return i.ItemsInGroups.Where((ItemsInGroup it) => it.GroupID == gID || it.Group.ParentGroupID == gID).Count() > 0;
			}
			return false;
		}

		internal bool _003CoutOfStockCB_CheckedChanged_003Eb__4(ItemsInGroup it)
		{
			if (it.GroupID != gID)
			{
				return it.Group.ParentGroupID == gID;
			}
			return true;
		}
	}

	private GClass6 gclass6_0;

	private string string_0;

	private bool bool_0;

	private bool bool_1;

	private List<InventoryItemControl> list_2;

	private List<Control> list_3;

	private IContainer icontainer_1;

	internal Button btnSearch;

	private Label label1;

	private FlowLayoutPanel pnlItems;

	internal Button btnCancel;

	internal Button btnSave;

	internal Button btnRefresh;

	private Label label2;

	private Class19 comboGroup;

	private Label lblReadOnlyMode;

	private Label lblSyncFailed;

	private Label label3;

	private Label label4;

	private RadToggleSwitch chkOutOfStock;

	private RadToggleSwitch chkMaterialsOnly;

	private System.Windows.Forms.Timer timer_0;

	internal Button btnShowKeyboard_Search;

	private Label lblTrainingMode;

	private RadTextBoxControl txtSearch;

	private System.Windows.Forms.Timer timer_1;

	internal Button btnPageUp;

	internal Button btnUp;

	internal Button btnDown;

	internal Button btnPageDown;

	private FlowLayoutPanel pnlHeading;

	public frmInventoryView(string _user, bool _readOnly)
	{
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		bool_0 = true;
		list_2 = new List<InventoryItemControl>();
		list_3 = new List<Control>();
		// base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		string_0 = _user;
		bool_0 = _readOnly;
		if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			lblTrainingMode.Visible = true;
		}
		else
		{
			lblTrainingMode.Visible = false;
		}
	}

	private void frmInventoryView_Load(object sender, EventArgs e)
	{
		method_3();
		btnSave.Enabled = !bool_0;
		lblReadOnlyMode.Visible = bool_0;
		method_13();
		InventoryItemHeaderControl value = new InventoryItemHeaderControl(pnlItems);
		pnlHeading.Controls.Add(value);
	}

	private void method_3()
	{
		Dictionary<string, string> groups = AdminMethods.getGroups();
		comboGroup.DisplayMember = "Value";
		comboGroup.ValueMember = "Key";
		comboGroup.DataSource = new BindingSource(groups, null);
		comboGroup.SelectedIndex = 0;
	}

	private void btnSearch_Click(object sender, EventArgs e)
	{
		method_4();
	}

	private void method_4()
	{
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
		gclass6_0 = new GClass6();
		CS_0024_003C_003E8__locals0.query = string.Empty;
		if (txtSearch.Text == Resources.Enter_Search_Criteria_Here)
		{
			CS_0024_003C_003E8__locals0.query = string.Empty;
		}
		else
		{
			CS_0024_003C_003E8__locals0.query = txtSearch.Text.Trim();
		}
		if (!chkMaterialsOnly.Value)
		{
			List<Item> list = (from t in gclass6_0.Items
				where t.ItemClassification == ItemClassifications.Product && t.TrackInventory == true && t.ItemName.Contains(CS_0024_003C_003E8__locals0.query) && t.isDeleted == false
				select t into i
				orderby (i.ItemsInGroups.Count() > 0) ? i.ItemsInGroups.FirstOrDefault().Group.GroupName : ""
				select i).ThenBy((Item x) => x.ItemName).ToList();
			if (comboGroup.SelectedIndex > -1)
			{
				_003C_003Ec__DisplayClass10_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass10_1();
				CS_0024_003C_003E8__locals1.gID = Convert.ToInt16(comboGroup.SelectedValue);
				if (CS_0024_003C_003E8__locals1.gID != 0)
				{
					list = list.Where((Item i) => i.ItemClassification == ItemClassifications.Product && !i.isDeleted && i.ItemsInGroups.Where((ItemsInGroup it) => it.GroupID == CS_0024_003C_003E8__locals1.gID || it.Group.ParentGroupID == CS_0024_003C_003E8__locals1.gID).Count() > 0).ToList();
				}
			}
			method_5(list);
		}
		else
		{
			List<Item> list_ = gclass6_0.Items.Where((Item m) => m.Active && m.ItemName.Contains(CS_0024_003C_003E8__locals0.query) && m.ItemClassification == ItemClassifications.Material && m.isDeleted == false).ToList();
			method_6(list_);
		}
	}

	private void method_5(List<Item> list_4 = null)
	{
		method_12(bool_2: true);
		list_3.AddRange(pnlItems.Controls.OfType<Control>().ToList());
		pnlItems.Controls.Clear();
		if (list_4 == null)
		{
			if (comboGroup.SelectedIndex > 0)
			{
				_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass11_0();
				CS_0024_003C_003E8__locals0.gID = Convert.ToInt16(comboGroup.SelectedValue);
				list_4 = (from t in new DataManager(gclass6_0).getAllItems()
					where t.ItemClassification == ItemClassifications.Product && t.TrackInventory && t.ItemsInGroups.Where((ItemsInGroup it) => it.GroupID == CS_0024_003C_003E8__locals0.gID || it.Group.ParentGroupID == CS_0024_003C_003E8__locals0.gID).Count() > 0
					select t into i
					orderby i.ItemsInGroups.FirstOrDefault().Group.GroupName
					select i).ThenBy((Item x) => x.ItemName).ToList();
			}
			else
			{
				list_4 = (from t in new DataManager(gclass6_0).getAllItems()
					where t.ItemClassification == ItemClassifications.Product && t.TrackInventory
					select t into i
					orderby (i.ItemsInGroups.FirstOrDefault() != null) ? i.ItemsInGroups.FirstOrDefault().Group.GroupName : string.Empty
					select i).ThenBy((Item x) => x.ItemName).ToList();
			}
		}
		if (chkOutOfStock.Value)
		{
			list_4 = list_4.Where((Item i) => i.InventoryCount <= 0m && i.ItemClassification == ItemClassifications.Product).ToList();
		}
		InventoryItemHeaderControl value = new InventoryItemHeaderControl(pnlItems);
		pnlHeading.Controls.Add(value);
		list_2 = new List<InventoryItemControl>();
		foreach (Item item2 in list_4)
		{
			InventoryItemControl item = new InventoryItemControl(item2, "product", string_0, bool_0, gclass6_0, pnlItems);
			list_2.Add(item);
		}
		method_11(bool_2: false);
		while (list_3.Count > 0)
		{
			Control control = list_3[0];
			list_3.Remove(control);
			control.Dispose();
		}
		GC.Collect();
	}

	private void method_6(List<Item> list_4 = null)
	{
		method_12(bool_2: true);
		list_3.AddRange(pnlItems.Controls.OfType<Control>().ToList());
		pnlItems.Controls.Clear();
		if (list_4 == null)
		{
			list_4 = gclass6_0.Items.Where((Item m) => m.Active && m.ItemClassification == ItemClassifications.Material).ToList();
		}
		InventoryItemHeaderControl value = new InventoryItemHeaderControl(pnlItems);
		pnlHeading.Controls.Add(value);
		list_2 = new List<InventoryItemControl>();
		foreach (Item item2 in list_4)
		{
			InventoryItemControl item = new InventoryItemControl(item2, "material", string_0, bool_0, gclass6_0, pnlItems);
			list_2.Add(item);
		}
		method_11(bool_2: false);
		while (list_3.Count > 0)
		{
			Control control = list_3[0];
			list_3.Remove(control);
			control.Dispose();
		}
		GC.Collect();
	}

	private void method_7(object sender, EventArgs e)
	{
		Close();
	}

	private void txtSearch_Enter(object sender, EventArgs e)
	{
		if (txtSearch.Text == Resources.Enter_Search_Criteria_Here)
		{
			txtSearch.ForeColor = HelperMethods.GetColor("40, 40, 40");
			txtSearch.Text = string.Empty;
		}
	}

	private void txtSearch_Leave(object sender, EventArgs e)
	{
		if (txtSearch.Text == string.Empty)
		{
			txtSearch.ForeColor = HelperMethods.GetColor("Gray");
			txtSearch.Text = Resources.Enter_Search_Criteria_Here;
		}
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		int num = 0;
		foreach (Control control3 in pnlItems.Controls)
		{
			if (control3.GetType().ToString().Contains("InventoryItemControl"))
			{
				InventoryItemControl inventoryItemControl = (InventoryItemControl)control3;
				if (!inventoryItemControl.checkIfValueIsValid())
				{
					return;
				}
				if (inventoryItemControl.checkIfEntryExist())
				{
					num++;
				}
			}
		}
		if (num == 0)
		{
			return;
		}
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Add_a_Note_for_Inventory_Updat);
		List<bool> list = new List<bool>();
		if (MemoryLoadedObjects.Keyboard.ShowDialog() == DialogResult.OK)
		{
			foreach (Control control4 in pnlItems.Controls)
			{
				if (control4.GetType().ToString().Contains("InventoryItemControl"))
				{
					InventoryItemControl inventoryItemControl2 = (InventoryItemControl)control4;
					if (inventoryItemControl2.isSaveNeeded)
					{
						list.Add(inventoryItemControl2.Save(MemoryLoadedObjects.Keyboard.textEntered));
					}
				}
			}
			if (list.Contains(item: false))
			{
				new NotificationLabel(this, "Not all items were saved.", NotificationTypes.Notification).Show();
			}
			else
			{
				new NotificationLabel(this, Resources.Inventory_updated_successfully, NotificationTypes.Success).Show();
			}
			method_4();
		}
		MemoryLoadedObjects.ItemsAndGroupsStationsRefresh();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		timer_1.Enabled = false;
		list_3.AddRange(pnlItems.Controls.OfType<Control>().ToList());
		pnlItems.Controls.Clear();
		while (list_3.Count > 0)
		{
			Control control = list_3[0];
			list_3.Remove(control);
			control.Dispose();
		}
		AuthMethods.LogOutUser();
		list_3 = null;
		list_2 = null;
		GC.Collect();
		Close();
	}

	private void btnRefresh_Click(object sender, EventArgs e)
	{
		btnSearch_Click(sender, e);
	}

	private void comboGroup_SelectionChangeCommitted(object sender, EventArgs e)
	{
		method_5();
	}

	private void method_8(object sender, EventArgs e)
	{
		if (chkOutOfStock.Value)
		{
			_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass20_0();
			CS_0024_003C_003E8__locals0.query = string.Empty;
			if (txtSearch.Text == Resources.Enter_Search_Criteria_Here)
			{
				CS_0024_003C_003E8__locals0.query = string.Empty;
			}
			else
			{
				CS_0024_003C_003E8__locals0.query = txtSearch.Text.Trim();
			}
			if (!chkMaterialsOnly.Value)
			{
				List<Item> list = (from t in new DataManager(gclass6_0).getAllItems(CS_0024_003C_003E8__locals0.query)
					where t.ItemClassification == ItemClassifications.Product && t.TrackInventory && t.InventoryCount <= 0m
					select t into i
					orderby i.ItemsInGroups.FirstOrDefault().Group.GroupName
					select i).ThenBy((Item x) => x.ItemName).ToList();
				if (comboGroup.SelectedIndex > -1)
				{
					_003C_003Ec__DisplayClass20_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass20_1();
					CS_0024_003C_003E8__locals1.gID = Convert.ToInt16(comboGroup.SelectedValue);
					if (CS_0024_003C_003E8__locals1.gID != 0)
					{
						list = list.Where((Item i) => i.ItemClassification == ItemClassifications.Product && i.ItemsInGroups.Where((ItemsInGroup it) => it.GroupID == CS_0024_003C_003E8__locals1.gID || it.Group.ParentGroupID == CS_0024_003C_003E8__locals1.gID).Count() > 0).ToList();
					}
				}
				method_5(list);
			}
			else
			{
				List<Item> list_ = gclass6_0.Items.Where((Item m) => m.InventoryCount <= 0m && m.Active && m.ItemName.Contains(CS_0024_003C_003E8__locals0.query) && m.ItemClassification == ItemClassifications.Material).ToList();
				method_6(list_);
			}
		}
		else
		{
			method_4();
		}
	}

	private void method_9()
	{
		Thread.Sleep(5000);
		bool_1 = false;
	}

	private void method_10(object sender, EventArgs e)
	{
		if (chkMaterialsOnly.Value)
		{
			comboGroup.Enabled = false;
			chkOutOfStock.Enabled = false;
			method_6();
		}
		else
		{
			comboGroup.Enabled = true;
			chkOutOfStock.Enabled = true;
			method_5();
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (base.Opacity < 1.0)
		{
			base.Opacity += 0.1;
			return;
		}
		base.Opacity = 1.0;
		timer_0.Enabled = false;
	}

	private void btnShowKeyboard_Search_Click(object sender, EventArgs e)
	{
		if (txtSearch.Text.Contains(Resources.Enter_Search_Criteria_Here))
		{
			txtSearch.Text = "";
		}
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Search_Inventory, 0, 128, txtSearch.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtSearch.Text = MemoryLoadedObjects.Keyboard.textEntered;
			txtSearch.ForeColor = HelperMethods.GetColor("40, 40, 40");
			method_4();
		}
		base.DialogResult = DialogResult.None;
	}

	private void txtSearch_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
		if (list_2 != null)
		{
			InventoryItemControl inventoryItemControl = list_2.Where((InventoryItemControl i) => !i.isLoaded).FirstOrDefault();
			if (inventoryItemControl != null)
			{
				inventoryItemControl.isLoaded = true;
				pnlItems.Controls.Add(inventoryItemControl);
				list_2.Remove(inventoryItemControl);
				return;
			}
			list_2.Clear();
			list_2 = null;
			GC.Collect();
		}
		method_11(bool_2: true);
	}

	private void method_11(bool bool_2)
	{
		if (bool_2)
		{
			method_12(bool_2: false);
			timer_1.Enabled = false;
		}
		else
		{
			timer_1.Enabled = true;
		}
	}

	private void method_12(bool bool_2)
	{
		if (bool_2)
		{
			btnSave.Enabled = false;
			btnSearch.Enabled = false;
			btnRefresh.Enabled = false;
		}
		else
		{
			btnSearch.Enabled = true;
			btnRefresh.Enabled = true;
			btnSave.Enabled = true;
		}
	}

	private void btnPageUp_Click(object sender, EventArgs e)
	{
		pnlItems.VerticalScroll.Value = pnlItems.VerticalScroll.Minimum;
		pnlItems.VerticalScroll.Value = pnlItems.VerticalScroll.Minimum;
	}

	private void btnPageDown_Click(object sender, EventArgs e)
	{
		pnlItems.VerticalScroll.Value = pnlItems.VerticalScroll.Maximum;
		pnlItems.VerticalScroll.Value = pnlItems.VerticalScroll.Maximum;
	}

	private void btnUp_Click(object sender, EventArgs e)
	{
		try
		{
			pnlItems.VerticalScroll.Value = pnlItems.VerticalScroll.Value - pnlItems.Height / 2;
			pnlItems.VerticalScroll.Value = pnlItems.VerticalScroll.Value - pnlItems.Height / 2;
		}
		catch
		{
			pnlItems.VerticalScroll.Value = pnlItems.VerticalScroll.Minimum;
			pnlItems.VerticalScroll.Value = pnlItems.VerticalScroll.Minimum;
		}
	}

	private void btnDown_Click(object sender, EventArgs e)
	{
		try
		{
			pnlItems.VerticalScroll.Value = pnlItems.VerticalScroll.Value + pnlItems.Height / 2;
			pnlItems.VerticalScroll.Value = pnlItems.VerticalScroll.Value + pnlItems.Height / 2;
		}
		catch
		{
			pnlItems.VerticalScroll.Value = pnlItems.VerticalScroll.Maximum;
			pnlItems.VerticalScroll.Value = pnlItems.VerticalScroll.Maximum;
		}
	}

	private void method_13()
	{
		int num = (base.Height - btnCancel.Height) / 4;
		btnUp.Height = num;
		btnPageUp.Height = num;
		btnDown.Height = num;
		int num2 = base.Height - btnCancel.Height - num * 4;
		if (num2 < 0)
		{
			num += num2;
		}
		btnPageDown.Height = num;
		btnPageUp.Location = new Point(btnPageUp.Location.X, btnCancel.Bottom + 1);
		btnUp.Location = new Point(btnPageUp.Location.X, btnPageUp.Bottom + 1);
		btnDown.Location = new Point(btnPageUp.Location.X, btnUp.Bottom + 1);
		btnPageDown.Location = new Point(btnPageUp.Location.X, btnDown.Bottom + 1);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_1 != null)
		{
			icontainer_1.Dispose();
		}
		base.Dispose(disposing);
		GC.Collect();
	}

	private void InitializeComponent_1()
	{
		icontainer_1 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmInventoryView));
		timer_0 = new System.Windows.Forms.Timer(icontainer_1);
		timer_1 = new System.Windows.Forms.Timer(icontainer_1);
		lblTrainingMode = new Label();
		txtSearch = new RadTextBoxControl();
		btnShowKeyboard_Search = new Button();
		chkMaterialsOnly = new RadToggleSwitch();
		chkOutOfStock = new RadToggleSwitch();
		label4 = new Label();
		label3 = new Label();
		lblReadOnlyMode = new Label();
		label2 = new Label();
		btnRefresh = new Button();
		btnCancel = new Button();
		btnSave = new Button();
		pnlItems = new FlowLayoutPanel();
		lblSyncFailed = new Label();
		btnSearch = new Button();
		label1 = new Label();
		comboGroup = new Class19();
		btnPageUp = new Button();
		btnUp = new Button();
		btnDown = new Button();
		btnPageDown = new Button();
		pnlHeading = new FlowLayoutPanel();
		((ISupportInitialize)txtSearch).BeginInit();
		((ISupportInitialize)chkMaterialsOnly).BeginInit();
		((ISupportInitialize)chkOutOfStock).BeginInit();
		pnlItems.SuspendLayout();
		SuspendLayout();
		timer_0.Enabled = true;
		timer_0.Interval = 50;
		timer_0.Tick += timer_0_Tick;
		timer_1.Interval = 10;
		timer_1.Tick += timer_1_Tick;
		componentResourceManager.ApplyResources(lblTrainingMode, "lblTrainingMode");
		lblTrainingMode.BackColor = Color.FromArgb(193, 57, 43);
		lblTrainingMode.ForeColor = Color.White;
		lblTrainingMode.Name = "lblTrainingMode";
		componentResourceManager.ApplyResources(txtSearch, "txtSearch");
		txtSearch.ForeColor = Color.Gray;
		txtSearch.Name = "txtSearch";
		txtSearch.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtSearch.Click += txtSearch_Click;
		txtSearch.Enter += txtSearch_Enter;
		txtSearch.Leave += txtSearch_Leave;
		((RadTextBoxControlElement)txtSearch.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtSearch.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		componentResourceManager.ApplyResources(btnShowKeyboard_Search, "btnShowKeyboard_Search");
		btnShowKeyboard_Search.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Search.DialogResult = DialogResult.OK;
		btnShowKeyboard_Search.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Search.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_Search.ForeColor = Color.White;
		btnShowKeyboard_Search.Name = "btnShowKeyboard_Search";
		btnShowKeyboard_Search.UseVisualStyleBackColor = false;
		btnShowKeyboard_Search.Click += btnShowKeyboard_Search_Click;
		componentResourceManager.ApplyResources(chkMaterialsOnly, "chkMaterialsOnly");
		chkMaterialsOnly.Name = "chkMaterialsOnly";
		chkMaterialsOnly.OffText = "NO";
		chkMaterialsOnly.OnText = "YES";
		chkMaterialsOnly.ToggleStateMode = ToggleStateMode.Click;
		chkMaterialsOnly.Value = false;
		((RadToggleSwitchElement)chkMaterialsOnly.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkMaterialsOnly.GetChildAt(0)).BorderWidth = 1f;
		((ToggleSwitchPartElement)chkMaterialsOnly.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkMaterialsOnly.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkMaterialsOnly.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkMaterialsOnly.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text");
		((ToggleSwitchPartElement)chkMaterialsOnly.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		componentResourceManager.ApplyResources(chkOutOfStock, "chkOutOfStock");
		chkOutOfStock.Name = "chkOutOfStock";
		chkOutOfStock.OffText = "NO";
		chkOutOfStock.OnText = "YES";
		chkOutOfStock.ToggleStateMode = ToggleStateMode.Click;
		chkOutOfStock.Value = false;
		((RadToggleSwitchElement)chkOutOfStock.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkOutOfStock.GetChildAt(0)).BorderWidth = 1f;
		((ToggleSwitchPartElement)chkOutOfStock.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkOutOfStock.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkOutOfStock.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkOutOfStock.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text1");
		((ToggleSwitchPartElement)chkOutOfStock.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		label4.BackColor = Color.FromArgb(150, 166, 166);
		label4.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		label3.BackColor = Color.FromArgb(150, 166, 166);
		label3.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		componentResourceManager.ApplyResources(lblReadOnlyMode, "lblReadOnlyMode");
		lblReadOnlyMode.BackColor = Color.FromArgb(193, 57, 43);
		lblReadOnlyMode.ForeColor = Color.White;
		lblReadOnlyMode.Name = "lblReadOnlyMode";
		label2.BackColor = Color.FromArgb(150, 166, 166);
		label2.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		componentResourceManager.ApplyResources(btnRefresh, "btnRefresh");
		btnRefresh.BackColor = Color.SandyBrown;
		btnRefresh.FlatAppearance.BorderColor = Color.White;
		btnRefresh.FlatAppearance.BorderSize = 0;
		btnRefresh.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnRefresh.ForeColor = Color.White;
		btnRefresh.Name = "btnRefresh";
		btnRefresh.UseVisualStyleBackColor = false;
		btnRefresh.Click += btnRefresh_Click;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderColor = Color.White;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnCancel.ForeColor = Color.White;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderColor = Color.White;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnSave.ForeColor = Color.White;
		btnSave.Name = "btnSave";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		componentResourceManager.ApplyResources(pnlItems, "pnlItems");
		pnlItems.BorderStyle = BorderStyle.FixedSingle;
		pnlItems.Controls.Add(lblSyncFailed);
		pnlItems.Name = "pnlItems";
		componentResourceManager.ApplyResources(lblSyncFailed, "lblSyncFailed");
		lblSyncFailed.BackColor = Color.FromArgb(244, 156, 20);
		lblSyncFailed.ForeColor = SystemColors.ButtonFace;
		lblSyncFailed.Name = "lblSyncFailed";
		componentResourceManager.ApplyResources(btnSearch, "btnSearch");
		btnSearch.BackColor = Color.FromArgb(53, 152, 220);
		btnSearch.FlatAppearance.BorderColor = Color.Black;
		btnSearch.FlatAppearance.BorderSize = 0;
		btnSearch.FlatAppearance.MouseDownBackColor = Color.White;
		btnSearch.ForeColor = Color.White;
		btnSearch.Name = "btnSearch";
		btnSearch.UseVisualStyleBackColor = false;
		btnSearch.Click += btnSearch_Click;
		componentResourceManager.ApplyResources(label1, "label1");
		label1.BackColor = Color.FromArgb(150, 166, 166);
		label1.FlatStyle = FlatStyle.Flat;
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		comboGroup.AllowDrop = true;
		comboGroup.BackColor = Color.White;
		comboGroup.DrawMode = DrawMode.OwnerDrawVariable;
		comboGroup.DropDownHeight = 400;
		comboGroup.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(comboGroup, "comboGroup");
		comboGroup.FormattingEnabled = true;
		comboGroup.Name = "comboGroup";
		comboGroup.SelectionChangeCommitted += comboGroup_SelectionChangeCommitted;
		componentResourceManager.ApplyResources(btnPageUp, "btnPageUp");
		btnPageUp.BackColor = Color.FromArgb(53, 152, 220);
		btnPageUp.FlatAppearance.BorderColor = Color.Black;
		btnPageUp.FlatAppearance.BorderSize = 0;
		btnPageUp.FlatAppearance.MouseDownBackColor = Color.White;
		btnPageUp.ForeColor = Color.White;
		btnPageUp.Name = "btnPageUp";
		btnPageUp.UseVisualStyleBackColor = false;
		btnPageUp.Click += btnPageUp_Click;
		componentResourceManager.ApplyResources(btnUp, "btnUp");
		btnUp.BackColor = Color.FromArgb(53, 152, 220);
		btnUp.FlatAppearance.BorderColor = Color.Black;
		btnUp.FlatAppearance.BorderSize = 0;
		btnUp.FlatAppearance.MouseDownBackColor = Color.White;
		btnUp.ForeColor = Color.White;
		btnUp.Name = "btnUp";
		btnUp.UseVisualStyleBackColor = false;
		btnUp.Click += btnUp_Click;
		componentResourceManager.ApplyResources(btnDown, "btnDown");
		btnDown.BackColor = Color.FromArgb(53, 152, 220);
		btnDown.FlatAppearance.BorderColor = Color.Black;
		btnDown.FlatAppearance.BorderSize = 0;
		btnDown.FlatAppearance.MouseDownBackColor = Color.White;
		btnDown.ForeColor = Color.White;
		btnDown.Name = "btnDown";
		btnDown.UseVisualStyleBackColor = false;
		btnDown.Click += btnDown_Click;
		componentResourceManager.ApplyResources(btnPageDown, "btnPageDown");
		btnPageDown.BackColor = Color.FromArgb(53, 152, 220);
		btnPageDown.FlatAppearance.BorderColor = Color.Black;
		btnPageDown.FlatAppearance.BorderSize = 0;
		btnPageDown.FlatAppearance.MouseDownBackColor = Color.White;
		btnPageDown.ForeColor = Color.White;
		btnPageDown.Name = "btnPageDown";
		btnPageDown.UseVisualStyleBackColor = false;
		btnPageDown.Click += btnPageDown_Click;
		componentResourceManager.ApplyResources(pnlHeading, "pnlHeading");
		pnlHeading.BorderStyle = BorderStyle.FixedSingle;
		pnlHeading.Name = "pnlHeading";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(pnlHeading);
		base.Controls.Add(btnPageUp);
		base.Controls.Add(btnPageDown);
		base.Controls.Add(btnDown);
		base.Controls.Add(btnUp);
		base.Controls.Add(lblReadOnlyMode);
		base.Controls.Add(lblTrainingMode);
		base.Controls.Add(txtSearch);
		base.Controls.Add(btnShowKeyboard_Search);
		base.Controls.Add(chkMaterialsOnly);
		base.Controls.Add(chkOutOfStock);
		base.Controls.Add(label4);
		base.Controls.Add(label3);
		base.Controls.Add(comboGroup);
		base.Controls.Add(label2);
		base.Controls.Add(btnRefresh);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnSave);
		base.Controls.Add(pnlItems);
		base.Controls.Add(btnSearch);
		base.Controls.Add(label1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmInventoryView";
		base.Opacity = 1.0;
		base.SizeGripStyle = SizeGripStyle.Show;
		base.WindowState = FormWindowState.Maximized;
		base.Load += frmInventoryView_Load;
		((ISupportInitialize)txtSearch).EndInit();
		((ISupportInitialize)chkMaterialsOnly).EndInit();
		((ISupportInitialize)chkOutOfStock).EndInit();
		pnlItems.ResumeLayout(performLayout: false);
		pnlItems.PerformLayout();
		ResumeLayout(performLayout: false);
	}
}
