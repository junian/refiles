using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.CustomControls;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmSelectDateOnSale : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass39_0
	{
		public string dayShortString;

		public _003C_003Ec__DisplayClass39_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CfrmSelectDateOnSale_Load_003Eb__0(RadToggleSwitch a)
		{
			return a.Name.ToUpper().Contains(dayShortString);
		}

		internal bool _003CfrmSelectDateOnSale_Load_003Eb__1(DateTimePicker a)
		{
			if (a.Name.ToUpper().Contains(dayShortString))
			{
				return a.Name.Contains("from");
			}
			return false;
		}

		internal bool _003CfrmSelectDateOnSale_Load_003Eb__2(DateTimePicker a)
		{
			if (a.Name.ToUpper().Contains(dayShortString))
			{
				return a.Name.Contains("to");
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass44_0
	{
		public string shortenedDayString;

		public _003C_003Ec__DisplayClass44_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CGetDaySaleListString_003Eb__0(DateTimePicker a)
		{
			if (a.Name.Contains(shortenedDayString))
			{
				return a.Name.Contains("from");
			}
			return false;
		}

		internal bool _003CGetDaySaleListString_003Eb__1(DateTimePicker a)
		{
			if (a.Name.Contains(shortenedDayString))
			{
				return a.Name.Contains("to");
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass60_0
	{
		public string dayString;

		public _003C_003Ec__DisplayClass60_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003Ccopy_button_003Eb__0(DateTimePicker a)
		{
			if (a.Name.Contains(dayString))
			{
				return a.Name.Contains("from");
			}
			return false;
		}

		internal bool _003Ccopy_button_003Eb__1(DateTimePicker a)
		{
			if (a.Name.Contains(dayString))
			{
				return a.Name.Contains("to");
			}
			return false;
		}

		internal bool _003Ccopy_button_003Eb__4(DateTimePicker a)
		{
			if (a.Name.Contains(dayString))
			{
				return a.Name.Contains("from");
			}
			return false;
		}

		internal bool _003Ccopy_button_003Eb__5(DateTimePicker a)
		{
			if (a.Name.Contains(dayString))
			{
				return a.Name.Contains("to");
			}
			return false;
		}
	}

	[CompilerGenerated]
	private DateTime? nullable_0;

	[CompilerGenerated]
	private DateTime? nullable_1;

	[CompilerGenerated]
	private DateTime? nullable_2;

	[CompilerGenerated]
	private DateTime? nullable_3;

	[CompilerGenerated]
	private decimal decimal_0;

	[CompilerGenerated]
	private decimal HTLFCZJRIQO;

	[CompilerGenerated]
	private string string_0;

	private DateTime? nullable_4;

	private DateTime? nullable_5;

	private bool bool_0;

	private DateTime? nullable_6;

	private DateTime? nullable_7;

	private decimal decimal_1;

	private string string_1;

	private decimal decimal_2;

	private decimal decimal_3;

	private decimal decimal_4;

	private DateTime dateTime_0;

	private DateTime dateTime_1;

	private IContainer icontainer_1;

	private DateTimePicker startDate;

	private DateTimePicker endDate;

	private Button btnClose;

	private Label label1;

	private Label label9;

	private Label label2;

	private Label label3;

	internal Button btnShowKeyboard_PercentageOff;

	private Label label17;

	internal Button btnShowKeyboard_txtSalePrice;

	private RadToggleSwitch chkDateRange;

	private RadTextBoxControl txtPercentageOff;

	private Label label4;

	private RadTextBoxControl txtSalePrice;

	private Button btnSave;

	private Label label23;

	private Label lblOriginalPrice;

	private CustomTimeControl toSun;

	private CustomTimeControl toSat;

	private CustomTimeControl fromSun;

	private CustomTimeControl fromSat;

	private CustomTimeControl toFri;

	private CustomTimeControl fromFri;

	private CustomTimeControl toThu;

	private CustomTimeControl fromThu;

	private CustomTimeControl toWed;

	private CustomTimeControl fromWed;

	private CustomTimeControl toTue;

	private CustomTimeControl fromTue;

	private CustomTimeControl toMon;

	private CustomTimeControl fromMon;

	internal Button btnCopySun;

	private Label label32;

	private Label label33;

	internal Button btnCopySat;

	private Label label30;

	private Label label31;

	internal Button btnCopyFri;

	private Label label28;

	private Label label29;

	internal Button btnCopyThu;

	private Label label16;

	private Label label27;

	internal Button btnCopyWed;

	private Label label14;

	private Label label15;

	internal Button btnCopyTue;

	private Label label12;

	private Label label13;

	internal Button btnCopyMon;

	private Label label11;

	private Label label10;

	private Label label19;

	private RadToggleSwitch chkDaySale;

	private Panel panel1;

	private RadToggleSwitch chkSun;

	private RadToggleSwitch chkWed;

	private RadToggleSwitch chkTue;

	private RadToggleSwitch chkMon;

	private RadToggleSwitch chkThu;

	private RadToggleSwitch chkFri;

	private RadToggleSwitch chkSat;

	private Label label8;

	private Label lbl1;

	private Label lbl2;

	public DateTime? returnStartDate
	{
		[CompilerGenerated]
		get
		{
			return nullable_0;
		}
		[CompilerGenerated]
		set
		{
			nullable_0 = value;
		}
	}

	public DateTime? returnEndDate
	{
		[CompilerGenerated]
		get
		{
			return nullable_1;
		}
		[CompilerGenerated]
		set
		{
			nullable_1 = value;
		}
	}

	public DateTime? returnStartTimeRange
	{
		[CompilerGenerated]
		get
		{
			return nullable_2;
		}
		[CompilerGenerated]
		set
		{
			nullable_2 = value;
		}
	}

	public DateTime? returnEndTimeRange
	{
		[CompilerGenerated]
		get
		{
			return nullable_3;
		}
		[CompilerGenerated]
		set
		{
			nullable_3 = value;
		}
	}

	public decimal returnPercentageOff
	{
		[CompilerGenerated]
		get
		{
			return decimal_0;
		}
		[CompilerGenerated]
		set
		{
			decimal_0 = value;
		}
	}

	public decimal returnSalePrice
	{
		[CompilerGenerated]
		get
		{
			return HTLFCZJRIQO;
		}
		[CompilerGenerated]
		set
		{
			HTLFCZJRIQO = value;
		}
	}

	public string returnDaysSaleList
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

	public frmSelectDateOnSale(DateTime? _itemStartDate = null, DateTime? _itemEndDate = null, string _daySaleList = null, decimal _itemPrice = 0m, decimal _salePrice = 0m)
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		nullable_4 = (nullable_6 = _itemStartDate);
		nullable_5 = (nullable_7 = _itemEndDate);
		string_1 = _daySaleList;
		decimal_1 = (decimal_2 = _salePrice);
		decimal_4 = _itemPrice;
		lblOriginalPrice.Text = "$" + decimal_4;
		decimal_3 = ((decimal_4 <= 0m) ? 0m : ((decimal_4 - decimal_2) / decimal_4 * 100m));
	}

	private void frmSelectDateOnSale_Load(object sender, EventArgs e)
	{
		if (decimal_2 >= 0m)
		{
			txtSalePrice.Text = decimal_2.ToString("0.00##");
			txtPercentageOff.Text = Math.Round(decimal_3, 0).ToString("0.00");
		}
		if (!nullable_6.HasValue)
		{
			chkDateRange.Value = false;
			startDate.Enabled = false;
			endDate.Enabled = false;
			startDate.Value = DateTime.Now.Date;
			endDate.Value = DateTime.Now.Date;
		}
		else
		{
			chkDateRange.Value = true;
			startDate.Enabled = true;
			endDate.Enabled = true;
			startDate.Value = nullable_6.Value;
			endDate.Value = nullable_7.Value;
		}
		if (!nullable_4.HasValue)
		{
			nullable_4 = Convert.ToDateTime(startDate.Value.ToLongDateString() + " 12:00:00 AM");
		}
		if (!nullable_5.HasValue)
		{
			nullable_5 = Convert.ToDateTime(endDate.Value.ToLongDateString() + " 11:59:59 PM");
		}
		bool_0 = chkDateRange.Value;
		if (string.IsNullOrEmpty(string_1))
		{
			return;
		}
		chkDaySale.Value = true;
		string[] array = string_1.Split('|');
		foreach (string obj in array)
		{
			_003C_003Ec__DisplayClass39_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass39_0();
			string[] array2 = obj.Split('-');
			string text = array2[0];
			string s = array2[1];
			string s2 = array2[2];
			CS_0024_003C_003E8__locals0.dayShortString = text.Substring(0, 3);
			(from a in panel1.Controls.OfType<RadToggleSwitch>()
				where a.Name.ToUpper().Contains(CS_0024_003C_003E8__locals0.dayShortString)
				select a).FirstOrDefault().Value = true;
			DateTimePicker dateTimePicker = (from a in base.Controls.OfType<DateTimePicker>()
				where a.Name.ToUpper().Contains(CS_0024_003C_003E8__locals0.dayShortString) && a.Name.Contains("from")
				select a).FirstOrDefault();
			DateTimePicker dateTimePicker2 = (from a in base.Controls.OfType<DateTimePicker>()
				where a.Name.ToUpper().Contains(CS_0024_003C_003E8__locals0.dayShortString) && a.Name.Contains("to")
				select a).FirstOrDefault();
			dateTimePicker.Value = DateTime.ParseExact(s, "H:mm", null, DateTimeStyles.None);
			dateTimePicker2.Value = DateTime.ParseExact(s2, "H:mm", null, DateTimeStyles.None);
		}
	}

	protected override void OnClosing(CancelEventArgs e)
	{
		base.OnClosing(e);
		if (!e.Cancel && base.Owner != null)
		{
			base.Owner.TopMost = true;
		}
	}

	protected override void OnClosed(EventArgs e)
	{
		base.OnClosed(e);
		if (base.Owner != null)
		{
			base.Owner.TopMost = false;
		}
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		bool flag = false;
		returnStartDate = Convert.ToDateTime(startDate.Value.ToLongDateString() + " 12:00:00 AM");
		returnEndDate = Convert.ToDateTime(endDate.Value.ToLongDateString() + " 11:59:59 PM");
		returnDaysSaleList = method_4(bool_1: false);
		returnSalePrice = (string.IsNullOrEmpty(txtSalePrice.Text) ? 0m : Convert.ToDecimal(txtSalePrice.Text));
		DateTime? dateTime = nullable_4;
		DateTime? dateTime2 = returnStartDate;
		if (((dateTime.HasValue != dateTime2.HasValue || (dateTime.HasValue && dateTime.GetValueOrDefault() != dateTime2.GetValueOrDefault()) || nullable_5 != returnEndDate) && chkDateRange.Value) || string_1 != returnDaysSaleList)
		{
			flag = true;
		}
		if (flag)
		{
			if (new frmMessageBox("Do you want to save the changes?", "Save Changes", CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
			{
				if (method_3())
				{
					base.DialogResult = DialogResult.OK;
				}
				else
				{
					base.DialogResult = DialogResult.None;
				}
			}
			else
			{
				base.DialogResult = DialogResult.None;
				Dispose();
			}
		}
		else
		{
			base.DialogResult = DialogResult.Cancel;
		}
		Close();
	}

	private bool method_3()
	{
		if (!chkDaySale.Value && txtPercentageOff.Text != "" && !MiscHelper.isNumberInRange(Convert.ToDecimal(txtPercentageOff.Text), 0m, 100m))
		{
			new frmMessageBox("Percentage Off Only accepts value 0-100").ShowDialog(this);
			return false;
		}
		if (chkDateRange.Value)
		{
			returnStartDate = Convert.ToDateTime(startDate.Value.ToLongDateString() + " 12:00:00 AM");
			returnEndDate = Convert.ToDateTime(endDate.Value.ToLongDateString() + " 11:59:59 PM");
		}
		else
		{
			returnStartDate = null;
			returnEndDate = null;
		}
		DateTime? dateTime = returnStartDate;
		DateTime? dateTime2 = returnEndDate;
		if ((dateTime.HasValue & dateTime2.HasValue) && dateTime.GetValueOrDefault() >= dateTime2.GetValueOrDefault() && chkDateRange.Value)
		{
			new frmMessageBox(Resources.Start_date_time_should_be_less).ShowDialog(this);
			return false;
		}
		returnSalePrice = (string.IsNullOrEmpty(txtSalePrice.Text) ? 0m : Convert.ToDecimal(txtSalePrice.Text));
		returnPercentageOff = (string.IsNullOrEmpty(txtPercentageOff.Text) ? 0m : Convert.ToDecimal(txtPercentageOff.Text));
		string text = method_4(bool_1: true);
		if (text == "false")
		{
			return false;
		}
		returnDaysSaleList = text;
		return true;
	}

	private string method_4(bool bool_1)
	{
		List<string> list = new List<string>();
		if (chkDaySale.Value)
		{
			foreach (Control control in panel1.Controls)
			{
				if (((RadToggleSwitch)control).Value)
				{
					_003C_003Ec__DisplayClass44_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass44_0();
					string text = control.Text.ToUpper();
					CS_0024_003C_003E8__locals0.shortenedDayString = control.Name.Replace("chk", string.Empty);
					DateTimePicker dateTimePicker = (from a in base.Controls.OfType<DateTimePicker>()
						where a.Name.Contains(CS_0024_003C_003E8__locals0.shortenedDayString) && a.Name.Contains("from")
						select a).FirstOrDefault();
					DateTimePicker dateTimePicker2 = (from a in base.Controls.OfType<DateTimePicker>()
						where a.Name.Contains(CS_0024_003C_003E8__locals0.shortenedDayString) && a.Name.Contains("to")
						select a).FirstOrDefault();
					if (bool_1 && dateTimePicker.Value > dateTimePicker2.Value)
					{
						new NotificationLabel(this, "From Time cannot be greater than To Time", NotificationTypes.Warning).Show();
						return "false";
					}
					list.Add(text + "-" + dateTimePicker.Value.ToString("HH:mm") + "-" + dateTimePicker2.Value.ToString("HH:mm"));
				}
			}
		}
		return string.Join("|", list);
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		if (method_3())
		{
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	private void btnShowKeyboard_PercentageOff_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Off, 2, 4);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtPercentageOff.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
			txtSalePrice.Text = ((txtPercentageOff.Text == "") ? "0" : (decimal_4 - Convert.ToDecimal(txtPercentageOff.Text) * Convert.ToDecimal(0.01) * decimal_4).ToString("0.00"));
		}
		base.DialogResult = DialogResult.None;
	}

	private void txtPercentageOff_KeyPress(object sender, KeyPressEventArgs e)
	{
		TextFilters.NumbersWithSingleDecimalPoint(sender, e);
	}

	private void startDate_ValueChanged(object sender, EventArgs e)
	{
		startDate.Value = startDate.Value.Date;
		if (startDate.Value >= endDate.Value)
		{
			endDate.Value = startDate.Value.AddHours(23.0);
		}
	}

	private void endDate_ValueChanged(object sender, EventArgs e)
	{
		endDate.Value = endDate.Value.Date.AddHours(23.0);
		if (endDate.Value < startDate.Value)
		{
			endDate.Value = startDate.Value.AddHours(23.0);
		}
	}

	private void chkDateRange_ValueChanged(object sender, EventArgs e)
	{
		if (chkDateRange.Value)
		{
			startDate.Enabled = true;
			endDate.Enabled = true;
		}
		else
		{
			startDate.Enabled = false;
			endDate.Enabled = false;
		}
	}

	private void btnShowKeyboard_txtSalePrice_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Sale Price", 4, 12, txtSalePrice.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtSalePrice.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
			decimal num = ((txtSalePrice.Text == "" || decimal_4 <= 0m) ? 0m : ((decimal_4 - Convert.ToDecimal(txtSalePrice.Text)) / decimal_4 * 100m));
			txtPercentageOff.Text = num.ToString("0.00");
		}
		base.DialogResult = DialogResult.None;
	}

	private void txtPercentageOff_KeyUp(object sender, KeyEventArgs e)
	{
		txtSalePrice.Text = ((txtPercentageOff.Text == "") ? "0" : (decimal_4 - Convert.ToDecimal(txtPercentageOff.Text) * Convert.ToDecimal(0.01) * decimal_4).ToString("0.00"));
	}

	private void txtSalePrice_KeyUp(object sender, KeyEventArgs e)
	{
		decimal num = ((txtSalePrice.Text == "" || decimal_4 <= 0m) ? 0m : ((decimal_4 - Convert.ToDecimal(txtSalePrice.Text)) / decimal_4 * 100m));
		txtPercentageOff.Text = num.ToString("0.00");
	}

	private void txtPercentageOff_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private DateTime method_5(DateTime dateTime_2)
	{
		frmDateSelector frmDateSelector2 = new frmDateSelector(dateTime_2);
		if (frmDateSelector2.ShowDialog() == DialogResult.OK)
		{
			base.DialogResult = DialogResult.None;
			return frmDateSelector2.returnDate;
		}
		base.DialogResult = DialogResult.None;
		return dateTime_2;
	}

	private void startDate_MouseDown(object sender, MouseEventArgs e)
	{
		DateTimePicker dateTimePicker = (DateTimePicker)sender;
		dateTimePicker.Value = method_5(dateTimePicker.Value);
	}

	private void method_6(object sender, MouseEventArgs e)
	{
		ControlHelpers.TimePick_Click(sender);
	}

	private void btnCopyMon_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass60_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass60_0();
		Button button = sender as Button;
		CS_0024_003C_003E8__locals0.dayString = button.Name.Replace("btnCopy", string.Empty);
		if (button.Text == "COPY")
		{
			dateTime_0 = (from a in base.Controls.OfType<DateTimePicker>()
				where a.Name.Contains(CS_0024_003C_003E8__locals0.dayString) && a.Name.Contains("from")
				select a).FirstOrDefault().Value;
			dateTime_1 = (from a in base.Controls.OfType<DateTimePicker>()
				where a.Name.Contains(CS_0024_003C_003E8__locals0.dayString) && a.Name.Contains("to")
				select a).FirstOrDefault().Value;
			foreach (Button item in from a in base.Controls.OfType<Button>()
				where a.Name.Contains("Copy")
				select a)
			{
				if (item.Name != button.Name)
				{
					item.Text = "PASTE";
				}
				else
				{
					item.Text = "CANCEL";
				}
			}
		}
		else if (button.Text == "CANCEL")
		{
			foreach (Button item2 in from a in base.Controls.OfType<Button>()
				where a.Name.Contains("Copy")
				select a)
			{
				item2.Text = "COPY";
			}
		}
		else
		{
			DateTimePicker dateTimePicker = (from a in base.Controls.OfType<DateTimePicker>()
				where a.Name.Contains(CS_0024_003C_003E8__locals0.dayString) && a.Name.Contains("from")
				select a).FirstOrDefault();
			DateTimePicker dateTimePicker2 = (from a in base.Controls.OfType<DateTimePicker>()
				where a.Name.Contains(CS_0024_003C_003E8__locals0.dayString) && a.Name.Contains("to")
				select a).FirstOrDefault();
			dateTimePicker.Value = dateTime_0;
			dateTimePicker2.Value = dateTime_1;
			button.Text = "COPY";
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSelectDateOnSale));
		lblOriginalPrice = new Label();
		label23 = new Label();
		btnSave = new Button();
		txtSalePrice = new RadTextBoxControl();
		label4 = new Label();
		txtPercentageOff = new RadTextBoxControl();
		chkDateRange = new RadToggleSwitch();
		btnShowKeyboard_txtSalePrice = new Button();
		label17 = new Label();
		btnShowKeyboard_PercentageOff = new Button();
		label3 = new Label();
		label2 = new Label();
		label9 = new Label();
		label1 = new Label();
		btnClose = new Button();
		endDate = new DateTimePicker();
		startDate = new DateTimePicker();
		toSun = new CustomTimeControl();
		toSat = new CustomTimeControl();
		fromSun = new CustomTimeControl();
		fromSat = new CustomTimeControl();
		toFri = new CustomTimeControl();
		fromFri = new CustomTimeControl();
		toThu = new CustomTimeControl();
		fromThu = new CustomTimeControl();
		toWed = new CustomTimeControl();
		fromWed = new CustomTimeControl();
		toTue = new CustomTimeControl();
		fromTue = new CustomTimeControl();
		toMon = new CustomTimeControl();
		fromMon = new CustomTimeControl();
		btnCopySun = new Button();
		label32 = new Label();
		label33 = new Label();
		btnCopySat = new Button();
		label30 = new Label();
		label31 = new Label();
		btnCopyFri = new Button();
		label28 = new Label();
		label29 = new Label();
		btnCopyThu = new Button();
		label16 = new Label();
		label27 = new Label();
		btnCopyWed = new Button();
		label14 = new Label();
		label15 = new Label();
		btnCopyTue = new Button();
		label12 = new Label();
		label13 = new Label();
		btnCopyMon = new Button();
		label11 = new Label();
		label10 = new Label();
		label19 = new Label();
		chkDaySale = new RadToggleSwitch();
		panel1 = new Panel();
		chkSun = new RadToggleSwitch();
		chkWed = new RadToggleSwitch();
		chkTue = new RadToggleSwitch();
		chkMon = new RadToggleSwitch();
		chkThu = new RadToggleSwitch();
		chkFri = new RadToggleSwitch();
		chkSat = new RadToggleSwitch();
		label8 = new Label();
		lbl1 = new Label();
		lbl2 = new Label();
		((ISupportInitialize)txtSalePrice).BeginInit();
		((ISupportInitialize)txtPercentageOff).BeginInit();
		((ISupportInitialize)chkDateRange).BeginInit();
		((ISupportInitialize)chkDaySale).BeginInit();
		panel1.SuspendLayout();
		((ISupportInitialize)chkSun).BeginInit();
		((ISupportInitialize)chkWed).BeginInit();
		((ISupportInitialize)chkTue).BeginInit();
		((ISupportInitialize)chkMon).BeginInit();
		((ISupportInitialize)chkThu).BeginInit();
		((ISupportInitialize)chkFri).BeginInit();
		((ISupportInitialize)chkSat).BeginInit();
		SuspendLayout();
		componentResourceManager.ApplyResources(lblOriginalPrice, "lblOriginalPrice");
		lblOriginalPrice.BackColor = Color.FromArgb(150, 166, 166);
		lblOriginalPrice.ForeColor = Color.White;
		lblOriginalPrice.Name = "lblOriginalPrice";
		label23.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label23, "label23");
		label23.ForeColor = Color.White;
		label23.Name = "label23";
		btnSave.BackColor = Color.FromArgb(65, 168, 95);
		btnSave.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.ForeColor = SystemColors.ButtonFace;
		btnSave.Name = "btnSave";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		componentResourceManager.ApplyResources(txtSalePrice, "txtSalePrice");
		txtSalePrice.ForeColor = Color.FromArgb(40, 40, 40);
		txtSalePrice.Name = "txtSalePrice";
		txtSalePrice.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtSalePrice.Tag = "product";
		txtSalePrice.TextAlign = HorizontalAlignment.Center;
		txtSalePrice.Click += txtPercentageOff_Click;
		txtSalePrice.KeyPress += txtPercentageOff_KeyPress;
		txtSalePrice.KeyUp += txtSalePrice_KeyUp;
		((RadTextBoxControlElement)txtSalePrice.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtSalePrice.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(0f, 5f);
		label4.BackColor = Color.FromArgb(150, 166, 166);
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		componentResourceManager.ApplyResources(txtPercentageOff, "txtPercentageOff");
		txtPercentageOff.ForeColor = Color.FromArgb(40, 40, 40);
		txtPercentageOff.Name = "txtPercentageOff";
		txtPercentageOff.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtPercentageOff.Tag = "product";
		txtPercentageOff.TextAlign = HorizontalAlignment.Center;
		txtPercentageOff.Click += txtPercentageOff_Click;
		txtPercentageOff.KeyPress += txtPercentageOff_KeyPress;
		txtPercentageOff.KeyUp += txtPercentageOff_KeyUp;
		((RadTextBoxControlElement)txtPercentageOff.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtPercentageOff.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(0f, 5f);
		componentResourceManager.ApplyResources(chkDateRange, "chkDateRange");
		chkDateRange.Name = "chkDateRange";
		chkDateRange.ToggleStateMode = ToggleStateMode.Click;
		chkDateRange.Value = false;
		chkDateRange.ValueChanged += chkDateRange_ValueChanged;
		((RadToggleSwitchElement)chkDateRange.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkDateRange.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkDateRange.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkDateRange.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkDateRange.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkDateRange.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkDateRange.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text");
		((ToggleSwitchPartElement)chkDateRange.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		btnShowKeyboard_txtSalePrice.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_txtSalePrice.DialogResult = DialogResult.OK;
		btnShowKeyboard_txtSalePrice.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_txtSalePrice.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_txtSalePrice, "btnShowKeyboard_txtSalePrice");
		btnShowKeyboard_txtSalePrice.ForeColor = Color.White;
		btnShowKeyboard_txtSalePrice.Name = "btnShowKeyboard_txtSalePrice";
		btnShowKeyboard_txtSalePrice.UseVisualStyleBackColor = false;
		btnShowKeyboard_txtSalePrice.Click += btnShowKeyboard_txtSalePrice_Click;
		label17.BackColor = Color.FromArgb(80, 203, 116);
		componentResourceManager.ApplyResources(label17, "label17");
		label17.ForeColor = Color.White;
		label17.Name = "label17";
		btnShowKeyboard_PercentageOff.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_PercentageOff.DialogResult = DialogResult.OK;
		btnShowKeyboard_PercentageOff.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_PercentageOff.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_PercentageOff, "btnShowKeyboard_PercentageOff");
		btnShowKeyboard_PercentageOff.ForeColor = Color.White;
		btnShowKeyboard_PercentageOff.Name = "btnShowKeyboard_PercentageOff";
		btnShowKeyboard_PercentageOff.UseVisualStyleBackColor = false;
		btnShowKeyboard_PercentageOff.Click += btnShowKeyboard_PercentageOff_Click;
		label3.BackColor = Color.FromArgb(80, 203, 116);
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		label2.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		componentResourceManager.ApplyResources(label9, "label9");
		label9.BackColor = Color.FromArgb(156, 89, 184);
		label9.ForeColor = Color.White;
		label9.Name = "label9";
		label1.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		btnClose.BackColor = Color.FromArgb(235, 107, 86);
		btnClose.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnClose, "btnClose");
		btnClose.ForeColor = SystemColors.ButtonFace;
		btnClose.Name = "btnClose";
		btnClose.UseVisualStyleBackColor = false;
		btnClose.Click += btnClose_Click;
		componentResourceManager.ApplyResources(endDate, "endDate");
		endDate.Format = DateTimePickerFormat.Short;
		endDate.Name = "endDate";
		endDate.ValueChanged += endDate_ValueChanged;
		endDate.MouseDown += startDate_MouseDown;
		startDate.Checked = false;
		componentResourceManager.ApplyResources(startDate, "startDate");
		startDate.Format = DateTimePickerFormat.Short;
		startDate.Name = "startDate";
		startDate.ValueChanged += startDate_ValueChanged;
		startDate.MouseDown += startDate_MouseDown;
		componentResourceManager.ApplyResources(toSun, "toSun");
		toSun.Format = DateTimePickerFormat.Time;
		toSun.Name = "toSun";
		toSun.ShowUpDown = true;
		componentResourceManager.ApplyResources(toSat, "toSat");
		toSat.Format = DateTimePickerFormat.Time;
		toSat.Name = "toSat";
		toSat.ShowUpDown = true;
		componentResourceManager.ApplyResources(fromSun, "fromSun");
		fromSun.Format = DateTimePickerFormat.Time;
		fromSun.Name = "fromSun";
		fromSun.ShowUpDown = true;
		componentResourceManager.ApplyResources(fromSat, "fromSat");
		fromSat.Format = DateTimePickerFormat.Time;
		fromSat.Name = "fromSat";
		fromSat.ShowUpDown = true;
		componentResourceManager.ApplyResources(toFri, "toFri");
		toFri.Format = DateTimePickerFormat.Time;
		toFri.Name = "toFri";
		toFri.ShowUpDown = true;
		componentResourceManager.ApplyResources(fromFri, "fromFri");
		fromFri.Format = DateTimePickerFormat.Time;
		fromFri.Name = "fromFri";
		fromFri.ShowUpDown = true;
		componentResourceManager.ApplyResources(toThu, "toThu");
		toThu.Format = DateTimePickerFormat.Time;
		toThu.Name = "toThu";
		toThu.ShowUpDown = true;
		componentResourceManager.ApplyResources(fromThu, "fromThu");
		fromThu.Format = DateTimePickerFormat.Time;
		fromThu.Name = "fromThu";
		fromThu.ShowUpDown = true;
		componentResourceManager.ApplyResources(toWed, "toWed");
		toWed.Format = DateTimePickerFormat.Time;
		toWed.Name = "toWed";
		toWed.ShowUpDown = true;
		componentResourceManager.ApplyResources(fromWed, "fromWed");
		fromWed.Format = DateTimePickerFormat.Time;
		fromWed.Name = "fromWed";
		fromWed.ShowUpDown = true;
		componentResourceManager.ApplyResources(toTue, "toTue");
		toTue.Format = DateTimePickerFormat.Time;
		toTue.Name = "toTue";
		toTue.ShowUpDown = true;
		componentResourceManager.ApplyResources(fromTue, "fromTue");
		fromTue.Format = DateTimePickerFormat.Time;
		fromTue.Name = "fromTue";
		fromTue.ShowUpDown = true;
		componentResourceManager.ApplyResources(toMon, "toMon");
		toMon.Format = DateTimePickerFormat.Time;
		toMon.Name = "toMon";
		toMon.ShowUpDown = true;
		componentResourceManager.ApplyResources(fromMon, "fromMon");
		fromMon.Format = DateTimePickerFormat.Time;
		fromMon.Name = "fromMon";
		fromMon.ShowUpDown = true;
		btnCopySun.BackColor = Color.FromArgb(77, 174, 225);
		btnCopySun.DialogResult = DialogResult.OK;
		btnCopySun.FlatAppearance.BorderColor = Color.Black;
		btnCopySun.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnCopySun, "btnCopySun");
		btnCopySun.ForeColor = Color.White;
		btnCopySun.Name = "btnCopySun";
		btnCopySun.UseVisualStyleBackColor = false;
		btnCopySun.Click += btnCopyMon_Click;
		label32.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label32, "label32");
		label32.ForeColor = Color.White;
		label32.Name = "label32";
		label33.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label33, "label33");
		label33.ForeColor = Color.White;
		label33.Name = "label33";
		btnCopySat.BackColor = Color.FromArgb(77, 174, 225);
		btnCopySat.DialogResult = DialogResult.OK;
		btnCopySat.FlatAppearance.BorderColor = Color.Black;
		btnCopySat.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnCopySat, "btnCopySat");
		btnCopySat.ForeColor = Color.White;
		btnCopySat.Name = "btnCopySat";
		btnCopySat.UseVisualStyleBackColor = false;
		btnCopySat.Click += btnCopyMon_Click;
		label30.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label30, "label30");
		label30.ForeColor = Color.White;
		label30.Name = "label30";
		label31.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label31, "label31");
		label31.ForeColor = Color.White;
		label31.Name = "label31";
		btnCopyFri.BackColor = Color.FromArgb(77, 174, 225);
		btnCopyFri.DialogResult = DialogResult.OK;
		btnCopyFri.FlatAppearance.BorderColor = Color.Black;
		btnCopyFri.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnCopyFri, "btnCopyFri");
		btnCopyFri.ForeColor = Color.White;
		btnCopyFri.Name = "btnCopyFri";
		btnCopyFri.UseVisualStyleBackColor = false;
		btnCopyFri.Click += btnCopyMon_Click;
		label28.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label28, "label28");
		label28.ForeColor = Color.White;
		label28.Name = "label28";
		label29.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label29, "label29");
		label29.ForeColor = Color.White;
		label29.Name = "label29";
		btnCopyThu.BackColor = Color.FromArgb(77, 174, 225);
		btnCopyThu.DialogResult = DialogResult.OK;
		btnCopyThu.FlatAppearance.BorderColor = Color.Black;
		btnCopyThu.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnCopyThu, "btnCopyThu");
		btnCopyThu.ForeColor = Color.White;
		btnCopyThu.Name = "btnCopyThu";
		btnCopyThu.UseVisualStyleBackColor = false;
		btnCopyThu.Click += btnCopyMon_Click;
		label16.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label16, "label16");
		label16.ForeColor = Color.White;
		label16.Name = "label16";
		label27.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label27, "label27");
		label27.ForeColor = Color.White;
		label27.Name = "label27";
		btnCopyWed.BackColor = Color.FromArgb(77, 174, 225);
		btnCopyWed.DialogResult = DialogResult.OK;
		btnCopyWed.FlatAppearance.BorderColor = Color.Black;
		btnCopyWed.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnCopyWed, "btnCopyWed");
		btnCopyWed.ForeColor = Color.White;
		btnCopyWed.Name = "btnCopyWed";
		btnCopyWed.UseVisualStyleBackColor = false;
		btnCopyWed.Click += btnCopyMon_Click;
		label14.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label14, "label14");
		label14.ForeColor = Color.White;
		label14.Name = "label14";
		label15.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label15, "label15");
		label15.ForeColor = Color.White;
		label15.Name = "label15";
		btnCopyTue.BackColor = Color.FromArgb(77, 174, 225);
		btnCopyTue.DialogResult = DialogResult.OK;
		btnCopyTue.FlatAppearance.BorderColor = Color.Black;
		btnCopyTue.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnCopyTue, "btnCopyTue");
		btnCopyTue.ForeColor = Color.White;
		btnCopyTue.Name = "btnCopyTue";
		btnCopyTue.UseVisualStyleBackColor = false;
		btnCopyTue.Click += btnCopyMon_Click;
		label12.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label12, "label12");
		label12.ForeColor = Color.White;
		label12.Name = "label12";
		label13.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label13, "label13");
		label13.ForeColor = Color.White;
		label13.Name = "label13";
		btnCopyMon.BackColor = Color.FromArgb(77, 174, 225);
		btnCopyMon.DialogResult = DialogResult.OK;
		btnCopyMon.FlatAppearance.BorderColor = Color.Black;
		btnCopyMon.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnCopyMon, "btnCopyMon");
		btnCopyMon.ForeColor = Color.White;
		btnCopyMon.Name = "btnCopyMon";
		btnCopyMon.UseVisualStyleBackColor = false;
		btnCopyMon.Click += btnCopyMon_Click;
		label11.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label11, "label11");
		label11.ForeColor = Color.White;
		label11.Name = "label11";
		label10.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label10, "label10");
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		label19.BackColor = Color.FromArgb(150, 166, 166);
		componentResourceManager.ApplyResources(label19, "label19");
		label19.ForeColor = Color.White;
		label19.Name = "label19";
		componentResourceManager.ApplyResources(chkDaySale, "chkDaySale");
		chkDaySale.Name = "chkDaySale";
		chkDaySale.ToggleStateMode = ToggleStateMode.Click;
		chkDaySale.Value = false;
		((RadToggleSwitchElement)chkDaySale.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkDaySale.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkDaySale.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkDaySale.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkDaySale.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkDaySale.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkDaySale.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text1");
		((ToggleSwitchPartElement)chkDaySale.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		panel1.Controls.Add(chkSun);
		panel1.Controls.Add(chkWed);
		panel1.Controls.Add(chkTue);
		panel1.Controls.Add(chkMon);
		panel1.Controls.Add(chkThu);
		panel1.Controls.Add(chkFri);
		panel1.Controls.Add(chkSat);
		componentResourceManager.ApplyResources(panel1, "panel1");
		panel1.Name = "panel1";
		componentResourceManager.ApplyResources(chkSun, "chkSun");
		chkSun.Name = "chkSun";
		chkSun.OffText = "SUNDAY OFF";
		chkSun.OnText = "SUNDAY ON";
		chkSun.Tag = "SundaySale";
		chkSun.ToggleStateMode = ToggleStateMode.Click;
		chkSun.Value = false;
		((RadToggleSwitchElement)chkSun.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkSun.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkSun.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkSun.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkSun.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkSun.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkSun.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text2");
		((ToggleSwitchPartElement)chkSun.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		componentResourceManager.ApplyResources(chkWed, "chkWed");
		chkWed.Name = "chkWed";
		chkWed.OffText = "WEDNESDAY OFF";
		chkWed.OnText = "WEDNESDAY ON";
		chkWed.Tag = "WednesdaySale";
		chkWed.ToggleStateMode = ToggleStateMode.Click;
		chkWed.Value = false;
		((RadToggleSwitchElement)chkWed.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkWed.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkWed.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkWed.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkWed.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkWed.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkWed.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text3");
		((ToggleSwitchPartElement)chkWed.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		componentResourceManager.ApplyResources(chkTue, "chkTue");
		chkTue.Name = "chkTue";
		chkTue.OffText = "TUESDAY OFF";
		chkTue.OnText = "TUESDAY ON";
		chkTue.Tag = "TuesdaySale";
		chkTue.ToggleStateMode = ToggleStateMode.Click;
		chkTue.Value = false;
		((RadToggleSwitchElement)chkTue.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkTue.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkTue.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkTue.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkTue.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkTue.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkTue.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text4");
		((ToggleSwitchPartElement)chkTue.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		componentResourceManager.ApplyResources(chkMon, "chkMon");
		chkMon.Name = "chkMon";
		chkMon.OffText = "MONDAY OFF";
		chkMon.OnText = "MONDAY ON";
		chkMon.Tag = "MondaySale";
		chkMon.ToggleStateMode = ToggleStateMode.Click;
		chkMon.Value = false;
		((RadToggleSwitchElement)chkMon.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkMon.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkMon.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkMon.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkMon.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkMon.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkMon.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text5");
		((ToggleSwitchPartElement)chkMon.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		componentResourceManager.ApplyResources(chkThu, "chkThu");
		chkThu.Name = "chkThu";
		chkThu.OffText = "THURSDAY OFF";
		chkThu.OnText = "THURSDAY ON";
		chkThu.Tag = "ThursdaySale";
		chkThu.ToggleStateMode = ToggleStateMode.Click;
		chkThu.Value = false;
		((RadToggleSwitchElement)chkThu.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkThu.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkThu.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkThu.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkThu.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkThu.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkThu.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text6");
		((ToggleSwitchPartElement)chkThu.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		componentResourceManager.ApplyResources(chkFri, "chkFri");
		chkFri.Name = "chkFri";
		chkFri.OffText = "FRIDAY OFF";
		chkFri.OnText = "FRIDAY ON";
		chkFri.Tag = "FridaySale";
		chkFri.ToggleStateMode = ToggleStateMode.Click;
		chkFri.Value = false;
		((RadToggleSwitchElement)chkFri.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkFri.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkFri.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkFri.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkFri.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkFri.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkFri.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text7");
		((ToggleSwitchPartElement)chkFri.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		componentResourceManager.ApplyResources(chkSat, "chkSat");
		chkSat.Name = "chkSat";
		chkSat.OffText = "SATURDAY OFF";
		chkSat.OnText = "SATURDAY ON";
		chkSat.Tag = "SaturdaySale";
		chkSat.ToggleStateMode = ToggleStateMode.Click;
		chkSat.Value = false;
		((RadToggleSwitchElement)chkSat.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkSat.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkSat.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkSat.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkSat.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkSat.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkSat.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text8");
		((ToggleSwitchPartElement)chkSat.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		label8.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label8, "label8");
		label8.ForeColor = Color.White;
		label8.Name = "label8";
		componentResourceManager.ApplyResources(lbl1, "lbl1");
		lbl1.BackColor = Color.FromArgb(150, 166, 166);
		lbl1.ForeColor = Color.White;
		lbl1.Name = "lbl1";
		componentResourceManager.ApplyResources(lbl2, "lbl2");
		lbl2.BackColor = Color.FromArgb(150, 166, 166);
		lbl2.ForeColor = Color.White;
		lbl2.Name = "lbl2";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(lbl2);
		base.Controls.Add(lbl1);
		base.Controls.Add(toSun);
		base.Controls.Add(toSat);
		base.Controls.Add(fromSun);
		base.Controls.Add(fromSat);
		base.Controls.Add(toFri);
		base.Controls.Add(fromFri);
		base.Controls.Add(toThu);
		base.Controls.Add(fromThu);
		base.Controls.Add(toWed);
		base.Controls.Add(fromWed);
		base.Controls.Add(toTue);
		base.Controls.Add(fromTue);
		base.Controls.Add(toMon);
		base.Controls.Add(fromMon);
		base.Controls.Add(btnCopySun);
		base.Controls.Add(label32);
		base.Controls.Add(label33);
		base.Controls.Add(btnCopySat);
		base.Controls.Add(label30);
		base.Controls.Add(label31);
		base.Controls.Add(btnCopyFri);
		base.Controls.Add(label28);
		base.Controls.Add(label29);
		base.Controls.Add(btnCopyThu);
		base.Controls.Add(label16);
		base.Controls.Add(label27);
		base.Controls.Add(btnCopyWed);
		base.Controls.Add(label14);
		base.Controls.Add(label15);
		base.Controls.Add(btnCopyTue);
		base.Controls.Add(label12);
		base.Controls.Add(label13);
		base.Controls.Add(btnCopyMon);
		base.Controls.Add(label11);
		base.Controls.Add(label10);
		base.Controls.Add(label19);
		base.Controls.Add(chkDaySale);
		base.Controls.Add(panel1);
		base.Controls.Add(label8);
		base.Controls.Add(lblOriginalPrice);
		base.Controls.Add(label23);
		base.Controls.Add(btnSave);
		base.Controls.Add(txtSalePrice);
		base.Controls.Add(label4);
		base.Controls.Add(txtPercentageOff);
		base.Controls.Add(chkDateRange);
		base.Controls.Add(btnShowKeyboard_txtSalePrice);
		base.Controls.Add(label17);
		base.Controls.Add(btnShowKeyboard_PercentageOff);
		base.Controls.Add(label3);
		base.Controls.Add(label2);
		base.Controls.Add(label9);
		base.Controls.Add(label1);
		base.Controls.Add(btnClose);
		base.Controls.Add(endDate);
		base.Controls.Add(startDate);
		base.Name = "frmSelectDateOnSale";
		base.Opacity = 1.0;
		base.Load += frmSelectDateOnSale_Load;
		((ISupportInitialize)txtSalePrice).EndInit();
		((ISupportInitialize)txtPercentageOff).EndInit();
		((ISupportInitialize)chkDateRange).EndInit();
		((ISupportInitialize)chkDaySale).EndInit();
		panel1.ResumeLayout(performLayout: false);
		((ISupportInitialize)chkSun).EndInit();
		((ISupportInitialize)chkWed).EndInit();
		((ISupportInitialize)chkTue).EndInit();
		((ISupportInitialize)chkMon).EndInit();
		((ISupportInitialize)chkThu).EndInit();
		((ISupportInitialize)chkFri).EndInit();
		((ISupportInitialize)chkSat).EndInit();
		ResumeLayout(performLayout: false);
	}
}
