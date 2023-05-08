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

public class ItemOptionControl : UserControl
{
	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private string string_0;

	private string string_1;

	public EventHandler chkPreselectOption_CheckedChanged;

	private GClass6 gclass6_0;

	private int int_1;

	private int int_2;

	private short short_0;

	private IContainer icontainer_0;

	private Label lblOptionName;

	private RadTextBoxControl inaJsyyrmO;

	private Class17 chkInclude;

	private Class17 chkAllowAdditional;

	private Label label1;

	private Label label2;

	private Class19 ddlOptionGroup;

	private RadTextBoxControl txtQty;

	private Label label3;

	private Class17 chkPreselect;

	private Class20 ddlColors;

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

	public int ItemOptionID
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public bool Included
	{
		get
		{
			return chkInclude.Checked;
		}
		set
		{
			chkInclude.Checked = value;
		}
	}

	public bool AllowAdditional
	{
		get
		{
			return chkAllowAdditional.Checked;
		}
		set
		{
			chkAllowAdditional.Checked = value;
		}
	}

	public string GroupOrderTypes
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public short GroupID
	{
		get
		{
			return Convert.ToInt16(((KeyValuePair<string, string>)ddlOptionGroup.SelectedItem).Key);
		}
		set
		{
			ddlOptionGroup.SelectedValue = value.ToString();
		}
	}

	public decimal Price
	{
		get
		{
			return Convert.ToDecimal(string.IsNullOrEmpty(((Control)(object)inaJsyyrmO).Text) ? "0" : ((Control)(object)inaJsyyrmO).Text.Trim());
		}
		set
		{
			((Control)(object)inaJsyyrmO).Text = value.ToString("0.00");
		}
	}

	public decimal Qty
	{
		get
		{
			return Convert.ToDecimal(string.IsNullOrEmpty(((Control)(object)txtQty).Text) ? "0" : ((Control)(object)txtQty).Text.Trim());
		}
		set
		{
			((Control)(object)txtQty).Text = value.ToString("0.0");
		}
	}

	public bool PreSelect
	{
		get
		{
			return chkPreselect.Checked;
		}
		set
		{
			chkPreselect.Checked = value;
		}
	}

