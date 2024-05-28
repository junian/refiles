using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmMaterialsInItem : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public MaterialsInItem materialInItem;

		public _003C_003Ec__DisplayClass14_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public ListViewItem materialAdded;

		public _003C_003Ec__DisplayClass16_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CrecalculateCost_003Eb__0(Item m)
		{
			return m.ItemName == materialAdded.SubItems[0].Text.ToString();
		}

		internal bool _003CrecalculateCost_003Eb__1(UOM u)
		{
			return u.Name == materialAdded.SubItems[2].Text;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public ListViewItem materialAdded;

		public _003C_003Ec__DisplayClass19_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public MaterialsInItem materialInItem;

		public _003C_003Ec__DisplayClass20_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	private GClass6 gclass6_0;

	private int int_0;

	private Item item_0;

	private List<Item> list_2;

	private List<UOM> list_3;

	private List<MaterialsInItem> list_4;

	[CompilerGenerated]
	private List<MaterialsInItem> list_5;

	private IContainer icontainer_1;

	internal Button btnClearAll;

	internal Button btnDeleteMaterial;

	internal Button btnReset;

	internal Button btnSave;

	internal Button btnExit;

	private Label lblItemName;

	private Label label1;

	private ColumnHeader columnHeader_0;

	private ColumnHeader columnHeader_1;

	private ListView lstMaterialsAddedToItem;

	private Label label19;

	private Class19 lstMaterials;

	private Label label3;

	private ColumnHeader columnHeader_2;

	private Label label4;

	private Label ChsfchqjoG;

	private Class19 lstUOM;

	internal Button btnAdd;

	private Label lowerLabelAddItem;

	private RadTextBoxControl txtQuantity;

	private Label label2;

	private RadTextBoxControl txtComments;

	private ColumnHeader columnHeader_3;

	internal Button btnShowKeyboard_Quantity;

	internal Button btnShowKeyboard_Comments;

	internal Button btnConfigureUOM;

	private Label lblSuggestedPriceByIngredients;

	private Label label12;

	public List<MaterialsInItem> returnMaterialsInItemList
	{
		[CompilerGenerated]
		get
		{
			return list_5;
		}
		[CompilerGenerated]
		set
		{
			list_5 = value;
		}
	}

	public frmMaterialsInItem(int _itemId, List<MaterialsInItem> _listOfMaterialsInItem)
	{
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		// base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		int_0 = _itemId;
		list_4 = _listOfMaterialsInItem;
		list_2 = gclass6_0.Items.Where((Item m) => m.ItemClassification == ItemClassifications.Material).ToList();
		list_3 = gclass6_0.UOMs.ToList();
	}

	private void frmMaterialsInItem_Load(object sender, EventArgs e)
	{
		if (int_0 != 0)
		{
			lblItemName.UseMnemonic = false;
			lblItemName.Text = (from i in gclass6_0.Items
				where i.ItemID == int_0
				select i into x
				select x.ItemName).FirstOrDefault();
		}
		method_4();
		method_3();
		method_5();
		lstMaterialsAddedToItem.Columns[0].Width = ControlHelpers.ControlWidthFixer(lstMaterialsAddedToItem, 4.0);
		lstMaterialsAddedToItem.Columns[1].Width = ControlHelpers.ControlWidthFixer(lstMaterialsAddedToItem, 2.0);
		lstMaterialsAddedToItem.Columns[2].Width = ControlHelpers.ControlWidthFixer(lstMaterialsAddedToItem, 2.0);
		lstMaterialsAddedToItem.Columns[3].Width = ControlHelpers.ControlWidthFixer(lstMaterialsAddedToItem, 4.0) - 10;
		method_6();
	}

	private void method_3()
	{
		lstUOM.Items.Clear();
		UOMMethods uOMMethods = new UOMMethods();
		item_0 = new GClass6().Items.Where((Item x) => x.ItemName == lstMaterials.Text && x.ItemClassification == ItemClassifications.Material).FirstOrDefault();
		if (item_0 == null)
		{
			return;
		}
		foreach (UOM item in uOMMethods.method_0(item_0.ItemID))
		{
			lstUOM.Items.Add(item.Name);
		}
		lstUOM.SelectedIndex = 0;
	}

	private void method_4()
	{
		lstMaterials.Items.Clear();
		gclass6_0 = new GClass6();
		List<Item> list = (from m in gclass6_0.Items
			where m.ItemClassification == ItemClassifications.Material
			orderby m.ItemName
			select m).ToList();
		if (list.Count <= 0)
		{
			return;
		}
		foreach (Item item2 in list)
		{
			lstMaterials.Items.Add(item2.ItemName);
		}
		lstMaterials.SelectedIndex = 0;
		Item item = gclass6_0.Items.Where((Item m) => m.ItemName == lstMaterials.SelectedItem.ToString() && m.ItemClassification == ItemClassifications.Material).FirstOrDefault();
		lstUOM.SelectedItem = item.UOM.Name.ToString();
	}

	private void method_5()
	{
		lstMaterialsAddedToItem.Items.Clear();
		gclass6_0 = new GClass6();
		if (list_4 == null)
		{
			return;
		}
		using List<MaterialsInItem>.Enumerator enumerator = list_4.GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass14_0();
			CS_0024_003C_003E8__locals0.materialInItem = enumerator.Current;
			Item item = gclass6_0.Items.Where((Item m) => m.ItemID == CS_0024_003C_003E8__locals0.materialInItem.ItemMaterialID && m.ItemClassification == ItemClassifications.Material).FirstOrDefault();
			if (item != null)
			{
				ListViewItem value = new ListViewItem(new string[4]
				{
					item.ItemName,
					CS_0024_003C_003E8__locals0.materialInItem.Quantity.Value.ToString("0.00##"),
					CS_0024_003C_003E8__locals0.materialInItem.UOM.Name,
					string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.materialInItem.Comments) ? "" : CS_0024_003C_003E8__locals0.materialInItem.Comments
				});
				lstMaterialsAddedToItem.Items.Add(value);
			}
		}
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		if (lstMaterials.SelectedIndex < 0)
		{
			new NotificationLabel(this, Resources.Please_select_an_ingredient_fr, NotificationTypes.Warning).Show();
			base.DialogResult = DialogResult.None;
			return;
		}
		if (string.IsNullOrEmpty(txtQuantity.Text))
		{
			new frmMessageBox(Resources.Please_enter_a_quantity, Resources.Quantity_Required).ShowDialog(this);
			base.DialogResult = DialogResult.None;
			return;
		}
		string text = lstMaterials.SelectedItem.ToString();
		string text2 = txtQuantity.Text;
		string text3 = lstUOM.SelectedItem.ToString();
		string text4 = txtComments.Text;
		ListViewItem value = new ListViewItem(new string[4] { text, text2, text3, text4 });
		lstMaterialsAddedToItem.Items.Add(value);
		base.DialogResult = DialogResult.None;
		method_6();
	}

	private void method_6()
	{
		try
		{
			decimal num = default(decimal);
			new List<MaterialsInItem>();
			IEnumerator enumerator = lstMaterialsAddedToItem.Items.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass16_0();
					CS_0024_003C_003E8__locals0.materialAdded = (ListViewItem)enumerator.Current;
					Item item = list_2.Where((Item m) => m.ItemName == CS_0024_003C_003E8__locals0.materialAdded.SubItems[0].Text.ToString()).FirstOrDefault();
					UOM uOM = list_3.Where((UOM u) => u.Name == CS_0024_003C_003E8__locals0.materialAdded.SubItems[2].Text).FirstOrDefault();
					if (item.UOMID != uOM.UOMID)
					{
						num += item.ItemCost * UOMMethods.ConvertByUOMID(item.ItemID, Convert.ToDecimal(CS_0024_003C_003E8__locals0.materialAdded.SubItems[1].Text), item.UOMID, uOM.UOMID);
					}
					else
					{
						num += item.ItemCost * Convert.ToDecimal(CS_0024_003C_003E8__locals0.materialAdded.SubItems[1].Text);
					}
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
			label12.Text = "Total Ingredient Cost:";
			lblSuggestedPriceByIngredients.Text = num.ToString("0.00##");
		}
		catch
		{
			new NotificationLabel(this, "There was a problem calculating ingredient cost, please check UOM conversions.", NotificationTypes.Warning).Show();
		}
	}

	private void btnDeleteMaterial_Click(object sender, EventArgs e)
	{
		foreach (ListViewItem selectedItem in lstMaterialsAddedToItem.SelectedItems)
		{
			lstMaterialsAddedToItem.Items.Remove(selectedItem);
		}
		base.DialogResult = DialogResult.None;
		method_6();
	}

	private void btnClearAll_Click(object sender, EventArgs e)
	{
		lstMaterialsAddedToItem.Items.Clear();
		base.DialogResult = DialogResult.None;
		method_6();
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		List<MaterialsInItem> list = new List<MaterialsInItem>();
		IEnumerator enumerator = lstMaterialsAddedToItem.Items.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass19_0();
				CS_0024_003C_003E8__locals0.materialAdded = (ListViewItem)enumerator.Current;
				Item item = gclass6_0.Items.Where((Item m) => m.ItemName == CS_0024_003C_003E8__locals0.materialAdded.SubItems[0].Text.ToString() && m.ItemClassification == ItemClassifications.Material).FirstOrDefault();
				UOM uOM = gclass6_0.UOMs.Where((UOM u) => u.Name == CS_0024_003C_003E8__locals0.materialAdded.SubItems[2].Text).FirstOrDefault();
				MaterialsInItem item2 = new MaterialsInItem
				{
					ItemID = int_0,
					ItemMaterialID = item.ItemID,
					Quantity = Convert.ToDecimal(CS_0024_003C_003E8__locals0.materialAdded.SubItems[1].Text),
					UOM = uOM,
					Comments = CS_0024_003C_003E8__locals0.materialAdded.SubItems[3].Text
				};
				list.Add(item2);
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
		base.DialogResult = DialogResult.OK;
		returnMaterialsInItemList = list;
		Close();
	}

	private void btnReset_Click(object sender, EventArgs e)
	{
		lstMaterialsAddedToItem.Items.Clear();
		if (list_4 != null)
		{
			using List<MaterialsInItem>.Enumerator enumerator = list_4.GetEnumerator();
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass20_0();
				CS_0024_003C_003E8__locals0.materialInItem = enumerator.Current;
				Item item = gclass6_0.Items.Where((Item m) => m.ItemID == CS_0024_003C_003E8__locals0.materialInItem.ItemMaterialID).FirstOrDefault();
				if (item != null)
				{
					ListViewItem value = new ListViewItem(new string[4]
					{
						item.ItemName,
						CS_0024_003C_003E8__locals0.materialInItem.Quantity.ToString(),
						CS_0024_003C_003E8__locals0.materialInItem.UOM.Name,
						string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.materialInItem.Comments) ? "" : CS_0024_003C_003E8__locals0.materialInItem.Comments
					});
					lstMaterialsAddedToItem.Items.Add(value);
				}
			}
		}
		method_6();
	}

	private void btnExit_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	public void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
	{
		TextFilters.NumberOnly(sender, e);
	}

	private void lstMaterials_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (lstMaterials.Items.Count > 0)
		{
			Item item = gclass6_0.Items.Where((Item m) => m.ItemName == lstMaterials.SelectedItem.ToString() && m.ItemClassification == ItemClassifications.Material).FirstOrDefault();
			method_3();
			lstUOM.SelectedItem = item.UOM.Name.ToString();
			txtQuantity.Text = string.Empty;
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		new frmAddEditMaterials().ShowDialog(this);
		base.DialogResult = DialogResult.None;
		method_4();
	}

	private void btnShowKeyboard_Quantity_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Quantity, 4, 8, txtQuantity.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtQuantity.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void txtQuantity_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private void btnShowKeyboard_Comments_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Comments, 1, 256, txtComments.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtComments.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnConfigureUOM_Click(object sender, EventArgs e)
	{
		if (item_0 != null)
		{
			new frmUOMConversions(item_0.ItemID, item_0.ItemName, item_0.UOMID.ToString(), item_0.UOM.Name).ShowDialog(this);
			base.DialogResult = DialogResult.None;
		}
		else
		{
			new NotificationLabel(this, Resources.An_error_occurred_trying_to_lo, NotificationTypes.Warning).Show();
		}
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmMaterialsInItem));
		btnShowKeyboard_Comments = new Button();
		btnShowKeyboard_Quantity = new Button();
		txtComments = new RadTextBoxControl();
		label2 = new Label();
		txtQuantity = new RadTextBoxControl();
		btnAdd = new Button();
		lstUOM = new Class19();
		ChsfchqjoG = new Label();
		label4 = new Label();
		label3 = new Label();
		btnClearAll = new Button();
		btnDeleteMaterial = new Button();
		btnReset = new Button();
		btnSave = new Button();
		btnExit = new Button();
		lblItemName = new Label();
		label1 = new Label();
		lstMaterialsAddedToItem = new ListView();
		columnHeader_1 = new ColumnHeader();
		columnHeader_0 = new ColumnHeader();
		columnHeader_2 = new ColumnHeader();
		columnHeader_3 = new ColumnHeader();
		label19 = new Label();
		lstMaterials = new Class19();
		lowerLabelAddItem = new Label();
		btnConfigureUOM = new Button();
		lblSuggestedPriceByIngredients = new Label();
		label12 = new Label();
		((ISupportInitialize)txtComments).BeginInit();
		((ISupportInitialize)txtQuantity).BeginInit();
		SuspendLayout();
		btnShowKeyboard_Comments.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Comments.DialogResult = DialogResult.OK;
		btnShowKeyboard_Comments.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Comments.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Comments, "btnShowKeyboard_Comments");
		btnShowKeyboard_Comments.ForeColor = Color.White;
		btnShowKeyboard_Comments.Name = "btnShowKeyboard_Comments";
		btnShowKeyboard_Comments.UseVisualStyleBackColor = false;
		btnShowKeyboard_Comments.Click += btnShowKeyboard_Comments_Click;
		btnShowKeyboard_Quantity.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Quantity.DialogResult = DialogResult.OK;
		btnShowKeyboard_Quantity.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Quantity.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Quantity, "btnShowKeyboard_Quantity");
		btnShowKeyboard_Quantity.ForeColor = Color.White;
		btnShowKeyboard_Quantity.Name = "btnShowKeyboard_Quantity";
		btnShowKeyboard_Quantity.UseVisualStyleBackColor = false;
		btnShowKeyboard_Quantity.Click += btnShowKeyboard_Quantity_Click;
		componentResourceManager.ApplyResources(txtComments, "txtComments");
		txtComments.Name = "txtComments";
		txtComments.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtComments.Tag = "product";
		txtComments.Click += txtQuantity_Click;
		((RadTextBoxControlElement)txtComments.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtComments.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(0f, 5f);
		label2.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		componentResourceManager.ApplyResources(txtQuantity, "txtQuantity");
		txtQuantity.Name = "txtQuantity";
		txtQuantity.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtQuantity.Tag = "product";
		txtQuantity.TextAlign = HorizontalAlignment.Center;
		txtQuantity.Click += txtQuantity_Click;
		txtQuantity.KeyPress += txtQuantity_KeyPress;
		((RadTextBoxControlElement)txtQuantity.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtQuantity.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(0f, 5f);
		btnAdd.BackColor = Color.FromArgb(47, 204, 113);
		btnAdd.DialogResult = DialogResult.OK;
		btnAdd.FlatAppearance.BorderColor = Color.White;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnAdd, "btnAdd");
		btnAdd.ForeColor = Color.White;
		btnAdd.Name = "btnAdd";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += btnAdd_Click;
		lstUOM.BackColor = Color.White;
		lstUOM.DrawMode = DrawMode.OwnerDrawVariable;
		lstUOM.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(lstUOM, "lstUOM");
		lstUOM.ForeColor = Color.FromArgb(40, 40, 40);
		lstUOM.FormattingEnabled = true;
		lstUOM.Name = "lstUOM";
		lstUOM.TabStop = false;
		ChsfchqjoG.BackColor = Color.FromArgb(132, 146, 146);
		ChsfchqjoG.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(ChsfchqjoG, "label5");
		ChsfchqjoG.ForeColor = Color.White;
		ChsfchqjoG.Name = "label5";
		label4.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		componentResourceManager.ApplyResources(label3, "label3");
		label3.BackColor = Color.LemonChiffon;
		label3.Name = "label3";
		btnClearAll.BackColor = Color.FromArgb(255, 192, 128);
		btnClearAll.FlatAppearance.BorderColor = Color.Black;
		btnClearAll.FlatAppearance.BorderSize = 0;
		btnClearAll.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnClearAll, "btnClearAll");
		btnClearAll.ForeColor = Color.White;
		btnClearAll.Name = "btnClearAll";
		btnClearAll.UseVisualStyleBackColor = false;
		btnClearAll.Click += btnClearAll_Click;
		btnDeleteMaterial.BackColor = Color.FromArgb(235, 107, 86);
		btnDeleteMaterial.FlatAppearance.BorderColor = Color.White;
		btnDeleteMaterial.FlatAppearance.BorderSize = 0;
		btnDeleteMaterial.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnDeleteMaterial, "btnDeleteMaterial");
		btnDeleteMaterial.ForeColor = Color.White;
		btnDeleteMaterial.Name = "btnDeleteMaterial";
		btnDeleteMaterial.UseVisualStyleBackColor = false;
		btnDeleteMaterial.Click += btnDeleteMaterial_Click;
		btnReset.BackColor = Color.SandyBrown;
		btnReset.FlatAppearance.BorderColor = Color.Black;
		btnReset.FlatAppearance.BorderSize = 0;
		btnReset.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnReset, "btnReset");
		btnReset.ForeColor = Color.White;
		btnReset.Name = "btnReset";
		btnReset.UseVisualStyleBackColor = false;
		btnReset.Click += btnReset_Click;
		btnSave.BackColor = Color.FromArgb(47, 204, 113);
		btnSave.FlatAppearance.BorderColor = Color.White;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.ForeColor = Color.White;
		btnSave.Name = "btnSave";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		btnExit.BackColor = Color.FromArgb(235, 107, 86);
		btnExit.FlatAppearance.BorderColor = Color.White;
		btnExit.FlatAppearance.BorderSize = 0;
		btnExit.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnExit, "btnExit");
		btnExit.ForeColor = Color.White;
		btnExit.Name = "btnExit";
		btnExit.UseVisualStyleBackColor = false;
		btnExit.Click += btnExit_Click;
		lblItemName.BackColor = SystemColors.AppWorkspace;
		componentResourceManager.ApplyResources(lblItemName, "lblItemName");
		lblItemName.Name = "lblItemName";
		label1.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		lstMaterialsAddedToItem.BackColor = Color.White;
		lstMaterialsAddedToItem.BorderStyle = BorderStyle.None;
		lstMaterialsAddedToItem.Columns.AddRange(new ColumnHeader[4] { columnHeader_1, columnHeader_0, columnHeader_2, columnHeader_3 });
		componentResourceManager.ApplyResources(lstMaterialsAddedToItem, "lstMaterialsAddedToItem");
		lstMaterialsAddedToItem.ForeColor = Color.FromArgb(40, 40, 40);
		lstMaterialsAddedToItem.FullRowSelect = true;
		lstMaterialsAddedToItem.GridLines = true;
		lstMaterialsAddedToItem.HideSelection = false;
		lstMaterialsAddedToItem.Name = "lstMaterialsAddedToItem";
		lstMaterialsAddedToItem.UseCompatibleStateImageBehavior = false;
		lstMaterialsAddedToItem.View = View.Details;
		componentResourceManager.ApplyResources(columnHeader_1, "LVMaterialName");
		componentResourceManager.ApplyResources(columnHeader_0, "LVQuantity");
		componentResourceManager.ApplyResources(columnHeader_2, "LVUOM");
		componentResourceManager.ApplyResources(columnHeader_3, "LVComments");
		label19.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label19, "label19");
		label19.ForeColor = Color.White;
		label19.Name = "label19";
		lstMaterials.BackColor = Color.White;
		lstMaterials.DrawMode = DrawMode.OwnerDrawVariable;
		lstMaterials.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(lstMaterials, "lstMaterials");
		lstMaterials.ForeColor = Color.FromArgb(40, 40, 40);
		lstMaterials.FormattingEnabled = true;
		lstMaterials.Name = "lstMaterials";
		lstMaterials.TabStop = false;
		lstMaterials.SelectedIndexChanged += lstMaterials_SelectedIndexChanged;
		componentResourceManager.ApplyResources(lowerLabelAddItem, "lowerLabelAddItem");
		lowerLabelAddItem.AutoEllipsis = true;
		lowerLabelAddItem.BackColor = Color.FromArgb(147, 101, 184);
		lowerLabelAddItem.ForeColor = SystemColors.Control;
		lowerLabelAddItem.Name = "lowerLabelAddItem";
		btnConfigureUOM.BackColor = Color.FromArgb(77, 174, 225);
		btnConfigureUOM.DialogResult = DialogResult.OK;
		btnConfigureUOM.FlatAppearance.BorderColor = Color.Black;
		btnConfigureUOM.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnConfigureUOM, "btnConfigureUOM");
		btnConfigureUOM.ForeColor = Color.White;
		btnConfigureUOM.Name = "btnConfigureUOM";
		btnConfigureUOM.UseVisualStyleBackColor = false;
		btnConfigureUOM.Click += btnConfigureUOM_Click;
		lblSuggestedPriceByIngredients.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(lblSuggestedPriceByIngredients, "lblSuggestedPriceByIngredients");
		lblSuggestedPriceByIngredients.ForeColor = Color.White;
		lblSuggestedPriceByIngredients.Name = "lblSuggestedPriceByIngredients";
		lblSuggestedPriceByIngredients.Tag = "";
		label12.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label12, "label12");
		label12.ForeColor = Color.White;
		label12.Name = "label12";
		label12.Tag = "";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(label12);
		base.Controls.Add(lblSuggestedPriceByIngredients);
		base.Controls.Add(btnConfigureUOM);
		base.Controls.Add(btnShowKeyboard_Comments);
		base.Controls.Add(btnShowKeyboard_Quantity);
		base.Controls.Add(txtComments);
		base.Controls.Add(label2);
		base.Controls.Add(txtQuantity);
		base.Controls.Add(btnAdd);
		base.Controls.Add(lstUOM);
		base.Controls.Add(ChsfchqjoG);
		base.Controls.Add(label4);
		base.Controls.Add(label3);
		base.Controls.Add(btnClearAll);
		base.Controls.Add(btnDeleteMaterial);
		base.Controls.Add(btnReset);
		base.Controls.Add(btnSave);
		base.Controls.Add(btnExit);
		base.Controls.Add(lblItemName);
		base.Controls.Add(label1);
		base.Controls.Add(lstMaterialsAddedToItem);
		base.Controls.Add(label19);
		base.Controls.Add(lstMaterials);
		base.Controls.Add(lowerLabelAddItem);
		base.Name = "frmMaterialsInItem";
		base.Opacity = 1.0;
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.Load += frmMaterialsInItem_Load;
		((ISupportInitialize)txtComments).EndInit();
		((ISupportInitialize)txtQuantity).EndInit();
		ResumeLayout(performLayout: false);
	}
}
