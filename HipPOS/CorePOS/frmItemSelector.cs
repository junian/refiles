using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Objects;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmItemSelector : frmMasterForm
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private bool bool_0;

	private string[] string_2;

	private Dictionary<string, string> dictionary_0;

	private string string_3;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private Func<object> func_0;

	private IContainer icontainer_1;

	private ListView lstItems;

	private Label lblTitle;

	internal Button btnSelect;

	internal Button btnCancel;

	private Label lblCustom;

	internal Button btnShowKeyboard_Custom;

	private ColumnHeader columnHeader_0;

	private RadTextBoxControl txtCustom;

	private PictureBox pictureBox1;

	private ColumnHeader columnHeader_1;

	internal Button btnRefreshData;

	private Class17 chkSameAll;

	private Panel pnlSame;

	private Label label1;

	private Panel wgCmTpwdu9;

	public string SingleSelectedItem
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

	public string SingleSelectedKey
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public bool SameForAllValue
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

	public frmItemSelector()
	{
		Class26.Ggkj0JxzN9YmC();
		bool_3 = true;
		// base._002Ector();
		InitializeComponent_1();
		ImageList smallImageList = new ImageList
		{
			ImageSize = new Size(1, 50)
		};
		lstItems.SmallImageList = smallImageList;
		lstItems.GridLines = true;
	}

	public void LoadForm(string[] _itemList, bool _withCustom = false, string _title = "Select Item", bool _IsMultipleSelect = false, bool _autoClose = false, bool _sameReasonForAll = false, Dictionary<string, string> _itemListWithId = null, Func<object> refreshFunction = null)
	{
		SingleSelectedItem = null;
		SingleSelectedKey = null;
		string_2 = _itemList;
		dictionary_0 = _itemListWithId;
		string_3 = _title;
		bool_1 = _IsMultipleSelect;
		bool_2 = _withCustom;
		bool_3 = _autoClose;
		bool_4 = _sameReasonForAll;
		func_0 = refreshFunction;
		txtCustom.Text = string.Empty;
		if (bool_3)
		{
			pictureBox1.Visible = true;
			Button button = btnSelect;
			btnCancel.Visible = false;
			button.Visible = false;
			base.Size = new Size(base.Width, base.Height - 97);
		}
		else
		{
			pictureBox1.Visible = false;
			btnSelect.Visible = true;
			btnCancel.Visible = true;
		}
		if (_title.ToUpper().Contains("VOID"))
		{
			label1.Text = "Use same reason for all cancelled items";
		}
		else
		{
			label1.Text = "Same reason for the rest of items";
		}
		lstItems.Columns[0].Width = ControlHelpers.ControlWidthFixer(lstItems, 12.0) - 10;
		lblTitle.Text = string_3;
		if (dictionary_0 == null)
		{
			string[] array = string_2;
			foreach (string text in array)
			{
				lstItems.Items.Add(new ListViewItem(new string[1] { text }));
			}
		}
		else
		{
			foreach (KeyValuePair<string, string> item in dictionary_0)
			{
				lstItems.Items.Add(new ListViewItem(new string[2] { item.Value, item.Key }));
			}
		}
		method_3();
	}

	private void frmItemSelector_Load(object sender, EventArgs e)
	{
	}

	private void method_3(bool bool_5 = false)
	{
		int num = 0;
		if (bool_4)
		{
			pnlSame.Visible = true;
			num = 51;
		}
		else
		{
			pnlSame.Visible = false;
			num = 0;
		}
		int num2 = lstItems.Items.Count * 51 + 5 + num;
		int num3 = lstItems.Height;
		if (num2 < num3)
		{
			lstItems.Height = num2;
			int num4 = num3 - num2;
			base.Height -= num4;
			CenterToScreen();
			btnRefreshData.Location = new Point(btnRefreshData.Location.X, btnRefreshData.Location.Y - num4);
			btnCancel.Location = new Point(btnCancel.Location.X, btnCancel.Location.Y - num4);
			btnSelect.Location = new Point(btnSelect.Location.X, btnSelect.Location.Y - num4);
		}
		else if (num2 > num3)
		{
			lstItems.Height = num2;
			int num5 = num2 - num3;
			base.Height += num5;
			CenterToScreen();
			btnRefreshData.Location = new Point(btnRefreshData.Location.X, btnRefreshData.Location.Y + num5);
			btnCancel.Location = new Point(btnCancel.Location.X, btnCancel.Location.Y + num5);
			btnSelect.Location = new Point(btnSelect.Location.X, btnSelect.Location.Y + num5);
		}
		txtCustom.Visible = true;
		lblCustom.Visible = true;
		btnShowKeyboard_Custom.Visible = true;
		if (!bool_2 && !bool_5)
		{
			txtCustom.Visible = false;
			lblCustom.Visible = false;
			btnShowKeyboard_Custom.Visible = false;
			btnSelect.Location = new Point(btnSelect.Location.X, btnSelect.Location.Y - 38);
			btnCancel.Location = new Point(btnCancel.Location.X, btnCancel.Location.Y - 38);
			base.Size = new Size(base.Width, base.Height - 40);
		}
		if (Thread.CurrentThread.CurrentCulture.Name.Equals("fr-CA"))
		{
			lblCustom.Font = new Font(lblCustom.Font.FontFamily, lblCustom.Font.Size - 0.75f);
		}
		btnRefreshData.Visible = false;
		if (string_3 == "Select TapMango Customer" && !bool_5)
		{
			int num6 = (btnCancel.Width + btnSelect.Width) / 3 + 1;
			Button button = btnRefreshData;
			Button button2 = btnSelect;
			int num8 = (btnCancel.Width = num6);
			int num10 = (button2.Width = num8);
			button.Width = num10;
			btnRefreshData.Visible = true;
			btnRefreshData.Location = new Point(btnRefreshData.Location.X, btnSelect.Location.Y);
			btnSelect.Location = new Point(btnRefreshData.Location.X + num6 + 1, btnSelect.Location.Y);
			btnCancel.Location = new Point(btnSelect.Location.X + num6 + 1, btnCancel.Location.Y);
			wxVibItidK();
		}
		if (bool_4)
		{
			wgCmTpwdu9.Location = new Point(wgCmTpwdu9.Location.X, pnlSame.Top - wgCmTpwdu9.Height);
		}
		else
		{
			wgCmTpwdu9.Location = new Point(wgCmTpwdu9.Location.X, lstItems.Bottom);
		}
	}

	private void lstItems_Click(object sender, EventArgs e)
	{
		if (lstItems.SelectedItems.Count > 0)
		{
			txtCustom.Text = "";
			if (bool_3)
			{
				SingleSelectedItem = lstItems.SelectedItems[0].Text;
				base.DialogResult = DialogResult.OK;
				method_4();
			}
		}
	}

	private void btnSelect_Click(object sender, EventArgs e)
	{
		if (bool_4)
		{
			SameForAllValue = chkSameAll.Checked;
		}
		string message = (bool_2 ? Resources.Please_select_an_item_or_fill_ : Resources.Please_select_an_item);
		if (string_3 == Resources.Select_a_Discount_Reasons)
		{
			message = Resources.Please_select_a_discount_reaso;
		}
		else if (string_3 == "Select TapMango Customer")
		{
			message = "Please select a customer";
		}
		if (dictionary_0 == null)
		{
			if (lstItems.SelectedItems.Count > 0 && string.IsNullOrEmpty(txtCustom.Text))
			{
				SingleSelectedItem = lstItems.SelectedItems[0].SubItems[0].Text;
				base.DialogResult = DialogResult.OK;
				method_4();
			}
			else if (bool_2 && !string.IsNullOrEmpty(txtCustom.Text))
			{
				SingleSelectedItem = txtCustom.Text;
				base.DialogResult = DialogResult.OK;
				method_4();
			}
			else
			{
				new NotificationLabel(this, message, NotificationTypes.Warning).Show();
				base.DialogResult = DialogResult.None;
			}
		}
		else if (lstItems.SelectedItems.Count > 0)
		{
			SingleSelectedItem = lstItems.SelectedItems[0].SubItems[0].Text;
			SingleSelectedKey = lstItems.SelectedItems[0].SubItems[1].Text;
			base.DialogResult = DialogResult.OK;
			method_4();
		}
		else
		{
			new NotificationLabel(this, message, NotificationTypes.Warning).Show();
			base.DialogResult = DialogResult.None;
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		method_4();
	}

	private void WlPiMdQaCd(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_a_Custom, 1, 128, txtCustom.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtCustom.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void txtCustom_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		method_4();
	}

	private void method_4()
	{
		base.Height = 591;
		lstItems.Size = new Size(515, 411);
		btnSelect.Size = new Size(257, 98);
		btnSelect.Location = new Point(4, 488);
		btnCancel.Size = new Size(257, 98);
		btnCancel.Location = new Point(262, 488);
		btnRefreshData.Size = new Size(142, 98);
		btnRefreshData.Location = new Point(4, 488);
		RadTextBoxControl radTextBoxControl = txtCustom;
		Label label = lblCustom;
		btnShowKeyboard_Custom.Visible = true;
		label.Visible = true;
		radTextBoxControl.Visible = true;
		string_3 = null;
		func_0 = null;
		dictionary_0 = null;
		string_2 = null;
		lstItems.Items.Clear();
		Hide();
		GC.Collect();
	}

	private void wxVibItidK()
	{
		if (dictionary_0.Count() > 1)
		{
			lstItems.Items[1].Selected = true;
			lstItems.Select();
		}
		else
		{
			lstItems.Items[0].Selected = true;
			lstItems.Select();
		}
	}

	private void btnRefreshData_Click(object sender, EventArgs e)
	{
		if (string_3 == "Select TapMango Customer" && func_0 != null)
		{
			List<ActiveCustomerPayObject> source = func_0() as List<ActiveCustomerPayObject>;
			dictionary_0 = source.ToDictionary((ActiveCustomerPayObject a) => a.customerId.ToString(), (ActiveCustomerPayObject a) => a.CustomerName);
			lstItems.Items.Clear();
			foreach (KeyValuePair<string, string> item in dictionary_0)
			{
				lstItems.Items.Add(new ListViewItem(new string[2] { item.Value, item.Key }));
			}
			wxVibItidK();
			method_3(bool_5: true);
		}
		else if (string_3 == Resources.Select_an_Order_Type)
		{
			base.DialogResult = DialogResult.Yes;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmItemSelector));
		lstItems = new ListView();
		columnHeader_0 = new ColumnHeader();
		columnHeader_1 = new ColumnHeader();
		pnlSame = new Panel();
		label1 = new Label();
		chkSameAll = new Class17();
		btnRefreshData = new Button();
		pictureBox1 = new PictureBox();
		txtCustom = new RadTextBoxControl();
		btnShowKeyboard_Custom = new Button();
		lblCustom = new Label();
		btnCancel = new Button();
		btnSelect = new Button();
		lblTitle = new Label();
		wgCmTpwdu9 = new Panel();
		pnlSame.SuspendLayout();
		((ISupportInitialize)pictureBox1).BeginInit();
		((ISupportInitialize)txtCustom).BeginInit();
		wgCmTpwdu9.SuspendLayout();
		SuspendLayout();
		lstItems.BackColor = Color.White;
		lstItems.BorderStyle = BorderStyle.None;
		lstItems.Columns.AddRange(new ColumnHeader[2] { columnHeader_0, columnHeader_1 });
		lstItems.Cursor = Cursors.Default;
		componentResourceManager.ApplyResources(lstItems, "lstItems");
		lstItems.ForeColor = Color.FromArgb(40, 40, 40, 40);
		lstItems.FullRowSelect = true;
		lstItems.GridLines = true;
		lstItems.HeaderStyle = ColumnHeaderStyle.None;
		lstItems.HideSelection = false;
		lstItems.MultiSelect = false;
		lstItems.Name = "lstItems";
		lstItems.UseCompatibleStateImageBehavior = false;
		lstItems.View = View.Details;
		lstItems.Click += lstItems_Click;
		componentResourceManager.ApplyResources(columnHeader_0, "columnHeader1");
		componentResourceManager.ApplyResources(columnHeader_1, "columnHeader2");
		componentResourceManager.ApplyResources(pnlSame, "pnlSame");
		pnlSame.BackColor = Color.White;
		pnlSame.Controls.Add(label1);
		pnlSame.Controls.Add(chkSameAll);
		pnlSame.Name = "pnlSame";
		componentResourceManager.ApplyResources(label1, "label1");
		label1.BackColor = Color.White;
		label1.Name = "label1";
		componentResourceManager.ApplyResources(chkSameAll, "chkSameAll");
		chkSameAll.Name = "chkSameAll";
		chkSameAll.UseVisualStyleBackColor = true;
		btnRefreshData.BackColor = Color.FromArgb(53, 152, 220);
		btnRefreshData.FlatAppearance.BorderColor = Color.Black;
		btnRefreshData.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnRefreshData, "btnRefreshData");
		btnRefreshData.ForeColor = Color.White;
		btnRefreshData.Name = "btnRefreshData";
		btnRefreshData.UseVisualStyleBackColor = false;
		btnRefreshData.Click += btnRefreshData_Click;
		componentResourceManager.ApplyResources(pictureBox1, "pictureBox1");
		pictureBox1.BackColor = Color.FromArgb(156, 89, 184);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.TabStop = false;
		pictureBox1.Click += pictureBox1_Click;
		componentResourceManager.ApplyResources(txtCustom, "txtCustom");
		txtCustom.Name = "txtCustom";
		txtCustom.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtCustom.Click += txtCustom_Click;
		((RadTextBoxControlElement)txtCustom.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtCustom.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		btnShowKeyboard_Custom.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Custom.DialogResult = DialogResult.OK;
		btnShowKeyboard_Custom.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Custom.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Custom, "btnShowKeyboard_Custom");
		btnShowKeyboard_Custom.ForeColor = Color.White;
		btnShowKeyboard_Custom.Name = "btnShowKeyboard_Custom";
		btnShowKeyboard_Custom.UseVisualStyleBackColor = false;
		btnShowKeyboard_Custom.Click += WlPiMdQaCd;
		lblCustom.BackColor = Color.Gray;
		lblCustom.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(lblCustom, "lblCustom");
		lblCustom.ForeColor = Color.White;
		lblCustom.Name = "lblCustom";
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.Cursor = Cursors.Default;
		btnCancel.FlatAppearance.BorderColor = Color.Black;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 0, 37);
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = Color.White;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnSelect.BackColor = Color.FromArgb(47, 204, 113);
		btnSelect.Cursor = Cursors.Default;
		btnSelect.FlatAppearance.BorderColor = Color.Black;
		btnSelect.FlatAppearance.BorderSize = 0;
		btnSelect.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 0, 37);
		componentResourceManager.ApplyResources(btnSelect, "btnSelect");
		btnSelect.ForeColor = Color.White;
		btnSelect.Name = "btnSelect";
		btnSelect.UseVisualStyleBackColor = false;
		btnSelect.Click += btnSelect_Click;
		componentResourceManager.ApplyResources(lblTitle, "lblTitle");
		lblTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblTitle.ForeColor = Color.White;
		lblTitle.Name = "lblTitle";
		componentResourceManager.ApplyResources(wgCmTpwdu9, "pnlCustom");
		wgCmTpwdu9.BackColor = Color.FromArgb(35, 39, 56);
		wgCmTpwdu9.Controls.Add(lblCustom);
		wgCmTpwdu9.Controls.Add(btnShowKeyboard_Custom);
		wgCmTpwdu9.Controls.Add(txtCustom);
		wgCmTpwdu9.Name = "pnlCustom";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(btnRefreshData);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnSelect);
		base.Controls.Add(pnlSame);
		base.Controls.Add(wgCmTpwdu9);
		base.Controls.Add(pictureBox1);
		base.Controls.Add(lblTitle);
		base.Controls.Add(lstItems);
		base.Name = "frmItemSelector";
		base.Opacity = 1.0;
		base.Load += frmItemSelector_Load;
		pnlSame.ResumeLayout(performLayout: false);
		pnlSame.PerformLayout();
		((ISupportInitialize)pictureBox1).EndInit();
		((ISupportInitialize)txtCustom).EndInit();
		wgCmTpwdu9.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}
}
