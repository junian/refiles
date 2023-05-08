using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Properties;

namespace CorePOS;

public class frmSelectPaymentMethodMultiple : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass27_0
	{
		public string selectedId;

		public _003C_003Ec__DisplayClass27_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CbtnRemove_Click_003Eb__0(ProcessorPaymentTypeWithId u)
		{
			return u.Id == selectedId;
		}
	}

	private decimal decimal_0;

	private decimal decimal_1;

	[CompilerGenerated]
	private List<ProcessorPaymentTypeWithId> list_2;

	public decimal TenderCash;

	public decimal TenderChange;

	public decimal Tip;

	private int int_0;

	private IContainer icontainer_1;

	private Label lblTitle;

	internal Button btnDone;

	internal Button btnCancel;

	internal Button button5;

	private Label label2;

	private Label label3;

	internal Button btnClear;

	internal Button button3;

	internal Button Button7;

	internal Button Button6;

	internal Button btnExactChange;

	internal Button Button8;

	internal Button Button29;

	internal Button Button26;

	internal Button Button27;

	internal Button Button28;

	internal Button Button18;

	internal Button Button19;

	internal Button Button20;

	internal Button Button0;

	internal Button Button4;

	internal Button Button2;

	internal Button Button1;

	internal Class18 txtInput;

	private Label label1;

	internal ListView lstTenderTypes;

	internal ColumnHeader columnHeader_0;

	internal ColumnHeader columnHeader_1;

	private Label sideLabel;

	internal TextBox txtAmountDue;

	internal Label Label6;

	internal Label Label5;

	internal TextBox txtChange;

	internal TextBox txtTotal;

	internal Label label4;

	internal Button btnRemove;

	private Panel panel1;

	private FlowLayoutPanel pnlTenderTypes;

	public List<ProcessorPaymentTypeWithId> paymentMethod
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

	public frmSelectPaymentMethodMultiple(decimal amountDue)
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		paymentMethod = new List<ProcessorPaymentTypeWithId>();
		txtTotal.Text = (txtAmountDue.Text = amountDue.ToString("0.00"));
		decimal_1 = amountDue;
		foreach (Button item in pnlTenderTypes.Controls.OfType<Button>().Cast<Control>().ToList())
		{
			item.EnabledChanged += btnDone_EnabledChanged;
		}
		txtInput.Text = txtAmountDue.Text.RemoveAllNonNumeric();
		method_5(bool_0: true);
	}

	private void frmSelectPaymentMethodMultiple_Load(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		int num = 0;
		foreach (PaymentType item in gClass.PaymentTypes.OrderBy((PaymentType x) => x.SortOrder))
		{
			for (int i = 0; i < 14; i++)
			{
				if (num != item.SortOrder)
				{
					method_8(num);
					num++;
					continue;
				}
				method_7(item.Name, item.OpenCashDrawer, item.UsePaymentTerminal);
				num++;
				break;
			}
		}
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		method_3((Button)sender);
	}

	private void method_3(Button button_0)
	{
		try
		{
			if (txtInput.Text.Equals(0.ToString("0.00")))
			{
				txtInput.Text = string.Empty;
			}
			if (txtInput.Text.Length >= txtInput.MaxLength)
			{
				return;
			}
			if (txtInput.Text != string.Empty && Convert.ToDecimal(txtInput.Text) > 1000000m)
			{
				new frmMessageBox("Tender input is too large.").ShowDialog();
				return;
			}
			char c = '-';
			if (txtInput.Text.Contains("."))
			{
				c = '.';
			}
			else if (txtInput.Text.Contains(","))
			{
				c = ',';
			}
			if (c != '-')
			{
				if (txtInput.Text.Split(c)[1].Length < 2)
				{
					txtInput.Text += button_0.Text;
				}
				else
				{
					txtInput.Text = button_0.Text;
				}
			}
			else
			{
				txtInput.Text += button_0.Text;
			}
		}
		catch
		{
			txtInput.Text = string.Empty;
		}
	}

	private void method_4(decimal decimal_2)
	{
		txtInput.Text = decimal_2.ToString();
		xqJoNcOqTd(Resources.CASH0);
		txtInput.Text = 0.ToString("0.00");
		Button button = btnExactChange;
		Button button2 = button5;
		Button button3 = this.button3;
		Button button4 = Button6;
		bool flag2 = (Button7.Enabled = !(txtAmountDue.Text.ToDecimalWithCleanUp() == 0m));
		bool flag4 = (button4.Enabled = flag2);
		bool flag6 = (button3.Enabled = flag4);
		bool enabled = (button2.Enabled = flag6);
		button.Enabled = enabled;
		method_6();
	}

	private void xqJoNcOqTd(string string_0)
	{
		if (paymentMethod.Count >= 5)
		{
			new frmMessageBox("You can only add up to 5 payment methods", "Exceeding Payment Methods").ShowDialog();
			return;
		}
		decimal_0 += Convert.ToDecimal(txtInput.Text);
		string text = Guid.NewGuid().ToString();
		decimal num = Convert.ToDecimal($"{txtInput.Text:0.00}");
		ListViewItem value = new ListViewItem(new string[3]
		{
			string_0.ToUpper(),
			$"{num:C}",
			text
		});
		lstTenderTypes.Items.Add(value);
		method_6();
		decimal num2 = txtChange.Text.ToDecimalWithCleanUp();
		if (string_0.ToUpper() == Resources.CASH0)
		{
			paymentMethod.Add(new ProcessorPaymentTypeWithId
			{
				PaymentTypeName = string_0.ToUpper(),
				Amount = num - num2,
				Id = text
			});
			TenderCash += num;
			if (num2 > 0m)
			{
				TenderChange = num2;
			}
			if (txtAmountDue.Text.ToDecimalWithCleanUp() <= 0m)
			{
				GClass8.OpenCashDrawer();
			}
			return;
		}
		paymentMethod.Add(new ProcessorPaymentTypeWithId
		{
			PaymentTypeName = string_0.ToUpper(),
			Amount = num,
			Id = text
		});
		if (num2 > 0m)
		{
			if (SettingsHelper.GetSettingValueByKey("auto_tip_cash_back") == "ON")
			{
				Tip = Math.Abs(txtChange.Text.ToDecimalWithCleanUp());
				return;
			}
			paymentMethod.Add(new ProcessorPaymentTypeWithId
			{
				PaymentTypeName = Resources.CashBack,
				Amount = -txtChange.Text.ToDecimalWithCleanUp(),
				Id = text
			});
		}
	}

	private void method_5(bool bool_0)
	{
		foreach (Button item in pnlTenderTypes.Controls.OfType<Button>().Cast<Control>().ToList())
		{
			item.Enabled = bool_0;
		}
		btnDone.Enabled = !bool_0;
	}

	private void method_6()
	{
		decimal num = decimal_1 - decimal_0;
		if (num > 0m)
		{
			txtAmountDue.Text = num.ToString("0.00", Thread.CurrentThread.CurrentCulture);
		}
		else
		{
			txtAmountDue.Text = 0.ToString("0.00", Thread.CurrentThread.CurrentCulture);
		}
		if (txtAmountDue.Text.ToDecimalWithCleanUp() == 0m)
		{
			method_5(bool_0: false);
			Button button = btnExactChange;
			Button button2 = this.button5;
			Button button3 = this.button3;
			Button button4 = Button6;
			Button7.Enabled = false;
			button4.Enabled = false;
			button3.Enabled = false;
			button2.Enabled = false;
			button.Enabled = false;
		}
		else
		{
			Button button5 = btnExactChange;
			Button button6 = this.button5;
			Button button7 = this.button3;
			Button button8 = Button6;
			Button7.Enabled = true;
			button8.Enabled = true;
			button7.Enabled = true;
			button6.Enabled = true;
			button5.Enabled = true;
			method_5(bool_0: true);
		}
		if (num <= 0m)
		{
			txtChange.Text = (-num).ToString("0.00", Thread.CurrentThread.CurrentCulture);
			btnDone.Enabled = true;
		}
		else
		{
			txtChange.Text = 0.ToString("0.00", Thread.CurrentThread.CurrentCulture);
			btnDone.Enabled = false;
		}
		txtInput.Text = txtAmountDue.Text;
	}

	private void Button6_Click(object sender, EventArgs e)
	{
		method_4(50m);
	}

	private void Button7_Click(object sender, EventArgs e)
	{
		method_4(20m);
	}

	private void button3_Click(object sender, EventArgs e)
	{
		method_4(10m);
	}

	private void button5_Click(object sender, EventArgs e)
	{
		method_4(5m);
	}

	private void btnExactChange_Click(object sender, EventArgs e)
	{
		txtInput.Text = txtAmountDue.Text.RemoveAllNonNumeric();
	}

	private void btnClear_Click(object sender, EventArgs e)
	{
		txtInput.Text = 0.ToString("0.00");
		txtInput.Select();
	}

	private void btnDone_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
	}

	private void btnDone_EnabledChanged(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (!button.Enabled)
		{
			button.Tag = button.BackColor;
			button.BackColor = Color.Gray;
		}
		else if (!string.IsNullOrEmpty(button.Tag.ToString()))
		{
			button.BackColor = (Color)button.Tag;
		}
	}

	private void btnRemove_Click(object sender, EventArgs e)
	{
		if (lstTenderTypes.SelectedItems.Count == 0 && lstTenderTypes.Items.Count != 1)
		{
			new frmMessageBox(Resources.Please_select_a_Tender_Type_to, Resources._Error).ShowDialog(this);
			return;
		}
		_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass27_0();
		if (lstTenderTypes.Items.Count == 1)
		{
			lstTenderTypes.Items[0].Selected = true;
		}
		string obj = lstTenderTypes.SelectedItems[0].Text;
		CS_0024_003C_003E8__locals0.selectedId = lstTenderTypes.SelectedItems[0].SubItems[2].Text;
		paymentMethod.RemoveAll((ProcessorPaymentTypeWithId u) => u.Id == CS_0024_003C_003E8__locals0.selectedId);
		string text = lstTenderTypes.SelectedItems[0].SubItems[1].Text.RemoveAllNonNumeric();
		if (text.Contains("("))
		{
			text = "-" + text.Replace("(", string.Empty).Replace(")", string.Empty);
		}
		decimal num = Convert.ToDecimal(text);
		decimal_0 -= num;
		lstTenderTypes.SelectedItems[0].Remove();
		method_6();
		if (obj.ToUpper() == Resources.Cash.ToUpper())
		{
			TenderCash -= num;
			TenderChange -= num;
			if (TenderChange <= 0m)
			{
				TenderChange = default(decimal);
			}
		}
		if (Convert.ToDecimal(txtInput.Text) == 0m)
		{
			method_5(bool_0: false);
		}
	}

	private void txtInput_TextChanged(object sender, EventArgs e)
	{
		try
		{
			decimal num = Convert.ToDecimal(txtInput.Text);
			if (num > 0m && num < 10000000m)
			{
				method_5(bool_0: true);
			}
			else
			{
				method_5(bool_0: false);
			}
		}
		catch
		{
			method_5(bool_0: false);
		}
	}

	private void QrjcCshqOc(object sender, EventArgs e)
	{
		Button button = sender as Button;
		if (button.Text.Contains(Resources.CASH0))
		{
			xqJoNcOqTd(Resources.CASH0);
			return;
		}
		string string_ = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(button.Text.ToLower());
		xqJoNcOqTd(string_);
	}

	private void method_7(string string_0, bool bool_0, bool bool_1)
	{
		Button button = new Button();
		button.BackColor = Color.FromArgb(50, 119, 155);
		button.FlatStyle = FlatStyle.Flat;
		button.FlatAppearance.BorderColor = Color.Black;
		button.FlatAppearance.BorderSize = 0;
		button.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		button.ForeColor = Color.White;
		button.Name = "btn" + string_0 + "_" + (bool_0 ? "YES" : "NO") + "_" + (bool_1 ? "YES" : "NO");
		button.Text = string_0.ToUpper();
		button.Size = new Size(145, 63);
		button.UseVisualStyleBackColor = false;
		button.Margin = new Padding(1, 0, 0, 1);
		button.Padding = new Padding(0, 0, 0, 0);
		button.Click += QrjcCshqOc;
		pnlTenderTypes.Controls.Add(button);
	}

	private void method_8(int int_1)
	{
		Button button = new Button();
		button.BackColor = Color.FromArgb(35, 39, 56);
		button.FlatStyle = FlatStyle.Flat;
		button.Enabled = false;
		button.FlatAppearance.BorderSize = 0;
		button.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 39, 56);
		button.Name = "btnPlaceHolder_" + int_0;
		button.Text = string.Empty;
		button.Size = new Size(145, 60);
		button.UseVisualStyleBackColor = false;
		button.Margin = new Padding(1, 0, 0, 1);
		button.Padding = new Padding(0, 0, 0, 0);
		pnlTenderTypes.Controls.Add(button);
		pnlTenderTypes.Controls.SetChildIndex(button, int_1);
		int_0++;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSelectPaymentMethodMultiple));
		btnDone = new Button();
		btnCancel = new Button();
		btnRemove = new Button();
		sideLabel = new Label();
		button5 = new Button();
		label2 = new Label();
		label3 = new Label();
		btnClear = new Button();
		button3 = new Button();
		Button7 = new Button();
		Button6 = new Button();
		btnExactChange = new Button();
		Button8 = new Button();
		Button29 = new Button();
		Button26 = new Button();
		Button27 = new Button();
		Button28 = new Button();
		Button18 = new Button();
		Button19 = new Button();
		Button20 = new Button();
		Button0 = new Button();
		Button4 = new Button();
		Button2 = new Button();
		Button1 = new Button();
		txtInput = new Class18();
		label1 = new Label();
		lstTenderTypes = new ListView();
		columnHeader_0 = new ColumnHeader();
		columnHeader_1 = new ColumnHeader();
		lblTitle = new Label();
		panel1 = new Panel();
		txtChange = new TextBox();
		Label5 = new Label();
		Label6 = new Label();
		txtTotal = new TextBox();
		txtAmountDue = new TextBox();
		label4 = new Label();
		pnlTenderTypes = new FlowLayoutPanel();
		panel1.SuspendLayout();
		SuspendLayout();
		btnDone.BackColor = Color.FromArgb(80, 203, 116);
		btnDone.DialogResult = DialogResult.OK;
		btnDone.FlatAppearance.BorderColor = Color.Black;
		btnDone.FlatAppearance.BorderSize = 0;
		btnDone.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnDone.FlatStyle = FlatStyle.Flat;
		btnDone.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
		btnDone.ForeColor = Color.White;
		btnDone.Image = (Image)componentResourceManager.GetObject("btnDone.Image");
		btnDone.ImageAlign = ContentAlignment.TopCenter;
		btnDone.ImeMode = ImeMode.NoControl;
		btnDone.Location = new Point(372, 647);
		btnDone.Name = "btnDone";
		btnDone.Padding = new Padding(0, 4, 0, 4);
		btnDone.Size = new Size(145, 82);
		btnDone.TabIndex = 190;
		btnDone.Text = "DONE / SAVE";
		btnDone.TextAlign = ContentAlignment.BottomCenter;
		btnDone.UseVisualStyleBackColor = false;
		btnDone.EnabledChanged += btnDone_EnabledChanged;
		btnDone.Click += btnDone_Click;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.DialogResult = DialogResult.Cancel;
		btnCancel.FlatAppearance.BorderColor = Color.Black;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnCancel.FlatStyle = FlatStyle.Flat;
		btnCancel.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
		btnCancel.ForeColor = Color.White;
		btnCancel.Image = (Image)componentResourceManager.GetObject("btnCancel.Image");
		btnCancel.ImageAlign = ContentAlignment.TopCenter;
		btnCancel.ImeMode = ImeMode.NoControl;
		btnCancel.Location = new Point(518, 647);
		btnCancel.Name = "btnCancel";
		btnCancel.Padding = new Padding(0, 4, 0, 4);
		btnCancel.Size = new Size(145, 82);
		btnCancel.TabIndex = 191;
		btnCancel.Text = "CANCEL";
		btnCancel.TextAlign = ContentAlignment.BottomCenter;
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnRemove.BackColor = Color.SandyBrown;
		btnRemove.FlatAppearance.BorderColor = Color.Black;
		btnRemove.FlatAppearance.BorderSize = 0;
		btnRemove.FlatAppearance.MouseDownBackColor = Color.White;
		btnRemove.FlatStyle = FlatStyle.Flat;
		btnRemove.Font = new Font("Microsoft Sans Serif", 7.5f);
		btnRemove.ForeColor = Color.White;
		btnRemove.Image = (Image)componentResourceManager.GetObject("btnRemove.Image");
		btnRemove.ImageAlign = ContentAlignment.TopCenter;
		btnRemove.ImeMode = ImeMode.NoControl;
		btnRemove.Location = new Point(372, 46);
		btnRemove.Margin = new Padding(3, 1, 3, 1);
		btnRemove.MinimumSize = new Size(122, 69);
		btnRemove.Name = "btnRemove";
		btnRemove.Size = new Size(291, 69);
		btnRemove.TabIndex = 250;
		btnRemove.Text = "REMOVE TENDER";
		btnRemove.TextImageRelation = TextImageRelation.ImageAboveText;
		btnRemove.UseVisualStyleBackColor = false;
		btnRemove.Click += btnRemove_Click;
		sideLabel.BackColor = Color.White;
		sideLabel.Font = new Font("Microsoft Sans Serif", 32f);
		sideLabel.ForeColor = Color.Black;
		sideLabel.ImeMode = ImeMode.NoControl;
		sideLabel.Location = new Point(11, 348);
		sideLabel.Name = "sideLabel";
		sideLabel.Size = new Size(35, 49);
		sideLabel.TabIndex = 242;
		sideLabel.Text = "$";
		button5.BackColor = Color.FromArgb(55, 141, 80);
		button5.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		button5.FlatAppearance.BorderSize = 0;
		button5.FlatStyle = FlatStyle.Flat;
		button5.Font = new Font("Microsoft Sans Serif", 12f);
		button5.ForeColor = Color.White;
		button5.ImeMode = ImeMode.NoControl;
		button5.Location = new Point(260, 604);
		button5.Name = "button5";
		button5.Size = new Size(111, 63);
		button5.TabIndex = 241;
		button5.Text = "$ 5";
		button5.UseVisualStyleBackColor = false;
		button5.Click += button5_Click;
		label2.BackColor = Color.Gray;
		label2.Font = new Font("Microsoft Sans Serif", 10f);
		label2.ForeColor = Color.White;
		label2.ImeMode = ImeMode.NoControl;
		label2.Location = new Point(242, 44);
		label2.Margin = new Padding(0);
		label2.Name = "label2";
		label2.Size = new Size(129, 35);
		label2.TabIndex = 220;
		label2.Text = "Amount";
		label2.TextAlign = ContentAlignment.MiddleLeft;
		label3.BackColor = Color.Gray;
		label3.Font = new Font("Microsoft Sans Serif", 10f);
		label3.ForeColor = Color.White;
		label3.ImeMode = ImeMode.NoControl;
		label3.Location = new Point(11, 44);
		label3.Margin = new Padding(0, 0, 0, 1);
		label3.MinimumSize = new Size(0, 35);
		label3.Name = "label3";
		label3.Size = new Size(230, 35);
		label3.TabIndex = 219;
		label3.Text = "Tender Type";
		label3.TextAlign = ContentAlignment.MiddleLeft;
		btnClear.BackColor = Color.FromArgb(77, 174, 225);
		btnClear.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnClear.FlatAppearance.BorderSize = 0;
		btnClear.FlatStyle = FlatStyle.Flat;
		btnClear.Font = new Font("Microsoft Sans Serif", 10f);
		btnClear.ForeColor = Color.White;
		btnClear.ImeMode = ImeMode.NoControl;
		btnClear.Location = new Point(260, 668);
		btnClear.Name = "btnClear";
		btnClear.Size = new Size(111, 61);
		btnClear.TabIndex = 240;
		btnClear.Text = "CLEAR";
		btnClear.UseVisualStyleBackColor = false;
		btnClear.Click += btnClear_Click;
		button3.BackColor = Color.FromArgb(55, 141, 80);
		button3.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		button3.FlatAppearance.BorderSize = 0;
		button3.FlatStyle = FlatStyle.Flat;
		button3.Font = new Font("Microsoft Sans Serif", 12f);
		button3.ForeColor = Color.White;
		button3.ImeMode = ImeMode.NoControl;
		button3.Location = new Point(260, 540);
		button3.Name = "button3";
		button3.Size = new Size(111, 63);
		button3.TabIndex = 239;
		button3.Text = "$ 10";
		button3.UseVisualStyleBackColor = false;
		button3.Click += button3_Click;
		Button7.BackColor = Color.FromArgb(65, 168, 95);
		Button7.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button7.FlatAppearance.BorderSize = 0;
		Button7.FlatStyle = FlatStyle.Flat;
		Button7.Font = new Font("Microsoft Sans Serif", 12f);
		Button7.ForeColor = Color.White;
		Button7.ImeMode = ImeMode.NoControl;
		Button7.Location = new Point(260, 476);
		Button7.Name = "Button7";
		Button7.Size = new Size(111, 63);
		Button7.TabIndex = 238;
		Button7.Text = "$ 20";
		Button7.UseVisualStyleBackColor = false;
		Button7.Click += Button7_Click;
		Button6.BackColor = Color.FromArgb(80, 203, 116);
		Button6.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button6.FlatAppearance.BorderSize = 0;
		Button6.FlatStyle = FlatStyle.Flat;
		Button6.Font = new Font("Microsoft Sans Serif", 12f);
		Button6.ForeColor = Color.White;
		Button6.ImeMode = ImeMode.NoControl;
		Button6.Location = new Point(260, 412);
		Button6.Name = "Button6";
		Button6.Size = new Size(111, 63);
		Button6.TabIndex = 237;
		Button6.Text = "$ 50";
		Button6.UseVisualStyleBackColor = false;
		Button6.Click += Button6_Click;
		btnExactChange.BackColor = Color.SandyBrown;
		btnExactChange.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnExactChange.FlatAppearance.BorderSize = 0;
		btnExactChange.FlatStyle = FlatStyle.Flat;
		btnExactChange.Font = new Font("Microsoft Sans Serif", 10f);
		btnExactChange.ForeColor = Color.White;
		btnExactChange.ImeMode = ImeMode.NoControl;
		btnExactChange.Location = new Point(260, 348);
		btnExactChange.Name = "btnExactChange";
		btnExactChange.Padding = new Padding(10);
		btnExactChange.Size = new Size(111, 63);
		btnExactChange.TabIndex = 236;
		btnExactChange.Text = "EXACT CHANGE";
		btnExactChange.UseVisualStyleBackColor = false;
		btnExactChange.Click += btnExactChange_Click;
		Button8.BackColor = Color.FromArgb(118, 130, 130);
		Button8.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button8.FlatAppearance.BorderSize = 0;
		Button8.FlatStyle = FlatStyle.Flat;
		Button8.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		Button8.ForeColor = Color.White;
		Button8.ImeMode = ImeMode.NoControl;
		Button8.Location = new Point(94, 647);
		Button8.Name = "Button8";
		Button8.Size = new Size(82, 82);
		Button8.TabIndex = 235;
		Button8.Text = "00";
		Button8.UseVisualStyleBackColor = false;
		Button8.Click += Button1_Click;
		Button29.BackColor = Color.FromArgb(118, 130, 130);
		Button29.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button29.FlatAppearance.BorderSize = 0;
		Button29.FlatStyle = FlatStyle.Flat;
		Button29.Font = new Font("Microsoft Sans Serif", 20f, FontStyle.Bold);
		Button29.ForeColor = Color.White;
		Button29.ImeMode = ImeMode.NoControl;
		Button29.Location = new Point(177, 647);
		Button29.Name = "Button29";
		Button29.Size = new Size(82, 82);
		Button29.TabIndex = 234;
		Button29.Text = ".";
		Button29.UseVisualStyleBackColor = false;
		Button29.Click += Button1_Click;
		Button26.BackColor = Color.FromArgb(132, 146, 146);
		Button26.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button26.FlatAppearance.BorderSize = 0;
		Button26.FlatStyle = FlatStyle.Flat;
		Button26.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		Button26.ForeColor = Color.White;
		Button26.ImeMode = ImeMode.NoControl;
		Button26.Location = new Point(177, 564);
		Button26.Name = "Button26";
		Button26.Size = new Size(82, 82);
		Button26.TabIndex = 233;
		Button26.Text = "3";
		Button26.UseVisualStyleBackColor = false;
		Button26.Click += Button1_Click;
		Button27.BackColor = Color.FromArgb(132, 146, 146);
		Button27.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button27.FlatAppearance.BorderSize = 0;
		Button27.FlatStyle = FlatStyle.Flat;
		Button27.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		Button27.ForeColor = Color.White;
		Button27.ImeMode = ImeMode.NoControl;
		Button27.Location = new Point(94, 564);
		Button27.Name = "Button27";
		Button27.Size = new Size(82, 82);
		Button27.TabIndex = 232;
		Button27.Text = "2";
		Button27.UseVisualStyleBackColor = false;
		Button27.Click += Button1_Click;
		Button28.BackColor = Color.FromArgb(132, 146, 146);
		Button28.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button28.FlatAppearance.BorderSize = 0;
		Button28.FlatStyle = FlatStyle.Flat;
		Button28.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		Button28.ForeColor = Color.White;
		Button28.ImeMode = ImeMode.NoControl;
		Button28.Location = new Point(11, 564);
		Button28.Name = "Button28";
		Button28.Size = new Size(82, 82);
		Button28.TabIndex = 231;
		Button28.Text = "1";
		Button28.UseVisualStyleBackColor = false;
		Button28.Click += Button1_Click;
		Button18.BackColor = Color.FromArgb(150, 166, 166);
		Button18.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button18.FlatAppearance.BorderSize = 0;
		Button18.FlatStyle = FlatStyle.Flat;
		Button18.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		Button18.ForeColor = Color.White;
		Button18.ImeMode = ImeMode.NoControl;
		Button18.Location = new Point(177, 481);
		Button18.Name = "Button18";
		Button18.Size = new Size(82, 82);
		Button18.TabIndex = 230;
		Button18.Text = "6";
		Button18.UseVisualStyleBackColor = false;
		Button18.Click += Button1_Click;
		Button19.BackColor = Color.FromArgb(150, 166, 166);
		Button19.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button19.FlatAppearance.BorderSize = 0;
		Button19.FlatStyle = FlatStyle.Flat;
		Button19.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		Button19.ForeColor = Color.White;
		Button19.ImeMode = ImeMode.NoControl;
		Button19.Location = new Point(94, 481);
		Button19.Name = "Button19";
		Button19.Size = new Size(82, 82);
		Button19.TabIndex = 229;
		Button19.Text = "5";
		Button19.UseVisualStyleBackColor = false;
		Button19.Click += Button1_Click;
		Button20.BackColor = Color.FromArgb(150, 166, 166);
		Button20.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button20.FlatAppearance.BorderSize = 0;
		Button20.FlatStyle = FlatStyle.Flat;
		Button20.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		Button20.ForeColor = Color.White;
		Button20.ImeMode = ImeMode.NoControl;
		Button20.Location = new Point(11, 481);
		Button20.Name = "Button20";
		Button20.Size = new Size(82, 82);
		Button20.TabIndex = 228;
		Button20.Text = "4";
		Button20.UseVisualStyleBackColor = false;
		Button20.Click += Button1_Click;
		Button0.BackColor = Color.FromArgb(118, 130, 130);
		Button0.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button0.FlatAppearance.BorderSize = 0;
		Button0.FlatStyle = FlatStyle.Flat;
		Button0.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		Button0.ForeColor = Color.White;
		Button0.ImeMode = ImeMode.NoControl;
		Button0.Location = new Point(11, 647);
		Button0.Name = "Button0";
		Button0.Size = new Size(82, 82);
		Button0.TabIndex = 227;
		Button0.Text = "0";
		Button0.UseVisualStyleBackColor = false;
		Button0.Click += Button1_Click;
		Button4.BackColor = Color.FromArgb(164, 181, 181);
		Button4.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button4.FlatAppearance.BorderSize = 0;
		Button4.FlatStyle = FlatStyle.Flat;
		Button4.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		Button4.ForeColor = Color.White;
		Button4.ImeMode = ImeMode.NoControl;
		Button4.Location = new Point(177, 398);
		Button4.Name = "Button4";
		Button4.Size = new Size(82, 82);
		Button4.TabIndex = 226;
		Button4.Text = "9";
		Button4.UseVisualStyleBackColor = false;
		Button4.Click += Button1_Click;
		Button2.BackColor = Color.FromArgb(164, 181, 181);
		Button2.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button2.FlatAppearance.BorderSize = 0;
		Button2.FlatStyle = FlatStyle.Flat;
		Button2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		Button2.ForeColor = Color.White;
		Button2.ImeMode = ImeMode.NoControl;
		Button2.Location = new Point(94, 398);
		Button2.Name = "Button2";
		Button2.Size = new Size(82, 82);
		Button2.TabIndex = 225;
		Button2.Text = "8";
		Button2.UseVisualStyleBackColor = false;
		Button2.Click += Button1_Click;
		Button1.BackColor = Color.FromArgb(164, 181, 181);
		Button1.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button1.FlatAppearance.BorderSize = 0;
		Button1.FlatStyle = FlatStyle.Flat;
		Button1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		Button1.ForeColor = Color.White;
		Button1.ImeMode = ImeMode.NoControl;
		Button1.Location = new Point(11, 398);
		Button1.Name = "Button1";
		Button1.Size = new Size(82, 82);
		Button1.TabIndex = 224;
		Button1.Text = "7";
		Button1.UseVisualStyleBackColor = false;
		Button1.Click += Button1_Click;
		txtInput.BorderStyle = BorderStyle.None;
		txtInput.Font = new Font("Microsoft Sans Serif", 32f, FontStyle.Bold);
		txtInput.Location = new Point(46, 348);
		txtInput.Margin = new Padding(3, 3, 15, 3);
		txtInput.MaxLength = 10;
		txtInput.Name = "txtInput";
		txtInput.Size = new Size(213, 49);
		txtInput.TabIndex = 223;
		txtInput.Text = "0.00";
		txtInput.TextAlign = HorizontalAlignment.Right;
		txtInput.method_1("keyboard");
		txtInput.TextChanged += txtInput_TextChanged;
		label1.BackColor = Color.FromArgb(147, 101, 184);
		label1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		label1.ForeColor = Color.White;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(11, 306);
		label1.Name = "label1";
		label1.Padding = new Padding(54, 0, 0, 0);
		label1.Size = new Size(360, 41);
		label1.TabIndex = 221;
		label1.Text = "ENTER TENDERED AMOUNT";
		label1.TextAlign = ContentAlignment.MiddleLeft;
		lstTenderTypes.BackColor = Color.FromArgb(255, 255, 192);
		lstTenderTypes.BorderStyle = BorderStyle.None;
		lstTenderTypes.Columns.AddRange(new ColumnHeader[2] { columnHeader_0, columnHeader_1 });
		lstTenderTypes.Font = new Font("Microsoft Sans Serif", 14f);
		lstTenderTypes.FullRowSelect = true;
		lstTenderTypes.GridLines = true;
		lstTenderTypes.HeaderStyle = ColumnHeaderStyle.None;
		lstTenderTypes.HideSelection = false;
		lstTenderTypes.Location = new Point(11, 80);
		lstTenderTypes.MultiSelect = false;
		lstTenderTypes.Name = "lstTenderTypes";
		lstTenderTypes.Size = new Size(360, 224);
		lstTenderTypes.TabIndex = 218;
		lstTenderTypes.TileSize = new Size(50, 200);
		lstTenderTypes.UseCompatibleStateImageBehavior = false;
		lstTenderTypes.View = View.Details;
		columnHeader_0.Text = "Tender Types";
		columnHeader_0.Width = 230;
		columnHeader_1.Text = "Amount";
		columnHeader_1.TextAlign = HorizontalAlignment.Right;
		columnHeader_1.Width = 105;
		lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblTitle.Font = new Font("Microsoft Sans Serif", 14f);
		lblTitle.ForeColor = Color.White;
		lblTitle.ImeMode = ImeMode.NoControl;
		lblTitle.Location = new Point(11, 10);
		lblTitle.Name = "lblTitle";
		lblTitle.Size = new Size(652, 35);
		lblTitle.TabIndex = 188;
		lblTitle.Text = "SELECT PAYMENT METHOD";
		lblTitle.TextAlign = ContentAlignment.MiddleCenter;
		panel1.BackColor = Color.Black;
		panel1.Controls.Add(txtChange);
		panel1.Controls.Add(Label5);
		panel1.Controls.Add(Label6);
		panel1.Controls.Add(txtTotal);
		panel1.Controls.Add(txtAmountDue);
		panel1.Controls.Add(label4);
		panel1.Location = new Point(372, 116);
		panel1.Name = "panel1";
		panel1.Size = new Size(292, 86);
		panel1.TabIndex = 251;
		txtChange.BackColor = Color.Black;
		txtChange.BorderStyle = BorderStyle.None;
		txtChange.Cursor = Cursors.Default;
		txtChange.Font = new Font("Microsoft Sans Serif", 20f, FontStyle.Bold);
		txtChange.ForeColor = Color.FromArgb(65, 168, 95);
		txtChange.Location = new Point(141, 51);
		txtChange.Name = "txtChange";
		txtChange.ReadOnly = true;
		txtChange.Size = new Size(144, 31);
		txtChange.TabIndex = 246;
		txtChange.Text = "0.00";
		txtChange.TextAlign = HorizontalAlignment.Right;
		Label5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold);
		Label5.ForeColor = Color.White;
		Label5.ImeMode = ImeMode.NoControl;
		Label5.Location = new Point(-4, 27);
		Label5.Name = "Label5";
		Label5.Size = new Size(142, 23);
		Label5.TabIndex = 243;
		Label5.Text = "Amount Due :";
		Label5.TextAlign = ContentAlignment.MiddleRight;
		Label6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold);
		Label6.ForeColor = Color.White;
		Label6.ImeMode = ImeMode.NoControl;
		Label6.Location = new Point(-4, 55);
		Label6.Name = "Label6";
		Label6.Size = new Size(142, 24);
		Label6.TabIndex = 244;
		Label6.Text = "Change :";
		Label6.TextAlign = ContentAlignment.MiddleRight;
		txtTotal.BackColor = Color.Black;
		txtTotal.BorderStyle = BorderStyle.None;
		txtTotal.Cursor = Cursors.Default;
		txtTotal.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold);
		txtTotal.ForeColor = Color.White;
		txtTotal.Location = new Point(141, 2);
		txtTotal.Name = "txtTotal";
		txtTotal.ReadOnly = true;
		txtTotal.Size = new Size(143, 25);
		txtTotal.TabIndex = 248;
		txtTotal.Text = "0.00";
		txtTotal.TextAlign = HorizontalAlignment.Right;
		txtAmountDue.BackColor = Color.Black;
		txtAmountDue.BorderStyle = BorderStyle.None;
		txtAmountDue.Cursor = Cursors.Default;
		txtAmountDue.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold);
		txtAmountDue.ForeColor = Color.White;
		txtAmountDue.Location = new Point(140, 25);
		txtAmountDue.Name = "txtAmountDue";
		txtAmountDue.ReadOnly = true;
		txtAmountDue.Size = new Size(143, 25);
		txtAmountDue.TabIndex = 245;
		txtAmountDue.Text = "0.00";
		txtAmountDue.TextAlign = HorizontalAlignment.Right;
		label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold);
		label4.ForeColor = Color.White;
		label4.ImeMode = ImeMode.NoControl;
		label4.Location = new Point(-4, 4);
		label4.Name = "label4";
		label4.Size = new Size(142, 23);
		label4.TabIndex = 247;
		label4.Text = "Total :";
		label4.TextAlign = ContentAlignment.MiddleRight;
		pnlTenderTypes.Location = new Point(371, 201);
		pnlTenderTypes.Margin = new Padding(0);
		pnlTenderTypes.Name = "pnlTenderTypes";
		pnlTenderTypes.Size = new Size(293, 445);
		pnlTenderTypes.TabIndex = 252;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(674, 740);
		base.Controls.Add(pnlTenderTypes);
		base.Controls.Add(btnDone);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnRemove);
		base.Controls.Add(sideLabel);
		base.Controls.Add(button5);
		base.Controls.Add(label2);
		base.Controls.Add(label3);
		base.Controls.Add(btnClear);
		base.Controls.Add(button3);
		base.Controls.Add(Button7);
		base.Controls.Add(Button6);
		base.Controls.Add(btnExactChange);
		base.Controls.Add(Button8);
		base.Controls.Add(Button29);
		base.Controls.Add(Button26);
		base.Controls.Add(Button27);
		base.Controls.Add(Button28);
		base.Controls.Add(Button18);
		base.Controls.Add(Button19);
		base.Controls.Add(Button20);
		base.Controls.Add(Button0);
		base.Controls.Add(Button4);
		base.Controls.Add(Button2);
		base.Controls.Add(Button1);
		base.Controls.Add(txtInput);
		base.Controls.Add(label1);
		base.Controls.Add(lstTenderTypes);
		base.Controls.Add(lblTitle);
		base.Controls.Add(panel1);
		base.Name = "frmSelectPaymentMethodMultiple";
		base.Opacity = 1.0;
		Text = "SELECT PAYMENT METHOD";
		base.Load += frmSelectPaymentMethodMultiple_Load;
		base.Controls.SetChildIndex(panel1, 0);
		base.Controls.SetChildIndex(lblTitle, 0);
		base.Controls.SetChildIndex(lstTenderTypes, 0);
		base.Controls.SetChildIndex(label1, 0);
		base.Controls.SetChildIndex(txtInput, 0);
		base.Controls.SetChildIndex(Button1, 0);
		base.Controls.SetChildIndex(Button2, 0);
		base.Controls.SetChildIndex(Button4, 0);
		base.Controls.SetChildIndex(Button0, 0);
		base.Controls.SetChildIndex(Button20, 0);
		base.Controls.SetChildIndex(Button19, 0);
		base.Controls.SetChildIndex(Button18, 0);
		base.Controls.SetChildIndex(Button28, 0);
		base.Controls.SetChildIndex(Button27, 0);
		base.Controls.SetChildIndex(Button26, 0);
		base.Controls.SetChildIndex(Button29, 0);
		base.Controls.SetChildIndex(Button8, 0);
		base.Controls.SetChildIndex(btnExactChange, 0);
		base.Controls.SetChildIndex(Button6, 0);
		base.Controls.SetChildIndex(Button7, 0);
		base.Controls.SetChildIndex(button3, 0);
		base.Controls.SetChildIndex(btnClear, 0);
		base.Controls.SetChildIndex(label3, 0);
		base.Controls.SetChildIndex(label2, 0);
		base.Controls.SetChildIndex(button5, 0);
		base.Controls.SetChildIndex(sideLabel, 0);
		base.Controls.SetChildIndex(btnRemove, 0);
		base.Controls.SetChildIndex(btnCancel, 0);
		base.Controls.SetChildIndex(btnDone, 0);
		base.Controls.SetChildIndex(pnlTenderTypes, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		panel1.ResumeLayout(performLayout: false);
		panel1.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