	public ItemOptionControl(int _id, int _selectedItemID, string _selectedTab, short _optionGroupID, GClass6 _context)
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent();
		int_1 = _id;
		string_1 = _selectedTab;
		gclass6_0 = _context;
		int_2 = _selectedItemID;
		short_0 = _optionGroupID;
		base.HandleDestroyed += ItemOptionControl_HandleDestroyed;
	}

	private void ItemOptionControl_Load(object sender, EventArgs e)
	{
		Dictionary<string, string> groups = AdminMethods.getGroups(ItemClassifications.Option, withShowItems: false, onlyActive: true);
		groups.Remove(0.ToString());
		groups.Add(0.ToString(), "** No Option Group **");
		ddlOptionGroup.DisplayMember = "Value";
		ddlOptionGroup.ValueMember = "Key";
		ddlOptionGroup.DataSource = new BindingSource(groups, null);
		Dictionary<string, string> dictionary = HelperMethods.ButtonColors();
		dictionary.Remove("Red");
		((RadDropDownList)ddlColors).set_DisplayMember("Key");
		((RadDropDownList)ddlColors).set_ValueMember("Value");
		((RadDropDownList)ddlColors).set_DataSource((object)new BindingSource(dictionary, null));
		((RadDropDownList)ddlColors).set_SelectedValue((object)dictionary["Gray"]);
		method_0();
		chkPreselect.CheckedChanged += chkPreselectOption_CheckedChanged;
	}

	private void ItemOptionControl_HandleDestroyed(object sender, EventArgs e)
	{
		ddlOptionGroup.DataSource = null;
		foreach (Control control in base.Controls)
		{
			control.Dispose();
		}
		gclass6_0.Dispose();
	}

	public void Save(string Tab = "")
	{
		_003C_003Ec__DisplayClass39_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass39_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.Tab = Tab;
		if (Convert.ToDecimal(string.IsNullOrEmpty(((Control)(object)inaJsyyrmO).Text) ? "0" : ((Control)(object)inaJsyyrmO).Text) > 1000m)
		{
			new frmMessageBox("Price is too large.", "error").ShowDialog();
			return;
		}
		if (Convert.ToDecimal(string.IsNullOrEmpty(((Control)(object)txtQty).Text) ? "0" : ((Control)(object)txtQty).Text) > 1000m)
		{
			new frmMessageBox("Qty is too large.", "error").ShowDialog();
			return;
		}
		gclass6_0 = new GClass6();
		CS_0024_003C_003E8__locals0.groupID = Convert.ToInt16(((KeyValuePair<string, string>)ddlOptionGroup.SelectedItem).Key);
		CS_0024_003C_003E8__locals0.opt = gclass6_0.Options.Where((Option x) => x.ItemID == (int?)int_1).FirstOrDefault();
		if (CS_0024_003C_003E8__locals0.opt == null)
		{
			CS_0024_003C_003E8__locals0.opt = new Option();
			CS_0024_003C_003E8__locals0.opt.ItemID = int_1;
			CS_0024_003C_003E8__locals0.opt.Synced = false;
			gclass6_0.Options.InsertOnSubmit(CS_0024_003C_003E8__locals0.opt);
			Helper.SubmitChangesWithCatch(gclass6_0);
			gclass6_0.Refresh(RefreshMode.OverwriteCurrentValues);
		}
		ItemsWithOption itemsWithOption;
		if (ItemOptionID == 0)
		{
			itemsWithOption = gclass6_0.ItemsWithOptions.Where((ItemsWithOption a) => a.ItemID == (int?)int_2 && a.OptionID == (int?)CS_0024_003C_003E8__locals0.opt.OptionID && a.Tab.ToUpper() == CS_0024_003C_003E8__locals0.Tab.ToUpper() && a.GroupID == CS_0024_003C_003E8__locals0.groupID).FirstOrDefault();
			if (itemsWithOption == null)
			{
				itemsWithOption = new ItemsWithOption();
				itemsWithOption.ItemID = int_2;
				itemsWithOption.OptionID = CS_0024_003C_003E8__locals0.opt.OptionID;
				itemsWithOption.Tab = CS_0024_003C_003E8__locals0.Tab;
				itemsWithOption.OptionDependency = "0";
				gclass6_0.ItemsWithOptions.InsertOnSubmit(itemsWithOption);
			}
		}
		else
		{
			itemsWithOption = gclass6_0.ItemsWithOptions.Where((ItemsWithOption x) => x.ItemWithOptionID == ItemOptionID).FirstOrDefault();
			if (itemsWithOption == null)
			{
				new NotificationLabel(base.ParentForm, "Error occurred while attempting to save, please try again.", NotificationTypes.Notification).Show();
				return;
			}
		}
		itemsWithOption.GroupID = CS_0024_003C_003E8__locals0.groupID;
		itemsWithOption.AllowAdditional = chkAllowAdditional.Checked;
		itemsWithOption.Price = Convert.ToDecimal(string.IsNullOrEmpty(((Control)(object)inaJsyyrmO).Text) ? "0" : ((Control)(object)inaJsyyrmO).Text);
		itemsWithOption.Qty = Convert.ToDecimal(string.IsNullOrEmpty(((Control)(object)txtQty).Text) ? "0" : ((Control)(object)txtQty).Text);
		itemsWithOption.Synced = false;
		itemsWithOption.ToBeDeleted = false;
		itemsWithOption.Color = ((RadDropDownList)ddlColors).get_SelectedValue().ToString();
		itemsWithOption.Preselect = chkPreselect.Checked;
		itemsWithOption.GroupOrderTypes = GroupOrderTypes;
		Helper.SubmitChangesWithCatch(gclass6_0);
		ItemOptionID = itemsWithOption.ItemWithOptionID;
	}

	public void Delete(string Tab)
	{
		_003C_003Ec__DisplayClass40_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass40_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.Tab = Tab;
		gclass6_0 = new GClass6();
		CS_0024_003C_003E8__locals0.opt = gclass6_0.Options.Where((Option x) => x.ItemID == (int?)int_1).ToList();
		if (CS_0024_003C_003E8__locals0.opt == null)
		{
			return;
		}
		ItemsWithOption itemsWithOption = gclass6_0.ItemsWithOptions.Where((ItemsWithOption x) => x.ItemID == (int?)int_2 && CS_0024_003C_003E8__locals0.opt.Select((Option a) => a.OptionID).Contains(x.OptionID.Value) && x.ToBeDeleted == false && x.Tab.ToUpper() == CS_0024_003C_003E8__locals0.Tab.ToUpper()).FirstOrDefault();
		if (itemsWithOption != null)
		{
			itemsWithOption.ToBeDeleted = true;
			itemsWithOption.Synced = false;
			Helper.SubmitChangesWithCatch(gclass6_0);
			ItemOptionID = 0;
		}
	}

	private void method_0()
	{
		Item item = gclass6_0.Items.Where((Item x) => x.ItemID == int_1).FirstOrDefault();
		if (item == null)
		{
			return;
		}
		_003C_003Ec__DisplayClass41_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass41_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		lblOptionName.Text = item.ItemName;
		CS_0024_003C_003E8__locals0.opt = gclass6_0.Options.Where((Option x) => x.ItemID == (int?)int_1).ToList();
		ItemsWithOption itemsWithOption = null;
		if (CS_0024_003C_003E8__locals0.opt != null)
		{
			itemsWithOption = gclass6_0.ItemsWithOptions.Where((ItemsWithOption x) => x.ItemID == (int?)int_2 && CS_0024_003C_003E8__locals0.opt.Select((Option a) => a.OptionID).Contains(x.OptionID.Value) && x.Tab == string_1 && x.GroupID == short_0 && x.ToBeDeleted == false).FirstOrDefault();
		}
		if (itemsWithOption != null)
		{
			ItemOptionID = itemsWithOption.ItemWithOptionID;
			chkInclude.Checked = true;
			chkAllowAdditional.Checked = itemsWithOption.AllowAdditional;
			chkPreselect.Checked = itemsWithOption.Preselect;
			((Control)(object)inaJsyyrmO).Text = itemsWithOption.Price.ToString("0.00");
			((Control)(object)txtQty).Text = itemsWithOption.Qty.ToString("0.0");
			ddlOptionGroup.SelectedValue = itemsWithOption.GroupID.ToString();
			string selectedValue = itemsWithOption.Color;
			if (string.IsNullOrEmpty(itemsWithOption.Color))
			{
				selectedValue = HelperMethods.ButtonColors()["Gray"];
			}
			((RadDropDownList)ddlColors).set_SelectedValue((object)selectedValue);
		}
	}

	public bool checkIfValueIsValid()
	{
		if (((Control)(object)inaJsyyrmO).Text != string.Empty && !decimal.TryParse(((Control)(object)inaJsyyrmO).Text, out var _))
		{
			new NotificationLabel(base.ParentForm, Resources.Please_Input_a_valid_number_de + lblOptionName.Text + "\"", NotificationTypes.Notification).Show();
			return false;
		}
		return true;
	}

	public void EnableAllowAdditional(bool enable)
	{
		if (enable)
		{
			chkAllowAdditional.Enabled = enable;
			return;
		}
		Class17 @class = chkAllowAdditional;
		Class17 class2 = chkAllowAdditional;
		bool flag2 = (AllowAdditional = enable);
		bool enabled = (class2.Checked = flag2);
		@class.Enabled = enabled;
	}

	public void EnablePreselect(bool enable)
	{
		chkPreselect.Checked = enable;
	}

	private void inaJsyyrmO_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Option_Price, 2, 8, ((Control)(object)inaJsyyrmO).Text, "", allowNegative: false, useNotifLabel: true);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)inaJsyyrmO).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString("0.00");
		}
	}

	private void txtQty_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Option Qty, Enter 0 For Unlimited", 1, 3, ((Control)(object)txtQty).Text, "", allowNegative: false, useNotifLabel: true);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtQty).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString("0.0");
		}
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
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.ItemOptionControl));
		this.lblOptionName = new System.Windows.Forms.Label();
		this.inaJsyyrmO = new RadTextBoxControl();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.txtQty = new RadTextBoxControl();
		this.ddlOptionGroup = new Class19();
		this.chkAllowAdditional = new Class17();
		this.chkInclude = new Class17();
		this.label3 = new System.Windows.Forms.Label();
		this.chkPreselect = new Class17();
		this.ddlColors = new Class20();
		((System.ComponentModel.ISupportInitialize)this.inaJsyyrmO).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtQty).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.ddlColors).BeginInit();
		base.SuspendLayout();
		this.lblOptionName.BackColor = System.Drawing.Color.White;
		resources.ApplyResources(this.lblOptionName, "lblOptionName");
		this.lblOptionName.ForeColor = System.Drawing.Color.FromArgb(44, 44, 44);
		this.lblOptionName.Name = "lblOptionName";
		this.lblOptionName.UseMnemonic = false;
		((System.Windows.Forms.Control)(object)this.inaJsyyrmO).BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
		resources.ApplyResources(this.inaJsyyrmO, "txtPrice");
		((System.Windows.Forms.Control)(object)this.inaJsyyrmO).ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		((System.Windows.Forms.Control)(object)this.inaJsyyrmO).Name = "txtPrice";
		((RadElement)((RadControl)this.inaJsyyrmO).get_RootElement()).set_MinSize(new System.Drawing.Size(65, 29));
		((RadElement)((RadControl)this.inaJsyyrmO).get_RootElement()).set_PositionOffset(new System.Drawing.SizeF(0f, 0f));
		this.inaJsyyrmO.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
		((System.Windows.Forms.Control)(object)this.inaJsyyrmO).Click += new System.EventHandler(inaJsyyrmO_Click);
		((UIItemBase)(RadTextBoxControlElement)((RadControl)this.inaJsyyrmO).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(RadTextBoxControlElement)((RadControl)this.inaJsyyrmO).GetChildAt(0)).set_Padding((System.Windows.Forms.Padding)resources.GetObject("resource.Padding"));
		((RadElement)(TextBoxViewElement)((RadControl)this.inaJsyyrmO).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new System.Drawing.SizeF(5f, 5f));
		this.label1.BackColor = System.Drawing.Color.White;
		resources.ApplyResources(this.label1, "label1");
		this.label1.Name = "label1";
		this.label2.BackColor = System.Drawing.Color.White;
		resources.ApplyResources(this.label2, "label2");
		this.label2.Name = "label2";
		((System.Windows.Forms.Control)(object)this.txtQty).BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
		resources.ApplyResources(this.txtQty, "txtQty");
		((System.Windows.Forms.Control)(object)this.txtQty).ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		((System.Windows.Forms.Control)(object)this.txtQty).Name = "txtQty";
		((RadElement)((RadControl)this.txtQty).get_RootElement()).set_MinSize(new System.Drawing.Size(0, 0));
		((RadElement)((RadControl)this.txtQty).get_RootElement()).set_PositionOffset(new System.Drawing.SizeF(0f, 0f));
		this.txtQty.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
		((System.Windows.Forms.Control)(object)this.txtQty).Click += new System.EventHandler(txtQty_Click);
		((UIItemBase)(RadTextBoxControlElement)((RadControl)this.txtQty).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(RadTextBoxControlElement)((RadControl)this.txtQty).GetChildAt(0)).set_Padding((System.Windows.Forms.Padding)resources.GetObject("resource.Padding1"));
		((RadElement)(TextBoxViewElement)((RadControl)this.txtQty).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new System.Drawing.SizeF(5f, 5f));
		this.ddlOptionGroup.BackColor = System.Drawing.Color.White;
		this.ddlOptionGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ddlOptionGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		resources.ApplyResources(this.ddlOptionGroup, "ddlOptionGroup");
		this.ddlOptionGroup.FormattingEnabled = true;
		this.ddlOptionGroup.Name = "ddlOptionGroup";
		resources.ApplyResources(this.chkAllowAdditional, "chkAllowAdditional");
		this.chkAllowAdditional.Name = "chkAllowAdditional";
		this.chkAllowAdditional.UseVisualStyleBackColor = true;
		resources.ApplyResources(this.chkInclude, "chkInclude");
		this.chkInclude.Name = "chkInclude";
		this.chkInclude.UseVisualStyleBackColor = true;
		this.label3.BackColor = System.Drawing.Color.White;
		resources.ApplyResources(this.label3, "label3");
		this.label3.Name = "label3";
		resources.ApplyResources(this.chkPreselect, "chkPreselect");
		this.chkPreselect.Name = "chkPreselect";
		this.chkPreselect.UseVisualStyleBackColor = true;
		resources.ApplyResources(this.ddlColors, "ddlColors");
		((System.Windows.Forms.Control)(object)this.ddlColors).BackColor = System.Drawing.Color.White;
		((RadDropDownList)this.ddlColors).set_DropDownStyle((RadDropDownStyle)2);
		((RadDropDownList)this.ddlColors).set_EnableKineticScrolling(true);
		((System.Windows.Forms.Control)(object)this.ddlColors).Name = "ddlColors";
		((RadElement)((RadControl)this.ddlColors).get_RootElement()).set_MinSize(new System.Drawing.Size(0, 0));
		((System.Windows.Forms.Control)(object)this.ddlColors).Tag = "product";
		((RadControl)this.ddlColors).set_ThemeName("Windows8");
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		this.BackColor = System.Drawing.Color.LightGray;
		base.Controls.Add((System.Windows.Forms.Control)(object)this.ddlColors);
		base.Controls.Add(this.chkPreselect);
		base.Controls.Add(this.label3);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.txtQty);
		base.Controls.Add(this.ddlOptionGroup);
		base.Controls.Add(this.chkAllowAdditional);
		base.Controls.Add(this.chkInclude);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.inaJsyyrmO);
		base.Controls.Add(this.lblOptionName);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.label2);
		this.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		resources.ApplyResources(this, "$this");
		base.Name = "ItemOptionControl";
		base.Load += new System.EventHandler(ItemOptionControl_Load);
		((System.ComponentModel.ISupportInitialize)this.inaJsyyrmO).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtQty).EndInit();
		((System.ComponentModel.ISupportInitialize)this.ddlColors).EndInit();
		base.ResumeLayout(false);
	}
}
