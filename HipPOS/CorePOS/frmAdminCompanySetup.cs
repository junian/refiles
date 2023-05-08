using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects.ThirdPartyAPIs.Other;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmAdminCompanySetup : frmMasterForm
{
	private bool bool_0;

	private string string_0;

	private IContainer icontainer_1;

	private Label label1;

	private Label label2;

	private Label label3;

	private Label label4;

	private Label label5;

	internal Button btnSave;

	private Label label8;

	private Label label7;

	private Label label9;

	private Label label10;

	private Label label11;

	private Label label6;

	internal Button btnShowKeyboard_CompanyName;

	internal Button btnShowKeyboard_Address;

	internal Button btnShowKeyboard_City;

	internal Button btnShowKeyboard_Phone;

	internal Button btnShowKeyboard_Fax;

	internal Button btnShowKeyboard_TaxNo;

	internal Button btnShowKeyboard_BusinessName;

	internal Button btnShowKeyboard_StateProv;

	internal Button btnShowKeyboard_Country;

	internal Button btnShowKeyboard_Zip;

	private Panel panel1;

	private Label label13;

	private DateTimePicker dateToOperation;

	private DateTimePicker dateFromOperation;

	private Label label12;

	private RadTextBoxControl txtCompanyName;

	private RadTextBoxControl txtStateProv;

	private RadTextBoxControl txtBusinessName;

	private RadTextBoxControl txtCity;

	private RadTextBoxControl txtAddress;

	private RadTextBoxControl txtZip;

	private RadTextBoxControl txtCountry;

	private RadTextBoxControl txtTaxNo;

	private RadTextBoxControl txtFax;

	private RadTextBoxControl txtPhone;

	private ComboBox lstDayOfWeek;

	private RadTextBoxControl txtCapacity;

	private Label label14;

	internal Button btnShowKeyboard_Capacity;

	internal ListView lstItems;

	private ColumnHeader columnHeader_0;

	internal ColumnHeader columnHeader_1;

	internal Button btnRemoveItem;

	internal Button btnAdd;

	private ColumnHeader columnHeader_2;

	private Label label15;

	private RadToggleSwitch chkPrintTaxNo;

	public frmAdminCompanySetup()
	{
		Class26.Ggkj0JxzN9YmC();
		string_0 = "";
		base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this, 2f);
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		if (((Control)(object)txtCompanyName).Text == string.Empty)
		{
			new frmMessageBox(Resources.Name_is_mandatory).ShowDialog(this);
		}
		else if (!(((Control)(object)txtAddress).Text == string.Empty) && !(((Control)(object)txtCity).Text == string.Empty) && !(((Control)(object)txtStateProv).Text == string.Empty) && !(((Control)(object)txtCountry).Text == string.Empty) && !(((Control)(object)txtZip).Text == string.Empty))
		{
			if (((Control)(object)txtPhone).Text == string.Empty)
			{
				new frmMessageBox(Resources.Phone_number_is_mandatory).ShowDialog(this);
				return;
			}
			if (!(((Control)(object)txtTaxNo).Text == string.Empty))
			{
				try
				{
					GClass6 gClass = new GClass6();
					CompanySetup companySetup = gClass.CompanySetups.FirstOrDefault();
					if (companySetup.Address1 != ((Control)(object)txtAddress).Text || companySetup.City != ((Control)(object)txtCity).Text || companySetup.StateProv != ((Control)(object)txtStateProv).Text || companySetup.Country != ((Control)(object)txtCountry).Text || companySetup.ZIP != ((Control)(object)txtZip).Text)
					{
						companySetup.Address1 = ((Control)(object)txtAddress).Text;
						companySetup.City = ((Control)(object)txtCity).Text;
						companySetup.StateProv = ((Control)(object)txtStateProv).Text;
						companySetup.Country = ((Control)(object)txtCountry).Text;
						companySetup.ZIP = ((Control)(object)txtZip).Text;
						GoogleObjects.LatLongModel latLongModel = GoogleMethods.ConvertAddressToLatLong(companySetup.Address1 + "+" + companySetup.City + "+" + companySetup.StateProv + "+" + companySetup.Country);
						companySetup.Long = latLongModel.Longitude;
						companySetup.Lat = latLongModel.Latitude;
						GoogleObjects.TimeZoneModel locationTimeZone = GoogleMethods.GetLocationTimeZone(companySetup.Lat, companySetup.Long);
						if (locationTimeZone != null && (companySetup.TimeZoneName != TimeZone.CurrentTimeZone.StandardName || companySetup.TimeZoneName != locationTimeZone.timeZoneName))
						{
							companySetup.TimeZoneName = locationTimeZone.timeZoneName;
							companySetup.TimeZoneOffset = locationTimeZone.rawOffset + locationTimeZone.dstOffset;
							MiscHelper.SetSystemTimeZone(locationTimeZone.timeZoneName);
						}
					}
					companySetup.Name = ((Control)(object)txtCompanyName).Text;
					companySetup.Phone = ((Control)(object)txtPhone).Text;
					companySetup.Fax = ((Control)(object)txtFax).Text;
					companySetup.String_0 = ((Control)(object)txtTaxNo).Text;
					companySetup.BusinessName = ((Control)(object)txtBusinessName).Text;
					companySetup.Capacity = Convert.ToInt32(((Control)(object)txtCapacity).Text);
					companySetup.LatestOpeningTime = dateFromOperation.Value.TimeOfDay.ToString();
					companySetup.LatestClosingTime = dateToOperation.Value.TimeOfDay.ToString();
					companySetup.isSynced = false;
					Helper.SubmitChangesWithCatch(gClass);
					Setting setting = gClass.Settings.Where((Setting s) => s.Key == "print_tax_no").FirstOrDefault();
					if (setting != null)
					{
						if (!chkPrintTaxNo.get_Value())
						{
							setting.Value = "OFF";
						}
						else
						{
							setting.Value = "ON";
						}
						Helper.SubmitChangesWithCatch(gClass);
						SettingsHelper.SetSettingValueByKey("print_tax_no", setting.Value);
					}
					method_7();
					bool_0 = false;
					CompanyHelper.SetCompany();
					new NotificationLabel(this, Resources.The_record_has_been_updated, NotificationTypes.Success).Show();
					return;
				}
				catch (Exception error)
				{
					NotificationMethods.sendCrash(AppSettings.AppVersion, Environment.OSVersion.VersionString, error);
					new frmMessageBox(Resources.Please_make_sure_all_required_).ShowDialog(this);
					return;
				}
			}
			new frmMessageBox(Resources.Tax_No_is_mandatory).ShowDialog(this);
		}
		else
		{
			new frmMessageBox(Resources.Address_fields_are_mandatory).ShowDialog(this);
		}
	}

	private void frmAdminCompanySetup_Load(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		CompanySetup companySetup = gClass.CompanySetups.FirstOrDefault();
		((Control)(object)txtCompanyName).Text = companySetup.Name;
		((Control)(object)txtAddress).Text = companySetup.Address1;
		((Control)(object)txtCity).Text = companySetup.City;
		((Control)(object)txtStateProv).Text = companySetup.StateProv;
		((Control)(object)txtCountry).Text = companySetup.Country;
		((Control)(object)txtZip).Text = companySetup.ZIP;
		((Control)(object)txtPhone).Text = companySetup.Phone;
		((Control)(object)txtFax).Text = companySetup.Fax;
		((Control)(object)txtTaxNo).Text = companySetup.String_0;
		((Control)(object)txtBusinessName).Text = companySetup.BusinessName;
		((Control)(object)txtCapacity).Text = companySetup.Capacity.ToString();
		chkPrintTaxNo.set_Value((SettingsHelper.GetSettingValueByKey("print_tax_no") == "ON") ? true : false);
		List<BusinessHour> source = gClass.BusinessHours.ToList();
		lstDayOfWeek.SelectedIndex = 0;
		lstItems.Items.Clear();
		List<BusinessHour> list = source.Where((BusinessHour businessHour_0) => businessHour_0.DayOfTheWeek.ToUpper() == lstDayOfWeek.SelectedItem.ToString().ToUpper()).ToList();
		int num = 1;
		foreach (BusinessHour item in list)
		{
			ListViewItem value = new ListViewItem(new string[4]
			{
				num.ToString(),
				item.LatestOpeningTime,
				item.LatestClosingTime,
				lstDayOfWeek.SelectedItem.ToString()
			});
			lstItems.Items.Add(value);
			num++;
		}
		btnRemoveItem.Enabled = false;
	}

	private void method_3(object sender, EventArgs e)
	{
	}

	private void method_4(object sender, EventArgs e)
	{
	}

	private void label11_Click(object sender, EventArgs e)
	{
	}

	private void method_5(string string_1, RadTextBoxControl radTextBoxControl_0)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(string_1, 1, 128, ((Control)(object)radTextBoxControl_0).Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)radTextBoxControl_0).Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void method_6(string string_1, RadTextBoxControl radTextBoxControl_0, int int_0 = 2, int int_1 = 4)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(string_1, int_0, int_1, ((Control)(object)radTextBoxControl_0).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)radTextBoxControl_0).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_CompanyName_Click(object sender, EventArgs e)
	{
		method_5(Resources.Company_Name, txtCompanyName);
	}

	private void btnShowKeyboard_Address_Click(object sender, EventArgs e)
	{
		method_5(Resources.Address, txtAddress);
	}

	private void btnShowKeyboard_City_Click(object sender, EventArgs e)
	{
		method_5(Resources.City, txtCity);
	}

	private void btnShowKeyboard_Phone_Click(object sender, EventArgs e)
	{
		method_5(Resources.Phone, txtPhone);
	}

	private void btnShowKeyboard_StateProv_Click(object sender, EventArgs e)
	{
		method_5(Resources.State_Province, txtStateProv);
	}

	private void btnShowKeyboard_Country_Click(object sender, EventArgs e)
	{
		method_5(Resources.Country, txtCountry);
	}

	private void btnShowKeyboard_Zip_Click(object sender, EventArgs e)
	{
		method_5(Resources.Zip, txtZip);
	}

	private void btnShowKeyboard_Fax_Click(object sender, EventArgs e)
	{
		method_5(Resources.Fax, txtFax);
	}

	private void btnShowKeyboard_TaxNo_Click(object sender, EventArgs e)
	{
		method_5(Resources.Tax_No, txtTaxNo);
	}

	private void btnShowKeyboard_BusinessName_Click(object sender, EventArgs e)
	{
		method_5(Resources.Legal_Business_Name, txtBusinessName);
	}

	private void btnShowKeyboard_Capacity_Click(object sender, EventArgs e)
	{
		method_6(Resources.Capacity, txtCapacity, 0, 5);
	}

	private void txtCapacity_KeyPress(object sender, KeyPressEventArgs e)
	{
		TextFilters.NumberOnly(sender, e);
	}

	private void txtCompanyName_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private void dateFromOperation_ValueChanged(object sender, EventArgs e)
	{
	}

	private void dateToOperation_ValueChanged(object sender, EventArgs e)
	{
	}

	private void method_7()
	{
		GClass6 gClass = new GClass6();
		foreach (BusinessHour item in gClass.BusinessHours.Where((BusinessHour c) => c.DayOfTheWeek.ToLower() == string_0.ToLower()).ToList())
		{
			gClass.BusinessHours.DeleteOnSubmit(item);
		}
		Helper.SubmitChangesWithCatch(gClass);
		if (lstItems.Items.Count > 0)
		{
			foreach (ListViewItem item2 in lstItems.Items)
			{
				BusinessHour businessHour = new BusinessHour();
				businessHour.DayOfTheWeek = item2.SubItems[3].Text.ToLower();
				businessHour.LatestOpeningTime = item2.SubItems[1].Text;
				businessHour.LatestClosingTime = item2.SubItems[2].Text;
				gClass.BusinessHours.InsertOnSubmit(businessHour);
			}
		}
		Helper.SubmitChangesWithCatch(gClass);
	}

	private void lstDayOfWeek_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (bool_0 && new frmMessageBox(Resources.Do_you_want_to_save_the_change + lstDayOfWeek.SelectedItem.ToString() + Resources._s_Hours_Of_Operation, Resources.Save_Changes, CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
		{
			method_7();
			new NotificationLabel(this, Resources.The_record_has_been_updated, NotificationTypes.Success).Show();
		}
		bool_0 = false;
		List<BusinessHour> list = new GClass6().BusinessHours.ToList();
		if (list.Count > 0)
		{
			BusinessHour businessHour = list.Where((BusinessHour businessHour_0) => businessHour_0.DayOfTheWeek == lstDayOfWeek.GetItemText(lstDayOfWeek.SelectedItem).ToLower()).FirstOrDefault();
			if (businessHour != null)
			{
				dateFromOperation.Value = Convert.ToDateTime(businessHour.LatestOpeningTime);
				try
				{
					dateToOperation.Value = Convert.ToDateTime(businessHour.LatestClosingTime);
				}
				catch
				{
					dateToOperation.Value = dateFromOperation.Value.AddHours(10.0);
					businessHour.LatestClosingTime = dateToOperation.Value.TimeOfDay.ToString();
				}
			}
			else
			{
				dateFromOperation.Value = Convert.ToDateTime("09:30:00");
				dateToOperation.Value = Convert.ToDateTime("23:00:00");
			}
			lstItems.Items.Clear();
			int num = 1;
			foreach (BusinessHour item in list.Where((BusinessHour businessHour_0) => businessHour_0.DayOfTheWeek.ToUpper() == lstDayOfWeek.SelectedItem.ToString().ToUpper()).ToList())
			{
				ListViewItem value = new ListViewItem(new string[4]
				{
					num.ToString(),
					item.LatestOpeningTime,
					item.LatestClosingTime,
					lstDayOfWeek.SelectedItem.ToString()
				});
				lstItems.Items.Add(value);
				num++;
			}
		}
		btnRemoveItem.Enabled = false;
		string_0 = lstDayOfWeek.SelectedItem.ToString();
	}

	private void btnRemoveItem_Click(object sender, EventArgs e)
	{
		if (lstItems.SelectedIndices.Count <= 0)
		{
			return;
		}
		bool_0 = true;
		lstItems.Items.RemoveAt(lstItems.SelectedIndices[0]);
		int num = 1;
		foreach (ListViewItem item in lstItems.Items)
		{
			item.SubItems[0].Text = num.ToString();
			num++;
		}
	}

	private bool method_8(ListViewItem listViewItem_0, DateTime dateTime_0)
	{
		DateTime dateTime = Convert.ToDateTime(listViewItem_0.SubItems[1].Text);
		DateTime dateTime2 = Convert.ToDateTime(listViewItem_0.SubItems[2].Text);
		if (dateTime_0 > dateTime && dateTime_0 < dateTime2)
		{
			return true;
		}
		return false;
	}

	private bool method_9(ListViewItem listViewItem_0, DateTime dateTime_0)
	{
		DateTime dateTime = Convert.ToDateTime(listViewItem_0.SubItems[1].Text);
		if (dateTime_0 == dateTime)
		{
			return true;
		}
		return false;
	}

	private bool method_10(ListViewItem listViewItem_0, DateTime dateTime_0)
	{
		DateTime dateTime = Convert.ToDateTime(listViewItem_0.SubItems[2].Text);
		if (dateTime_0 == dateTime)
		{
			return true;
		}
		return false;
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		DateTime value = dateFromOperation.Value;
		DateTime dateTime = dateToOperation.Value;
		if (dateTime <= value)
		{
			dateTime = dateTime.AddDays(1.0);
		}
		bool flag = false;
		foreach (ListViewItem item in lstItems.Items)
		{
			bool flag2 = method_8(item, value);
			bool flag3 = method_9(item, value);
			method_10(item, value);
			bool num = method_8(item, dateTime);
			method_9(item, dateTime);
			if ((num | method_10(item, dateTime)) || flag3 || flag2)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			new frmMessageBox(Resources.You_cannot_have_overlapping_ho, Resources.OVERLAPPING_HOURS).ShowDialog(this);
			return;
		}
		int num2 = lstItems.Items.Count + 1;
		bool_0 = true;
		ListViewItem value2 = new ListViewItem(new string[4]
		{
			num2.ToString(),
			dateFromOperation.Value.TimeOfDay.ToString(),
			dateToOperation.Value.TimeOfDay.ToString(),
			lstDayOfWeek.SelectedItem.ToString()
		});
		lstItems.Items.Add(value2);
	}

	private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (lstItems.SelectedIndices.Count > 0)
		{
			btnRemoveItem.Enabled = true;
		}
		else
		{
			btnRemoveItem.Enabled = false;
		}
	}

	private void btnRemoveItem_EnabledChanged(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (!button.Enabled)
		{
			button.Tag = button.BackColor;
			button.BackColor = Color.Gray;
		}
		else if (button.Tag != null)
		{
			button.BackColor = (Color)button.Tag;
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
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_09d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d01: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e88: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fee: Unknown result type (might be due to invalid IL or missing references)
		//IL_1080: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1133: Unknown result type (might be due to invalid IL or missing references)
		//IL_1154: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1207: Unknown result type (might be due to invalid IL or missing references)
		//IL_1299: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fa6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ff6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2023: Unknown result type (might be due to invalid IL or missing references)
		//IL_2050: Unknown result type (might be due to invalid IL or missing references)
		//IL_207d: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmAdminCompanySetup));
		panel1 = new Panel();
		btnRemoveItem = new Button();
		btnAdd = new Button();
		lstItems = new ListView();
		columnHeader_0 = new ColumnHeader();
		columnHeader_1 = new ColumnHeader();
		columnHeader_2 = new ColumnHeader();
		txtCapacity = new RadTextBoxControl();
		label14 = new Label();
		btnShowKeyboard_Capacity = new Button();
		lstDayOfWeek = new ComboBox();
		txtTaxNo = new RadTextBoxControl();
		txtFax = new RadTextBoxControl();
		txtPhone = new RadTextBoxControl();
		txtZip = new RadTextBoxControl();
		txtCountry = new RadTextBoxControl();
		txtStateProv = new RadTextBoxControl();
		txtBusinessName = new RadTextBoxControl();
		txtCity = new RadTextBoxControl();
		txtAddress = new RadTextBoxControl();
		txtCompanyName = new RadTextBoxControl();
		label13 = new Label();
		dateToOperation = new DateTimePicker();
		dateFromOperation = new DateTimePicker();
		label12 = new Label();
		btnSave = new Button();
		btnShowKeyboard_Zip = new Button();
		label1 = new Label();
		btnShowKeyboard_Country = new Button();
		label2 = new Label();
		btnShowKeyboard_StateProv = new Button();
		label3 = new Label();
		btnShowKeyboard_BusinessName = new Button();
		label4 = new Label();
		btnShowKeyboard_TaxNo = new Button();
		label5 = new Label();
		btnShowKeyboard_Fax = new Button();
		btnShowKeyboard_Phone = new Button();
		btnShowKeyboard_City = new Button();
		btnShowKeyboard_Address = new Button();
		btnShowKeyboard_CompanyName = new Button();
		label8 = new Label();
		label10 = new Label();
		label9 = new Label();
		label11 = new Label();
		label7 = new Label();
		label6 = new Label();
		label15 = new Label();
		chkPrintTaxNo = new RadToggleSwitch();
		panel1.SuspendLayout();
		((ISupportInitialize)txtCapacity).BeginInit();
		((ISupportInitialize)txtTaxNo).BeginInit();
		((ISupportInitialize)txtFax).BeginInit();
		((ISupportInitialize)txtPhone).BeginInit();
		((ISupportInitialize)txtZip).BeginInit();
		((ISupportInitialize)txtCountry).BeginInit();
		((ISupportInitialize)txtStateProv).BeginInit();
		((ISupportInitialize)txtBusinessName).BeginInit();
		((ISupportInitialize)txtCity).BeginInit();
		((ISupportInitialize)txtAddress).BeginInit();
		((ISupportInitialize)txtCompanyName).BeginInit();
		((ISupportInitialize)chkPrintTaxNo).BeginInit();
		SuspendLayout();
		panel1.Controls.Add((Control)(object)chkPrintTaxNo);
		panel1.Controls.Add(label15);
		panel1.Controls.Add(btnRemoveItem);
		panel1.Controls.Add(btnAdd);
		panel1.Controls.Add(lstItems);
		panel1.Controls.Add((Control)(object)txtCapacity);
		panel1.Controls.Add(label14);
		panel1.Controls.Add(btnShowKeyboard_Capacity);
		panel1.Controls.Add(lstDayOfWeek);
		panel1.Controls.Add((Control)(object)txtTaxNo);
		panel1.Controls.Add((Control)(object)txtFax);
		panel1.Controls.Add((Control)(object)txtPhone);
		panel1.Controls.Add((Control)(object)txtZip);
		panel1.Controls.Add((Control)(object)txtCountry);
		panel1.Controls.Add((Control)(object)txtStateProv);
		panel1.Controls.Add((Control)(object)txtBusinessName);
		panel1.Controls.Add((Control)(object)txtCity);
		panel1.Controls.Add((Control)(object)txtAddress);
		panel1.Controls.Add((Control)(object)txtCompanyName);
		panel1.Controls.Add(label13);
		panel1.Controls.Add(dateToOperation);
		panel1.Controls.Add(dateFromOperation);
		panel1.Controls.Add(label12);
		panel1.Controls.Add(btnSave);
		panel1.Controls.Add(btnShowKeyboard_Zip);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(btnShowKeyboard_Country);
		panel1.Controls.Add(label2);
		panel1.Controls.Add(btnShowKeyboard_StateProv);
		panel1.Controls.Add(label3);
		panel1.Controls.Add(btnShowKeyboard_BusinessName);
		panel1.Controls.Add(label4);
		panel1.Controls.Add(btnShowKeyboard_TaxNo);
		panel1.Controls.Add(label5);
		panel1.Controls.Add(btnShowKeyboard_Fax);
		panel1.Controls.Add(btnShowKeyboard_Phone);
		panel1.Controls.Add(btnShowKeyboard_City);
		panel1.Controls.Add(btnShowKeyboard_Address);
		panel1.Controls.Add(btnShowKeyboard_CompanyName);
		panel1.Controls.Add(label8);
		panel1.Controls.Add(label10);
		panel1.Controls.Add(label9);
		panel1.Controls.Add(label11);
		panel1.Controls.Add(label7);
		componentResourceManager.ApplyResources(panel1, "panel1");
		panel1.Name = "panel1";
		btnRemoveItem.BackColor = Color.SandyBrown;
		btnRemoveItem.Cursor = Cursors.Default;
		btnRemoveItem.FlatAppearance.BorderColor = Color.Black;
		btnRemoveItem.FlatAppearance.BorderSize = 0;
		btnRemoveItem.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 0, 37);
		componentResourceManager.ApplyResources(btnRemoveItem, "btnRemoveItem");
		btnRemoveItem.ForeColor = Color.White;
		btnRemoveItem.Name = "btnRemoveItem";
		btnRemoveItem.UseVisualStyleBackColor = false;
		btnRemoveItem.EnabledChanged += btnRemoveItem_EnabledChanged;
		btnRemoveItem.Click += btnRemoveItem_Click;
		btnAdd.BackColor = Color.FromArgb(61, 142, 185);
		btnAdd.Cursor = Cursors.Default;
		btnAdd.FlatAppearance.BorderColor = Color.Black;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 0, 37);
		componentResourceManager.ApplyResources(btnAdd, "btnAdd");
		btnAdd.ForeColor = Color.White;
		btnAdd.Name = "btnAdd";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += btnAdd_Click;
		componentResourceManager.ApplyResources(lstItems, "lstItems");
		lstItems.BorderStyle = BorderStyle.FixedSingle;
		lstItems.Columns.AddRange(new ColumnHeader[3] { columnHeader_0, columnHeader_1, columnHeader_2 });
		lstItems.FullRowSelect = true;
		lstItems.GridLines = true;
		lstItems.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		lstItems.HideSelection = false;
		lstItems.MultiSelect = false;
		lstItems.Name = "lstItems";
		lstItems.TileSize = new Size(20, 20);
		lstItems.UseCompatibleStateImageBehavior = false;
		lstItems.View = View.Details;
		lstItems.SelectedIndexChanged += lstItems_SelectedIndexChanged;
		componentResourceManager.ApplyResources(columnHeader_0, "No");
		componentResourceManager.ApplyResources(columnHeader_1, "StartHour");
		componentResourceManager.ApplyResources(columnHeader_2, "EndHour");
		componentResourceManager.ApplyResources(txtCapacity, "txtCapacity");
		((Control)(object)txtCapacity).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtCapacity).Name = "txtCapacity";
		((RadElement)((RadControl)txtCapacity).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtCapacity).Click += txtCompanyName_Click;
		((Control)(object)txtCapacity).KeyPress += txtCapacity_KeyPress;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtCapacity).GetChildAt(0)).set_BorderWidth(1f);
		((RadElement)(TextBoxViewElement)((RadControl)txtCapacity).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		label14.BackColor = Color.FromArgb(132, 146, 146);
		label14.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label14, "label14");
		label14.ForeColor = Color.White;
		label14.Name = "label14";
		btnShowKeyboard_Capacity.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Capacity.DialogResult = DialogResult.OK;
		btnShowKeyboard_Capacity.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Capacity.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Capacity, "btnShowKeyboard_Capacity");
		btnShowKeyboard_Capacity.ForeColor = Color.White;
		btnShowKeyboard_Capacity.Name = "btnShowKeyboard_Capacity";
		btnShowKeyboard_Capacity.UseVisualStyleBackColor = false;
		btnShowKeyboard_Capacity.Click += btnShowKeyboard_Capacity_Click;
		lstDayOfWeek.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(lstDayOfWeek, "lstDayOfWeek");
		lstDayOfWeek.FormattingEnabled = true;
		lstDayOfWeek.Items.AddRange(new object[7]
		{
			componentResourceManager.GetString("lstDayOfWeek.Items"),
			componentResourceManager.GetString("lstDayOfWeek.Items1"),
			componentResourceManager.GetString("lstDayOfWeek.Items2"),
			componentResourceManager.GetString("lstDayOfWeek.Items3"),
			componentResourceManager.GetString("lstDayOfWeek.Items4"),
			componentResourceManager.GetString("lstDayOfWeek.Items5"),
			componentResourceManager.GetString("lstDayOfWeek.Items6")
		});
		lstDayOfWeek.Name = "lstDayOfWeek";
		lstDayOfWeek.SelectedIndexChanged += lstDayOfWeek_SelectedIndexChanged;
		componentResourceManager.ApplyResources(txtTaxNo, "txtTaxNo");
		((Control)(object)txtTaxNo).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtTaxNo).Name = "txtTaxNo";
		((RadElement)((RadControl)txtTaxNo).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtTaxNo).Click += txtCompanyName_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtTaxNo).GetChildAt(0)).set_BorderWidth(1f);
		((RadElement)(TextBoxViewElement)((RadControl)txtTaxNo).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		componentResourceManager.ApplyResources(txtFax, "txtFax");
		((Control)(object)txtFax).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtFax).Name = "txtFax";
		((RadElement)((RadControl)txtFax).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtFax).Click += txtCompanyName_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtFax).GetChildAt(0)).set_BorderWidth(1f);
		((RadElement)(TextBoxViewElement)((RadControl)txtFax).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		componentResourceManager.ApplyResources(txtPhone, "txtPhone");
		((Control)(object)txtPhone).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtPhone).Name = "txtPhone";
		((RadElement)((RadControl)txtPhone).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtPhone).Click += txtCompanyName_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtPhone).GetChildAt(0)).set_BorderWidth(1f);
		((RadElement)(TextBoxViewElement)((RadControl)txtPhone).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		componentResourceManager.ApplyResources(txtZip, "txtZip");
		((Control)(object)txtZip).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtZip).Name = "txtZip";
		((RadElement)((RadControl)txtZip).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtZip).Click += txtCompanyName_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtZip).GetChildAt(0)).set_BorderWidth(1f);
		((RadElement)(TextBoxViewElement)((RadControl)txtZip).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		componentResourceManager.ApplyResources(txtCountry, "txtCountry");
		((Control)(object)txtCountry).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtCountry).Name = "txtCountry";
		((RadElement)((RadControl)txtCountry).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtCountry).Click += txtCompanyName_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtCountry).GetChildAt(0)).set_BorderWidth(1f);
		((RadElement)(TextBoxViewElement)((RadControl)txtCountry).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		componentResourceManager.ApplyResources(txtStateProv, "txtStateProv");
		((Control)(object)txtStateProv).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtStateProv).Name = "txtStateProv";
		((RadElement)((RadControl)txtStateProv).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtStateProv).Click += txtCompanyName_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtStateProv).GetChildAt(0)).set_BorderWidth(1f);
		((RadElement)(TextBoxViewElement)((RadControl)txtStateProv).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		componentResourceManager.ApplyResources(txtBusinessName, "txtBusinessName");
		((Control)(object)txtBusinessName).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtBusinessName).Name = "txtBusinessName";
		((RadElement)((RadControl)txtBusinessName).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtBusinessName).Click += txtCompanyName_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtBusinessName).GetChildAt(0)).set_BorderWidth(1f);
		((RadElement)(TextBoxViewElement)((RadControl)txtBusinessName).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		componentResourceManager.ApplyResources(txtCity, "txtCity");
		((Control)(object)txtCity).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtCity).Name = "txtCity";
		((RadElement)((RadControl)txtCity).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtCity).Click += txtCompanyName_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtCity).GetChildAt(0)).set_BorderWidth(1f);
		((RadElement)(TextBoxViewElement)((RadControl)txtCity).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		componentResourceManager.ApplyResources(txtAddress, "txtAddress");
		((Control)(object)txtAddress).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtAddress).Name = "txtAddress";
		((RadElement)((RadControl)txtAddress).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtAddress).Click += txtCompanyName_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtAddress).GetChildAt(0)).set_BorderWidth(1f);
		((RadElement)(TextBoxViewElement)((RadControl)txtAddress).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		componentResourceManager.ApplyResources(txtCompanyName, "txtCompanyName");
		((Control)(object)txtCompanyName).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtCompanyName).Name = "txtCompanyName";
		((RadElement)((RadControl)txtCompanyName).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtCompanyName).Click += txtCompanyName_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtCompanyName).GetChildAt(0)).set_BorderWidth(1f);
		((RadElement)(TextBoxViewElement)((RadControl)txtCompanyName).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		componentResourceManager.ApplyResources(label13, "label13");
		label13.Name = "label13";
		componentResourceManager.ApplyResources(dateToOperation, "dateToOperation");
		dateToOperation.Format = DateTimePickerFormat.Time;
		dateToOperation.Name = "dateToOperation";
		dateToOperation.ShowUpDown = true;
		dateToOperation.ValueChanged += dateToOperation_ValueChanged;
		componentResourceManager.ApplyResources(dateFromOperation, "dateFromOperation");
		dateFromOperation.Format = DateTimePickerFormat.Time;
		dateFromOperation.Name = "dateFromOperation";
		dateFromOperation.ShowUpDown = true;
		dateFromOperation.ValueChanged += dateFromOperation_ValueChanged;
		label12.BackColor = Color.FromArgb(132, 146, 146);
		label12.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label12, "label12");
		label12.ForeColor = Color.White;
		label12.Name = "label12";
		btnSave.BackColor = Color.FromArgb(47, 204, 113);
		btnSave.FlatAppearance.BorderColor = Color.White;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.ForeColor = Color.White;
		btnSave.Name = "btnSave";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		btnShowKeyboard_Zip.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Zip.DialogResult = DialogResult.OK;
		btnShowKeyboard_Zip.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Zip.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Zip, "btnShowKeyboard_Zip");
		btnShowKeyboard_Zip.ForeColor = Color.White;
		btnShowKeyboard_Zip.Name = "btnShowKeyboard_Zip";
		btnShowKeyboard_Zip.UseVisualStyleBackColor = false;
		btnShowKeyboard_Zip.Click += btnShowKeyboard_Zip_Click;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		label1.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		btnShowKeyboard_Country.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Country.DialogResult = DialogResult.OK;
		btnShowKeyboard_Country.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Country.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Country, "btnShowKeyboard_Country");
		btnShowKeyboard_Country.ForeColor = Color.White;
		btnShowKeyboard_Country.Name = "btnShowKeyboard_Country";
		btnShowKeyboard_Country.UseVisualStyleBackColor = false;
		btnShowKeyboard_Country.Click += btnShowKeyboard_Country_Click;
		label2.BackColor = Color.FromArgb(132, 146, 146);
		label2.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		btnShowKeyboard_StateProv.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_StateProv.DialogResult = DialogResult.OK;
		btnShowKeyboard_StateProv.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_StateProv.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_StateProv, "btnShowKeyboard_StateProv");
		btnShowKeyboard_StateProv.ForeColor = Color.White;
		btnShowKeyboard_StateProv.Name = "btnShowKeyboard_StateProv";
		btnShowKeyboard_StateProv.UseVisualStyleBackColor = false;
		btnShowKeyboard_StateProv.Click += btnShowKeyboard_StateProv_Click;
		label3.BackColor = Color.FromArgb(132, 146, 146);
		label3.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		btnShowKeyboard_BusinessName.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_BusinessName.DialogResult = DialogResult.OK;
		btnShowKeyboard_BusinessName.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_BusinessName.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_BusinessName, "btnShowKeyboard_BusinessName");
		btnShowKeyboard_BusinessName.ForeColor = Color.White;
		btnShowKeyboard_BusinessName.Name = "btnShowKeyboard_BusinessName";
		btnShowKeyboard_BusinessName.UseVisualStyleBackColor = false;
		btnShowKeyboard_BusinessName.Click += btnShowKeyboard_BusinessName_Click;
		label4.BackColor = Color.FromArgb(132, 146, 146);
		label4.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		btnShowKeyboard_TaxNo.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_TaxNo.DialogResult = DialogResult.OK;
		btnShowKeyboard_TaxNo.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_TaxNo.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_TaxNo, "btnShowKeyboard_TaxNo");
		btnShowKeyboard_TaxNo.ForeColor = Color.White;
		btnShowKeyboard_TaxNo.Name = "btnShowKeyboard_TaxNo";
		btnShowKeyboard_TaxNo.UseVisualStyleBackColor = false;
		btnShowKeyboard_TaxNo.Click += btnShowKeyboard_TaxNo_Click;
		label5.BackColor = Color.FromArgb(132, 146, 146);
		label5.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label5, "label5");
		label5.ForeColor = Color.White;
		label5.Name = "label5";
		btnShowKeyboard_Fax.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Fax.DialogResult = DialogResult.OK;
		btnShowKeyboard_Fax.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Fax.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Fax, "btnShowKeyboard_Fax");
		btnShowKeyboard_Fax.ForeColor = Color.White;
		btnShowKeyboard_Fax.Name = "btnShowKeyboard_Fax";
		btnShowKeyboard_Fax.UseVisualStyleBackColor = false;
		btnShowKeyboard_Fax.Click += btnShowKeyboard_Fax_Click;
		btnShowKeyboard_Phone.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Phone.DialogResult = DialogResult.OK;
		btnShowKeyboard_Phone.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Phone.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Phone, "btnShowKeyboard_Phone");
		btnShowKeyboard_Phone.ForeColor = Color.White;
		btnShowKeyboard_Phone.Name = "btnShowKeyboard_Phone";
		btnShowKeyboard_Phone.UseVisualStyleBackColor = false;
		btnShowKeyboard_Phone.Click += btnShowKeyboard_Phone_Click;
		btnShowKeyboard_City.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_City.DialogResult = DialogResult.OK;
		btnShowKeyboard_City.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_City.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_City, "btnShowKeyboard_City");
		btnShowKeyboard_City.ForeColor = Color.White;
		btnShowKeyboard_City.Name = "btnShowKeyboard_City";
		btnShowKeyboard_City.UseVisualStyleBackColor = false;
		btnShowKeyboard_City.Click += btnShowKeyboard_City_Click;
		btnShowKeyboard_Address.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Address.DialogResult = DialogResult.OK;
		btnShowKeyboard_Address.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Address.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Address, "btnShowKeyboard_Address");
		btnShowKeyboard_Address.ForeColor = Color.White;
		btnShowKeyboard_Address.Name = "btnShowKeyboard_Address";
		btnShowKeyboard_Address.UseVisualStyleBackColor = false;
		btnShowKeyboard_Address.Click += btnShowKeyboard_Address_Click;
		btnShowKeyboard_CompanyName.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_CompanyName.DialogResult = DialogResult.OK;
		btnShowKeyboard_CompanyName.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_CompanyName.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_CompanyName, "btnShowKeyboard_CompanyName");
		btnShowKeyboard_CompanyName.ForeColor = Color.White;
		btnShowKeyboard_CompanyName.Name = "btnShowKeyboard_CompanyName";
		btnShowKeyboard_CompanyName.UseVisualStyleBackColor = false;
		btnShowKeyboard_CompanyName.Click += btnShowKeyboard_CompanyName_Click;
		label8.BackColor = Color.FromArgb(132, 146, 146);
		label8.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label8, "label8");
		label8.ForeColor = Color.White;
		label8.Name = "label8";
		label10.BackColor = Color.FromArgb(132, 146, 146);
		label10.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label10, "label10");
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		label9.BackColor = Color.FromArgb(132, 146, 146);
		label9.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label9, "label9");
		label9.ForeColor = Color.White;
		label9.Name = "label9";
		label11.BackColor = Color.FromArgb(132, 146, 146);
		label11.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label11, "label11");
		label11.ForeColor = Color.White;
		label11.Name = "label11";
		label11.Click += label11_Click;
		label7.BackColor = Color.FromArgb(132, 146, 146);
		label7.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label7, "label7");
		label7.ForeColor = Color.White;
		label7.Name = "label7";
		componentResourceManager.ApplyResources(label6, "label6");
		label6.BackColor = Color.FromArgb(147, 101, 184);
		label6.ForeColor = Color.White;
		label6.Name = "label6";
		label15.BackColor = Color.FromArgb(132, 146, 146);
		label15.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label15, "label15");
		label15.ForeColor = Color.White;
		label15.Name = "label15";
		componentResourceManager.ApplyResources(chkPrintTaxNo, "chkPrintTaxNo");
		((Control)(object)chkPrintTaxNo).Name = "chkPrintTaxNo";
		((Control)(object)chkPrintTaxNo).Tag = "restaurant_capacity";
		chkPrintTaxNo.set_ThumbTickness(27);
		chkPrintTaxNo.set_ToggleStateMode((ToggleStateMode)1);
		chkPrintTaxNo.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkPrintTaxNo).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)chkPrintTaxNo).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkPrintTaxNo).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkPrintTaxNo).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkPrintTaxNo).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkPrintTaxNo).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkPrintTaxNo).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = SystemColors.Control;
		base.Controls.Add(panel1);
		base.Controls.Add(label6);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmAdminCompanySetup";
		base.Opacity = 1.0;
		base.Load += frmAdminCompanySetup_Load;
		panel1.ResumeLayout(performLayout: false);
		panel1.PerformLayout();
		((ISupportInitialize)txtCapacity).EndInit();
		((ISupportInitialize)txtTaxNo).EndInit();
		((ISupportInitialize)txtFax).EndInit();
		((ISupportInitialize)txtPhone).EndInit();
		((ISupportInitialize)txtZip).EndInit();
		((ISupportInitialize)txtCountry).EndInit();
		((ISupportInitialize)txtStateProv).EndInit();
		((ISupportInitialize)txtBusinessName).EndInit();
		((ISupportInitialize)txtCity).EndInit();
		((ISupportInitialize)txtAddress).EndInit();
		((ISupportInitialize)txtCompanyName).EndInit();
		((ISupportInitialize)chkPrintTaxNo).EndInit();
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private bool method_11(BusinessHour businessHour_0)
	{
		return businessHour_0.DayOfTheWeek.ToUpper() == lstDayOfWeek.SelectedItem.ToString().ToUpper();
	}

	[CompilerGenerated]
	private bool method_12(BusinessHour businessHour_0)
	{
		return businessHour_0.DayOfTheWeek == lstDayOfWeek.GetItemText(lstDayOfWeek.SelectedItem).ToLower();
	}

	[CompilerGenerated]
	private bool method_13(BusinessHour businessHour_0)
	{
		return businessHour_0.DayOfTheWeek.ToUpper() == lstDayOfWeek.SelectedItem.ToString().ToUpper();
	}
}
