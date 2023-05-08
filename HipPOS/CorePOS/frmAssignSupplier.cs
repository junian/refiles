using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Data;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmAssignSupplier : frmMasterForm
{
	[CompilerGenerated]
	private List<int> list_2;

	private Dictionary<string, string> dictionary_0;

	private IContainer icontainer_1;

	internal Button btnShowKeyboard_Supplier;

	private RadTextBoxControl txtSupplier;

	private Label lblTitle;

	private Class19 ddlSupplier;

	private Label label4;

	private Label lblItemName;

	private Label label1;

	private ListView lstSupplier;

	private ColumnHeader columnHeader_0;

	internal Button btnAddSupplierToitem;

	internal Button btnClearAll;

	internal Button btnDeleteItem;

	internal Button btnReset;

	internal Button btnSave;

	internal Button btnExit;

	public List<int> supplierIds
	{
		[CompilerGenerated]
		get
		{
			return list_2;
		}
		[CompilerGenerated]
		set
		{
			list_2 = value;
		}
	}

	public frmAssignSupplier(string itemName, List<int> supplierIds)
	{
		Class26.Ggkj0JxzN9YmC();
		dictionary_0 = new Dictionary<string, string>();
		base._002Ector();
		InitializeComponent_1();
		lblItemName.Text = itemName;
		this.supplierIds = supplierIds;
		base.FormClosing += frmAssignSupplier_FormClosing;
	}

	private void frmAssignSupplier_Load(object sender, EventArgs e)
	{
		((Control)(object)txtSupplier).GotFocus += txtSupplier_GotFocus;
		((Control)(object)txtSupplier).LostFocus += txtSupplier_LostFocus;
		method_3();
		method_4();
	}

	private void frmAssignSupplier_FormClosing(object sender, EventArgs e)
	{
		lstSupplier.Items.Clear();
		btnAddSupplierToitem.Image = null;
		ControlHelpers.ClearControlsInControl(lstSupplier);
		ControlHelpers.ClearControlsInForm(this);
		ddlSupplier.DataSource = null;
		ddlSupplier = null;
		dictionary_0 = null;
		Dispose(disposing: true);
		GC.Collect();
	}

	private void method_3()
	{
		GClass6 gClass = new GClass6();
		dictionary_0 = new Dictionary<string, string>();
		foreach (Supplier item in gClass.Suppliers.ToList())
		{
			dictionary_0.Add(item.Id.ToString(), item.Name);
		}
		dictionary_0.Add("0", "+Add New");
		ddlSupplier.DataSource = new BindingSource(dictionary_0, null);
		ddlSupplier.DisplayMember = "Value";
		ddlSupplier.ValueMember = "Key";
	}

	private void method_4()
	{
		lstSupplier.Items.Clear();
		if (supplierIds == null || supplierIds.Count <= 0)
		{
			return;
		}
		GClass6 gClass = new GClass6();
		using List<int>.Enumerator enumerator = supplierIds.GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
			CS_0024_003C_003E8__locals0.supId = enumerator.Current;
			Supplier supplier = gClass.Suppliers.Where((Supplier a) => a.Id == CS_0024_003C_003E8__locals0.supId).FirstOrDefault();
			ListViewItem value = new ListViewItem(new string[2]
			{
				supplier.Name,
				supplier.Id.ToString()
			});
			lstSupplier.Items.Add(value);
		}
	}

	private void btnReset_Click(object sender, EventArgs e)
	{
		method_4();
		base.DialogResult = DialogResult.None;
	}

	private void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
	{
		((Control)(object)txtSupplier).ForeColor = Color.Black;
		if (ddlSupplier.SelectedValue.ToString() == "0")
		{
			method_5(bool_0: true);
		}
		else
		{
			((Control)(object)txtSupplier).Text = ddlSupplier.Text;
		}
	}

	private void btnAddSupplierToitem_Click(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		foreach (ListViewItem item in lstSupplier.Items)
		{
			if (item.SubItems[0].Text == ddlSupplier.Text)
			{
				new NotificationLabel(this, "Supplier already added", NotificationTypes.Warning).Show();
				base.DialogResult = DialogResult.None;
				return;
			}
		}
		if (!string.IsNullOrEmpty(((Control)(object)txtSupplier).Text) && !(((Control)(object)txtSupplier).Text == "Enter Supplier Name"))
		{
			Supplier supplier;
			if (ddlSupplier.SelectedValue.ToString() == "0")
			{
				supplier = new Supplier
				{
					Name = ((Control)(object)txtSupplier).Text,
					Synced = false
				};
				gClass.Suppliers.InsertOnSubmit(supplier);
				Helper.SubmitChangesWithCatch(gClass);
			}
			else
			{
				supplier = gClass.Suppliers.Where((Supplier a) => a.Id.ToString() == ddlSupplier.SelectedValue.ToString()).FirstOrDefault();
				if (supplier != null)
				{
					supplier.Name = ((Control)(object)txtSupplier).Text;
					supplier.Synced = false;
					Helper.SubmitChangesWithCatch(gClass);
				}
			}
			ListViewItem value = new ListViewItem(new string[2]
			{
				supplier.Name,
				supplier.Id.ToString()
			});
			lstSupplier.Items.Add(value);
			method_3();
			base.DialogResult = DialogResult.None;
		}
		else
		{
			new NotificationLabel(this, "Please fill in the supplier name", NotificationTypes.Warning).Show();
			base.DialogResult = DialogResult.None;
		}
	}

	private void txtSupplier_GotFocus(object sender, EventArgs e)
	{
		if (((Control)(object)txtSupplier).Text == "Enter Supplier Name")
		{
			((Control)(object)txtSupplier).ForeColor = Color.Black;
			((Control)(object)txtSupplier).Text = "";
		}
	}

	private void txtSupplier_LostFocus(object sender, EventArgs e)
	{
		if (((Control)(object)txtSupplier).Text == string.Empty)
		{
			((Control)(object)txtSupplier).Text = "Enter Supplier Name";
			((Control)(object)txtSupplier).ForeColor = Color.Gray;
		}
	}

	private void btnClearAll_Click(object sender, EventArgs e)
	{
		lstSupplier.Items.Clear();
		base.DialogResult = DialogResult.None;
	}

	private void btnDeleteItem_Click(object sender, EventArgs e)
	{
		if (lstSupplier.SelectedItems.Count > 0)
		{
			lstSupplier.SelectedItems[0].Remove();
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnExit_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		supplierIds = new List<int>();
		foreach (ListViewItem item in lstSupplier.Items)
		{
			supplierIds.Add(Convert.ToInt32(item.SubItems[1].Text));
		}
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void btnShowKeyboard_Supplier_Click(object sender, EventArgs e)
	{
		method_5(bool_0: false);
		base.DialogResult = DialogResult.None;
	}

	private void method_5(bool bool_0)
	{
		string title = "Supplier Name";
		string default_text = ((Control)(object)txtSupplier).Text;
		if (bool_0)
		{
			title = "Add New Supplier";
			default_text = "";
		}
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(title, 0, 256, default_text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtSupplier).Text = MemoryLoadedObjects.Keyboard.textEntered;
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
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmAssignSupplier));
		btnShowKeyboard_Supplier = new Button();
		txtSupplier = new RadTextBoxControl();
		lblTitle = new Label();
		ddlSupplier = new Class19();
		label4 = new Label();
		lblItemName = new Label();
		label1 = new Label();
		lstSupplier = new ListView();
		columnHeader_0 = new ColumnHeader();
		btnAddSupplierToitem = new Button();
		btnClearAll = new Button();
		btnDeleteItem = new Button();
		btnReset = new Button();
		btnSave = new Button();
		btnExit = new Button();
		((ISupportInitialize)txtSupplier).BeginInit();
		SuspendLayout();
		btnShowKeyboard_Supplier.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Supplier.DialogResult = DialogResult.OK;
		btnShowKeyboard_Supplier.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Supplier.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_Supplier.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_Supplier.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_Supplier.ForeColor = Color.White;
		btnShowKeyboard_Supplier.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_Supplier.Image");
		btnShowKeyboard_Supplier.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_Supplier.Location = new Point(723, 72);
		btnShowKeyboard_Supplier.Name = "btnShowKeyboard_Supplier";
		btnShowKeyboard_Supplier.Size = new Size(57, 33);
		btnShowKeyboard_Supplier.TabIndex = 223;
		btnShowKeyboard_Supplier.UseVisualStyleBackColor = false;
		btnShowKeyboard_Supplier.Click += btnShowKeyboard_Supplier_Click;
		((Control)(object)txtSupplier).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		((Control)(object)txtSupplier).ForeColor = Color.Silver;
		((Control)(object)txtSupplier).Location = new Point(428, 72);
		((Control)(object)txtSupplier).Name = "txtSupplier";
		((RadElement)((RadControl)txtSupplier).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtSupplier).Size = new Size(294, 33);
		((Control)(object)txtSupplier).TabIndex = 222;
		((Control)(object)txtSupplier).Text = "Enter Supplier Name";
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtSupplier).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtSupplier).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblTitle.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		lblTitle.ForeColor = Color.White;
		lblTitle.ImeMode = ImeMode.NoControl;
		lblTitle.Location = new Point(-1, 0);
		lblTitle.Name = "lblTitle";
		lblTitle.Size = new Size(831, 35);
		lblTitle.TabIndex = 221;
		lblTitle.Text = "ASSIGN SUPPLIER";
		lblTitle.TextAlign = ContentAlignment.MiddleCenter;
		ddlSupplier.BackColor = Color.White;
		ddlSupplier.DrawMode = DrawMode.OwnerDrawVariable;
		ddlSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlSupplier.FlatStyle = FlatStyle.Flat;
		ddlSupplier.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		ddlSupplier.ForeColor = Color.FromArgb(40, 40, 40);
		ddlSupplier.FormattingEnabled = true;
		ddlSupplier.ItemHeight = 27;
		ddlSupplier.Items.AddRange(new object[2] { "Vertical", "Horizontal" });
		ddlSupplier.Location = new Point(120, 72);
		ddlSupplier.Margin = new Padding(4, 5, 4, 5);
		ddlSupplier.Name = "ddlSupplier";
		ddlSupplier.Size = new Size(307, 33);
		ddlSupplier.TabIndex = 219;
		ddlSupplier.SelectedIndexChanged += ddlSupplier_SelectedIndexChanged;
		label4.BackColor = Color.FromArgb(132, 146, 146);
		label4.Font = new Font("Microsoft Sans Serif", 12f);
		label4.ForeColor = Color.White;
		label4.ImeMode = ImeMode.NoControl;
		label4.Location = new Point(-1, 72);
		label4.Margin = new Padding(4, 0, 4, 0);
		label4.MinimumSize = new Size(120, 33);
		label4.Name = "label4";
		label4.Padding = new Padding(0, 0, 5, 0);
		label4.Size = new Size(120, 33);
		label4.TabIndex = 218;
		label4.Text = "Supplier";
		label4.TextAlign = ContentAlignment.MiddleRight;
		lblItemName.BackColor = SystemColors.AppWorkspace;
		lblItemName.Font = new Font("Microsoft Sans Serif", 14.25f);
		lblItemName.ImeMode = ImeMode.NoControl;
		lblItemName.Location = new Point(120, 36);
		lblItemName.Name = "lblItemName";
		lblItemName.Size = new Size(710, 35);
		lblItemName.TabIndex = 225;
		lblItemName.Text = "Item Name";
		lblItemName.TextAlign = ContentAlignment.MiddleLeft;
		label1.BackColor = Color.Gray;
		label1.Font = new Font("Microsoft Sans Serif", 12f);
		label1.ForeColor = Color.White;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(-1, 36);
		label1.Margin = new Padding(4, 0, 4, 0);
		label1.MinimumSize = new Size(0, 35);
		label1.Name = "label1";
		label1.Padding = new Padding(0, 0, 5, 0);
		label1.Size = new Size(120, 35);
		label1.TabIndex = 224;
		label1.Text = "Item Name";
		label1.TextAlign = ContentAlignment.MiddleRight;
		lstSupplier.BackColor = Color.White;
		lstSupplier.BorderStyle = BorderStyle.None;
		lstSupplier.Columns.AddRange(new ColumnHeader[1] { columnHeader_0 });
		lstSupplier.Font = new Font("Microsoft Sans Serif", 12f);
		lstSupplier.ForeColor = Color.FromArgb(40, 40, 40);
		lstSupplier.FullRowSelect = true;
		lstSupplier.GridLines = true;
		lstSupplier.HideSelection = false;
		lstSupplier.LabelWrap = false;
		lstSupplier.Location = new Point(3, 106);
		lstSupplier.Name = "lstSupplier";
		lstSupplier.Size = new Size(827, 215);
		lstSupplier.TabIndex = 227;
		lstSupplier.UseCompatibleStateImageBehavior = false;
		lstSupplier.View = View.Details;
		columnHeader_0.Text = "Supplier Name";
		columnHeader_0.Width = 800;
		btnAddSupplierToitem.BackColor = Color.Transparent;
		btnAddSupplierToitem.DialogResult = DialogResult.OK;
		btnAddSupplierToitem.FlatAppearance.BorderColor = Color.Black;
		btnAddSupplierToitem.FlatAppearance.BorderSize = 0;
		btnAddSupplierToitem.FlatStyle = FlatStyle.Flat;
		btnAddSupplierToitem.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnAddSupplierToitem.ForeColor = Color.White;
		btnAddSupplierToitem.Image = (Image)componentResourceManager.GetObject("btnAddSupplierToitem.Image");
		btnAddSupplierToitem.ImeMode = ImeMode.NoControl;
		btnAddSupplierToitem.Location = new Point(781, 71);
		btnAddSupplierToitem.Name = "btnAddSupplierToitem";
		btnAddSupplierToitem.Size = new Size(47, 34);
		btnAddSupplierToitem.TabIndex = 226;
		btnAddSupplierToitem.UseVisualStyleBackColor = false;
		btnAddSupplierToitem.Click += btnAddSupplierToitem_Click;
		btnClearAll.BackColor = Color.FromArgb(61, 142, 185);
		btnClearAll.FlatAppearance.BorderColor = Color.Black;
		btnClearAll.FlatAppearance.BorderSize = 0;
		btnClearAll.FlatAppearance.MouseDownBackColor = Color.White;
		btnClearAll.FlatStyle = FlatStyle.Flat;
		btnClearAll.Font = new Font("Microsoft Sans Serif", 11f);
		btnClearAll.ForeColor = Color.White;
		btnClearAll.Image = (Image)componentResourceManager.GetObject("btnClearAll.Image");
		btnClearAll.ImageAlign = ContentAlignment.TopCenter;
		btnClearAll.ImeMode = ImeMode.NoControl;
		btnClearAll.Location = new Point(176, 323);
		btnClearAll.Name = "btnClearAll";
		btnClearAll.Padding = new Padding(5);
		btnClearAll.Size = new Size(160, 90);
		btnClearAll.TabIndex = 232;
		btnClearAll.Text = "CLEAR ALL";
		btnClearAll.TextAlign = ContentAlignment.BottomCenter;
		btnClearAll.UseVisualStyleBackColor = false;
		btnClearAll.Click += btnClearAll_Click;
		btnDeleteItem.BackColor = Color.FromArgb(214, 142, 81);
		btnDeleteItem.FlatAppearance.BorderColor = Color.White;
		btnDeleteItem.FlatAppearance.BorderSize = 0;
		btnDeleteItem.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnDeleteItem.FlatStyle = FlatStyle.Flat;
		btnDeleteItem.Font = new Font("Microsoft Sans Serif", 11f);
		btnDeleteItem.ForeColor = Color.White;
		btnDeleteItem.Image = (Image)componentResourceManager.GetObject("btnDeleteItem.Image");
		btnDeleteItem.ImageAlign = ContentAlignment.TopCenter;
		btnDeleteItem.ImeMode = ImeMode.NoControl;
		btnDeleteItem.Location = new Point(3, 323);
		btnDeleteItem.Name = "btnDeleteItem";
		btnDeleteItem.Padding = new Padding(5);
		btnDeleteItem.Size = new Size(172, 90);
		btnDeleteItem.TabIndex = 231;
		btnDeleteItem.Text = "REMOVE";
		btnDeleteItem.TextAlign = ContentAlignment.BottomCenter;
		btnDeleteItem.UseVisualStyleBackColor = false;
		btnDeleteItem.Click += btnDeleteItem_Click;
		btnReset.BackColor = Color.SandyBrown;
		btnReset.FlatAppearance.BorderColor = Color.Black;
		btnReset.FlatAppearance.BorderSize = 0;
		btnReset.FlatAppearance.MouseDownBackColor = Color.White;
		btnReset.FlatStyle = FlatStyle.Flat;
		btnReset.Font = new Font("Microsoft Sans Serif", 11f);
		btnReset.ForeColor = Color.White;
		btnReset.Image = (Image)componentResourceManager.GetObject("btnReset.Image");
		btnReset.ImageAlign = ContentAlignment.TopCenter;
		btnReset.ImeMode = ImeMode.NoControl;
		btnReset.Location = new Point(514, 323);
		btnReset.Name = "btnReset";
		btnReset.Padding = new Padding(5);
		btnReset.Size = new Size(159, 90);
		btnReset.TabIndex = 230;
		btnReset.Text = "RESET";
		btnReset.TextAlign = ContentAlignment.BottomCenter;
		btnReset.UseVisualStyleBackColor = false;
		btnReset.Visible = false;
		btnReset.Click += btnReset_Click;
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderColor = Color.White;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnSave.FlatStyle = FlatStyle.Flat;
		btnSave.Font = new Font("Microsoft Sans Serif", 11f);
		btnSave.ForeColor = Color.White;
		btnSave.Image = (Image)componentResourceManager.GetObject("btnSave.Image");
		btnSave.ImageAlign = ContentAlignment.TopCenter;
		btnSave.ImeMode = ImeMode.NoControl;
		btnSave.Location = new Point(337, 323);
		btnSave.Margin = new Padding(4, 5, 4, 5);
		btnSave.Name = "btnSave";
		btnSave.Padding = new Padding(5);
		btnSave.Size = new Size(176, 90);
		btnSave.TabIndex = 229;
		btnSave.Text = "DONE";
		btnSave.TextAlign = ContentAlignment.BottomCenter;
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		btnExit.BackColor = Color.FromArgb(235, 107, 86);
		btnExit.FlatAppearance.BorderColor = Color.White;
		btnExit.FlatAppearance.BorderSize = 0;
		btnExit.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnExit.FlatStyle = FlatStyle.Flat;
		btnExit.Font = new Font("Microsoft Sans Serif", 11f);
		btnExit.ForeColor = Color.White;
		btnExit.Image = (Image)componentResourceManager.GetObject("btnExit.Image");
		btnExit.ImageAlign = ContentAlignment.TopCenter;
		btnExit.ImeMode = ImeMode.NoControl;
		btnExit.Location = new Point(674, 323);
		btnExit.Name = "btnExit";
		btnExit.Padding = new Padding(5);
		btnExit.Size = new Size(157, 90);
		btnExit.TabIndex = 228;
		btnExit.Text = "EXIT";
		btnExit.TextAlign = ContentAlignment.BottomCenter;
		btnExit.UseVisualStyleBackColor = false;
		btnExit.Click += btnExit_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(832, 418);
		base.Controls.Add(btnClearAll);
		base.Controls.Add(btnDeleteItem);
		base.Controls.Add(btnReset);
		base.Controls.Add(btnSave);
		base.Controls.Add(btnExit);
		base.Controls.Add(lstSupplier);
		base.Controls.Add(btnAddSupplierToitem);
		base.Controls.Add(lblItemName);
		base.Controls.Add(label1);
		base.Controls.Add(btnShowKeyboard_Supplier);
		base.Controls.Add((Control)(object)txtSupplier);
		base.Controls.Add(lblTitle);
		base.Controls.Add(ddlSupplier);
		base.Controls.Add(label4);
		base.Name = "frmAssignSupplier";
		base.Opacity = 1.0;
		Text = "frmAssignSupplier";
		base.Load += frmAssignSupplier_Load;
		((ISupportInitialize)txtSupplier).EndInit();
		ResumeLayout(performLayout: false);
	}
}
