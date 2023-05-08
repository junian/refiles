using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Data;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmManagePaymentTypes : frmMasterForm
{
	private bool bool_0;

	private IContainer icontainer_1;

	private PictureBox pictureBox1;

	private Label lblHeaderTitle;

	private Class19 ddlPaymentTypes;

	private Label label1;

	private RadTextBoxControl txtName;

	private Label label2;

	internal Button btnShowKeyboard_Name;

	internal Button btnDelete;

	internal Button btnAddNew;

	internal Button btnUpdate;

	private Label label4;

	private RadToggleSwitch chkEnableCashDrawer;

	private Label label7;

	private RadToggleSwitch chkSendToPaymentTerminal;

	private Label label8;

	private Label lblPrinterName;

	internal Button btnSort;

	private Label label3;

	private RadToggleSwitch chkPrintReceipt;

	private Label label5;

	public frmManagePaymentTypes()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
	}

	private void frmManagePaymentTypes_Load(object sender, EventArgs e)
	{
		method_3();
	}

	private void method_3()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("0", "+ Add New");
		foreach (PaymentType item in from x in new GClass6().PaymentTypes
			where x.SystemDefault == false
			orderby x.Name
			select x)
		{
			dictionary.Add(item.Id.ToString(), item.Name);
		}
		ddlPaymentTypes.DisplayMember = "Value";
		ddlPaymentTypes.ValueMember = "Key";
		ddlPaymentTypes.DataSource = new BindingSource(dictionary, null);
	}

	private void ddlPaymentTypes_SelectedIndexChanged(object sender, EventArgs e)
	{
		btnDelete.Visible = true;
		txtName.Enabled = true;
		if (ddlPaymentTypes.SelectedValue.ToString() != "0")
		{
			new GClass6();
			PaymentType paymentType = new GClass6().PaymentTypes.Where((PaymentType a) => a.Id == Convert.ToInt16(ddlPaymentTypes.SelectedValue)).FirstOrDefault();
			txtName.Text = paymentType.Name;
			chkEnableCashDrawer.Value = paymentType.OpenCashDrawer;
			chkSendToPaymentTerminal.Value = paymentType.UsePaymentTerminal;
			chkPrintReceipt.Value = paymentType.PrintReceipt;
		}
		else
		{
			txtName.Text = "";
			chkEnableCashDrawer.Value = false;
			chkSendToPaymentTerminal.Value = false;
		}
	}

	private void btnAddNew_Click(object sender, EventArgs e)
	{
		ddlPaymentTypes.SelectedIndex = 0;
	}

	private void btnDelete_Click(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		if (new frmMessageBox("Are you sure you want to delete this payment type?", "Delete Payment Type", CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
		{
			_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
			CS_0024_003C_003E8__locals0.selectedPaymentTypeId = Convert.ToInt16(ddlPaymentTypes.SelectedValue);
			PaymentType paymentType = gClass.PaymentTypes.Where((PaymentType a) => a.Id == CS_0024_003C_003E8__locals0.selectedPaymentTypeId && a.SystemDefault == false).FirstOrDefault();
			if (paymentType != null)
			{
				gClass.PaymentTypes.DeleteOnSubmit(paymentType);
				Helper.SubmitChangesWithCatch(gClass);
				new NotificationLabel(this, "Payment Type successfully deleted.", NotificationTypes.Success).Show();
				bool_0 = true;
			}
			method_3();
		}
	}

	private void btnUpdate_Click(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(txtName.Text))
		{
			new NotificationLabel(this, "Please add a payment type name.", NotificationTypes.Warning).Show();
			return;
		}
		GClass6 gClass = new GClass6();
		if (ddlPaymentTypes.SelectedIndex == 0)
		{
			List<PaymentType> list = gClass.PaymentTypes.ToList();
			if (list.Count >= 14)
			{
				new NotificationLabel(this, "You cannot have more than 14 payment types.  Please remove unused payment types before proceeding.", NotificationTypes.Notification).Show();
				return;
			}
			PaymentType paymentType = list.Where((PaymentType paymentType_0) => paymentType_0.Name.ToUpper() == txtName.Text.Trim().ToUpper() && paymentType_0.Id.ToString() != ddlPaymentTypes.SelectedValue.ToString()).FirstOrDefault();
			if (paymentType != null)
			{
				new NotificationLabel(this, "Payment Type with the same name already exists", NotificationTypes.Notification).Show();
				return;
			}
			paymentType = new PaymentType();
			paymentType.Name = txtName.Text.Trim().ToUpper();
			paymentType.OpenCashDrawer = chkEnableCashDrawer.Value;
			paymentType.UsePaymentTerminal = chkSendToPaymentTerminal.Value;
			paymentType.SortOrder = gClass.PaymentTypes.OrderByDescending((PaymentType x) => x.SortOrder).FirstOrDefault().SortOrder + 1;
			paymentType.PrintReceipt = chkPrintReceipt.Value;
			gClass.PaymentTypes.InsertOnSubmit(paymentType);
			Helper.SubmitChangesWithCatch(gClass);
			new NotificationLabel(this, "Payment Type successfully added.", NotificationTypes.Success).Show();
			method_3();
		}
		else
		{
			_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
			CS_0024_003C_003E8__locals0.selectedPaymentTypeId = Convert.ToInt16(ddlPaymentTypes.SelectedValue);
			PaymentType paymentType2 = gClass.PaymentTypes.Where((PaymentType a) => a.Name.ToUpper() == txtName.Text.Trim().ToUpper() && a.Id.ToString() != ddlPaymentTypes.SelectedValue.ToString()).FirstOrDefault();
			if (paymentType2 != null)
			{
				new NotificationLabel(this, "Payment Type with the same name already exists", NotificationTypes.Notification).Show();
				return;
			}
			paymentType2 = gClass.PaymentTypes.Where((PaymentType a) => a.Id == CS_0024_003C_003E8__locals0.selectedPaymentTypeId && a.SystemDefault == false).FirstOrDefault();
			if (paymentType2 == null)
			{
				new NotificationLabel(this, "An error had occurred trying to save.  Please restart and try again.", NotificationTypes.Warning).Show();
				return;
			}
			paymentType2.Name = txtName.Text.Trim().ToUpper();
			paymentType2.OpenCashDrawer = chkEnableCashDrawer.Value;
			paymentType2.UsePaymentTerminal = chkSendToPaymentTerminal.Value;
			paymentType2.PrintReceipt = chkPrintReceipt.Value;
			Helper.SubmitChangesWithCatch(gClass);
			new NotificationLabel(this, "Payment Type successfully saved.", NotificationTypes.Success).Show();
		}
		method_3();
		bool_0 = true;
	}

	private void method_4(object sender, EventArgs e)
	{
		PrintDialog printDialog = new PrintDialog();
		if (printDialog.ShowDialog(this) != DialogResult.Cancel)
		{
			lblPrinterName.Text = printDialog.PrinterSettings.PrinterName;
		}
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		if (bool_0)
		{
			GClass6 gClass = new GClass6();
			gClass.Terminals.ToList().ForEach(delegate(Terminal a)
			{
				a.AppRestartRequired = true;
			});
			try
			{
				gClass.SubmitChanges(ConflictMode.ContinueOnConflict);
			}
			catch (ChangeConflictException ex)
			{
				Console.WriteLine(ex.Message);
				foreach (ObjectChangeConflict changeConflict in gClass.ChangeConflicts)
				{
					changeConflict.Resolve(RefreshMode.OverwriteCurrentValues);
				}
			}
		}
		Close();
	}

	private void btnShowKeyboard_Name_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData("Enter Station Name", 1, 20, txtName.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtName.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnSort_Click(object sender, EventArgs e)
	{
		new frmManagePaymentTypesSortOrder().Show(this);
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmManagePaymentTypes));
		pictureBox1 = new PictureBox();
		lblHeaderTitle = new Label();
		ddlPaymentTypes = new Class19();
		label1 = new Label();
		txtName = new RadTextBoxControl();
		label2 = new Label();
		btnShowKeyboard_Name = new Button();
		btnDelete = new Button();
		btnAddNew = new Button();
		btnUpdate = new Button();
		label4 = new Label();
		chkEnableCashDrawer = new RadToggleSwitch();
		label7 = new Label();
		chkSendToPaymentTerminal = new RadToggleSwitch();
		label8 = new Label();
		lblPrinterName = new Label();
		btnSort = new Button();
		label3 = new Label();
		chkPrintReceipt = new RadToggleSwitch();
		label5 = new Label();
		((ISupportInitialize)pictureBox1).BeginInit();
		((ISupportInitialize)txtName).BeginInit();
		((ISupportInitialize)chkEnableCashDrawer).BeginInit();
		((ISupportInitialize)chkSendToPaymentTerminal).BeginInit();
		((ISupportInitialize)chkPrintReceipt).BeginInit();
		SuspendLayout();
		pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		pictureBox1.BackColor = Color.FromArgb(156, 89, 184);
		pictureBox1.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
		pictureBox1.ImeMode = ImeMode.NoControl;
		pictureBox1.Location = new Point(614, 5);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new Size(44, 37);
		pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 238;
		pictureBox1.TabStop = false;
		pictureBox1.Click += pictureBox1_Click;
		lblHeaderTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblHeaderTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblHeaderTitle.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		lblHeaderTitle.ForeColor = Color.White;
		lblHeaderTitle.ImeMode = ImeMode.NoControl;
		lblHeaderTitle.Location = new Point(7, 4);
		lblHeaderTitle.Name = "lblHeaderTitle";
		lblHeaderTitle.Size = new Size(652, 38);
		lblHeaderTitle.TabIndex = 237;
		lblHeaderTitle.Text = "MANAGE PAYMENT TYPES";
		lblHeaderTitle.TextAlign = ContentAlignment.MiddleCenter;
		ddlPaymentTypes.BackColor = Color.White;
		ddlPaymentTypes.DrawMode = DrawMode.OwnerDrawVariable;
		ddlPaymentTypes.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlPaymentTypes.FlatStyle = FlatStyle.Flat;
		ddlPaymentTypes.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		ddlPaymentTypes.FormattingEnabled = true;
		ddlPaymentTypes.ItemHeight = 28;
		ddlPaymentTypes.Items.AddRange(new object[1] { "**Please Select A Field Name**" });
		ddlPaymentTypes.Location = new Point(189, 43);
		ddlPaymentTypes.Margin = new Padding(2);
		ddlPaymentTypes.Name = "ddlPaymentTypes";
		ddlPaymentTypes.Size = new Size(470, 34);
		ddlPaymentTypes.TabIndex = 240;
		ddlPaymentTypes.SelectedIndexChanged += ddlPaymentTypes_SelectedIndexChanged;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		label1.Font = new Font("Microsoft Sans Serif", 12f);
		label1.ForeColor = SystemColors.ButtonFace;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(7, 43);
		label1.Margin = new Padding(2, 0, 2, 0);
		label1.Name = "label1";
		label1.Padding = new Padding(3, 0, 0, 0);
		label1.Size = new Size(181, 34);
		label1.TabIndex = 239;
		label1.Text = "Payment Types";
		label1.TextAlign = ContentAlignment.MiddleLeft;
		txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		txtName.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		txtName.ForeColor = Color.FromArgb(40, 40, 40);
		txtName.Location = new Point(189, 78);
		txtName.MaxLength = 20;
		txtName.Name = "txtName";
		txtName.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtName.Size = new Size(418, 35);
		txtName.TabIndex = 243;
		((RadTextBoxControlElement)txtName.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtName.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		label2.BackColor = Color.FromArgb(132, 146, 146);
		label2.Font = new Font("Microsoft Sans Serif", 12f);
		label2.ForeColor = SystemColors.ButtonFace;
		label2.ImeMode = ImeMode.NoControl;
		label2.Location = new Point(7, 78);
		label2.Margin = new Padding(2, 0, 2, 0);
		label2.Name = "label2";
		label2.Padding = new Padding(3, 0, 0, 0);
		label2.Size = new Size(181, 35);
		label2.TabIndex = 242;
		label2.Text = "Name";
		label2.TextAlign = ContentAlignment.MiddleLeft;
		btnShowKeyboard_Name.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Name.DialogResult = DialogResult.OK;
		btnShowKeyboard_Name.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Name.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_Name.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_Name.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_Name.ForeColor = Color.White;
		btnShowKeyboard_Name.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_Name.Image");
		btnShowKeyboard_Name.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_Name.Location = new Point(607, 78);
		btnShowKeyboard_Name.Margin = new Padding(2);
		btnShowKeyboard_Name.Name = "btnShowKeyboard_Name";
		btnShowKeyboard_Name.Size = new Size(52, 35);
		btnShowKeyboard_Name.TabIndex = 241;
		btnShowKeyboard_Name.UseVisualStyleBackColor = false;
		btnShowKeyboard_Name.Click += btnShowKeyboard_Name_Click;
		btnDelete.BackColor = Color.FromArgb(235, 107, 86);
		btnDelete.FlatAppearance.BorderColor = Color.White;
		btnDelete.FlatAppearance.BorderSize = 0;
		btnDelete.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnDelete.FlatStyle = FlatStyle.Flat;
		btnDelete.Font = new Font("Microsoft Sans Serif", 9f);
		btnDelete.ForeColor = Color.White;
		btnDelete.Image = (Image)componentResourceManager.GetObject("btnDelete.Image");
		btnDelete.ImeMode = ImeMode.NoControl;
		btnDelete.Location = new Point(297, 183);
		btnDelete.Name = "btnDelete";
		btnDelete.Size = new Size(120, 80);
		btnDelete.TabIndex = 246;
		btnDelete.Text = "DELETE";
		btnDelete.TextImageRelation = TextImageRelation.ImageAboveText;
		btnDelete.UseVisualStyleBackColor = false;
		btnDelete.Click += btnDelete_Click;
		btnAddNew.BackColor = Color.FromArgb(1, 110, 211);
		btnAddNew.DialogResult = DialogResult.OK;
		btnAddNew.FlatAppearance.BorderColor = Color.Black;
		btnAddNew.FlatAppearance.BorderSize = 0;
		btnAddNew.FlatStyle = FlatStyle.Flat;
		btnAddNew.Font = new Font("Microsoft Sans Serif", 9f);
		btnAddNew.ForeColor = Color.White;
		btnAddNew.Image = (Image)componentResourceManager.GetObject("btnAddNew.Image");
		btnAddNew.ImeMode = ImeMode.NoControl;
		btnAddNew.Location = new Point(418, 182);
		btnAddNew.Name = "btnAddNew";
		btnAddNew.Size = new Size(120, 80);
		btnAddNew.TabIndex = 245;
		btnAddNew.Text = "NEW";
		btnAddNew.TextImageRelation = TextImageRelation.ImageAboveText;
		btnAddNew.UseVisualStyleBackColor = false;
		btnAddNew.Click += btnAddNew_Click;
		btnUpdate.BackColor = Color.FromArgb(80, 203, 116);
		btnUpdate.FlatAppearance.BorderColor = Color.White;
		btnUpdate.FlatAppearance.BorderSize = 0;
		btnUpdate.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnUpdate.FlatStyle = FlatStyle.Flat;
		btnUpdate.Font = new Font("Microsoft Sans Serif", 9f);
		btnUpdate.ForeColor = Color.White;
		btnUpdate.Image = (Image)componentResourceManager.GetObject("btnUpdate.Image");
		btnUpdate.ImeMode = ImeMode.NoControl;
		btnUpdate.Location = new Point(539, 182);
		btnUpdate.Margin = new Padding(4, 5, 4, 5);
		btnUpdate.Name = "btnUpdate";
		btnUpdate.Size = new Size(120, 80);
		btnUpdate.TabIndex = 244;
		btnUpdate.Text = "SAVE";
		btnUpdate.TextImageRelation = TextImageRelation.ImageAboveText;
		btnUpdate.UseVisualStyleBackColor = false;
		btnUpdate.Click += btnUpdate_Click;
		label4.BackColor = Color.FromArgb(132, 146, 146);
		label4.Font = new Font("Microsoft Sans Serif", 12f);
		label4.ForeColor = SystemColors.ButtonFace;
		label4.ImeMode = ImeMode.NoControl;
		label4.Location = new Point(7, 114);
		label4.Margin = new Padding(2, 0, 2, 0);
		label4.Name = "label4";
		label4.Padding = new Padding(3, 0, 0, 0);
		label4.Size = new Size(181, 33);
		label4.TabIndex = 250;
		label4.Text = "Open Cash Drawer?";
		label4.TextAlign = ContentAlignment.MiddleLeft;
		chkEnableCashDrawer.Location = new Point(189, 114);
		chkEnableCashDrawer.Name = "chkEnableCashDrawer";
		chkEnableCashDrawer.OffText = "NO";
		chkEnableCashDrawer.OnText = "YES";
		chkEnableCashDrawer.Size = new Size(66, 33);
		chkEnableCashDrawer.TabIndex = 251;
		chkEnableCashDrawer.Tag = "";
		chkEnableCashDrawer.ToggleStateMode = ToggleStateMode.Click;
		chkEnableCashDrawer.Value = false;
		((RadToggleSwitchElement)chkEnableCashDrawer.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkEnableCashDrawer.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkEnableCashDrawer.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkEnableCashDrawer.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkEnableCashDrawer.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkEnableCashDrawer.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkEnableCashDrawer.GetChildAt(0).GetChildAt(0)).Text = "YES";
		((ToggleSwitchPartElement)chkEnableCashDrawer.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		label7.BackColor = Color.LemonChiffon;
		label7.Cursor = Cursors.Default;
		label7.Font = new Font("Microsoft Sans Serif", 9f);
		label7.ImeMode = ImeMode.NoControl;
		label7.Location = new Point(7, 182);
		label7.Name = "label7";
		label7.Padding = new Padding(5);
		label7.Size = new Size(181, 80);
		label7.TabIndex = 257;
		label7.Text = "Use this module to add, edit, delete payment types that will show in Cash Out screen.";
		chkSendToPaymentTerminal.Location = new Point(490, 114);
		chkSendToPaymentTerminal.Name = "chkSendToPaymentTerminal";
		chkSendToPaymentTerminal.OffText = "NO";
		chkSendToPaymentTerminal.OnText = "YES";
		chkSendToPaymentTerminal.Size = new Size(66, 33);
		chkSendToPaymentTerminal.TabIndex = 259;
		chkSendToPaymentTerminal.Tag = "";
		chkSendToPaymentTerminal.ToggleStateMode = ToggleStateMode.Click;
		chkSendToPaymentTerminal.Value = false;
		((RadToggleSwitchElement)chkSendToPaymentTerminal.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkSendToPaymentTerminal.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkSendToPaymentTerminal.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkSendToPaymentTerminal.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkSendToPaymentTerminal.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkSendToPaymentTerminal.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkSendToPaymentTerminal.GetChildAt(0).GetChildAt(0)).Text = "YES";
		((ToggleSwitchPartElement)chkSendToPaymentTerminal.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		label8.BackColor = Color.FromArgb(132, 146, 146);
		label8.Font = new Font("Microsoft Sans Serif", 12f);
		label8.ForeColor = SystemColors.ButtonFace;
		label8.ImeMode = ImeMode.NoControl;
		label8.Location = new Point(256, 114);
		label8.Margin = new Padding(2, 0, 2, 0);
		label8.Name = "label8";
		label8.Padding = new Padding(3, 0, 0, 0);
		label8.Size = new Size(233, 33);
		label8.TabIndex = 258;
		label8.Text = "Uses Payment Terminal?";
		label8.TextAlign = ContentAlignment.MiddleLeft;
		lblPrinterName.BackColor = Color.Gray;
		lblPrinterName.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		lblPrinterName.ForeColor = Color.White;
		lblPrinterName.ImeMode = ImeMode.NoControl;
		lblPrinterName.Location = new Point(557, 114);
		lblPrinterName.Name = "lblPrinterName";
		lblPrinterName.Padding = new Padding(5, 0, 0, 0);
		lblPrinterName.Size = new Size(102, 33);
		lblPrinterName.TabIndex = 253;
		lblPrinterName.TextAlign = ContentAlignment.MiddleLeft;
		lblPrinterName.UseWaitCursor = true;
		btnSort.BackColor = Color.FromArgb(50, 119, 155);
		btnSort.FlatAppearance.BorderColor = Color.White;
		btnSort.FlatAppearance.BorderSize = 0;
		btnSort.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnSort.FlatStyle = FlatStyle.Flat;
		btnSort.Font = new Font("Microsoft Sans Serif", 9f);
		btnSort.ForeColor = Color.White;
		btnSort.Image = (Image)componentResourceManager.GetObject("btnSort.Image");
		btnSort.ImeMode = ImeMode.NoControl;
		btnSort.Location = new Point(189, 182);
		btnSort.Name = "btnSort";
		btnSort.Size = new Size(107, 80);
		btnSort.TabIndex = 260;
		btnSort.Text = "SORT";
		btnSort.TextImageRelation = TextImageRelation.ImageAboveText;
		btnSort.UseVisualStyleBackColor = false;
		btnSort.Click += btnSort_Click;
		label3.BackColor = Color.FromArgb(132, 146, 146);
		label3.Font = new Font("Microsoft Sans Serif", 12f);
		label3.ForeColor = SystemColors.ButtonFace;
		label3.ImeMode = ImeMode.NoControl;
		label3.Location = new Point(7, 148);
		label3.Margin = new Padding(2, 0, 2, 0);
		label3.Name = "label3";
		label3.Padding = new Padding(3, 0, 0, 0);
		label3.Size = new Size(181, 33);
		label3.TabIndex = 261;
		label3.Text = "Auto Print Receipt";
		label3.TextAlign = ContentAlignment.MiddleLeft;
		chkPrintReceipt.Location = new Point(189, 148);
		chkPrintReceipt.Name = "chkPrintReceipt";
		chkPrintReceipt.OffText = "NO";
		chkPrintReceipt.OnText = "YES";
		chkPrintReceipt.Size = new Size(66, 33);
		chkPrintReceipt.TabIndex = 262;
		chkPrintReceipt.Tag = "";
		chkPrintReceipt.ToggleStateMode = ToggleStateMode.Click;
		chkPrintReceipt.Value = false;
		((RadToggleSwitchElement)chkPrintReceipt.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkPrintReceipt.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkPrintReceipt.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkPrintReceipt.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkPrintReceipt.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkPrintReceipt.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkPrintReceipt.GetChildAt(0).GetChildAt(0)).Text = "YES";
		((ToggleSwitchPartElement)chkPrintReceipt.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		label5.BackColor = Color.Gray;
		label5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		label5.ForeColor = Color.White;
		label5.ImeMode = ImeMode.NoControl;
		label5.Location = new Point(256, 148);
		label5.Name = "label5";
		label5.Padding = new Padding(5, 0, 0, 0);
		label5.Size = new Size(403, 33);
		label5.TabIndex = 263;
		label5.TextAlign = ContentAlignment.MiddleLeft;
		label5.UseWaitCursor = true;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(666, 275);
		base.Controls.Add(label5);
		base.Controls.Add(chkPrintReceipt);
		base.Controls.Add(label3);
		base.Controls.Add(btnSort);
		base.Controls.Add(chkSendToPaymentTerminal);
		base.Controls.Add(label8);
		base.Controls.Add(label7);
		base.Controls.Add(lblPrinterName);
		base.Controls.Add(chkEnableCashDrawer);
		base.Controls.Add(label4);
		base.Controls.Add(btnDelete);
		base.Controls.Add(btnAddNew);
		base.Controls.Add(btnUpdate);
		base.Controls.Add(txtName);
		base.Controls.Add(label2);
		base.Controls.Add(btnShowKeyboard_Name);
		base.Controls.Add(ddlPaymentTypes);
		base.Controls.Add(label1);
		base.Controls.Add(pictureBox1);
		base.Controls.Add(lblHeaderTitle);
		base.Name = "frmManagePaymentTypes";
		base.Opacity = 1.0;
		Text = "frmManageStations";
		base.Load += frmManagePaymentTypes_Load;
		((ISupportInitialize)pictureBox1).EndInit();
		((ISupportInitialize)txtName).EndInit();
		((ISupportInitialize)chkEnableCashDrawer).EndInit();
		((ISupportInitialize)chkSendToPaymentTerminal).EndInit();
		((ISupportInitialize)chkPrintReceipt).EndInit();
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private bool method_5(PaymentType paymentType_0)
	{
		if (paymentType_0.Name.ToUpper() == txtName.Text.Trim().ToUpper())
		{
			return paymentType_0.Id.ToString() != ddlPaymentTypes.SelectedValue.ToString();
		}
		return false;
	}
}
