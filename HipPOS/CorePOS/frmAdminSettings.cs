using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using CorePOS.AdminPanel;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;

namespace CorePOS;

public class frmAdminSettings : frmMasterForm
{
	private delegate Tk8D6ee0R8lyCSr3QN Delegate5<out Tk8D6ee0R8lyCSr3QN>();

	public class ImportCSVTypes
	{
		public const string Item = "Item";

		public const string Member = "Member";

		public ImportCSVTypes()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	private string string_0;

	private string string_1;

	private string string_2;

	private char char_0;

	private CultureInfo cultureInfo_0;

	private bool bool_0;

	private bool bool_1;

	private List<Item> list_2;

	private LoadingLabel loadingLabel_0;

	private List<string> list_3;

	private int int_0;

	private int int_1;

	private bool bool_2;

	private string string_3;

	private List<string> list_4;

	private IContainer icontainer_1;

	private Label lblTitle;

	private TabPage tabSettings;

	private TabPage tabTools;

	private Button btnExportCsv;

	private Button btnImportCsv;

	private Button btnManageCustomFields;

	private Button btnOpenDiscountResons;

	private System.Windows.Forms.Timer timer_0;

	private Button btnOpenRefundReasons;

	private Button btnOpenChangelog;

	private TabPage tabCompanySetup;

	private TabControl tabControl1;

	private Panel panel1;

	private Button btnMaintenance;

	private Button rUvFdMuDxdq;

	private Button btnUsefulTips;

	private Button btnZohoAssist;

	private Button btnOpenTaxChangeReasons;

	private Button btnImportMember;

	private Button btnExportMember;

	private Button btnSecurity;

	private Button btnImportItemOptions;

	private Button btnExportItemOptions;

	private Button btnInstructionExport;

	private Button btnInstructionImport;

	private Button btnManageTerminal;

	private Button btnOpenVoidReasons;

	private Button btnOpenPayoutReason;

	private Button btnManageItemCourse;

