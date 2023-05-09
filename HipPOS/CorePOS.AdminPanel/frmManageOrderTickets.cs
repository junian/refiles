using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace CorePOS.AdminPanel;

public class frmManageOrderTickets : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public short genKeyId;

		public _003C_003Ec__DisplayClass6_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_1
	{
		public string orderType;

		public _003C_003Ec__DisplayClass6_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public short genKeyId;

		public _003C_003Ec__DisplayClass11_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	private Dictionary<string, string> dictionary_0;

	private IContainer icontainer_1;

	private Label lblHeaderTitle;

	private Label label2;

	private RadTextBoxControl txtStartKey;

	internal Button btnShowKeyboard_StartKey;

	internal Button btnShowKeyboard_EndKey;

	private RadTextBoxControl txtEndKey;

	private Label label3;

	private Label label5;

	internal Button btnSave;

	private PictureBox btnClose;

	internal Button btnExit;

	private Panel panel1;

	private Label label1;

	private Class20 ddlGenKey;

	private Label label9;

	public frmManageOrderTickets()
	{
		Class26.Ggkj0JxzN9YmC();
		dictionary_0 = new Dictionary<string, string>();
		// base._002Ector();
		InitializeComponent_1();
	}

	private void frmManageOrderTickets_Load(object sender, EventArgs e)
	{
		Dictionary<string, string> dictionary = OrderTypesDictionary.OrderTypes.ToDictionary((KeyValuePair<string, string> a) => a.Key, (KeyValuePair<string, string> a) => a.Value);
		dictionary_0 = dictionary;
		method_3();
		method_4();
	}

	private void method_3()
	{
		ddlGenKey.Items.Clear();
		GClass6 gClass = new GClass6();
		Dictionary<string, string> dictionary = new Dictionary<string, string> { { "0", "**ADD NEW TICKET RANGE**" } };
		foreach (GenKey item in gClass.GenKeys.Where((GenKey a) => a.GenKeyID > 3 && a.KeyName != "OrderNumber" && a.KeyName != "RefundNumber" && a.KeyName != "OrderTicket").ToList())
		{
			dictionary.Add(item.GenKeyID.ToString(), item.KeyName);
		}
		ddlGenKey.DisplayMember = "Value";
		ddlGenKey.ValueMember = "Key";
		ddlGenKey.DataSource = new BindingSource(dictionary, null);
		ddlGenKey.SelectedIndex = 0;
	}

	private void method_4()
	{
		int num = 0;
		foreach (KeyValuePair<string, string> item in dictionary_0)
		{
			Class17 @class = new Class17();
			@class.Name = item.Value;
			@class.Tag = item.Key;
			@class.Location = new Point(10, 40 * num + 10);
			panel1.Controls.Add(@class);
			Label label = new Label();
			label.Name = "lbl" + item.Value;
			label.Text = item.Value;
			label.Location = new Point(50, 40 * num + 10);
			label.Size = new Size(300, 30);
			label.Font = new Font(lblHeaderTitle.Font.FontFamily, 13f, FontStyle.Regular);
			label.ForeColor = Color.Black;
			label.BackColor = Color.White;
			label.TextAlign = ContentAlignment.MiddleLeft;
			panel1.Controls.Add(label);
			num++;
		}
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		if (string.IsNullOrEmpty(txtStartKey.Text))
		{
			new NotificationLabel(this, "Please add a start num", NotificationTypes.Warning).Show();
			return;
		}
		if (string.IsNullOrEmpty(txtEndKey.Text))
		{
			new NotificationLabel(this, "Please add a end num", NotificationTypes.Warning).Show();
			return;
		}
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals0.genKeyId = Convert.ToInt16(ddlGenKey.SelectedValue.ToString());
		int num = Convert.ToInt32(txtStartKey.Text);
		int num2 = Convert.ToInt32(txtEndKey.Text);
		foreach (GenKey item in gClass.GenKeys.Where((GenKey a) => a.GenKeyID != CS_0024_003C_003E8__locals0.genKeyId && a.KeyName.Contains("OrderTicket") && a.StartKey != null && a.EndKey != null).ToList())
		{
			if (MathHelper.IsOverlapping(num, num2, item.StartKey.Value, item.EndKey.Value))
			{
				new NotificationLabel(this, "Ticket range is already in use please use another", NotificationTypes.Warning).Show();
				return;
			}
		}
		List<string> list = new List<string>();
		foreach (object control in panel1.Controls)
		{
			if (control is Class17)
			{
				Class17 @class = control as Class17;
				if (@class.Checked)
				{
					list.Add(@class.Tag.ToString());
				}
			}
		}
		if (CS_0024_003C_003E8__locals0.genKeyId != 0)
		{
			GenKey genKey = gClass.GenKeys.Where((GenKey a) => a.GenKeyID == CS_0024_003C_003E8__locals0.genKeyId).FirstOrDefault();
			if (Convert.ToInt32(txtStartKey.Text) != genKey.StartKey)
			{
				genKey.LastKey = Convert.ToInt32(txtStartKey.Text);
			}
			genKey.StartKey = num;
			genKey.EndKey = num2;
			gClass.SubmitChanges();
		}
		else
		{
			GenKey genKey2 = new GenKey
			{
				KeyName = "OrderTicket " + txtStartKey.Text + "-" + txtEndKey.Text,
				LastKey = num,
				StartKey = num,
				EndKey = num2
			};
			gClass.GenKeys.InsertOnSubmit(genKey2);
			gClass.SubmitChanges();
			CS_0024_003C_003E8__locals0.genKeyId = genKey2.GenKeyID;
		}
		using (IEnumerator<string> enumerator3 = dictionary_0.Select((KeyValuePair<string, string> a) => a.Key).GetEnumerator())
		{
			while (enumerator3.MoveNext())
			{
				_003C_003Ec__DisplayClass6_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass6_1();
				CS_0024_003C_003E8__locals1.orderType = enumerator3.Current;
				OrderTypeGenKey orderTypeGenKey = gClass.OrderTypeGenKeys.Where((OrderTypeGenKey a) => a.OrderType == CS_0024_003C_003E8__locals1.orderType).FirstOrDefault();
				if (list.Contains(CS_0024_003C_003E8__locals1.orderType))
				{
					if (orderTypeGenKey != null)
					{
						orderTypeGenKey.GenKeysId = CS_0024_003C_003E8__locals0.genKeyId;
						gClass.SubmitChanges();
						continue;
					}
					orderTypeGenKey = new OrderTypeGenKey
					{
						OrderType = CS_0024_003C_003E8__locals1.orderType,
						GenKeysId = CS_0024_003C_003E8__locals0.genKeyId
					};
					gClass.OrderTypeGenKeys.InsertOnSubmit(orderTypeGenKey);
					gClass.SubmitChanges();
				}
				else if (orderTypeGenKey != null && orderTypeGenKey.GenKeysId == CS_0024_003C_003E8__locals0.genKeyId)
				{
					gClass.OrderTypeGenKeys.DeleteOnSubmit(orderTypeGenKey);
					gClass.SubmitChanges();
				}
			}
		}
		method_3();
		new NotificationLabel(this, "Order ticket range saved.", NotificationTypes.Success).Show();
	}

	private void btnShowKeyboard_StartKey_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Start Key", 0, 5, txtStartKey.Text, "", allowNegative: false, useNotifLabel: true);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtStartKey.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_EndKey_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("End Key", 0, 5, txtStartKey.Text, "", allowNegative: false, useNotifLabel: true);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtEndKey.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnExit_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void method_5()
	{
		foreach (object control in panel1.Controls)
		{
			if (control is Class17)
			{
				(control as Class17).Checked = false;
			}
		}
	}

	private void ddlGenKey_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
	{
		if (ddlGenKey.Items == null || ddlGenKey.Items.Count <= 0 || ddlGenKey.SelectedValue == null)
		{
			return;
		}
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass11_0();
		method_5();
		CS_0024_003C_003E8__locals0.genKeyId = Convert.ToInt16(ddlGenKey.SelectedValue.ToString());
		if (CS_0024_003C_003E8__locals0.genKeyId != 0)
		{
			GenKey genKey = new GClass6().GenKeys.Where((GenKey a) => a.GenKeyID == CS_0024_003C_003E8__locals0.genKeyId).FirstOrDefault();
			List<OrderTypeGenKey> source = genKey.OrderTypeGenKeys.ToList();
			txtStartKey.Text = genKey.StartKey.ToString();
			txtEndKey.Text = genKey.EndKey.ToString();
			{
				foreach (object control in panel1.Controls)
				{
					if (control is Class17)
					{
						Class17 @class = control as Class17;
						if (source.Select((OrderTypeGenKey a) => a.OrderType).Contains(@class.Tag.ToString()))
						{
							@class.Checked = true;
						}
					}
				}
				return;
			}
		}
		txtStartKey.Text = "";
		txtEndKey.Text = "";
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmManageOrderTickets));
		lblHeaderTitle = new Label();
		label2 = new Label();
		txtStartKey = new RadTextBoxControl();
		btnShowKeyboard_StartKey = new Button();
		btnShowKeyboard_EndKey = new Button();
		txtEndKey = new RadTextBoxControl();
		label3 = new Label();
		label5 = new Label();
		btnSave = new Button();
		btnClose = new PictureBox();
		btnExit = new Button();
		panel1 = new Panel();
		label1 = new Label();
		label9 = new Label();
		ddlGenKey = new Class20();
		((ISupportInitialize)txtStartKey).BeginInit();
		((ISupportInitialize)txtEndKey).BeginInit();
		((ISupportInitialize)btnClose).BeginInit();
		((ISupportInitialize)ddlGenKey).BeginInit();
		SuspendLayout();
		lblHeaderTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblHeaderTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblHeaderTitle.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		lblHeaderTitle.ForeColor = Color.White;
		lblHeaderTitle.ImeMode = ImeMode.NoControl;
		lblHeaderTitle.Location = new Point(5, 6);
		lblHeaderTitle.Name = "lblHeaderTitle";
		lblHeaderTitle.Size = new Size(592, 38);
		lblHeaderTitle.TabIndex = 122;
		lblHeaderTitle.Text = "ASSIGN ORDER TICKET RANGES";
		lblHeaderTitle.TextAlign = ContentAlignment.MiddleCenter;
		label2.BackColor = Color.FromArgb(132, 146, 146);
		label2.Font = new Font("Microsoft Sans Serif", 12f);
		label2.ForeColor = Color.White;
		label2.ImeMode = ImeMode.NoControl;
		label2.Location = new Point(5, 386);
		label2.Margin = new Padding(4, 0, 4, 0);
		label2.MinimumSize = new Size(120, 34);
		label2.Name = "label2";
		label2.Size = new Size(136, 45);
		label2.TabIndex = 213;
		label2.Text = "Start Number";
		label2.TextAlign = ContentAlignment.MiddleLeft;
		txtStartKey.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		txtStartKey.Location = new Point(142, 386);
		txtStartKey.MaxLength = 50;
		txtStartKey.Name = "txtStartKey";
		txtStartKey.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtStartKey.Size = new Size(101, 44);
		txtStartKey.TabIndex = 214;
		((RadTextBoxControlElement)txtStartKey.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtStartKey.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		btnShowKeyboard_StartKey.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_StartKey.DialogResult = DialogResult.OK;
		btnShowKeyboard_StartKey.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_StartKey.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_StartKey.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_StartKey.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_StartKey.ForeColor = Color.White;
		btnShowKeyboard_StartKey.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_StartKey.Image");
		btnShowKeyboard_StartKey.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_StartKey.Location = new Point(244, 386);
		btnShowKeyboard_StartKey.Name = "btnShowKeyboard_StartKey";
		btnShowKeyboard_StartKey.Size = new Size(60, 44);
		btnShowKeyboard_StartKey.TabIndex = 216;
		btnShowKeyboard_StartKey.UseVisualStyleBackColor = false;
		btnShowKeyboard_StartKey.Click += btnShowKeyboard_StartKey_Click;
		btnShowKeyboard_EndKey.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_EndKey.DialogResult = DialogResult.OK;
		btnShowKeyboard_EndKey.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_EndKey.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_EndKey.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_EndKey.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_EndKey.ForeColor = Color.White;
		btnShowKeyboard_EndKey.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_EndKey.Image");
		btnShowKeyboard_EndKey.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_EndKey.Location = new Point(244, 431);
		btnShowKeyboard_EndKey.Name = "btnShowKeyboard_EndKey";
		btnShowKeyboard_EndKey.Size = new Size(60, 42);
		btnShowKeyboard_EndKey.TabIndex = 219;
		btnShowKeyboard_EndKey.UseVisualStyleBackColor = false;
		btnShowKeyboard_EndKey.Click += btnShowKeyboard_EndKey_Click;
		txtEndKey.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		txtEndKey.Location = new Point(142, 431);
		txtEndKey.MaxLength = 50;
		txtEndKey.Name = "txtEndKey";
		txtEndKey.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtEndKey.Size = new Size(101, 42);
		txtEndKey.TabIndex = 218;
		((RadTextBoxControlElement)txtEndKey.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtEndKey.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		label3.BackColor = Color.FromArgb(132, 146, 146);
		label3.Font = new Font("Microsoft Sans Serif", 12f);
		label3.ForeColor = Color.White;
		label3.ImeMode = ImeMode.NoControl;
		label3.Location = new Point(5, 432);
		label3.Margin = new Padding(4, 0, 4, 0);
		label3.MinimumSize = new Size(120, 34);
		label3.Name = "label3";
		label3.Size = new Size(136, 41);
		label3.TabIndex = 217;
		label3.Text = "End Number";
		label3.TextAlign = ContentAlignment.MiddleLeft;
		label5.BackColor = Color.FromArgb(132, 146, 146);
		label5.Font = new Font("Microsoft Sans Serif", 12f);
		label5.ForeColor = Color.White;
		label5.ImeMode = ImeMode.NoControl;
		label5.Location = new Point(5, 79);
		label5.Margin = new Padding(4, 0, 4, 0);
		label5.MinimumSize = new Size(120, 34);
		label5.Name = "label5";
		label5.Size = new Size(136, 34);
		label5.TabIndex = 247;
		label5.Text = "Order Type";
		label5.TextAlign = ContentAlignment.MiddleLeft;
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderColor = Color.White;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnSave.FlatStyle = FlatStyle.Flat;
		btnSave.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		btnSave.ForeColor = Color.White;
		btnSave.Image = (Image)componentResourceManager.GetObject("btnSave.Image");
		btnSave.ImeMode = ImeMode.NoControl;
		btnSave.Location = new Point(305, 385);
		btnSave.Margin = new Padding(4, 5, 4, 5);
		btnSave.Name = "btnSave";
		btnSave.Size = new Size(145, 88);
		btnSave.TabIndex = 252;
		btnSave.Text = "SAVE";
		btnSave.TextImageRelation = TextImageRelation.ImageAboveText;
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnClose.BackColor = Color.FromArgb(156, 89, 184);
		btnClose.Image = (Image)componentResourceManager.GetObject("btnClose.Image");
		btnClose.ImeMode = ImeMode.NoControl;
		btnClose.Location = new Point(557, 6);
		btnClose.Name = "btnClose";
		btnClose.Size = new Size(40, 37);
		btnClose.SizeMode = PictureBoxSizeMode.StretchImage;
		btnClose.TabIndex = 253;
		btnClose.TabStop = false;
		btnClose.Click += btnClose_Click;
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
		btnExit.Location = new Point(451, 386);
		btnExit.Name = "btnExit";
		btnExit.Padding = new Padding(0, 5, 0, 5);
		btnExit.Size = new Size(146, 87);
		btnExit.TabIndex = 258;
		btnExit.Text = "CLOSE";
		btnExit.TextAlign = ContentAlignment.BottomCenter;
		btnExit.UseVisualStyleBackColor = false;
		btnExit.Click += btnExit_Click;
		panel1.AutoScroll = true;
		panel1.BackColor = Color.White;
		panel1.Location = new Point(142, 80);
		panel1.Margin = new Padding(10);
		panel1.Name = "panel1";
		panel1.Padding = new Padding(10);
		panel1.Size = new Size(455, 305);
		panel1.TabIndex = 260;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		label1.Font = new Font("Microsoft Sans Serif", 12f);
		label1.ForeColor = Color.White;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(5, 113);
		label1.Margin = new Padding(4, 0, 4, 0);
		label1.MinimumSize = new Size(120, 34);
		label1.Name = "label1";
		label1.Size = new Size(136, 272);
		label1.TabIndex = 261;
		label1.TextAlign = ContentAlignment.MiddleLeft;
		label9.BackColor = Color.FromArgb(132, 146, 146);
		label9.Font = new Font("Microsoft Sans Serif", 12f);
		label9.ForeColor = Color.White;
		label9.ImeMode = ImeMode.NoControl;
		label9.Location = new Point(5, 44);
		label9.Margin = new Padding(4, 0, 4, 0);
		label9.MinimumSize = new Size(120, 34);
		label9.Name = "label9";
		label9.Size = new Size(136, 34);
		label9.TabIndex = 262;
		label9.Text = "Ticket Name";
		label9.TextAlign = ContentAlignment.MiddleLeft;
		ddlGenKey.AutoSize = false;
		ddlGenKey.BackColor = Color.White;
		ddlGenKey.DefaultItemsCountInDropDown = 10;
		ddlGenKey.DropDownStyle = RadDropDownStyle.DropDownList;
		ddlGenKey.EnableKineticScrolling = true;
		ddlGenKey.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		ddlGenKey.Location = new Point(142, 44);
		ddlGenKey.Name = "ddlGenKey";
		ddlGenKey.Size = new Size(455, 34);
		ddlGenKey.TabIndex = 263;
		ddlGenKey.ThemeName = "Windows8";
		ddlGenKey.SelectedIndexChanged += ddlGenKey_SelectedIndexChanged;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(602, 480);
		base.Controls.Add(panel1);
		base.Controls.Add(ddlGenKey);
		base.Controls.Add(label9);
		base.Controls.Add(label1);
		base.Controls.Add(btnExit);
		base.Controls.Add(btnClose);
		base.Controls.Add(btnSave);
		base.Controls.Add(label5);
		base.Controls.Add(btnShowKeyboard_EndKey);
		base.Controls.Add(txtEndKey);
		base.Controls.Add(label3);
		base.Controls.Add(btnShowKeyboard_StartKey);
		base.Controls.Add(txtStartKey);
		base.Controls.Add(label2);
		base.Controls.Add(lblHeaderTitle);
		base.Name = "frmManageOrderTickets";
		base.Opacity = 1.0;
		Text = "frmManageOrderTickets";
		base.Load += frmManageOrderTickets_Load;
		((ISupportInitialize)txtStartKey).EndInit();
		((ISupportInitialize)txtEndKey).EndInit();
		((ISupportInitialize)btnClose).EndInit();
		((ISupportInitialize)ddlGenKey).EndInit();
		ResumeLayout(performLayout: false);
	}
}
