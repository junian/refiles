using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class InventoryItemControl : UserControl
{
	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private bool bool_1;

	private GClass6 gclass6_0;

	private Item item_0;

	private int int_0;

	private string string_0;

	private bool bool_2;

	private bool bool_3;

	private string string_1;

	private bool bool_4;

	private IContainer icontainer_0;

	private Label lblItemName;

	private Label lblGroupName;

	internal Button btnEdit;

	internal Button btnViewLogs;

	private Label lblUOM;

	private Label txtQtyCurrent;

	private RadTextBoxControl txtQtyChange;

	private RadTextBoxControl txtQtyNew;

	private RadTextBoxControl txtComment;

	internal Button btnOtherLoc;

	public bool isLoaded
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public bool isSaveNeeded
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public InventoryItemControl(Item _item, string _type, string _user, bool _readOnly, GClass6 _context, FlowLayoutPanel _PanelItems)
	{
		Class26.Ggkj0JxzN9YmC();
		bool_4 = true;
		base._002Ector();
		InitializeComponent();
		item_0 = _item;
		string_0 = _type;
		gclass6_0 = _context;
		string_1 = _user;
		bool_4 = _readOnly;
		isLoaded = false;
		isSaveNeeded = false;
		base.Width = _PanelItems.Width - 20;
		lblGroupName.Width = ControlHelpers.ControlWidthFixer(_PanelItems, 2.0);
		lblItemName.Width = ControlHelpers.ControlWidthFixer(_PanelItems, 2.0) - 2;
		lblItemName.Left = ControlHelpers.ControlWidthFixer(_PanelItems, 2.0) + 1;
		lblUOM.Width = ControlHelpers.ControlWidthFixer(_PanelItems, 1.0) - 1;
		lblUOM.Left = ControlHelpers.ControlWidthFixer(_PanelItems, 4.0);
		txtQtyCurrent.Width = ControlHelpers.ControlWidthFixer(_PanelItems, 1.0) - 1;
		txtQtyCurrent.Left = ControlHelpers.ControlWidthFixer(_PanelItems, 5.0) + 1;
		((Control)(object)txtQtyChange).Width = ControlHelpers.ControlWidthFixer(_PanelItems, 1.0) - 1;
		((Control)(object)txtQtyChange).Left = ControlHelpers.ControlWidthFixer(_PanelItems, 6.0) + 1;
		((Control)(object)txtQtyNew).Width = ControlHelpers.ControlWidthFixer(_PanelItems, 1.0) - 1;
		((Control)(object)txtQtyNew).Left = ControlHelpers.ControlWidthFixer(_PanelItems, 7.0) + 1;
		if (MemoryLoadedObjects.isMultipleLocation)
		{
			((Control)(object)txtComment).Width = ControlHelpers.ControlWidthFixer(_PanelItems, 1.0) - 1;
			((Control)(object)txtComment).Left = ((Control)(object)txtQtyNew).Right + 2;
			btnEdit.Width = ControlHelpers.ControlWidthFixer(_PanelItems, 1.0) - 15;
			btnEdit.Left = ((Control)(object)txtComment).Right + 1;
			btnViewLogs.Width = ControlHelpers.ControlWidthFixer(_PanelItems, 1.0);
			btnViewLogs.Left = btnEdit.Right + 1;
			btnOtherLoc.Width = ControlHelpers.ControlWidthFixer(_PanelItems, 1.0);
			btnOtherLoc.Left = btnViewLogs.Right + 1;
		}
		else
		{
			((Control)(object)txtComment).Width = ControlHelpers.ControlWidthFixer(_PanelItems, 2.0) - 1;
			((Control)(object)txtComment).Left = ((Control)(object)txtQtyNew).Right + 2;
			btnEdit.Width = ControlHelpers.ControlWidthFixer(_PanelItems, 1.0) - 15;
			btnEdit.Left = ((Control)(object)txtComment).Right + 1;
			btnViewLogs.Width = ControlHelpers.ControlWidthFixer(_PanelItems, 1.0);
			btnViewLogs.Left = btnEdit.Right + 1;
			btnOtherLoc.Visible = false;
		}
	}

	private void InventoryItemControl_Load(object sender, EventArgs e)
	{
		method_0();
	}

	private void method_0()
	{
		lblItemName.Text = item_0.ItemName;
		try
		{
			lblGroupName.Text = item_0.ItemsInGroups.FirstOrDefault().Group.GroupName;
		}
		catch
		{
			lblGroupName.Text = string.Empty;
		}
		txtQtyCurrent.Text = MathHelper.RemoveTrailingZeros(item_0.InventoryCount.ToString("0.0000"));
		if (!item_0.UOM.isFractional)
		{
			txtQtyCurrent.Text = Math.Round(item_0.InventoryCount, 0).ToString();
		}
		lblUOM.Text = item_0.UOM.Name;
		RadTextBoxControl obj2 = txtQtyChange;
		RadTextBoxControl obj3 = txtQtyNew;
		Button button = btnEdit;
		Button button2 = btnViewLogs;
		bool flag2 = (((Control)(object)txtComment).Enabled = !bool_4);
		bool flag4 = (button2.Enabled = flag2);
		bool flag6 = (button.Enabled = flag4);
		bool enabled = (((Control)(object)obj3).Enabled = flag6);
		((Control)(object)obj2).Enabled = enabled;
		txtQtyChange.set_MaxLength(11);
		txtQtyNew.set_MaxLength(11);
	}

	public bool checkIfEntryExist()
	{
		if (((Control)(object)txtQtyNew).Text != string.Empty)
		{
			return true;
		}
		return false;
	}

	public bool checkIfValueIsValid()
	{
		if (((Control)(object)txtQtyNew).Text != string.Empty)
		{
			if (!decimal.TryParse(((Control)(object)txtQtyChange).Text, out var result) || !decimal.TryParse(((Control)(object)txtQtyNew).Text, out result))
			{
				new frmMessageBox(Resources.Please_Input_a_valid_number_de + lblItemName.Text + "\"").ShowDialog(this);
				return false;
			}
			if (!item_0.UOM.isFractional && result % 1m != 0m)
			{
				new frmMessageBox("Please Input a valid UOM number on " + lblItemName.Text + "\"").ShowDialog(this);
				return false;
			}
		}
		return true;
	}

	public bool Save(string Note = "")
	{
		bool result = false;
		if (((Control)(object)txtQtyNew).Text != string.Empty)
		{
			_ = item_0.ItemID;
			gclass6_0.Refresh(RefreshMode.OverwriteCurrentValues, item_0);
			decimal num = Convert.ToDecimal(((Control)(object)txtQtyNew).Text.Trim());
			decimal inventoryCount = item_0.InventoryCount;
			bool flag = false;
			Note = ((Note == "") ? "" : (Note + ". "));
			string text = ((!(((Control)(object)txtComment).Text == "") || !(Note == "")) ? (Note + ((Control)(object)txtComment).Text) : (Resources.Inventory_Update_by + string_1));
			if (item_0.TrackExpiryDate && item_0.TrackInventory && num > inventoryCount)
			{
				frmAddInventoryBatches frmAddInventoryBatches2 = new frmAddInventoryBatches(item_0.ItemID, num - inventoryCount);
				if (frmAddInventoryBatches2.ShowDialog(this) == DialogResult.OK)
				{
					text = text + ", Batch/Lot #: " + frmAddInventoryBatches2.BatchNumber;
					flag = true;
				}
				frmAddInventoryBatches2.Dispose();
			}
			if (item_0.TrackExpiryDate && item_0.TrackInventory && num < inventoryCount)
			{
				frmReduceInventoryBatch frmReduceInventoryBatch2 = new frmReduceInventoryBatch(item_0.ItemID, inventoryCount - num);
				if (frmReduceInventoryBatch2.ShowDialog(this) == DialogResult.OK)
				{
					text = text + ", Batch/Lot #: " + frmReduceInventoryBatch2.BatchNumbers;
					flag = true;
				}
				frmReduceInventoryBatch2.Dispose();
			}
			if (!item_0.TrackExpiryDate && item_0.TrackInventory && num != inventoryCount)
			{
				flag = true;
			}
			if (flag)
			{
				try
				{
					item_0.Synced = false;
					item_0.InventoryCount = Convert.ToDecimal(((Control)(object)txtQtyNew).Text.Trim());
					Helper.SubmitChangesWithCatch(gclass6_0);
				}
				catch
				{
					foreach (ObjectChangeConflict changeConflict in gclass6_0.ChangeConflicts)
					{
						changeConflict.Resolve(RefreshMode.KeepChanges);
					}
				}
				decimal num2 = num - inventoryCount;
				int supplierId = 0;
				if (num2 > 0m)
				{
					List<Supplier> itemsSuppliers = AdminMethods.GetItemsSuppliers(item_0.ItemID);
					if (itemsSuppliers.Count > 0)
					{
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						foreach (Supplier item in itemsSuppliers)
						{
							dictionary.Add(item.Id.ToString(), item.Name);
						}
						frmDDLSelector frmDDLSelector2 = new frmDDLSelector("Select Supplier", dictionary);
						if (frmDDLSelector2.ShowDialog(this) == DialogResult.OK)
						{
							supplierId = Convert.ToInt32(frmDDLSelector2.SelectedValue);
						}
					}
				}
				new InventoryMethods(gclass6_0).LogInventoryChange(item_0.ItemID, inventoryCount, num2, num, string_1, text, supplierId, string_0);
				result = true;
			}
		}
		else
		{
			result = true;
		}
		return result;
	}

	private void btnEdit_Click(object sender, EventArgs e)
	{
		if (string_0 == "product")
		{
			new frmAddEditItems(item_0.ItemID, ItemClassifications.Product).ShowDialog(this);
		}
		else if (string_0 == "material")
		{
			new frmAddEditMaterials(item_0.ItemID).ShowDialog(this);
		}
		gclass6_0.Refresh(RefreshMode.OverwriteCurrentValues, item_0);
		method_0();
		string text2 = (((Control)(object)txtQtyChange).Text = (((Control)(object)txtQtyNew).Text = string.Empty));
	}

	private void method_1(object sender, EventArgs e)
	{
	}

	private void txtQtyChange_TextChanged(object sender, EventArgs e)
	{
		if (bool_3)
		{
			return;
		}
		bool_2 = true;
		if (((Control)(object)txtQtyChange).Text.Trim() == string.Empty)
		{
			((Control)(object)txtQtyNew).Text = string.Empty;
			isSaveNeeded = false;
		}
		else
		{
			decimal result = default(decimal);
			decimal.TryParse(((Control)(object)txtQtyChange).Text.Trim(), out result);
			decimal num = item_0.InventoryCount + result;
			if (num < 0m && item_0.InventoryCount >= 0m)
			{
				new frmMessageBox(Resources.This_change_will_result_in_a_n, Resources.Invalid_Quantity_Entered).ShowDialog(this);
				((Control)(object)txtQtyChange).Text = string.Empty;
			}
			else if (num > 999999m)
			{
				new frmMessageBox(Resources.Inventory_limit_reached_Please, Resources.Invalid_Quantity_Entered).ShowDialog(this);
				if (((Control)(object)txtQtyChange).Text.Length > 6)
				{
					((Control)(object)txtQtyChange).Text = ((Control)(object)txtQtyChange).Text.Substring(0, 6);
				}
				if (((Control)(object)txtQtyNew).Text.Length > 6)
				{
					((Control)(object)txtQtyNew).Text = ((Control)(object)txtQtyNew).Text.Substring(0, 6);
				}
			}
			else
			{
				((Control)(object)txtQtyNew).Text = MathHelper.RemoveTrailingZeros(num.ToString("0.0000"));
			}
			isSaveNeeded = true;
		}
		bool_2 = false;
	}

	private void txtQtyChange_KeyPress(object sender, KeyPressEventArgs e)
	{
		TextFilters.NumbersWithSingleDecimalPoint(sender, e);
	}

	private void method_2(object sender, EventArgs e)
	{
	}

	private void txtQtyNew_TextChanged(object sender, EventArgs e)
	{
		if (bool_2)
		{
			return;
		}
		bool_3 = true;
		if (((Control)(object)txtQtyNew).Text.Trim() == string.Empty)
		{
			((Control)(object)txtQtyChange).Text = string.Empty;
			isSaveNeeded = false;
		}
		else
		{
			decimal result = default(decimal);
			decimal.TryParse(((Control)(object)txtQtyNew).Text.Trim(), out result);
			if (result > 999999m)
			{
				new frmMessageBox(Resources.Inventory_limit_reached_Please, Resources.Invalid_Quantity_Entered).ShowDialog(this);
				if (((Control)(object)txtQtyChange).Text.Length > 6)
				{
					((Control)(object)txtQtyChange).Text = ((Control)(object)txtQtyChange).Text.Substring(0, 6);
				}
				if (((Control)(object)txtQtyNew).Text.Length > 6)
				{
					((Control)(object)txtQtyNew).Text = ((Control)(object)txtQtyNew).Text.Substring(0, 6);
				}
			}
			else if (result >= 0m)
			{
				decimal num = result - item_0.InventoryCount;
				((Control)(object)txtQtyChange).Text = MathHelper.RemoveTrailingZeros(num.ToString("0.0000"));
			}
			else
			{
				new frmMessageBox(Resources.You_cannot_change_the_inventor, Resources.Invalid_Quantity_Entered).ShowDialog(this);
				string text2 = (((Control)(object)txtQtyNew).Text = (((Control)(object)txtQtyChange).Text = string.Empty));
			}
			isSaveNeeded = true;
		}
		bool_3 = false;
	}

	private void txtQtyNew_KeyPress(object sender, KeyPressEventArgs e)
	{
		TextFilters.NumbersWithSingleDecimalPoint(sender, e);
	}

	private void btnViewLogs_Click(object sender, EventArgs e)
	{
		if (string_0 == "product")
		{
			new frmInventoryAuditView(item_0.ItemID, item_0.ItemName).ShowDialog(this);
		}
		else if (string_0 == "material")
		{
			new frmInventoryAuditView(item_0.ItemID, item_0.ItemName, "material").ShowDialog(this);
		}
	}

	private void txtQtyChange_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_A_Change, 2, 6, ((Control)(object)txtQtyChange).Text, "", allowNegative: true);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtQtyChange).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
	}

	private void txtQtyNew_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_A_New_Quantity, 0, 8, ((Control)(object)txtQtyNew).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtQtyNew).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
	}

	private void txtComment_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Notes, 1, 128, ((Control)(object)txtComment).Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtComment).Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
	}

	private void btnOtherLoc_Click(object sender, EventArgs e)
	{
		new frmInventoryOtherLocation(item_0.ItemID).ShowDialog();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_052f: Unknown result type (might be due to invalid IL or missing references)
		//IL_054a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0576: Unknown result type (might be due to invalid IL or missing references)
		//IL_064c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0667: Unknown result type (might be due to invalid IL or missing references)
		//IL_0693: Unknown result type (might be due to invalid IL or missing references)
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.InventoryItemControl));
		this.lblItemName = new System.Windows.Forms.Label();
		this.lblGroupName = new System.Windows.Forms.Label();
		this.btnEdit = new System.Windows.Forms.Button();
		this.btnViewLogs = new System.Windows.Forms.Button();
		this.lblUOM = new System.Windows.Forms.Label();
		this.txtQtyCurrent = new System.Windows.Forms.Label();
		this.txtQtyChange = new RadTextBoxControl();
		this.txtQtyNew = new RadTextBoxControl();
		this.txtComment = new RadTextBoxControl();
		this.btnOtherLoc = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)this.txtQtyChange).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtQtyNew).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtComment).BeginInit();
		base.SuspendLayout();
		resources.ApplyResources(this.lblItemName, "lblItemName");
		this.lblItemName.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		this.lblItemName.Name = "lblItemName";
		this.lblItemName.UseMnemonic = false;
		this.lblGroupName.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		resources.ApplyResources(this.lblGroupName, "lblGroupName");
		this.lblGroupName.Name = "lblGroupName";
		this.lblGroupName.UseMnemonic = false;
		this.btnEdit.BackColor = System.Drawing.Color.FromArgb(53, 152, 220);
		this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnEdit.FlatAppearance.BorderSize = 0;
		this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		resources.ApplyResources(this.btnEdit, "btnEdit");
		this.btnEdit.ForeColor = System.Drawing.Color.White;
		this.btnEdit.Name = "btnEdit";
		this.btnEdit.UseVisualStyleBackColor = false;
		this.btnEdit.Click += new System.EventHandler(btnEdit_Click);
		this.btnViewLogs.BackColor = System.Drawing.Color.SandyBrown;
		this.btnViewLogs.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnViewLogs.FlatAppearance.BorderSize = 0;
		this.btnViewLogs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		resources.ApplyResources(this.btnViewLogs, "btnViewLogs");
		this.btnViewLogs.ForeColor = System.Drawing.Color.White;
		this.btnViewLogs.Name = "btnViewLogs";
		this.btnViewLogs.UseVisualStyleBackColor = false;
		this.btnViewLogs.Click += new System.EventHandler(btnViewLogs_Click);
		this.lblUOM.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		resources.ApplyResources(this.lblUOM, "lblUOM");
		this.lblUOM.Name = "lblUOM";
		this.txtQtyCurrent.BackColor = System.Drawing.Color.White;
		resources.ApplyResources(this.txtQtyCurrent, "txtQtyCurrent");
		this.txtQtyCurrent.Name = "txtQtyCurrent";
		resources.ApplyResources(this.txtQtyChange, "txtQtyChange");
		((System.Windows.Forms.Control)(object)this.txtQtyChange).BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
		((System.Windows.Forms.Control)(object)this.txtQtyChange).ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		((System.Windows.Forms.Control)(object)this.txtQtyChange).Name = "txtQtyChange";
		((RadElement)((RadControl)this.txtQtyChange).get_RootElement()).set_MinSize(new System.Drawing.Size(65, 30));
		((RadElement)((RadControl)this.txtQtyChange).get_RootElement()).set_PositionOffset(new System.Drawing.SizeF(0f, 0f));
		this.txtQtyChange.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
		((System.Windows.Forms.Control)(object)this.txtQtyChange).TextChanged += new System.EventHandler(txtQtyChange_TextChanged);
		((System.Windows.Forms.Control)(object)this.txtQtyChange).Click += new System.EventHandler(txtQtyChange_Click);
		((System.Windows.Forms.Control)(object)this.txtQtyChange).KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtQtyChange_KeyPress);
		((UIItemBase)(RadTextBoxControlElement)((RadControl)this.txtQtyChange).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(RadTextBoxControlElement)((RadControl)this.txtQtyChange).GetChildAt(0)).set_Padding((System.Windows.Forms.Padding)resources.GetObject("resource.Padding"));
		((RadElement)(TextBoxViewElement)((RadControl)this.txtQtyChange).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new System.Drawing.SizeF(5f, 5f));
		resources.ApplyResources(this.txtQtyNew, "txtQtyNew");
		((System.Windows.Forms.Control)(object)this.txtQtyNew).BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
		((System.Windows.Forms.Control)(object)this.txtQtyNew).ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		((System.Windows.Forms.Control)(object)this.txtQtyNew).Name = "txtQtyNew";
		((RadElement)((RadControl)this.txtQtyNew).get_RootElement()).set_MinSize(new System.Drawing.Size(65, 30));
		((RadElement)((RadControl)this.txtQtyNew).get_RootElement()).set_PositionOffset(new System.Drawing.SizeF(0f, 0f));
		this.txtQtyNew.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
		((System.Windows.Forms.Control)(object)this.txtQtyNew).TextChanged += new System.EventHandler(txtQtyNew_TextChanged);
		((System.Windows.Forms.Control)(object)this.txtQtyNew).Click += new System.EventHandler(txtQtyNew_Click);
		((System.Windows.Forms.Control)(object)this.txtQtyNew).KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtQtyNew_KeyPress);
		((UIItemBase)(RadTextBoxControlElement)((RadControl)this.txtQtyNew).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(RadTextBoxControlElement)((RadControl)this.txtQtyNew).GetChildAt(0)).set_Padding((System.Windows.Forms.Padding)resources.GetObject("resource.Padding1"));
		((RadElement)(TextBoxViewElement)((RadControl)this.txtQtyNew).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new System.Drawing.SizeF(5f, 5f));
		resources.ApplyResources(this.txtComment, "txtComment");
		((System.Windows.Forms.Control)(object)this.txtComment).BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
		((System.Windows.Forms.Control)(object)this.txtComment).ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		((System.Windows.Forms.Control)(object)this.txtComment).Name = "txtComment";
		((RadElement)((RadControl)this.txtComment).get_RootElement()).set_MinSize(new System.Drawing.Size(70, 30));
		((RadElement)((RadControl)this.txtComment).get_RootElement()).set_PositionOffset(new System.Drawing.SizeF(0f, 0f));
		this.txtComment.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
		((System.Windows.Forms.Control)(object)this.txtComment).Click += new System.EventHandler(txtComment_Click);
		((UIItemBase)(RadTextBoxControlElement)((RadControl)this.txtComment).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(RadTextBoxControlElement)((RadControl)this.txtComment).GetChildAt(0)).set_Padding((System.Windows.Forms.Padding)resources.GetObject("resource.Padding2"));
		((RadElement)(TextBoxViewElement)((RadControl)this.txtComment).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new System.Drawing.SizeF(5f, 5f));
		this.btnOtherLoc.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		this.btnOtherLoc.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnOtherLoc.FlatAppearance.BorderSize = 0;
		this.btnOtherLoc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		resources.ApplyResources(this.btnOtherLoc, "btnOtherLoc");
		this.btnOtherLoc.ForeColor = System.Drawing.Color.White;
		this.btnOtherLoc.Name = "btnOtherLoc";
		this.btnOtherLoc.UseVisualStyleBackColor = false;
		this.btnOtherLoc.Click += new System.EventHandler(btnOtherLoc_Click);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		this.BackColor = System.Drawing.Color.FromArgb(35, 39, 56);
		base.Controls.Add(this.btnOtherLoc);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.txtQtyNew);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.txtQtyChange);
		base.Controls.Add(this.txtQtyCurrent);
		base.Controls.Add(this.lblUOM);
		base.Controls.Add(this.lblGroupName);
		base.Controls.Add(this.lblItemName);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.txtComment);
		base.Controls.Add(this.btnEdit);
		base.Controls.Add(this.btnViewLogs);
		this.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		resources.ApplyResources(this, "$this");
		base.Name = "InventoryItemControl";
		base.Load += new System.EventHandler(InventoryItemControl_Load);
		((System.ComponentModel.ISupportInitialize)this.txtQtyChange).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtQtyNew).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtComment).EndInit();
		base.ResumeLayout(false);
	}
}