	public frmAdminSettings()
	{
		Class26.Ggkj0JxzN9YmC();
		string_2 = "";
		char_0 = Convert.ToChar(Thread.CurrentThread.CurrentCulture.TextInfo.ListSeparator.Substring(0, 1));
		cultureInfo_0 = Thread.CurrentThread.CurrentCulture;
		list_3 = new List<string>();
		int_0 = 1;
		int_1 = 1;
		string_3 = "Importing...";
		list_4 = new List<string>();
		base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this, 1.5f);
		if (!Thread.CurrentThread.CurrentCulture.Name.Equals("en-US"))
		{
			foreach (TabPage tabPage in tabControl1.TabPages)
			{
				tabPage.Width = tabPage.Text.Length * 20;
			}
		}
		frmAdminCompanySetup frmAdminCompanySetup2 = new frmAdminCompanySetup();
		frmAdminCompanySetup2.TopLevel = false;
		frmAdminCompanySetup2.FormBorderStyle = FormBorderStyle.None;
		frmAdminCompanySetup2.Dock = DockStyle.Fill;
		frmAdminCompanySetup2.Show();
		tabCompanySetup.Controls.Add(frmAdminCompanySetup2);
		frmSettings frmSettings2 = new frmSettings();
		frmSettings2.TopLevel = false;
		frmSettings2.FormBorderStyle = FormBorderStyle.None;
		frmSettings2.Dock = DockStyle.None;
		frmSettings2.Show();
		panel1.Dispose();
		tabSettings.Controls.Add(frmSettings2);
		if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			rUvFdMuDxdq.Visible = false;
		}
	}

	private void frmAdminSettings_Load(object sender, EventArgs e)
	{
	}

	private void method_3(object sender, EventArgs e)
	{
	}

	private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void tabTools_Click(object sender, EventArgs e)
	{
	}

	private bool method_4(string string_4, int[] int_2, Func<string[], bool> func_0)
	{
		list_3 = new List<string>();
		StreamReader streamReader;
		try
		{
			streamReader = new StreamReader(string_4);
		}
		catch
		{
			string_0 = Resources.Please_make_sure_that_the_file;
			string_1 = Resources.File_NOT_Found_File_is_locked;
			return false;
		}
		int_0 = 1;
		string text = streamReader.ReadLine();
		if (text.Length != 0 && Regex.Matches(text, "[a-zA-Z]").Count != 0)
		{
			while (true)
			{
				if (!streamReader.EndOfStream)
				{
					string[] array = streamReader.ReadLine().Split(char_0);
					if (array.Length >= int_2.Min())
					{
						if (array.Length > int_2.Max())
						{
							string[] array2 = new string[int_2.Max()];
							int num = 0;
							for (int i = 0; i < array.Length; i++)
							{
								if (!string.IsNullOrEmpty(array[i]))
								{
									if (array[i].Substring(0, 1) == "\"" && array[i].Substring(array[i].Length - 1, 1) != "\"")
									{
										for (int j = 1; j < array.Length - i; j++)
										{
											if (!string.IsNullOrEmpty(array[i + j]))
											{
												array[i] = array[i] + char_0 + " " + array[i + j].Trim();
												if (array[i + j].Substring(array[i + j].Length - 1, 1) == "\"")
												{
													array2[num] = array[i];
													num++;
													i += j;
													break;
												}
												array[i + j] = null;
											}
										}
									}
									else
									{
										array2[num] = array[i];
										num++;
									}
								}
								else
								{
									array2[num] = array[i];
									num++;
								}
							}
							if (array2.Length > int_2.Max())
							{
								string_0 = Resources.Please_make_sure_that_the_file0 + string.Join("|", array) + Resources._has_extra_comma_seperator_rem;
								string_1 = Resources.File_not_a_VALID_format0;
								streamReader.Close();
								return false;
							}
							array = array2;
						}
						if (!func_0(array))
						{
							break;
						}
						int_0++;
						continue;
					}
					string_0 = Resources.Please_make_sure_that_the_file0 + string.Join("|", array);
					string_1 = Resources.File_not_a_VALID_format0;
					streamReader.Close();
					return false;
				}
				streamReader.Close();
				return true;
			}
			streamReader.Close();
			return false;
		}
		string_0 = Resources.CSV_file_has_no_data;
		string_1 = Resources._ERROR0;
		return false;
	}

	private bool method_5(string[] string_4)
	{
		_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass19_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		GClass6 gClass = new GClass6();
		string[] restaurantHeader = ItemCSVHeader.RestaurantHeader;
		int num = ItemCSVHeader.RestaurantHeader.Length;
		CS_0024_003C_003E8__locals0.eName = "";
		CS_0024_003C_003E8__locals0.itemId = "";
		_003C_003Ec__DisplayClass19_1 CS_0024_003C_003E8__locals1;
		for (int i = 0; i < num; i++)
		{
			string text = restaurantHeader[i];
			string text2 = string_4[i];
			CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass19_1();
			switch (text)
			{
			case "Name":
				CS_0024_003C_003E8__locals0.eName = text2;
				if (string.IsNullOrEmpty(text2))
				{
					string_0 = Resources.Row + int_0 + Resources._has_no_item_name;
					string_1 = Resources.Row_not_valid;
					return false;
				}
				break;
			case "Item Classification":
			{
				string text3 = text2.ToLower();
				if (text3 != ItemClassifications.Product && text3 != ItemClassifications.Material && text3 != ItemClassifications.Option)
				{
					string_0 = Resources.Row + int_0 + " has invalid Item Classification.";
					string_1 = Resources.Row_not_valid;
					return false;
				}
				break;
			}
			case "ItemID":
			{
				CS_0024_003C_003E8__locals0.itemId = text2;
				if (int.TryParse(CS_0024_003C_003E8__locals0.itemId, out var _) || string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.itemId))
				{
					if ((string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.itemId) ? null : gClass.Items.Where((Item a) => a.ItemID == Convert.ToInt16(CS_0024_003C_003E8__locals0.itemId)).FirstOrDefault()) == null && !string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.itemId) && CS_0024_003C_003E8__locals0.itemId != "0")
					{
						string_0 = Resources.Row + int_0 + Resources._has_an_Item_ID_but_does_not_e;
						string_1 = Resources.Row_not_valid;
						return false;
					}
					break;
				}
				string_0 = Resources.Row + int_0 + Resources._has_an_invalid_ID_Please_inpu;
				string_1 = Resources.Row_not_valid;
				return false;
			}
			case "UOM":
				CS_0024_003C_003E8__locals1.eUOM = string_4[11].Replace("\"", string.Empty).ToUpper();
				if (gClass.UOMs.Where((UOM x) => x.Name.ToUpper() == CS_0024_003C_003E8__locals1.eUOM).FirstOrDefault() == null)
				{
					string_0 = "UOM: " + CS_0024_003C_003E8__locals1.eUOM + " does not exist.";
					string_1 = "INVALID UOM";
					return false;
				}
				break;
			case "Item Cost":
			case "Inventory Qty":
			case "Item Sale Price":
			case "Item Price":
			{
				if (!decimal.TryParse(text2.Replace("\"", string.Empty), out var _))
				{
					string_0 = Resources.Row + text2 + Resources._is_invalid_Please_make_sure_a;
					string_1 = Resources.Row_not_valid;
					return false;
				}
				break;
			}
			case "Button Color":
				if (string.IsNullOrEmpty(text2))
				{
					string_0 = Resources.Row + int_0 + " has no button color.";
					string_1 = Resources.Row_not_valid;
					return false;
				}
				break;
			}
		}
		if ((string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.itemId) || CS_0024_003C_003E8__locals0.itemId == "0") && list_2 != null)
		{
			CS_0024_003C_003E8__locals0.eName = method_7(CS_0024_003C_003E8__locals0.eName);
			Item item = list_2.Where((Item a) => a.ItemName.ToLower() == CS_0024_003C_003E8__locals0.eName.ToLower()).FirstOrDefault();
			if ((string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.itemId) || CS_0024_003C_003E8__locals0.itemId == "0") && item != null)
			{
				int num2 = 0;
				if (bool_0)
				{
					num2 = 1;
				}
				else
				{
					string_1 = Resources.Confirmation;
					string_0 = Resources.Item0 + item.ItemName + Resources._already_exists_in_the_databas;
					num2 = (int)Invoke((Delegate5<int>)(() => CS_0024_003C_003E8__locals0._003C_003E4__this.method_11(bool_3: true)));
					bool_1 = false;
				}
				if (num2 == 3)
				{
					bool_0 = true;
					num2 = 1;
				}
				switch (num2)
				{
				case 1:
					list_3.Add(item.ItemName);
					break;
				case 0:
					return false;
				}
			}
		}
		return true;
	}

	private void method_6(OpenFileDialog openFileDialog_0, int[] int_2, Action<StreamReader> action_0, Func<string[], bool> func_0)
	{
		string fileName = openFileDialog_0.FileName;
		string_3 = "Importing...";
		bool_2 = false;
		try
		{
			if (!method_4(fileName, int_2, func_0))
			{
				if (!string_1.Contains(Resources.Confirmation))
				{
					Invoke(new MethodInvoker(method_10));
				}
				return;
			}
		}
		catch (Exception error)
		{
			NotificationMethods.sendCrash(AppSettings.AppVersion, "", error);
			string_0 = "An error had occurred while attempting to read the file.";
			string_1 = "ERROR";
			Invoke(new MethodInvoker(method_10));
			return;
		}
		StreamReader streamReader;
		try
		{
			streamReader = new StreamReader(fileName);
		}
		catch
		{
			string_0 = Resources.Please_make_sure_that_the_file;
			string_1 = Resources.File_NOT_Found_File_is_locked;
			Invoke(new MethodInvoker(method_10));
			return;
		}
		streamReader.ReadLine();
		int_1 = 1;
		try
		{
			action_0(streamReader);
			streamReader.Close();
			MemoryLoadedObjects.ItemsAndGroupsStationsRefresh();
			MemoryLoadedData.ListOfItemsInGroupMemory = new GClass6().ItemsInGroups.Where((ItemsInGroup a) => a.Item.isDeleted == false && a.Item.Active == true).ToList();
		}
		catch (Exception error2)
		{
			NotificationMethods.sendCrash(AppSettings.AppVersion, "", error2);
			string_0 = "Something went wrong with the IMPORT";
			string_1 = "ERROR";
			Invoke(new MethodInvoker(method_10));
		}
	}

	private string method_7(string string_4)
	{
		if (string.IsNullOrEmpty(string_4))
		{
			return string_4;
		}
		if (string_4.Substring(0, 1).Equals("\"") && string_4.Substring(string_4.Length - 1, 1).Equals("\""))
		{
			string_4 = string_4.Remove(0, 1);
			string_4 = string_4.Remove(string_4.Length - 1, 1);
		}
		string_4 = string_4.Replace("\"\"", "\"");
		return string_4;
	}

	private string[] method_8(string[] string_4, int int_2)
	{
		if (string_4.Length < int_2 - 1)
		{
			string_0 = Resources.Please_make_sure_that_the_file0 + " " + int_1 + " " + string.Join("|", string_4);
			string_1 = Resources.File_not_a_VALID_format0;
			Invoke(new MethodInvoker(method_10));
			return null;
		}
		if (string_4.Length > int_2)
		{
			string[] array = new string[int_2];
			int num = 0;
			for (int i = 0; i < string_4.Length; i++)
			{
				if (!string.IsNullOrEmpty(string_4[i]))
				{
					if (string_4[i].Substring(0, 1) == "\"" && string_4[i].Substring(string_4[i].Length - 1, 1) != "\"")
					{
						for (int j = 1; j < string_4.Length - i; j++)
						{
							if (!string.IsNullOrEmpty(string_4[i + j]))
							{
								string_4[i] = string_4[i] + char_0 + " " + string_4[i + j].Trim();
								if (string_4[i + j].Substring(string_4[i + j].Length - 1, 1) == "\"")
								{
									array[num] = string_4[i];
									num++;
									i += j;
									break;
								}
								string_4[i + j] = null;
							}
						}
					}
					else
					{
						array[num] = string_4[i];
						num++;
					}
				}
				else
				{
					array[num] = string_4[i];
					num++;
				}
			}
			if (array.Length > int_2)
			{
				string_0 = Resources.Please_make_sure_that_the_file0 + string.Join("|", string_4) + Resources._has_extra_comma_seperator_rem;
				string_1 = Resources.File_not_a_VALID_format0;
				Invoke(new MethodInvoker(method_10));
				return null;
			}
			string_4 = array;
		}
		return string_4;
	}

	private void method_9(StreamReader streamReader_0)
	{
		GClass6 gClass = new GClass6();
		List<ItemType> source = gClass.ItemTypes.ToList();
		List<TaxRule> source2 = gClass.TaxRules.ToList();
		_003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals0;
		while (true)
		{
			if (!streamReader_0.EndOfStream)
			{
				CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass24_0();
				int_1++;
				string[] string_ = streamReader_0.ReadLine().Split(char_0);
				string[] restaurantHeader = ItemCSVHeader.RestaurantHeader;
				int num = ItemCSVHeader.RestaurantHeader.Length;
				string_ = method_8(string_, num);
				if (string_ == null)
				{
					return;
				}
				CS_0024_003C_003E8__locals0.itemId = "";
				CS_0024_003C_003E8__locals0.eBarcode = "";
				bool useSmartBarcode = false;
				CS_0024_003C_003E8__locals0.eName = "";
				string string_2 = "";
				string itemDescription = "";
				decimal itemCost = default(decimal);
				decimal itemPrice = default(decimal);
				decimal itemSalePrice = default(decimal);
				decimal inventoryQTY = default(decimal);
				bool trackInventory = true;
				CS_0024_003C_003E8__locals0.eUOM = "";
				CS_0024_003C_003E8__locals0.itemType = "";
				int itemTypeID = 1;
				CS_0024_003C_003E8__locals0.taxRule = "";
				int taxruleID = 9;
				string color = "";
				string string_3 = "";
				string string_4 = string.Empty;
				decimal num2 = default(decimal);
				decimal num3 = default(decimal);
				string text = string.Empty;
				string text2 = "";
				bool active = false;
				bool taxesIncluded = false;
				decimal reOrderLimit = -1m;
				decimal reOrderQty = default(decimal);
				bool redemptionLoyalty = false;
				bool flag = false;
				for (int j = 0; j < num; j++)
				{
					string text3 = restaurantHeader[j];
					string text4 = string_[j];
					switch (text3)
					{
					case "Name":
						CS_0024_003C_003E8__locals0.eName = text4;
						break;
					case "Item Classification":
						text2 = text4.ToLower();
						break;
					case "Group":
						string_3 = text4.Replace("\"\"", "\"");
						string_3 = string_3.Replace("\"", string.Empty);
						break;
					case "Inventory Qty":
						inventoryQTY = (string.IsNullOrEmpty(text4) ? 0m : decimal.Parse(text4));
						break;
					case "Is Deleted":
						flag = text4.ToLower() == "true";
						break;
					case "Min Free Options":
						num2 = (string.IsNullOrEmpty(text4) ? 0m : decimal.Parse(text4.Replace("\"", string.Empty)));
						break;
					case "Item Cost":
						itemCost = (string.IsNullOrEmpty(text4) ? 0m : decimal.Parse(text4.Replace("\"", string.Empty)));
						break;
					case "Item Type":
					{
						CS_0024_003C_003E8__locals0.itemType = text4;
						itemTypeID = 1;
						ItemType itemType = source.Where((ItemType a) => a.ItemTypeName.ToUpper() == CS_0024_003C_003E8__locals0.itemType.ToUpper()).FirstOrDefault();
						if (itemType != null)
						{
							itemTypeID = itemType.ItemTypeID;
						}
						break;
					}
					case "Long Name":
						string_2 = text4;
						break;
					case "ItemID":
						CS_0024_003C_003E8__locals0.itemId = text4;
						break;
					case "Re-Order Limit":
						reOrderLimit = (string.IsNullOrEmpty(text4) ? 0m : decimal.Parse(text4.Replace("\"", string.Empty)));
						break;
					case "Track Inventory":
						trackInventory = text4.ToLower() == "true";
						break;
					case "Item Sale Price":
						itemSalePrice = (string.IsNullOrEmpty(text4) ? 0m : decimal.Parse(text4.Replace("\"", string.Empty)));
						break;
					case "Tax Rule":
					{
						CS_0024_003C_003E8__locals0.taxRule = text4;
						taxruleID = 9;
						TaxRule taxRule = source2.Where((TaxRule a) => a.RuleName.ToUpper() == CS_0024_003C_003E8__locals0.taxRule.ToUpper()).FirstOrDefault();
						if (taxRule != null)
						{
							taxruleID = taxRule.TaxRuleId;
						}
						break;
					}
					case "Re-Order Qty":
						reOrderQty = (string.IsNullOrEmpty(text4) ? 0m : decimal.Parse(text4.Replace("\"", string.Empty)));
						break;
					case "Description":
						itemDescription = text4.Replace("\"\"", "\"");
						itemDescription = itemDescription.Replace("\"", string.Empty);
						break;
					case "Max Free Options":
						num3 = (string.IsNullOrEmpty(text4) ? 0m : decimal.Parse(text4.Replace("\"", string.Empty)));
						break;
					case "Is Active":
						active = text4.ToLower() == "true";
						break;
					case "Button Color":
						color = HelperMethods.ButtonColors()[text4];
						break;
					case "Parent Group":
						string_4 = text4.Replace("\"", string.Empty).Trim();
						break;
					case "Item Price":
						itemPrice = (string.IsNullOrEmpty(text4) ? 0m : decimal.Parse(text4.Replace("\"", string.Empty)));
						break;
					case "Barcode":
						CS_0024_003C_003E8__locals0.eBarcode = (string.IsNullOrEmpty(text4) ? text4 : text4.Replace("\"", string.Empty));
						break;
					case "UOM":
						CS_0024_003C_003E8__locals0.eUOM = text4.Replace("\"", string.Empty).ToUpper();
						break;
					case "Taxes Included":
						taxesIncluded = text4.ToLower() == "true";
						break;
					case "Use Smart Barcode":
						useSmartBarcode = text4.ToLower() == "true";
						break;
					case "Station":
						text = text4.Replace("\"", string.Empty).Trim();
						break;
					case "Loyalty Redemption":
						redemptionLoyalty = text4.ToLower() == "true";
						break;
					}
				}
				if (CS_0024_003C_003E8__locals0.eName == string.Empty)
				{
					continue;
				}
				CS_0024_003C_003E8__locals0.eName = method_7(CS_0024_003C_003E8__locals0.eName);
				string_2 = method_7(string_2);
				UOM uOM = gClass.UOMs.Where((UOM x) => x.Name.ToUpper() == CS_0024_003C_003E8__locals0.eUOM).FirstOrDefault();
				if (uOM == null)
				{
					break;
				}
				string stationIdsFromStationNames = StationMethods.GetStationIdsFromStationNames(text.Replace("\"", string.Empty));
				Item item = gClass.Items.Where((Item i) => i.ItemName == CS_0024_003C_003E8__locals0.eName).FirstOrDefault();
				if (item != null && list_3.Contains(item.ItemName))
				{
					if (flag)
					{
						AdminMethods.DeleteItem(gClass, item);
						continue;
					}
					AdminMethods.updateItem(item.ItemID, CS_0024_003C_003E8__locals0.eBarcode, CS_0024_003C_003E8__locals0.eName, itemCost, itemPrice, itemSalePrice, item.OnSale, item.StartDateOnSale, item.EndTimeOnSale, item.StartTimeOnSale, item.EndDateOnSale, item.DaysSaleList, itemTypeID, taxruleID, stationIdsFromStationNames, item.SortOrder, color, active, inventoryQTY, item.DisableSoldOutItems, uOM.UOMID, trackInventory, text2, itemDescription, item.Notes, item.ItemCourse, (int)num3, (int)num2, item.TrackExpiryDate, item.ApplySaleComboOption, 0, item.AutoResetQty, item.ResetQty, redemptionLoyalty, useSmartBarcode, item.AutoPromptOptions, item.BatchStockQty, taxesIncluded, reOrderLimit, reOrderQty, "Csv Import");
					method_15(item, string_3, string_4);
				}
				else
				{
					if (item != null && !list_3.Contains(item.ItemName) && string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.itemId))
					{
						continue;
					}
					Item item2 = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.itemId) ? null : gClass.Items.Where((Item i) => i.ItemID == Convert.ToInt16(CS_0024_003C_003E8__locals0.itemId)).FirstOrDefault());
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.eBarcode))
					{
						item2 = gClass.Items.Where((Item i) => i.Barcode == CS_0024_003C_003E8__locals0.eBarcode).FirstOrDefault();
					}
					if (item2 == null)
					{
						AdminMethods.addNewItem(CS_0024_003C_003E8__locals0.eBarcode, CS_0024_003C_003E8__locals0.eName, itemCost, itemPrice, itemSalePrice, onsale: false, null, null, null, null, "", itemTypeID, taxruleID, stationIdsFromStationNames, 1, color, active, inventoryQTY, disableIfSoldOut: false, uOM.UOMID, trackInventory, text2, itemDescription, "", ItemCourses.Uncategorized, (int)num3, (int)num2, TrackExpiry: false, ApplySaleComboOption: false, AutoResetQty: false, 0m, redemptionLoyalty, useSmartBarcode, AutoPromptOption: true, 1m, taxesIncluded, reOrderLimit, reOrderQty);
						item2 = gClass.Items.Where((Item i) => i.ItemName == CS_0024_003C_003E8__locals0.eName).FirstOrDefault();
						method_15(item2, string_3, string_4);
					}
					else if (!(item2.Barcode == CS_0024_003C_003E8__locals0.eBarcode) && !(item2.ItemName == CS_0024_003C_003E8__locals0.eName))
					{
						Console.WriteLine(Resources.Error_Barcode_and_name_does_no);
					}
					else if (flag)
					{
						AdminMethods.DeleteItem(gClass, item);
					}
					else
					{
						AdminMethods.updateItem(item2.ItemID, CS_0024_003C_003E8__locals0.eBarcode, CS_0024_003C_003E8__locals0.eName, itemCost, itemPrice, itemSalePrice, item2.OnSale, item2.StartDateOnSale, item2.EndDateOnSale, item2.StartTimeOnSale, item2.EndTimeOnSale, item2.DaysSaleList, itemTypeID, taxruleID, stationIdsFromStationNames, item2.SortOrder, color, active, inventoryQTY, item2.DisableSoldOutItems, uOM.UOMID, trackInventory, text2, itemDescription, item2.Notes, item2.ItemCourse, (int)num3, (int)num2, item2.TrackExpiryDate, item2.ApplySaleComboOption, 0, item2.AutoResetQty, item2.ResetQty, redemptionLoyalty, useSmartBarcode, item2.AutoPromptOptions, item2.BatchStockQty, taxesIncluded, reOrderLimit, reOrderQty, "Csv Import");
						method_15(item2, string_3, string_4);
					}
				}
				continue;
			}
			MemoryLoadedObjects.RefreshItemOptions = true;
			MemoryLoadedObjects.ItemsAndGroupsStationsRefresh();
			MemoryLoadedObjects.RefreshGeneralOEData();
			return;
		}
		string_0 = "UOM: " + CS_0024_003C_003E8__locals0.eUOM + " does not exist.";
		string_1 = "INVALID UOM";
	}

	private void method_10()
	{
		bool_2 = true;
		new frmMessageBox(string_0, string_1).ShowDialog(this);
	}

	private int method_11(bool bool_3 = false)
	{
		bool_1 = true;
		return new frmImportConfirmation(string_0, bool_3)
		{
			TopMost = true,
			TopLevel = true
		}.ShowDialog(this) switch
		{
			DialogResult.OK => 1, 
			DialogResult.Yes => 3, 
			DialogResult.Abort => 0, 
			_ => 2, 
		};
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		int num = Convert.ToInt32((float)int_1 / (float)int_0 * 100f);
		if ((bool_0 || bool_1) && num == 100)
		{
			num = 99;
		}
		loadingLabel_0.SetPercentage(num, string_3 + " (" + int_1 + "/" + int_0 + ")");
		if ((int_1 != 1 && int_1 >= int_0) || bool_2)
		{
			if (!bool_2)
			{
				loadingLabel_0.SetPercentage(100);
			}
			loadingLabel_0.EndLoading();
			timer_0.Enabled = false;
			int_1 = 1;
			int_0 = 1;
			if (!bool_2)
			{
				new NotificationLabel(this, string_2, NotificationTypes.Success).Show();
			}
		}
	}

	private void method_12()
	{
		loadingLabel_0 = new LoadingLabel(this);
		loadingLabel_0.StartLoading();
		timer_0.Enabled = true;
	}

	private void btnImportCsv_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass31_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass31_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.openCsv = new OpenFileDialog();
		string_2 = Resources.Items_Imported;
		if (CS_0024_003C_003E8__locals0.openCsv.ShowDialog(this) == DialogResult.OK)
		{
			GClass6 gClass = new GClass6();
			MemoryLoadedObjects.all_groups = gClass.Groups.Where((CorePOS.Data.Group a) => a.Archived == false).ToList();
			list_2 = gClass.Items.ToList();
			MemoryLoadedData.all_items = gClass.Items.Where((Item a) => a.isDeleted == false).ToList();
			bool_0 = false;
			new Thread((ThreadStart)delegate
			{
				CS_0024_003C_003E8__locals0._003C_003E4__this.method_6(CS_0024_003C_003E8__locals0.openCsv, new int[1] { ItemCSVHeader.RestaurantHeader.Length }, CS_0024_003C_003E8__locals0._003C_003E4__this.method_9, CS_0024_003C_003E8__locals0._003C_003E4__this.method_5);
			}).Start();
			method_12();
		}
	}

	private void method_13(Action<string> action_0, string string_4, string string_5)
	{
		bool_2 = false;
		string_3 = "Exporting...";
		if (string.IsNullOrWhiteSpace(string_4))
		{
			return;
		}
		string text = string_4 + "\\" + string_5;
		if (!File.Exists(text))
		{
			try
			{
				File.Create(text).Close();
			}
			catch
			{
				string_0 = Resources.Please_make_sure_that_the_path;
				string_1 = Resources.Path_not_found_Path_access_den;
				Invoke(new MethodInvoker(method_10));
				return;
			}
		}
		action_0(text);
	}

	private void method_14(string string_4)
	{
		GClass6 gClass = new GClass6();
		List<Item> list = (from a in gClass.Items
			where a.isDeleted == false
			orderby a.ItemName
			select a).ToList();
		if (list.Count == 0)
		{
			string_0 = "No Data to Export";
			string_1 = Resources.Error_exporting;
			Invoke(new MethodInvoker(method_10));
			return;
		}
		string_3 = "Exporting...";
		int_0 = list.Count;
		try
		{
			using TextWriter textWriter = File.CreateText(string_4);
			string[] restaurantHeader = ItemCSVHeader.RestaurantHeader;
			textWriter.WriteLine(string.Join(char_0.ToString(), restaurantHeader));
			int_1 = 1;
			using (List<Item>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass33_0();
					CS_0024_003C_003E8__locals1.item = enumerator.Current;
					string text = string.Empty;
					string text2 = string.Empty;
					if (CS_0024_003C_003E8__locals1.item.ItemsInGroups.Count() > 0)
					{
						List<ItemsInGroup> list2 = CS_0024_003C_003E8__locals1.item.ItemsInGroups.ToList();
						for (int i = 0; i < list2.Count; i++)
						{
							_003C_003Ec__DisplayClass33_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass33_1();
							text += ((i == 0) ? list2[i].Group.GroupName : ("|" + list2[i].Group.GroupName));
							CS_0024_003C_003E8__locals0.parentGroupId = list2[i].Group.ParentGroupID;
							if (CS_0024_003C_003E8__locals0.parentGroupId != 0)
							{
								CorePOS.Data.Group group = gClass.Groups.Where((CorePOS.Data.Group g) => g.GroupID == CS_0024_003C_003E8__locals0.parentGroupId).FirstOrDefault();
								if (group != null)
								{
									text2 = group.GroupName;
								}
							}
						}
					}
					string text3 = "\"" + (string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.item.ItemSalePrice.ToString()) ? "0" : CS_0024_003C_003E8__locals1.item.ItemSalePrice.ToString()) + "\"";
					string text4 = "\"" + (string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.item.ItemCost.ToString()) ? "0" : CS_0024_003C_003E8__locals1.item.ItemCost.ToString()) + "\"";
					string text5 = "\"" + (string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.item.ItemPrice.ToString()) ? "0" : CS_0024_003C_003E8__locals1.item.ItemPrice.ToString()) + "\"";
					string text6 = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.item.InventoryCount.ToString()) ? "0" : CS_0024_003C_003E8__locals1.item.InventoryCount.ToString());
					string text7 = "\"" + StationMethods.GetStationNamesFromStationIds(CS_0024_003C_003E8__locals1.item.StationID) + "\"";
					string text8 = ((CS_0024_003C_003E8__locals1.item.ItemsSuppliers.FirstOrDefault() != null) ? CS_0024_003C_003E8__locals1.item.ItemsSuppliers.FirstOrDefault().Supplier.Name : "");
					string text9 = "Gray";
					if ((from a in HelperMethods.ButtonColors()
						where a.Value == CS_0024_003C_003E8__locals1.item.ItemColor
						select a).Any())
					{
						text9 = (from a in HelperMethods.ButtonColors()
							where a.Value == CS_0024_003C_003E8__locals1.item.ItemColor
							select a).First().Key.ToString();
					}
					string[] value = new string[31]
					{
						CS_0024_003C_003E8__locals1.item.ItemID.ToString(),
						"\"" + CS_0024_003C_003E8__locals1.item.Barcode + "\"",
						CS_0024_003C_003E8__locals1.item.UseSmartBarcode.ToString(),
						"\"" + CS_0024_003C_003E8__locals1.item.ItemName + "\"",
						"\"" + CS_0024_003C_003E8__locals1.item.ItemLongName + "\"",
						"\"" + CS_0024_003C_003E8__locals1.item.Description + "\"",
						text4,
						text5,
						text3,
						text6,
						CS_0024_003C_003E8__locals1.item.TrackInventory.ToString(),
						CS_0024_003C_003E8__locals1.item.UOM.Name,
						"\"" + CS_0024_003C_003E8__locals1.item.ItemType.ItemTypeName + "\"",
						"\"" + CS_0024_003C_003E8__locals1.item.TaxRule.RuleName + "\"",
						text9,
						"\"" + text + "\"",
						"\"" + text2 + "\"",
						CS_0024_003C_003E8__locals1.item.MinFreeOptions.ToString(),
						CS_0024_003C_003E8__locals1.item.MaxFreeOptions.ToString(),
						text7,
						CS_0024_003C_003E8__locals1.item.ItemClassification,
						CS_0024_003C_003E8__locals1.item.Active.ToString(),
						CS_0024_003C_003E8__locals1.item.TaxesIncluded.ToString(),
						CS_0024_003C_003E8__locals1.item.ReOrderLimit.ToString(),
						CS_0024_003C_003E8__locals1.item.ReorderQty.ToString(),
						text8,
						"",
						"",
						"",
						CS_0024_003C_003E8__locals1.item.LoyaltyRedemption.ToString(),
						CS_0024_003C_003E8__locals1.item.isDeleted.ToString()
					};
					textWriter.WriteLine(string.Join(char_0.ToString(), value));
					int_1++;
				}
			}
			string_2 = Resources.Items_Exported;
			textWriter.Close();
			textWriter.Dispose();
		}
		catch (Exception ex)
		{
			string_0 = ex.Message;
			string_1 = Resources.Error_exporting;
			Invoke(new MethodInvoker(method_10));
		}
	}

	private void btnExportCsv_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass34_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass34_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.fbd = new FolderBrowserDialog();
		if (CS_0024_003C_003E8__locals0.fbd.ShowDialog(this) == DialogResult.OK)
		{
			new Thread((ThreadStart)delegate
			{
				CS_0024_003C_003E8__locals0._003C_003E4__this.method_13(CS_0024_003C_003E8__locals0._003C_003E4__this.method_14, CS_0024_003C_003E8__locals0.fbd.SelectedPath, "HipposExportedItems.csv");
			}).Start();
			method_12();
		}
	}

	private void method_15(Item item_0, string string_4, string string_5)
	{
		_003C_003Ec__DisplayClass35_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass35_0();
		CS_0024_003C_003E8__locals0.item = item_0;
		CS_0024_003C_003E8__locals0.eParentGroup = string_5;
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals0.GroupIdToNotDelete = new List<short>();
		if (!string.IsNullOrEmpty(string_4))
		{
			List<CorePOS.Data.Group> list = new List<CorePOS.Data.Group>();
			string[] array = string_4.Split('|');
			for (int j = 0; j < array.Length; j++)
			{
				_003C_003Ec__DisplayClass35_1 _003C_003Ec__DisplayClass35_ = new _003C_003Ec__DisplayClass35_1();
				_003C_003Ec__DisplayClass35_.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
				_003C_003Ec__DisplayClass35_.eGroup = array[j];
				_003C_003Ec__DisplayClass35_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass35_2();
				CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2 = _003C_003Ec__DisplayClass35_;
				list = AdminMethods.GetAllGroup(ItemClassifications.Product);
				CS_0024_003C_003E8__locals1.group = list.Where((CorePOS.Data.Group s) => s.GroupName == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.eGroup).FirstOrDefault();
				if (CS_0024_003C_003E8__locals1.group != null)
				{
					CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.GroupIdToNotDelete.Add(CS_0024_003C_003E8__locals1.group.GroupID);
					if (gClass.ItemsInGroups.Where((ItemsInGroup i) => (int?)i.GroupID == (int?)CS_0024_003C_003E8__locals1.group.GroupID && i.ItemID == (int?)CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.item.ItemID).FirstOrDefault() == null)
					{
						AdminMethods.addItemInGroup(CS_0024_003C_003E8__locals1.group.GroupID, CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.item.ItemID);
					}
					continue;
				}
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.eParentGroup))
				{
					AdminMethods.addNewGroup(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.eGroup, "150,166,166", highTraffic: false, isActive: true, 0, ItemClassifications.Product, 0, OEShow: true, PatronShow: true);
					list = AdminMethods.GetAllGroup(ItemClassifications.Product);
					CorePOS.Data.Group group = list.Where((CorePOS.Data.Group s) => s.GroupName == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.eGroup).FirstOrDefault();
					AdminMethods.addItemInGroup(group.GroupID, CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.item.ItemID);
					CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.GroupIdToNotDelete.Add(group.GroupID);
					continue;
				}
				CorePOS.Data.Group group2 = list.Where((CorePOS.Data.Group s) => s.GroupName == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.eParentGroup).FirstOrDefault();
				if (group2 == null)
				{
					AdminMethods.addNewGroup(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.eParentGroup, "150,166,166", highTraffic: false, isActive: true, 0, ItemClassifications.Product, 0, OEShow: true, PatronShow: true);
					list = AdminMethods.GetAllGroup(ItemClassifications.Product);
					CorePOS.Data.Group group3 = list.Where((CorePOS.Data.Group s) => s.GroupName == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.eParentGroup).FirstOrDefault();
					AdminMethods.addNewGroup(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.eGroup, "150,166,166", highTraffic: false, isActive: true, group3.GroupID, ItemClassifications.Product, 0, OEShow: true, PatronShow: true);
					list = AdminMethods.GetAllGroup(ItemClassifications.Product);
					CorePOS.Data.Group group4 = list.Where((CorePOS.Data.Group s) => s.GroupName == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.eGroup).FirstOrDefault();
					AdminMethods.addItemInGroup(group4.GroupID, CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.item.ItemID);
					CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.GroupIdToNotDelete.Add(group4.GroupID);
				}
				else
				{
					AdminMethods.addNewGroup(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.eGroup, "150,166,166", highTraffic: false, isActive: true, group2.GroupID, ItemClassifications.Product, 0, OEShow: true, PatronShow: true);
					list = AdminMethods.GetAllGroup(ItemClassifications.Product);
					CorePOS.Data.Group group5 = list.Where((CorePOS.Data.Group s) => s.GroupName == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.eGroup).FirstOrDefault();
					AdminMethods.addItemInGroup(group5.GroupID, CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.item.ItemID);
					CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.GroupIdToNotDelete.Add(group5.GroupID);
				}
			}
		}
		List<ItemsInGroup> list2 = gClass.ItemsInGroups.Where((ItemsInGroup i) => i.ItemID == (int?)CS_0024_003C_003E8__locals0.item.ItemID && !CS_0024_003C_003E8__locals0.GroupIdToNotDelete.Contains(i.GroupID.Value)).ToList();
		if (list2.Count > 0)
		{
			gClass.ItemsInGroups.DeleteAllOnSubmit(list2);
			Helper.SubmitChangesWithCatch(gClass);
		}
	}

	private void btnManageCustomFields_Click(object sender, EventArgs e)
	{
		new frmManageCustomField().ShowDialog(this);
	}

	private void method_16(object sender, EventArgs e)
	{
		new frmEditLayout().Show();
	}

	private void btnOpenDiscountResons_Click(object sender, EventArgs e)
	{
		new frmAddEditInstructions(ReasonTypes.discount).ShowDialog(this);
	}

	private void btnOpenRefundReasons_Click(object sender, EventArgs e)
	{
		new frmAddEditInstructions(ReasonTypes.refund).ShowDialog(this);
	}

	private void btnOpenChangelog_Click(object sender, EventArgs e)
	{
		string text = AppDomain.CurrentDomain.BaseDirectory + "\\changelog.txt";
		if (File.Exists(text))
		{
			Process.Start(text);
		}
		else
		{
			new frmMessageBox(Resources.Help_documentation_is_missing_, Resources.File_Missing_or_Corrupted).ShowDialog(this);
		}
	}

	private void method_17(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private void method_18(object sender, ScrollEventArgs e)
	{
	}

	private void btnMaintenance_Click(object sender, EventArgs e)
	{
		new frmMaintenance().ShowDialog(this);
	}

	private void UhkFcOjbpaB(object sender, EventArgs e)
	{
		new frmDataTranfer().ShowDialog(this);
	}

	private void btnUsefulTips_Click(object sender, EventArgs e)
	{
		new frmUsefulTips().Show(this);
	}

	private void btnZohoAssist_Click(object sender, EventArgs e)
	{
		new frmRemoteSession().ShowDialog(this);
	}

	private void btnOpenTaxChangeReasons_Click(object sender, EventArgs e)
	{
		new frmAddEditInstructions(ReasonTypes.tax_change).ShowDialog(this);
	}

	private void btnImportMember_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass48_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass48_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.openCsv = new OpenFileDialog();
		string_2 = Resources.Members_have_been_imported_suc;
		if (CS_0024_003C_003E8__locals0.openCsv.ShowDialog(this) == DialogResult.OK)
		{
			new Thread((ThreadStart)delegate
			{
				CS_0024_003C_003E8__locals0._003C_003E4__this.method_6(CS_0024_003C_003E8__locals0.openCsv, new int[1] { 7 }, CS_0024_003C_003E8__locals0._003C_003E4__this.method_20, CS_0024_003C_003E8__locals0._003C_003E4__this.method_19);
			}).Start();
			method_12();
		}
	}

	private bool method_19(string[] string_4)
	{
		_003C_003Ec__DisplayClass50_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass50_0();
		CS_0024_003C_003E8__locals0.values = string_4;
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		GClass6 gClass = new GClass6();
		if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.values[1]))
		{
			string_0 = Resources.Row + int_0 + Resources._has_no_member_name;
			string_1 = Resources.Row_not_valid;
			return false;
		}
		if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.values[2]) && string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.values[4]))
		{
			string_0 = Resources.Row + int_0 + Resources._is_missing_one_required_conta;
			string_1 = Resources.Row_not_valid;
			return false;
		}
		Regex regex = new Regex("^\\d{10}$");
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.values[2]) && !regex.Match(CS_0024_003C_003E8__locals0.values[2]).Success)
		{
			string_0 = Resources.Row + int_0 + Resources._Cell_phone_number_is_not_in_c;
			string_1 = Resources.Row_not_valid;
			return false;
		}
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.values[3]) && !regex.Match(CS_0024_003C_003E8__locals0.values[3]).Success)
		{
			string_0 = Resources.Row + int_0 + Resources._Home_phone_number_is_not_in_c;
			string_1 = Resources.Row_not_valid;
			return false;
		}
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.values[4]) && !Regex.IsMatch(CS_0024_003C_003E8__locals0.values[4], "\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z", RegexOptions.IgnoreCase))
		{
			string_0 = Resources.Row + int_0 + Resources._E_mail_address_is_not_in_corr;
			string_1 = Resources.Row_not_valid;
			return false;
		}
		Customer customer = gClass.Customers.Where((Customer a) => a.CustomerName == CS_0024_003C_003E8__locals0.values[1]).FirstOrDefault();
		if (customer != null && (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.values[0]) || CS_0024_003C_003E8__locals0.values[0] == "0"))
		{
			string_1 = Resources.Confirmation;
			string_0 = Resources.Member + customer.CustomerName + Resources._already_exists_in_the_databas;
			switch ((int)Invoke((Delegate5<int>)(() => CS_0024_003C_003E8__locals0._003C_003E4__this.method_11())))
			{
			case 1:
				list_4.Add(customer.CustomerName);
				break;
			case 0:
				return false;
			}
		}
		return true;
	}

	private void method_20(StreamReader streamReader_0)
	{
		GClass6 gClass = new GClass6();
		while (!streamReader_0.EndOfStream)
		{
			_003C_003Ec__DisplayClass51_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass51_0();
			int_1++;
			string[] string_ = streamReader_0.ReadLine().Split(',');
			string_ = method_8(string_, 7);
			if (string_ == null)
			{
				break;
			}
			CS_0024_003C_003E8__locals0.memId = string_[0];
			CS_0024_003C_003E8__locals0.memName = string_[1];
			string customerCell = string_[2];
			string customerHome = string_[3];
			string customerEmail = string_[4];
			string string_2 = string_[5];
			bool active = string_[6].ToLower() == "true";
			CS_0024_003C_003E8__locals0.memName = method_7(CS_0024_003C_003E8__locals0.memName);
			string_2 = method_7(string_2);
			Customer customer = gClass.Customers.Where((Customer a) => a.CustomerName == CS_0024_003C_003E8__locals0.memName).FirstOrDefault();
			if (customer != null && list_4.Contains(CS_0024_003C_003E8__locals0.memName))
			{
				customer.CustomerCell = customerCell;
				customer.CustomerHome = customerHome;
				customer.CustomerEmail = customerEmail;
				customer.Comments = string_2;
				customer.Active = active;
			}
			else
			{
				Customer customer2 = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.memId) ? null : gClass.Customers.Where((Customer i) => i.CustomerID == Convert.ToInt32(CS_0024_003C_003E8__locals0.memId)).FirstOrDefault());
				if (customer2 == null)
				{
					customer2 = new Customer();
					customer2.EmployeeID = 1;
					customer2.MemberNumber = "";
					customer2.DateCreated = DateTime.Now;
					gClass.Customers.InsertOnSubmit(customer2);
				}
				customer2.CustomerName = CS_0024_003C_003E8__locals0.memName;
				customer2.CustomerCell = customerCell;
				customer2.CustomerHome = customerHome;
				customer2.CustomerEmail = customerEmail;
				customer2.Comments = string_2;
				customer2.Active = active;
			}
			Helper.SubmitChangesWithCatch(gClass);
		}
	}

	private void method_21(string string_4)
	{
		List<Customer> list = new GClass6().Customers.ToList();
		if (list.Count == 0)
		{
			string_0 = "No Data to Export";
			string_1 = Resources.Error_exporting;
			Invoke(new MethodInvoker(method_10));
			return;
		}
		int_0 = list.Count;
		try
		{
			using TextWriter textWriter = File.CreateText(string_4);
			string[] value = new string[7] { "MemberID", "Name", "Cell Phone", "Home Phone", "Email", "Notes", "Active" };
			textWriter.WriteLine(string.Join(char_0.ToString(), value));
			int_1 = 1;
			foreach (Customer item in list)
			{
				string[] value2 = new string[7]
				{
					item.CustomerID.ToString(),
					item.CustomerName,
					item.CustomerCell,
					item.CustomerHome,
					item.CustomerEmail,
					item.Comments,
					item.Active.ToString()
				};
				textWriter.WriteLine(string.Join(char_0.ToString(), value2));
				int_1++;
			}
			string_2 = Resources.Members_have_been_exported;
			textWriter.Close();
			textWriter.Dispose();
		}
		catch (Exception ex)
		{
			string_0 = ex.Message;
			string_1 = Resources.Error_exporting;
			Invoke(new MethodInvoker(method_10));
		}
	}

	private void btnExportMember_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass53_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass53_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.fbd = new FolderBrowserDialog();
		if (CS_0024_003C_003E8__locals0.fbd.ShowDialog(this) == DialogResult.OK)
		{
			new Thread((ThreadStart)delegate
			{
				CS_0024_003C_003E8__locals0._003C_003E4__this.method_13(CS_0024_003C_003E8__locals0._003C_003E4__this.method_21, CS_0024_003C_003E8__locals0.fbd.SelectedPath, "HipposExportedMembers.csv");
			}).Start();
			method_12();
		}
	}

	private void btnSecurity_Click(object sender, EventArgs e)
	{
		new frmManageSecurity().Show(this);
	}

	private void btnImportItemOptions_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass55_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass55_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.openCsv = new OpenFileDialog();
		string_2 = "Item Options successfully imported.";
		if (CS_0024_003C_003E8__locals0.openCsv.ShowDialog(this) == DialogResult.OK)
		{
			GClass6 gClass = new GClass6();
			MemoryLoadedObjects.all_groups = gClass.Groups.ToList();
			MemoryLoadedData.all_items = gClass.Items.ToList();
			new Thread((ThreadStart)delegate
			{
				CS_0024_003C_003E8__locals0._003C_003E4__this.method_6(CS_0024_003C_003E8__locals0.openCsv, new int[1] { 19 }, CS_0024_003C_003E8__locals0._003C_003E4__this.method_23, CS_0024_003C_003E8__locals0._003C_003E4__this.method_22);
			}).Start();
			method_12();
		}
	}

	private bool method_22(string[] string_4)
	{
		_003C_003Ec__DisplayClass56_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass56_0();
		CS_0024_003C_003E8__locals0.values = string_4;
		new GClass6();
		if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.values[0]))
		{
			string_0 = Resources.Row + int_0 + " Main Item is missing.";
			string_1 = Resources.Row_not_valid;
			return false;
		}
		if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.values[1]))
		{
			string_0 = Resources.Row + int_0 + " Option Item is missing";
			string_1 = Resources.Row_not_valid;
			return false;
		}
		if (CS_0024_003C_003E8__locals0.values[3].ToLower() != "true" && CS_0024_003C_003E8__locals0.values[3].ToLower() != "false")
		{
			string_0 = Resources.Row + int_0 + " Allow Additional information missing, please add either true or false in this field.";
			string_1 = Resources.Row_not_valid;
			return false;
		}
		if (!decimal.TryParse(CS_0024_003C_003E8__locals0.values[4], out var _))
		{
			string_0 = Resources.Row + int_0 + " Price is missing or not in a correct Decimal format";
			string_1 = Resources.Row_not_valid;
			return false;
		}
		if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.values[7]))
		{
			string_0 = Resources.Row + int_0 + " Tab is missing";
			string_1 = Resources.Row_not_valid;
			return false;
		}
		if (MemoryLoadedData.all_items != null)
		{
			if (MemoryLoadedData.all_items.Where((Item a) => a.ItemName.ToUpper().Replace("\"", string.Empty) == CS_0024_003C_003E8__locals0.values[0].ToUpper().Replace("\"", string.Empty) && !a.isDeleted).FirstOrDefault() == null)
			{
				string_0 = Resources.Row + int_0 + " " + CS_0024_003C_003E8__locals0.values[0].ToUpper() + " Main Item does not exists in the database please check the spelling of the item.";
				string_1 = Resources.Row_not_valid;
				return false;
			}
			if (MemoryLoadedData.all_items.Where((Item a) => a.ItemName.ToUpper().Replace("\"", string.Empty) == CS_0024_003C_003E8__locals0.values[1].ToUpper().Replace("\"", string.Empty) && !a.isDeleted).FirstOrDefault() == null)
			{
				string_0 = Resources.Row + int_0 + " " + CS_0024_003C_003E8__locals0.values[1].ToUpper() + " Option Item does not exists in the database please check the spelling of the item.";
				string_1 = Resources.Row_not_valid;
				return false;
			}
		}
		return true;
	}

	private void method_23(StreamReader streamReader_0)
	{
		GClass6 gClass = new GClass6();
		short result = 0;
		List<Item> source = gClass.Items.Where((Item x) => x.isDeleted == false).ToList();
		List<ItemsWithOption> source2 = gClass.ItemsWithOptions.Where((ItemsWithOption a) => a.OptionID != null).ToList();
		List<ItemsWithOption> list = new List<ItemsWithOption>();
		List<CorePOS.Data.Group> source3 = gClass.Groups.ToList();
		List<Option> source4 = gClass.Options.ToList();
		while (!streamReader_0.EndOfStream)
		{
			_003C_003Ec__DisplayClass57_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass57_0();
			int_1++;
			string[] string_ = streamReader_0.ReadLine().Split(',');
			string_ = method_8(string_, 19);
			if (string_ == null)
			{
				break;
			}
			CS_0024_003C_003E8__locals0.MainItem = string_[0];
			CS_0024_003C_003E8__locals0.OptionItem = string_[1];
			string text = string_[2];
			bool flag = string_[3].ToLower() == "true";
			string value = string_[4];
			decimal num = MathHelper.FractionToDecimal(string_[5]);
			CS_0024_003C_003E8__locals0.GroupName = string_[6];
			CS_0024_003C_003E8__locals0.tab = string_[7];
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.tab))
			{
				CS_0024_003C_003E8__locals0.tab = CS_0024_003C_003E8__locals0.tab.ToUpper();
			}
			if (!short.TryParse(string_[9], out result))
			{
				result = 0;
			}
			string text2 = string_[8];
			string text3 = (string.IsNullOrEmpty(text2) ? HelperMethods.ButtonColors()["Gray"] : ((!string.IsNullOrEmpty(text2)) ? HelperMethods.ButtonColors()[text2.Replace("\"", string.Empty)] : HelperMethods.ButtonColors()["Gray"]));
			bool flag2 = string_[10].ToLower() == "true";
			short num2 = Convert.ToInt16(string_[11]);
			short num3 = Convert.ToInt16(string_[12]);
			bool flag3 = string_[13].ToLower() == "true";
			short num4 = Convert.ToInt16(string_[14]);
			CS_0024_003C_003E8__locals0.GroupDependencyName = string_[15];
			string text4 = ((!string.IsNullOrEmpty(string_[16])) ? string_[16].Replace("\"", string.Empty) : string_[16]);
			string text5 = ((!string.IsNullOrEmpty(string_[17])) ? string_[17].Replace("\"", string.Empty) : string_[17]);
			if (!string.IsNullOrEmpty(text5))
			{
				text5 = string.Join(",", (from p in text5.Split(',')
					select p.Trim()).ToList());
			}
			bool flag4 = string_[18].ToLower() == "true";
			CS_0024_003C_003E8__locals0.MainItem = method_7(CS_0024_003C_003E8__locals0.MainItem);
			CS_0024_003C_003E8__locals0.OptionItem = method_7(CS_0024_003C_003E8__locals0.OptionItem);
			CS_0024_003C_003E8__locals0.GroupName = method_7(CS_0024_003C_003E8__locals0.GroupName);
			CS_0024_003C_003E8__locals0.mItem = source.Where((Item a) => a.ItemName.ToUpper().Replace("\"", string.Empty) == CS_0024_003C_003E8__locals0.MainItem.ToUpper().Replace("\"", string.Empty) && !a.isDeleted).FirstOrDefault();
			CS_0024_003C_003E8__locals0.oItem = source.Where((Item a) => a.ItemName.ToUpper().Replace("\"", string.Empty) == CS_0024_003C_003E8__locals0.OptionItem.ToUpper().Replace("\"", string.Empty) && !a.isDeleted).FirstOrDefault();
			CS_0024_003C_003E8__locals0.groupId = 0;
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.GroupName))
			{
				CorePOS.Data.Group group = source3.Where((CorePOS.Data.Group a) => a.GroupName.Replace("\"", string.Empty) == CS_0024_003C_003E8__locals0.GroupName.Replace("\"", string.Empty) && !a.Archived && a.GroupClassification == ItemClassifications.Option).FirstOrDefault();
				if (group == null)
				{
					AdminMethods.addNewGroup(CS_0024_003C_003E8__locals0.GroupName, "150,166,166", highTraffic: false, isActive: true, 0, ItemClassifications.Option, 0, OEShow: true, PatronShow: true);
					gClass.Refresh(RefreshMode.OverwriteCurrentValues);
					source3 = gClass.Groups.ToList();
					group = source3.Where((CorePOS.Data.Group a) => a.GroupName == CS_0024_003C_003E8__locals0.GroupName && !a.Archived && a.GroupClassification == ItemClassifications.Option).FirstOrDefault();
					if (group == null)
					{
						throw new Exception("Unable to create new options group.");
					}
				}
				CS_0024_003C_003E8__locals0.groupId = group.GroupID;
			}
			CS_0024_003C_003E8__locals0.GroupDependencyId = 0;
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.GroupDependencyName))
			{
				CorePOS.Data.Group group2 = source3.Where((CorePOS.Data.Group a) => a.GroupName.Replace("\"", string.Empty) == CS_0024_003C_003E8__locals0.GroupDependencyName.Replace("\"", string.Empty) && !a.Archived && a.GroupClassification == ItemClassifications.Option).FirstOrDefault();
				if (group2 != null)
				{
					CS_0024_003C_003E8__locals0.GroupDependencyId = group2.GroupID;
				}
			}
			string text6 = "0";
			if (!string.IsNullOrEmpty(text4))
			{
				List<int> list2 = new List<int>();
				using (List<string>.Enumerator enumerator = text4.Split(',').ToList().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass57_1 _003C_003Ec__DisplayClass57_ = new _003C_003Ec__DisplayClass57_1();
						_003C_003Ec__DisplayClass57_.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
						_003C_003Ec__DisplayClass57_.optionName = enumerator.Current;
						_003C_003Ec__DisplayClass57_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass57_2();
						CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2 = _003C_003Ec__DisplayClass57_;
						List<Option> list3 = source4.Where((Option a) => a.Item.ItemName.ToUpper() == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.optionName.Replace("\"", string.Empty).Trim().ToUpper()).ToList();
						if (list3.Count == 0)
						{
							source4 = new GClass6().Options.ToList();
							list3 = source4.Where((Option a) => a.Item.ItemName.ToUpper() == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.optionName.Replace("\"", string.Empty).Trim().ToUpper()).ToList();
						}
						CS_0024_003C_003E8__locals1.optionIds = list3.Select((Option a) => a.OptionID).ToList();
						ItemsWithOption itemsWithOption = source2.Where((ItemsWithOption a) => a.ItemID == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.mItem.ItemID && a.GroupID == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.GroupDependencyId && CS_0024_003C_003E8__locals1.optionIds.Contains(a.OptionID.Value) && !a.ToBeDeleted).FirstOrDefault();
						if (itemsWithOption == null)
						{
							itemsWithOption = source2.Where((ItemsWithOption a) => a.ItemID == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.mItem.ItemID && CS_0024_003C_003E8__locals1.optionIds.Contains(a.OptionID.Value) && !a.ToBeDeleted).FirstOrDefault();
						}
						if (itemsWithOption == null)
						{
							itemsWithOption = source2.Where((ItemsWithOption a) => a.ItemID == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.mItem.ItemID && CS_0024_003C_003E8__locals1.optionIds.Contains(a.OptionID.Value)).FirstOrDefault();
						}
						if (itemsWithOption == null)
						{
							itemsWithOption = gClass.ItemsWithOptions.Where((ItemsWithOption a) => a.ItemID == (int?)CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.mItem.ItemID && CS_0024_003C_003E8__locals1.optionIds.Contains(a.OptionID.Value)).FirstOrDefault();
						}
						if (itemsWithOption != null)
						{
							list2.Add(itemsWithOption.ItemWithOptionID);
						}
					}
				}
				text6 = string.Join(",", list2);
			}
			if (CS_0024_003C_003E8__locals0.mItem == null || CS_0024_003C_003E8__locals0.oItem == null)
			{
				continue;
			}
			_003C_003Ec__DisplayClass57_3 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass57_3();
			CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3 = CS_0024_003C_003E8__locals0;
			CS_0024_003C_003E8__locals2.opt = gClass.Options.Where((Option a) => a.ItemID == (int?)CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.oItem.ItemID).FirstOrDefault();
			if (CS_0024_003C_003E8__locals2.opt == null)
			{
				if (!flag4)
				{
					list.Add(method_24(gClass, CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.mItem.ItemID, CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.oItem.ItemID, Convert.ToDecimal(value), flag, num, CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.groupId, CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.tab, text3, result, flag2, num2, num3, flag3, num4, text, CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.GroupDependencyId, text6, text5));
					gClass.Refresh(RefreshMode.OverwriteCurrentValues);
				}
				continue;
			}
			ItemsWithOption itemsWithOption2 = source2.Where((ItemsWithOption a) => a.ItemID == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.mItem.ItemID && a.OptionID == CS_0024_003C_003E8__locals2.opt.OptionID && a.Tab.ToUpper() == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.tab.ToUpper() && !a.ToBeDeleted && a.GroupID == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.groupId).FirstOrDefault();
			if (itemsWithOption2 == null)
			{
				itemsWithOption2 = source2.Where((ItemsWithOption a) => a.ItemID == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.mItem.ItemID && a.OptionID == CS_0024_003C_003E8__locals2.opt.OptionID && a.Tab.ToUpper() == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.tab.ToUpper() && a.GroupID == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.groupId).FirstOrDefault();
			}
			if (itemsWithOption2 != null)
			{
				itemsWithOption2.Notes = text;
				itemsWithOption2.Qty = Convert.ToDecimal(num);
				itemsWithOption2.Price = Convert.ToDecimal(value);
				itemsWithOption2.AllowAdditional = flag;
				itemsWithOption2.Color = text3;
				itemsWithOption2.SortOrder = result;
				itemsWithOption2.ExcludeFromFreeOption = flag2;
				itemsWithOption2.MinGroupOptions = num2;
				itemsWithOption2.MaxGroupOptions = num3;
				itemsWithOption2.Preselect = flag3;
				itemsWithOption2.GroupID = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.groupId;
				itemsWithOption2.MaxFreeOptionPerGroup = num4;
				itemsWithOption2.ToBeDeleted = flag4;
				itemsWithOption2.GroupDependency = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.GroupDependencyId;
				itemsWithOption2.OptionDependency = text6;
				itemsWithOption2.GroupOrderTypes = text5;
				itemsWithOption2.Synced = false;
				Helper.SubmitChangesWithCatch(gClass);
				gClass.Refresh(RefreshMode.OverwriteCurrentValues);
				continue;
			}
			itemsWithOption2 = list.Where((ItemsWithOption a) => a.ItemID == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.mItem.ItemID && a.OptionID == CS_0024_003C_003E8__locals2.opt.OptionID && a.Tab.ToUpper() == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.tab.ToUpper() && a.GroupID == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.groupId).FirstOrDefault();
			if (itemsWithOption2 != null)
			{
				itemsWithOption2.Notes = text;
				itemsWithOption2.Qty = Convert.ToDecimal(num);
				itemsWithOption2.Price = Convert.ToDecimal(value);
				itemsWithOption2.AllowAdditional = flag;
				itemsWithOption2.Color = text3;
				itemsWithOption2.SortOrder = result;
				itemsWithOption2.ExcludeFromFreeOption = flag2;
				itemsWithOption2.MinGroupOptions = num2;
				itemsWithOption2.MaxGroupOptions = num3;
				itemsWithOption2.Preselect = flag3;
				itemsWithOption2.GroupID = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.groupId;
				itemsWithOption2.MaxFreeOptionPerGroup = num4;
				itemsWithOption2.ToBeDeleted = flag4;
				itemsWithOption2.GroupDependency = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.GroupDependencyId;
				itemsWithOption2.OptionDependency = text6;
				itemsWithOption2.GroupOrderTypes = text5;
				itemsWithOption2.Synced = false;
				Helper.SubmitChangesWithCatch(gClass);
			}
			else if (!flag4)
			{
				list.Add(method_24(gClass, CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.mItem.ItemID, CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.oItem.ItemID, Convert.ToDecimal(value), flag, num, CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.groupId, CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.tab, text3, result, flag2, num2, num3, flag3, num4, text, CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.GroupDependencyId, text6, text5));
			}
		}
	}

	private ItemsWithOption method_24(GClass6 gclass6_0, int int_2, int int_3, decimal decimal_0, bool bool_3, decimal decimal_1, short short_0, string string_4, string string_5, short short_1, bool bool_4, short short_2, short short_3, bool bool_5, short short_4, string string_6, short short_5, string string_7, string string_8)
	{
		_003C_003Ec__DisplayClass58_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass58_0();
		CS_0024_003C_003E8__locals0.OptionItemId = int_3;
		CS_0024_003C_003E8__locals0.tab = string_4;
		Option option = gclass6_0.Options.Where((Option a) => a.ItemID == (int?)CS_0024_003C_003E8__locals0.OptionItemId).FirstOrDefault();
		if (option == null)
		{
			option = new Option
			{
				ItemID = CS_0024_003C_003E8__locals0.OptionItemId,
				Synced = false
			};
			gclass6_0.Options.InsertOnSubmit(option);
			Helper.SubmitChangesWithCatch(gclass6_0);
		}
		Reason reason = gclass6_0.Reasons.Where((Reason a) => a.ReasonType == ReasonTypes.option_tab && a.Value != null && a.Value.ToUpper() == CS_0024_003C_003E8__locals0.tab.ToUpper()).FirstOrDefault();
		if (reason == null)
		{
			reason = new Reason
			{
				ReasonType = ReasonTypes.option_tab,
				Value = CS_0024_003C_003E8__locals0.tab.ToUpper(),
				isDefault = false,
				Synced = false,
				SortOrder = 0
			};
			gclass6_0.Reasons.InsertOnSubmit(reason);
			Helper.SubmitChangesWithCatch(gclass6_0);
		}
		ItemsWithOption itemsWithOption = new ItemsWithOption
		{
			Notes = string_6,
			AllowAdditional = bool_3,
			ItemID = int_2,
			OptionID = option.OptionID,
			Price = decimal_0,
			Synced = false,
			Qty = decimal_1,
			GroupID = short_0,
			Tab = CS_0024_003C_003E8__locals0.tab,
			Color = string_5,
			SortOrder = short_1,
			ExcludeFromFreeOption = bool_4,
			Preselect = bool_5,
			GroupOrderTypes = string_8,
			MaxGroupOptions = short_3,
			MinGroupOptions = short_2,
			OptionDependency = string_7,
			MaxFreeOptionPerGroup = short_4,
			GroupDependency = short_5
		};
		gclass6_0.ItemsWithOptions.InsertOnSubmit(itemsWithOption);
		Helper.SubmitChangesWithCatch(gclass6_0);
		return itemsWithOption;
	}

	private void method_25(string string_4)
	{
		GClass6 gClass = new GClass6();
		List<ItemsWithOption> list = gClass.ItemsWithOptions.Where((ItemsWithOption a) => a.ToBeDeleted == false).ToList();
		if (list.Count == 0)
		{
			string_0 = "No Data to Export";
			string_1 = Resources.Error_exporting;
			Invoke(new MethodInvoker(method_10));
			return;
		}
		string_3 = "Exporting...";
		int_1 = 1;
		int_0 = list.Count;
		try
		{
			using TextWriter textWriter = File.CreateText(string_4);
			string[] value = new string[19]
			{
				"Main Item", "Option Item", "Notes", "Allow Additional", "Price", "Qty", "Group Name", "Tab", "Color", "Sort Order",
				"Exclude From Free Item", "Min Group Opt", "Max Group Opt", "Pre-selected", "Max FREE Opt per Group", "Group Dependency", "Option Dependency", "GroupOrderTypes", "Is Deleted"
			};
			textWriter.WriteLine(string.Join(char_0.ToString(), value));
			List<Item> source = gClass.Items.Where((Item a) => a.isDeleted == false && a.Active == true).ToList();
			List<Option> source2 = gClass.Options.ToList();
			List<CorePOS.Data.Group> source3 = gClass.Groups.Where((CorePOS.Data.Group a) => a.Archived == false).ToList();
			using (List<ItemsWithOption>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass59_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass59_0();
					CS_0024_003C_003E8__locals4.itemsWithOption = enumerator.Current;
					_003C_003Ec__DisplayClass59_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass59_1();
					Item item = source.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals4.itemsWithOption.ItemID && !a.isDeleted).FirstOrDefault();
					CS_0024_003C_003E8__locals0.opt = source2.Where((Option a) => a.OptionID == CS_0024_003C_003E8__locals4.itemsWithOption.OptionID).FirstOrDefault();
					if (CS_0024_003C_003E8__locals0.opt != null)
					{
						Item item2 = source.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals0.opt.ItemID && !a.isDeleted).FirstOrDefault();
						string text = "";
						CorePOS.Data.Group group = source3.Where((CorePOS.Data.Group a) => a.GroupID == CS_0024_003C_003E8__locals4.itemsWithOption.GroupID && !a.Archived).FirstOrDefault();
						if (group != null)
						{
							text = group.GroupName;
						}
						if (item != null && item2 != null)
						{
							_003C_003Ec__DisplayClass59_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass59_2();
							CS_0024_003C_003E8__locals1.string_0 = CS_0024_003C_003E8__locals4.itemsWithOption.Color;
							string text2;
							if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.string_0))
							{
								text2 = (from x in HelperMethods.ButtonColors()
									where x.Value.Replace(" ", string.Empty) == CS_0024_003C_003E8__locals1.string_0.Replace(" ", string.Empty)
									select x).FirstOrDefault().Key.ToString();
								if (string.IsNullOrEmpty(text2))
								{
									text2 = "Gray";
								}
							}
							else
							{
								text2 = "Gray";
							}
							string text3 = "";
							if (CS_0024_003C_003E8__locals4.itemsWithOption.GroupDependency > 0)
							{
								CorePOS.Data.Group group2 = source3.Where((CorePOS.Data.Group a) => a.GroupID == CS_0024_003C_003E8__locals4.itemsWithOption.GroupDependency && !a.Archived).FirstOrDefault();
								if (group2 != null)
								{
									text3 = group2.GroupName;
								}
							}
							string text4 = "";
							if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals4.itemsWithOption.OptionDependency))
							{
								_003C_003Ec__DisplayClass59_3 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass59_3();
								List<string> list2 = new List<string>();
								CS_0024_003C_003E8__locals2.itemsWithOptionIdDependency = (from a in CS_0024_003C_003E8__locals4.itemsWithOption.OptionDependency.Split(',')
									select Convert.ToInt32(a)).ToList();
								using (List<ItemsWithOption>.Enumerator enumerator2 = list.Where((ItemsWithOption a) => CS_0024_003C_003E8__locals2.itemsWithOptionIdDependency.Contains(a.ItemWithOptionID)).ToList().GetEnumerator())
								{
									while (enumerator2.MoveNext())
									{
										_003C_003Ec__DisplayClass59_4 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass59_4();
										CS_0024_003C_003E8__locals3.iwo = enumerator2.Current;
										Option option = source2.Where((Option a) => a.OptionID == CS_0024_003C_003E8__locals3.iwo.OptionID).FirstOrDefault();
										if (option != null)
										{
											list2.Add(option.Item.ItemName);
										}
									}
								}
								text4 = string.Join(",", list2);
							}
							string[] value2 = new string[19]
							{
								"\"" + item.ItemName + "\"",
								"\"" + item2.ItemName + "\"",
								"\"" + CS_0024_003C_003E8__locals4.itemsWithOption.Notes + "\"",
								CS_0024_003C_003E8__locals4.itemsWithOption.AllowAdditional ? "true" : "false",
								CS_0024_003C_003E8__locals4.itemsWithOption.Price.ToString("0.00"),
								CS_0024_003C_003E8__locals4.itemsWithOption.Qty.ToString(),
								"\"" + text + "\"",
								CS_0024_003C_003E8__locals4.itemsWithOption.Tab,
								"\"" + text2 + "\"",
								CS_0024_003C_003E8__locals4.itemsWithOption.SortOrder.ToString(),
								CS_0024_003C_003E8__locals4.itemsWithOption.ExcludeFromFreeOption ? "true" : "false",
								CS_0024_003C_003E8__locals4.itemsWithOption.MinGroupOptions.ToString(),
								CS_0024_003C_003E8__locals4.itemsWithOption.MaxGroupOptions.ToString(),
								CS_0024_003C_003E8__locals4.itemsWithOption.Preselect ? "true" : "false",
								CS_0024_003C_003E8__locals4.itemsWithOption.MaxFreeOptionPerGroup.ToString(),
								"\"" + text3 + "\"",
								"\"" + text4 + "\"",
								"\"" + CS_0024_003C_003E8__locals4.itemsWithOption.GroupOrderTypes + "\"",
								CS_0024_003C_003E8__locals4.itemsWithOption.ToBeDeleted.ToString()
							};
							textWriter.WriteLine(string.Join(char_0.ToString(), value2));
						}
					}
					int_1++;
				}
			}
			string_2 = "Item Option Exported.";
			textWriter.Close();
			textWriter.Dispose();
		}
		catch (Exception ex)
		{
			string_0 = ex.Message;
			string_1 = Resources.Error_exporting;
			Invoke(new MethodInvoker(method_10));
		}
	}

	private void btnExportItemOptions_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass60_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass60_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.fbd = new FolderBrowserDialog();
		string_2 = "Item Options have been exported.";
		if (CS_0024_003C_003E8__locals0.fbd.ShowDialog(this) == DialogResult.OK)
		{
			new Thread((ThreadStart)delegate
			{
				CS_0024_003C_003E8__locals0._003C_003E4__this.method_13(CS_0024_003C_003E8__locals0._003C_003E4__this.method_25, CS_0024_003C_003E8__locals0.fbd.SelectedPath, "HipposExportedItemOptions.csv");
			}).Start();
			method_12();
		}
	}

	private void btnInstructionImport_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass61_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass61_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.openCsv = new OpenFileDialog();
		string_2 = "Instructions successfully imported.";
		if (CS_0024_003C_003E8__locals0.openCsv.ShowDialog(this) == DialogResult.OK)
		{
			new Thread((ThreadStart)delegate
			{
				CS_0024_003C_003E8__locals0._003C_003E4__this.method_6(CS_0024_003C_003E8__locals0.openCsv, new int[1] { 3 }, CS_0024_003C_003E8__locals0._003C_003E4__this.method_27, CS_0024_003C_003E8__locals0._003C_003E4__this.method_26);
			}).Start();
			method_12();
		}
	}

	private bool method_26(string[] string_4)
	{
		new GClass6();
		if (!string.IsNullOrEmpty(string_4[0]) && !int.TryParse(string_4[0], out var _))
		{
			string_0 = Resources.Row + int_0 + " ID should be in while number format, or empty or zero for new instructions.";
			string_1 = Resources.Row_not_valid;
			return false;
		}
		if (string.IsNullOrEmpty(string_4[1]))
		{
			string_0 = Resources.Row + int_0 + " Instruction is missing.";
			string_1 = Resources.Row_not_valid;
			return false;
		}
		return true;
	}

	private void method_27(StreamReader streamReader_0)
	{
		GClass6 gClass = new GClass6();
		while (!streamReader_0.EndOfStream)
		{
			_003C_003Ec__DisplayClass63_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass63_0();
			int_1++;
			string[] string_ = streamReader_0.ReadLine().Split(',');
			string_ = method_8(string_, 3);
			if (string_ != null)
			{
				CS_0024_003C_003E8__locals0.id = string_[0];
				string string_2 = string_[1];
				string text = string_[2];
				int stationID = 0;
				if (text.ToUpper() == "KITCHEN")
				{
					stationID = 1;
				}
				else if (text.ToUpper() == "BAR")
				{
					stationID = 2;
				}
				else if (text.ToUpper() == "BUFFET")
				{
					stationID = 3;
				}
				string_2 = method_7(string_2);
				text = method_7(text);
				SpecialInstruction specialInstruction = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.id) ? null : gClass.SpecialInstructions.Where((SpecialInstruction a) => a.SpecialInstructionID == Convert.ToInt32(CS_0024_003C_003E8__locals0.id)).FirstOrDefault());
				if (specialInstruction != null)
				{
					specialInstruction.Instruction = string_2;
					specialInstruction.StationID = stationID;
				}
				else
				{
					SpecialInstruction entity = new SpecialInstruction
					{
						Instruction = string_2,
						StationID = stationID
					};
					gClass.SpecialInstructions.InsertOnSubmit(entity);
				}
				Helper.SubmitChangesWithCatch(gClass);
				continue;
			}
			break;
		}
	}

	private void method_28(string string_4)
	{
		List<SpecialInstruction> list = new GClass6().SpecialInstructions.ToList();
		if (list.Count == 0)
		{
			string_0 = "No Data to Export";
			string_1 = Resources.Error_exporting;
			Invoke(new MethodInvoker(method_10));
			return;
		}
		int_0 = list.Count;
		try
		{
			using TextWriter textWriter = File.CreateText(string_4);
			string[] value = new string[3] { "Id", "Instructions", "Station" };
			textWriter.WriteLine(string.Join(char_0.ToString(), value));
			int_1 = 1;
			foreach (SpecialInstruction item in list)
			{
				string text = "ALL";
				if (item.StationID == 1)
				{
					text = "KITCHEN";
				}
				else if (item.StationID == 2)
				{
					text = "BAR";
				}
				else if (item.StationID == 3)
				{
					text = "BUFFET";
				}
				string[] value2 = new string[3]
				{
					item.SpecialInstructionID.ToString(),
					"\"" + item.Instruction + "\"",
					text
				};
				textWriter.WriteLine(string.Join(char_0.ToString(), value2));
				int_1++;
			}
			string_2 = "Instructions have been Exported.";
			textWriter.Close();
			textWriter.Dispose();
		}
		catch (Exception ex)
		{
			string_0 = ex.Message;
			string_1 = Resources.Error_exporting;
			Invoke(new MethodInvoker(method_10));
		}
	}

	private void btnInstructionExport_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass65_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass65_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.fbd = new FolderBrowserDialog();
		if (CS_0024_003C_003E8__locals0.fbd.ShowDialog(this) == DialogResult.OK)
		{
			new Thread((ThreadStart)delegate
			{
				CS_0024_003C_003E8__locals0._003C_003E4__this.method_13(CS_0024_003C_003E8__locals0._003C_003E4__this.method_28, CS_0024_003C_003E8__locals0.fbd.SelectedPath, "HipposExportedInstructions.csv");
			}).Start();
			method_12();
		}
	}

	private void btnManageTerminal_Click(object sender, EventArgs e)
	{
		new frmManageTerminalSettings().Show(this);
	}

	private void VovFdvepuNI(object sender, EventArgs e)
	{
		new frmAddEditInstructions(ReasonTypes.voidreason).ShowDialog(this);
	}

	private void btnOpenPayoutReason_Click(object sender, EventArgs e)
	{
		new frmAddEditInstructions(ReasonTypes.payout).ShowDialog(this);
	}

	private void btnManageItemCourse_Click(object sender, EventArgs e)
	{
		new frmManageItemCourses().ShowDialog();
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
		icontainer_1 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmAdminSettings));
		timer_0 = new System.Windows.Forms.Timer(icontainer_1);
		tabControl1 = new TabControl();
		tabTools = new TabPage();
		btnOpenPayoutReason = new Button();
		btnOpenVoidReasons = new Button();
		btnManageTerminal = new Button();
		btnInstructionExport = new Button();
		btnInstructionImport = new Button();
		btnImportItemOptions = new Button();
		btnExportItemOptions = new Button();
		btnSecurity = new Button();
		btnExportMember = new Button();
		btnImportMember = new Button();
		btnOpenTaxChangeReasons = new Button();
		btnZohoAssist = new Button();
		btnUsefulTips = new Button();
		rUvFdMuDxdq = new Button();
		btnMaintenance = new Button();
		btnOpenChangelog = new Button();
		btnOpenRefundReasons = new Button();
		btnOpenDiscountResons = new Button();
		btnManageCustomFields = new Button();
		btnExportCsv = new Button();
		btnImportCsv = new Button();
		tabSettings = new TabPage();
		panel1 = new Panel();
		tabCompanySetup = new TabPage();
		lblTitle = new Label();
		btnManageItemCourse = new Button();
		tabControl1.SuspendLayout();
		tabTools.SuspendLayout();
		tabSettings.SuspendLayout();
		SuspendLayout();
		timer_0.Interval = 200;
		timer_0.Tick += timer_0_Tick;
		componentResourceManager.ApplyResources(tabControl1, "tabControl1");
		tabControl1.Controls.Add(tabTools);
		tabControl1.Controls.Add(tabSettings);
		tabControl1.Controls.Add(tabCompanySetup);
		tabControl1.Name = "tabControl1";
		tabControl1.SelectedIndex = 0;
		tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
		tabTools.BackColor = Color.Transparent;
		tabTools.Controls.Add(btnManageItemCourse);
		tabTools.Controls.Add(btnOpenPayoutReason);
		tabTools.Controls.Add(btnOpenVoidReasons);
		tabTools.Controls.Add(btnManageTerminal);
		tabTools.Controls.Add(btnInstructionExport);
		tabTools.Controls.Add(btnInstructionImport);
		tabTools.Controls.Add(btnImportItemOptions);
		tabTools.Controls.Add(btnExportItemOptions);
		tabTools.Controls.Add(btnSecurity);
		tabTools.Controls.Add(btnExportMember);
		tabTools.Controls.Add(btnImportMember);
		tabTools.Controls.Add(btnOpenTaxChangeReasons);
		tabTools.Controls.Add(btnZohoAssist);
		tabTools.Controls.Add(btnUsefulTips);
		tabTools.Controls.Add(rUvFdMuDxdq);
		tabTools.Controls.Add(btnMaintenance);
		tabTools.Controls.Add(btnOpenChangelog);
		tabTools.Controls.Add(btnOpenRefundReasons);
		tabTools.Controls.Add(btnOpenDiscountResons);
		tabTools.Controls.Add(btnManageCustomFields);
		tabTools.Controls.Add(btnExportCsv);
		tabTools.Controls.Add(btnImportCsv);
		componentResourceManager.ApplyResources(tabTools, "tabTools");
		tabTools.Name = "tabTools";
		tabTools.Click += tabTools_Click;
		btnOpenPayoutReason.BackColor = Color.FromArgb(0, 145, 196);
		componentResourceManager.ApplyResources(btnOpenPayoutReason, "btnOpenPayoutReason");
		btnOpenPayoutReason.ForeColor = SystemColors.Control;
		btnOpenPayoutReason.Name = "btnOpenPayoutReason";
		btnOpenPayoutReason.UseVisualStyleBackColor = false;
		btnOpenPayoutReason.Click += btnOpenPayoutReason_Click;
		btnOpenVoidReasons.BackColor = Color.FromArgb(0, 145, 196);
		btnOpenVoidReasons.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnOpenVoidReasons, "btnOpenVoidReasons");
		btnOpenVoidReasons.ForeColor = SystemColors.Control;
		btnOpenVoidReasons.Name = "btnOpenVoidReasons";
		btnOpenVoidReasons.UseVisualStyleBackColor = false;
		btnOpenVoidReasons.Click += VovFdvepuNI;
		btnManageTerminal.BackColor = Color.FromArgb(0, 210, 95);
		btnManageTerminal.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnManageTerminal, "btnManageTerminal");
		btnManageTerminal.ForeColor = SystemColors.Control;
		btnManageTerminal.Name = "btnManageTerminal";
		btnManageTerminal.UseVisualStyleBackColor = false;
		btnManageTerminal.Click += btnManageTerminal_Click;
		btnInstructionExport.BackColor = Color.FromArgb(120, 182, 78);
		btnInstructionExport.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnInstructionExport, "btnInstructionExport");
		btnInstructionExport.ForeColor = SystemColors.Control;
		btnInstructionExport.Name = "btnInstructionExport";
		btnInstructionExport.UseVisualStyleBackColor = false;
		btnInstructionExport.Click += btnInstructionExport_Click;
		btnInstructionImport.BackColor = Color.FromArgb(120, 182, 78);
		btnInstructionImport.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnInstructionImport, "btnInstructionImport");
		btnInstructionImport.ForeColor = SystemColors.Control;
		btnInstructionImport.Name = "btnInstructionImport";
		btnInstructionImport.UseVisualStyleBackColor = false;
		btnInstructionImport.Click += btnInstructionImport_Click;
		btnImportItemOptions.BackColor = Color.FromArgb(103, 140, 207);
		btnImportItemOptions.FlatAppearance.BorderColor = Color.White;
		btnImportItemOptions.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnImportItemOptions, "btnImportItemOptions");
		btnImportItemOptions.ForeColor = SystemColors.Control;
		btnImportItemOptions.Name = "btnImportItemOptions";
		btnImportItemOptions.UseVisualStyleBackColor = false;
		btnImportItemOptions.Click += btnImportItemOptions_Click;
		btnExportItemOptions.BackColor = Color.FromArgb(103, 140, 207);
		btnExportItemOptions.FlatAppearance.BorderColor = Color.White;
		btnExportItemOptions.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnExportItemOptions, "btnExportItemOptions");
		btnExportItemOptions.ForeColor = SystemColors.Control;
		btnExportItemOptions.Name = "btnExportItemOptions";
		btnExportItemOptions.UseVisualStyleBackColor = false;
		btnExportItemOptions.Click += btnExportItemOptions_Click;
		btnSecurity.BackColor = Color.FromArgb(0, 210, 95);
		btnSecurity.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnSecurity, "btnSecurity");
		btnSecurity.ForeColor = SystemColors.Control;
		btnSecurity.Name = "btnSecurity";
		btnSecurity.UseVisualStyleBackColor = false;
		btnSecurity.Click += btnSecurity_Click;
		btnExportMember.BackColor = Color.FromArgb(240, 148, 86);
		btnExportMember.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnExportMember, "btnExportMember");
		btnExportMember.ForeColor = SystemColors.Control;
		btnExportMember.Name = "btnExportMember";
		btnExportMember.UseVisualStyleBackColor = false;
		btnExportMember.Click += btnExportMember_Click;
		btnImportMember.BackColor = Color.FromArgb(240, 148, 86);
		btnImportMember.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnImportMember, "btnImportMember");
		btnImportMember.ForeColor = SystemColors.Control;
		btnImportMember.Name = "btnImportMember";
		btnImportMember.UseVisualStyleBackColor = false;
		btnImportMember.Click += btnImportMember_Click;
		btnOpenTaxChangeReasons.BackColor = Color.FromArgb(0, 145, 196);
		btnOpenTaxChangeReasons.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnOpenTaxChangeReasons, "btnOpenTaxChangeReasons");
		btnOpenTaxChangeReasons.ForeColor = SystemColors.Control;
		btnOpenTaxChangeReasons.Name = "btnOpenTaxChangeReasons";
		btnOpenTaxChangeReasons.UseVisualStyleBackColor = false;
		btnOpenTaxChangeReasons.Click += btnOpenTaxChangeReasons_Click;
		btnZohoAssist.BackColor = Color.FromArgb(255, 75, 75);
		btnZohoAssist.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnZohoAssist, "btnZohoAssist");
		btnZohoAssist.ForeColor = SystemColors.Control;
		btnZohoAssist.Name = "btnZohoAssist";
		btnZohoAssist.UseVisualStyleBackColor = false;
		btnZohoAssist.Click += btnZohoAssist_Click;
		btnUsefulTips.BackColor = Color.FromArgb(145, 72, 200);
		btnUsefulTips.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnUsefulTips, "btnUsefulTips");
		btnUsefulTips.ForeColor = SystemColors.Control;
		btnUsefulTips.Name = "btnUsefulTips";
		btnUsefulTips.UseVisualStyleBackColor = false;
		btnUsefulTips.Click += btnUsefulTips_Click;
		rUvFdMuDxdq.BackColor = Color.FromArgb(255, 148, 59);
		rUvFdMuDxdq.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(rUvFdMuDxdq, "btnSynData");
		rUvFdMuDxdq.ForeColor = SystemColors.Control;
		rUvFdMuDxdq.Name = "btnSynData";
		rUvFdMuDxdq.UseVisualStyleBackColor = false;
		rUvFdMuDxdq.Click += UhkFcOjbpaB;
		btnMaintenance.BackColor = Color.FromArgb(255, 148, 59);
		btnMaintenance.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnMaintenance, "btnMaintenance");
		btnMaintenance.ForeColor = SystemColors.Control;
		btnMaintenance.Name = "btnMaintenance";
		btnMaintenance.UseVisualStyleBackColor = false;
		btnMaintenance.Click += btnMaintenance_Click;
		btnOpenChangelog.BackColor = Color.FromArgb(145, 72, 200);
		btnOpenChangelog.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnOpenChangelog, "btnOpenChangelog");
		btnOpenChangelog.ForeColor = SystemColors.Control;
		btnOpenChangelog.Name = "btnOpenChangelog";
		btnOpenChangelog.UseVisualStyleBackColor = false;
		btnOpenChangelog.Click += btnOpenChangelog_Click;
		btnOpenRefundReasons.BackColor = Color.FromArgb(0, 145, 196);
		btnOpenRefundReasons.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnOpenRefundReasons, "btnOpenRefundReasons");
		btnOpenRefundReasons.ForeColor = SystemColors.Control;
		btnOpenRefundReasons.Name = "btnOpenRefundReasons";
		btnOpenRefundReasons.UseVisualStyleBackColor = false;
		btnOpenRefundReasons.Click += btnOpenRefundReasons_Click;
		btnOpenDiscountResons.BackColor = Color.FromArgb(0, 145, 196);
		btnOpenDiscountResons.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnOpenDiscountResons, "btnOpenDiscountResons");
		btnOpenDiscountResons.ForeColor = SystemColors.Control;
		btnOpenDiscountResons.Name = "btnOpenDiscountResons";
		btnOpenDiscountResons.UseVisualStyleBackColor = false;
		btnOpenDiscountResons.Click += btnOpenDiscountResons_Click;
		btnManageCustomFields.BackColor = Color.FromArgb(170, 113, 217);
		btnManageCustomFields.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnManageCustomFields, "btnManageCustomFields");
		btnManageCustomFields.ForeColor = SystemColors.ButtonFace;
		btnManageCustomFields.Name = "btnManageCustomFields";
		btnManageCustomFields.UseVisualStyleBackColor = false;
		btnManageCustomFields.Click += btnManageCustomFields_Click;
		btnExportCsv.BackColor = Color.FromArgb(170, 113, 217);
		btnExportCsv.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnExportCsv, "btnExportCsv");
		btnExportCsv.ForeColor = SystemColors.Control;
		btnExportCsv.Name = "btnExportCsv";
		btnExportCsv.UseVisualStyleBackColor = false;
		btnExportCsv.Click += btnExportCsv_Click;
		btnImportCsv.BackColor = Color.FromArgb(170, 113, 217);
		btnImportCsv.FlatAppearance.BorderColor = Color.White;
		btnImportCsv.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnImportCsv, "btnImportCsv");
		btnImportCsv.ForeColor = SystemColors.Control;
		btnImportCsv.Name = "btnImportCsv";
		btnImportCsv.UseVisualStyleBackColor = false;
		btnImportCsv.Click += btnImportCsv_Click;
		componentResourceManager.ApplyResources(tabSettings, "tabSettings");
		tabSettings.BackColor = Color.Transparent;
		tabSettings.BorderStyle = BorderStyle.FixedSingle;
		tabSettings.Controls.Add(panel1);
		tabSettings.Name = "tabSettings";
		componentResourceManager.ApplyResources(panel1, "panel1");
		panel1.Name = "panel1";
		tabCompanySetup.BackColor = Color.Transparent;
		tabCompanySetup.BorderStyle = BorderStyle.FixedSingle;
		componentResourceManager.ApplyResources(tabCompanySetup, "tabCompanySetup");
		tabCompanySetup.Name = "tabCompanySetup";
		componentResourceManager.ApplyResources(lblTitle, "lblTitle");
		lblTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblTitle.ForeColor = Color.White;
		lblTitle.Name = "lblTitle";
		btnManageItemCourse.BackColor = Color.FromArgb(255, 75, 75);
		btnManageItemCourse.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnManageItemCourse, "btnManageItemCourse");
		btnManageItemCourse.ForeColor = SystemColors.Control;
		btnManageItemCourse.Name = "btnManageItemCourse";
		btnManageItemCourse.UseVisualStyleBackColor = false;
		btnManageItemCourse.Click += btnManageItemCourse_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = SystemColors.Control;
		base.ControlBox = false;
		base.Controls.Add(tabControl1);
		base.Controls.Add(lblTitle);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmAdminSettings";
		base.Opacity = 1.0;
		base.Load += frmAdminSettings_Load;
		tabControl1.ResumeLayout(performLayout: false);
		tabTools.ResumeLayout(performLayout: false);
		tabSettings.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}
}
