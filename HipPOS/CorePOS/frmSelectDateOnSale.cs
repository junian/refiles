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
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmSelectDateOnSale : frmMasterForm
{
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
			((Control)(object)txtSalePrice).Text = decimal_2.ToString("0.00##");
			((Control)(object)txtPercentageOff).Text = Math.Round(decimal_3, 0).ToString("0.00");
		}
		if (!nullable_6.HasValue)
		{
			chkDateRange.set_Value(false);
			startDate.Enabled = false;
			endDate.Enabled = false;
			startDate.Value = DateTime.Now.Date;
			endDate.Value = DateTime.Now.Date;
		}
		else
		{
			chkDateRange.set_Value(true);
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
		bool_0 = chkDateRange.get_Value();
		if (string.IsNullOrEmpty(string_1))
		{
			return;
		}
		chkDaySale.set_Value(true);
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
				where ((Control)(object)a).Name.ToUpper().Contains(CS_0024_003C_003E8__locals0.dayShortString)
				select a).FirstOrDefault().set_Value(true);
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
		returnSalePrice = (string.IsNullOrEmpty(((Control)(object)txtSalePrice).Text) ? 0m : Convert.ToDecimal(((Control)(object)txtSalePrice).Text));
		DateTime? dateTime = nullable_4;
		DateTime? dateTime2 = returnStartDate;
		if (((dateTime.HasValue != dateTime2.HasValue || (dateTime.HasValue && dateTime.GetValueOrDefault() != dateTime2.GetValueOrDefault()) || nullable_5 != returnEndDate) && chkDateRange.get_Value()) || string_1 != returnDaysSaleList)
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
		if (!chkDaySale.get_Value() && ((Control)(object)txtPercentageOff).Text != "" && !MiscHelper.isNumberInRange(Convert.ToDecimal(((Control)(object)txtPercentageOff).Text), 0m, 100m))
		{
			new frmMessageBox("Percentage Off Only accepts value 0-100").ShowDialog(this);
			return false;
		}
		if (chkDateRange.get_Value())
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
		if ((dateTime.HasValue & dateTime2.HasValue) && dateTime.GetValueOrDefault() >= dateTime2.GetValueOrDefault() && chkDateRange.get_Value())
		{
			new frmMessageBox(Resources.Start_date_time_should_be_less).ShowDialog(this);
			return false;
		}
		returnSalePrice = (string.IsNullOrEmpty(((Control)(object)txtSalePrice).Text) ? 0m : Convert.ToDecimal(((Control)(object)txtSalePrice).Text));
		returnPercentageOff = (string.IsNullOrEmpty(((Control)(object)txtPercentageOff).Text) ? 0m : Convert.ToDecimal(((Control)(object)txtPercentageOff).Text));
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
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		List<string> list = new List<string>();
		if (chkDaySale.get_Value())
		{
			foreach (Control control in panel1.Controls)
			{
				RadToggleSwitch val = (RadToggleSwitch)control;
				if (val.get_Value())
				{
					_003C_003Ec__DisplayClass44_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass44_0();
					string text = ((Control)(object)val).Text.ToUpper();
					CS_0024_003C_003E8__locals0.shortenedDayString = ((Control)(object)val).Name.Replace("chk", string.Empty);
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
			((Control)(object)txtPercentageOff).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
			((Control)(object)txtSalePrice).Text = ((((Control)(object)txtPercentageOff).Text == "") ? "0" : (decimal_4 - Convert.ToDecimal(((Control)(object)txtPercentageOff).Text) * Convert.ToDecimal(0.01) * decimal_4).ToString("0.00"));
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
		if (chkDateRange.get_Value())
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
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Sale Price", 4, 12, ((Control)(object)txtSalePrice).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtSalePrice).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
			decimal num = ((((Control)(object)txtSalePrice).Text == "" || decimal_4 <= 0m) ? 0m : ((decimal_4 - Convert.ToDecimal(((Control)(object)txtSalePrice).Text)) / decimal_4 * 100m));
			((Control)(object)txtPercentageOff).Text = num.ToString("0.00");
		}
		base.DialogResult = DialogResult.None;
	}

	private void txtPercentageOff_KeyUp(object sender, KeyEventArgs e)
	{
		((Control)(object)txtSalePrice).Text = ((((Control)(object)txtPercentageOff).Text == "") ? "0" : (decimal_4 - Convert.ToDecimal(((Control)(object)txtPercentageOff).Text) * Convert.ToDecimal(0.01) * decimal_4).ToString("0.00"));
	}

	private void txtSalePrice_KeyUp(object sender, KeyEventArgs e)
	{
		decimal num = ((((Control)(object)txtSalePrice).Text == "" || decimal_4 <= 0m) ? 0m : ((decimal_4 - Convert.ToDecimal(((Control)(object)txtSalePrice).Text)) / decimal_4 * 100m));
		((Control)(object)txtPercentageOff).Text = num.ToString("0.00");
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
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected O, but got Unknown
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Expected O, but got Unknown
		//IL_0547: Unknown result type (might be due to invalid IL or missing references)
		//IL_0568: Unknown result type (might be due to invalid IL or missing references)
		//IL_0694: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_072a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0742: Unknown result type (might be due to invalid IL or missing references)
		//IL_0759: Unknown result type (might be due to invalid IL or missing references)
		//IL_077a: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0801: Unknown result type (might be due to invalid IL or missing references)
		//IL_0828: Unknown result type (might be due to invalid IL or missing references)
		//IL_18c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_18f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1919: Unknown result type (might be due to invalid IL or missing references)
		//IL_1946: Unknown result type (might be due to invalid IL or missing references)
		//IL_1973: Unknown result type (might be due to invalid IL or missing references)
		//IL_19a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_19c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b12: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b41: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b62: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1be9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c10: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ccf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cf0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d77: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e46: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eab: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ed8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f05: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1feb: Unknown result type (might be due to invalid IL or missing references)
		//IL_200c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2039: Unknown result type (might be due to invalid IL or missing references)
		//IL_2066: Unknown result type (might be due to invalid IL or missing references)
		//IL_2093: Unknown result type (might be due to invalid IL or missing references)
		//IL_20ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_214a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2162: Unknown result type (might be due to invalid IL or missing references)
		//IL_2179: Unknown result type (might be due to invalid IL or missing references)
		//IL_219a: Unknown result type (might be due to invalid IL or missing references)
		//IL_21c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_21f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2221: Unknown result type (might be due to invalid IL or missing references)
		//IL_2248: Unknown result type (might be due to invalid IL or missing references)
		//IL_22d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_22f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2307: Unknown result type (might be due to invalid IL or missing references)
		//IL_2328: Unknown result type (might be due to invalid IL or missing references)
		//IL_2355: Unknown result type (might be due to invalid IL or missing references)
		//IL_2382: Unknown result type (might be due to invalid IL or missing references)
		//IL_23af: Unknown result type (might be due to invalid IL or missing references)
		//IL_23d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2466: Unknown result type (might be due to invalid IL or missing references)
		//IL_247e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2495: Unknown result type (might be due to invalid IL or missing references)
		//IL_24b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_24e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2510: Unknown result type (might be due to invalid IL or missing references)
		//IL_253d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2564: Unknown result type (might be due to invalid IL or missing references)
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
		((Control)(object)txtSalePrice).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtSalePrice).Name = "txtSalePrice";
		((RadElement)((RadControl)txtSalePrice).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtSalePrice).Tag = "product";
		txtSalePrice.set_TextAlign(HorizontalAlignment.Center);
		((Control)(object)txtSalePrice).Click += txtPercentageOff_Click;
		((Control)(object)txtSalePrice).KeyPress += txtPercentageOff_KeyPress;
		((Control)(object)txtSalePrice).KeyUp += txtSalePrice_KeyUp;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtSalePrice).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtSalePrice).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(0f, 5f));
		label4.BackColor = Color.FromArgb(150, 166, 166);
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		componentResourceManager.ApplyResources(txtPercentageOff, "txtPercentageOff");
		((Control)(object)txtPercentageOff).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtPercentageOff).Name = "txtPercentageOff";
		((RadElement)((RadControl)txtPercentageOff).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtPercentageOff).Tag = "product";
		txtPercentageOff.set_TextAlign(HorizontalAlignment.Center);
		((Control)(object)txtPercentageOff).Click += txtPercentageOff_Click;
		((Control)(object)txtPercentageOff).KeyPress += txtPercentageOff_KeyPress;
		((Control)(object)txtPercentageOff).KeyUp += txtPercentageOff_KeyUp;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtPercentageOff).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtPercentageOff).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(0f, 5f));
		componentResourceManager.ApplyResources(chkDateRange, "chkDateRange");
		((Control)(object)chkDateRange).Name = "chkDateRange";
		chkDateRange.set_ToggleStateMode((ToggleStateMode)1);
		chkDateRange.set_Value(false);
		chkDateRange.add_ValueChanged((EventHandler)chkDateRange_ValueChanged);
		((RadToggleSwitchElement)((RadControl)chkDateRange).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkDateRange).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkDateRange).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkDateRange).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkDateRange).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkDateRange).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkDateRange).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkDateRange).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
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
		((Control)(object)chkDaySale).Name = "chkDaySale";
		chkDaySale.set_ToggleStateMode((ToggleStateMode)1);
		chkDaySale.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkDaySale).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkDaySale).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkDaySale).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkDaySale).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkDaySale).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkDaySale).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkDaySale).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text1"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkDaySale).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		panel1.Controls.Add((Control)(object)chkSun);
		panel1.Controls.Add((Control)(object)chkWed);
		panel1.Controls.Add((Control)(object)chkTue);
		panel1.Controls.Add((Control)(object)chkMon);
		panel1.Controls.Add((Control)(object)chkThu);
		panel1.Controls.Add((Control)(object)chkFri);
		panel1.Controls.Add((Control)(object)chkSat);
		componentResourceManager.ApplyResources(panel1, "panel1");
		panel1.Name = "panel1";
		componentResourceManager.ApplyResources(chkSun, "chkSun");
		((Control)(object)chkSun).Name = "chkSun";
		chkSun.set_OffText("SUNDAY OFF");
		chkSun.set_OnText("SUNDAY ON");
		((Control)(object)chkSun).Tag = "SundaySale";
		chkSun.set_ToggleStateMode((ToggleStateMode)1);
		chkSun.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkSun).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkSun).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkSun).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkSun).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkSun).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkSun).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkSun).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text2"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkSun).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		componentResourceManager.ApplyResources(chkWed, "chkWed");
		((Control)(object)chkWed).Name = "chkWed";
		chkWed.set_OffText("WEDNESDAY OFF");
		chkWed.set_OnText("WEDNESDAY ON");
		((Control)(object)chkWed).Tag = "WednesdaySale";
		chkWed.set_ToggleStateMode((ToggleStateMode)1);
		chkWed.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkWed).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkWed).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkWed).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkWed).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkWed).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkWed).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkWed).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text3"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkWed).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		componentResourceManager.ApplyResources(chkTue, "chkTue");
		((Control)(object)chkTue).Name = "chkTue";
		chkTue.set_OffText("TUESDAY OFF");
		chkTue.set_OnText("TUESDAY ON");
		((Control)(object)chkTue).Tag = "TuesdaySale";
		chkTue.set_ToggleStateMode((ToggleStateMode)1);
		chkTue.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkTue).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkTue).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkTue).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTue).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTue).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTue).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkTue).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text4"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkTue).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		componentResourceManager.ApplyResources(chkMon, "chkMon");
		((Control)(object)chkMon).Name = "chkMon";
		chkMon.set_OffText("MONDAY OFF");
		chkMon.set_OnText("MONDAY ON");
		((Control)(object)chkMon).Tag = "MondaySale";
		chkMon.set_ToggleStateMode((ToggleStateMode)1);
		chkMon.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkMon).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkMon).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkMon).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkMon).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkMon).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkMon).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkMon).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text5"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkMon).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		componentResourceManager.ApplyResources(chkThu, "chkThu");
		((Control)(object)chkThu).Name = "chkThu";
		chkThu.set_OffText("THURSDAY OFF");
		chkThu.set_OnText("THURSDAY ON");
		((Control)(object)chkThu).Tag = "ThursdaySale";
		chkThu.set_ToggleStateMode((ToggleStateMode)1);
		chkThu.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkThu).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkThu).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkThu).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkThu).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkThu).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkThu).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkThu).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text6"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkThu).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		componentResourceManager.ApplyResources(chkFri, "chkFri");
		((Control)(object)chkFri).Name = "chkFri";
		chkFri.set_OffText("FRIDAY OFF");
		chkFri.set_OnText("FRIDAY ON");
		((Control)(object)chkFri).Tag = "FridaySale";
		chkFri.set_ToggleStateMode((ToggleStateMode)1);
		chkFri.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkFri).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkFri).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkFri).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkFri).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkFri).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkFri).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkFri).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text7"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkFri).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		componentResourceManager.ApplyResources(chkSat, "chkSat");
		((Control)(object)chkSat).Name = "chkSat";
		chkSat.set_OffText("SATURDAY OFF");
		chkSat.set_OnText("SATURDAY ON");
		((Control)(object)chkSat).Tag = "SaturdaySale";
		chkSat.set_ToggleStateMode((ToggleStateMode)1);
		chkSat.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkSat).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkSat).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkSat).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkSat).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkSat).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkSat).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkSat).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text8"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkSat).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
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
		base.Controls.Add((Control)(object)chkDaySale);
		base.Controls.Add(panel1);
		base.Controls.Add(label8);
		base.Controls.Add(lblOriginalPrice);
		base.Controls.Add(label23);
		base.Controls.Add(btnSave);
		base.Controls.Add((Control)(object)txtSalePrice);
		base.Controls.Add(label4);
		base.Controls.Add((Control)(object)txtPercentageOff);
		base.Controls.Add((Control)(object)chkDateRange);
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
