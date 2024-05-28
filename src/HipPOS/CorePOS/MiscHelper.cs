using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;
using DeviceId;
using Microsoft.Win32;
using Telerik.WinControls.UI;

namespace CorePOS;

public static class MiscHelper
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int EmpID;

		public _003C_003Ec__DisplayClass8_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public Item item;

		public Func<ListViewDataItem, bool> _003C_003E9__1;

		public _003C_003Ec__DisplayClass9_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CCheckItemDisableSOldOut_003Eb__1(ListViewDataItem a)
		{
			return a[1].ToString().ToUpper() == item.ItemName.ToUpper();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_1
	{
		public MaterialsInItem matInItem;

		public _003C_003Ec__DisplayClass9_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CCheckItemDisableSOldOut_003Eb__2(Item a)
		{
			return a.ItemID == matInItem.ItemMaterialID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_2
	{
		public Item material;

		public _003C_003Ec__DisplayClass9_2()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_3
	{
		public ListViewDataItem rvi;

		public _003C_003Ec__DisplayClass9_2 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass9_3()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CCheckItemDisableSOldOut_003Eb__3(Item a)
		{
			return a.ItemID.ToString() == rvi.SubItems[4].ToString();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_4
	{
		public Item otherItem;

		public _003C_003Ec__DisplayClass9_3 CS_0024_003C_003E8__locals2;

		public _003C_003Ec__DisplayClass9_4()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public string orderNumber;

		public bool suppressAlreadySentNotification;

		public Form frm;

		public string orderType;

		public string cellphone;

		public int tries;

		public _003C_003Ec__DisplayClass10_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal void _003CNotifyCustomer_003Eb__0()
		{
			try
			{
				if (!orderNumber.Contains("SKIP") && !orderNumber.Contains("UBER"))
				{
					orderType = orderType.ToUpper();
					if (!orderType.Contains(OrderTypes.PickUp.ToUpper()) && !orderType.Contains(OrderTypes.PickUpOnline.ToUpper()))
					{
						if (!suppressAlreadySentNotification)
						{
							frm.Invoke((Action)delegate
							{
								new NotificationLabel(frm, "Please choose a Pick-Up/Pick-Up-Online orders.", NotificationTypes.Notification);
							});
						}
					}
					else if (SettingsHelper.GetSettingValueByKey("sms") == "Enabled")
					{
						if (cellphone.Length >= 10 && cellphone.Substring(0, 4) != "1234" && cellphone.Substring(0, 1) != "0")
						{
							GClass6 gClass = new GClass6();
							List<Order> list = gClass.Orders.Where((Order x) => x.OrderNumber == orderNumber && x.Void == false && x.CustomerNotified == false).ToList();
							if (list.Any())
							{
								string source = list.FirstOrDefault().Source;
								if (!string.IsNullOrEmpty(source) && !source.Contains("Hippos") && !source.Contains("Moduurn"))
								{
									foreach (Order item in list)
									{
										item.CustomerNotified = true;
									}
									Helper.SubmitChangesWithCatch(gClass);
									return;
								}
								string token = SyncMethods.GetToken();
								string message = SettingsHelper.GetSettingValueByKey("sms_message_order_ready").Replace("<company_name>", CompanyHelper.CompanyDataSetup.Name).Replace("<company_phone>", CompanyHelper.CompanyDataSetup.Phone);
								foreach (Order item2 in list)
								{
									item2.CustomerNotified = true;
								}
								Helper.SubmitChangesWithCatch(gClass);
								if (NotificationMethods.SendSMS(token, cellphone, message))
								{
									foreach (Order item3 in list)
									{
										item3.CustomerNotified = true;
									}
									Helper.SubmitChangesWithCatch(gClass);
									frm.Invoke((Action)delegate
									{
										new NotificationLabel(frm, Resources.Text_message_notification_sent, NotificationTypes.Success).Show();
										MakeOrderIsModified(frm, orderNumber);
									});
								}
								else
								{
									frm.Invoke((Action)delegate
									{
										new NotificationLabel(frm, Resources.Could_not_send_text_message_no + cellphone, NotificationTypes.Warning).Show();
									});
								}
							}
							else if (!suppressAlreadySentNotification)
							{
								frm.Invoke((Action)delegate
								{
									new NotificationLabel(frm, "Customer has already been notified.", NotificationTypes.Notification).Show();
								});
							}
						}
						else if (!suppressAlreadySentNotification && cellphone.Length >= 8)
						{
							frm.Invoke((Action)delegate
							{
								new NotificationLabel(frm, "Invalid phone number, not enough digits.", NotificationTypes.Warning).Show();
							});
						}
					}
					else if (!suppressAlreadySentNotification)
					{
						frm.Invoke((Action)delegate
						{
							new NotificationLabel(frm, "You do not have an SMS add-on subscription.  Please contact Hippos to enable the service.", NotificationTypes.Notification).Show();
						});
					}
				}
				else if (!suppressAlreadySentNotification)
				{
					frm.Invoke((Action)delegate
					{
						new NotificationLabel(frm, "Skip/Uber customers cannot be notified.", NotificationTypes.Notification).Show();
					});
				}
			}
			catch (Exception ex)
			{
				LogHelper.WriteLog(ex.Message + " " + ex.StackTrace, LogTypes.error_log);
				tries++;
				if (tries <= 3)
				{
					NotifyCustomer(frm, orderNumber, cellphone, orderType, suppressAlreadySentNotification, tries);
				}
			}
		}

		internal void _003CNotifyCustomer_003Eb__1()
		{
			new NotificationLabel(frm, "Skip/Uber customers cannot be notified.", NotificationTypes.Notification).Show();
		}

		internal void _003CNotifyCustomer_003Eb__7()
		{
			new NotificationLabel(frm, Resources.Text_message_notification_sent, NotificationTypes.Success).Show();
			MakeOrderIsModified(frm, orderNumber);
		}

		internal void _003CNotifyCustomer_003Eb__8()
		{
			new NotificationLabel(frm, Resources.Could_not_send_text_message_no + cellphone, NotificationTypes.Warning).Show();
		}

		internal void _003CNotifyCustomer_003Eb__6()
		{
			new NotificationLabel(frm, "Customer has already been notified.", NotificationTypes.Notification).Show();
		}

		internal void _003CNotifyCustomer_003Eb__2()
		{
			new NotificationLabel(frm, "Invalid phone number, not enough digits.", NotificationTypes.Warning).Show();
		}

		internal void _003CNotifyCustomer_003Eb__3()
		{
			new NotificationLabel(frm, "You do not have an SMS add-on subscription.  Please contact Hippos to enable the service.", NotificationTypes.Notification).Show();
		}

		internal void _003CNotifyCustomer_003Eb__4()
		{
			new NotificationLabel(frm, "Please choose a Pick-Up/Pick-Up-Online orders.", NotificationTypes.Notification);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public string orderNumber;

		public _003C_003Ec__DisplayClass11_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CMakeOrderIsModified_003Eb__0(OrderResult a)
		{
			return a.OrderNumber == orderNumber;
		}

		internal bool _003CMakeOrderIsModified_003Eb__1(OrderResult a)
		{
			return a.OrderNumber == orderNumber;
		}
	}

	public static void openKeyboard()
	{
		if (!Convert.ToBoolean(CorePOS.Properties.Settings.Default["KeyboardConnected"]))
		{
			Process.Start("C:\\Program Files\\Common Files\\Microsoft Shared\\ink\\tabtip.exe".ToLower());
		}
	}

	public static string getRegistryValue(string registry, string valueName)
	{
		try
		{
			return RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Default)?.OpenSubKey(registry).GetValue(valueName).ToString();
		}
		catch (Exception error)
		{
			NotificationMethods.sendCrash(AppSettings.AppVersion, Environment.OSVersion.VersionString, error);
			return null;
		}
	}

	public static bool setRegistryValue(string registry, string valueName, string value)
	{
		try
		{
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Default);
			if (registryKey != null)
			{
				registryKey.OpenSubKey(registry, writable: true).SetValue(valueName, value, RegistryValueKind.String);
				return true;
			}
			return false;
		}
		catch (Exception error)
		{
			NotificationMethods.sendCrash(AppSettings.AppVersion, Environment.OSVersion.VersionString, error);
			return false;
		}
	}

	public static void checkRegistryKeys()
	{
		List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
		string text = "Software\\DigitalCraft\\HipPOS";
		list.Add(new KeyValuePair<string, string>(text, "ProductKey"));
		list.Add(new KeyValuePair<string, string>(text, "InstallToken"));
		list.Add(new KeyValuePair<string, string>(text, "InstallID"));
		try
		{
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Default);
			if (registryKey == null)
			{
				return;
			}
			RegistryKey registryKey2 = registryKey.OpenSubKey(text, writable: true);
			if (registryKey2 == null)
			{
				registryKey.CreateSubKey(text);
				registryKey2 = registryKey.OpenSubKey(text, writable: true);
				{
					foreach (KeyValuePair<string, string> item in list)
					{
						registryKey2.SetValue(item.Value, string.Empty, RegistryValueKind.String);
					}
					return;
				}
			}
			string[] valueNames = registryKey.OpenSubKey(list.FirstOrDefault().Key).GetValueNames();
			foreach (KeyValuePair<string, string> item2 in list)
			{
				if (!valueNames.Contains(item2.Value))
				{
					registryKey2.SetValue(item2.Value, string.Empty, RegistryValueKind.String);
				}
			}
		}
		catch (Exception error)
		{
			NotificationMethods.sendCrash(AppSettings.AppVersion, Environment.OSVersion.VersionString, error);
		}
	}

	public static string productkeyCheckHelper(string productKey, bool required = true)
	{
		GClass6 gClass = new GClass6();
		Terminal terminal = gClass.Terminals.Where((Terminal x) => x.SystemName == Environment.MachineName).FirstOrDefault();
		if (terminal == null)
		{
			terminal = new Terminal();
			terminal.SystemName = Environment.MachineName;
			terminal.String_0 = StringCipher.Encrypt(getRegistryValue("Software\\Microsoft\\Windows NT\\CurrentVersion", "ProductId"), GetSystemUIDCipher());
			terminal.ProductKey = productKey;
			terminal.LastCheckedIn = DateTime.Now;
			terminal.DefaultLayoutSectionName = "1";
			terminal.OperatingMode = "Normal";
			terminal.AppRestartRequired = false;
			terminal.Status = TerminalStatus.active;
			terminal.LastCheckedIn = DateTime.Now;
			terminal.DefaultLayoutSectionName = string.Empty;
			terminal.DefaultOrderTypes = "Dine In,To-Go";
			terminal.DefaultStation1 = 1;
			terminal.DefaultStation1 = 2;
			terminal.LayoutZoomValue = 5;
			gClass.Terminals.InsertOnSubmit(terminal);
			gClass.SubmitChanges();
		}
		else
		{
			terminal.ProductKey = productKey;
			if (string.IsNullOrEmpty(terminal.String_0))
			{
				terminal.String_0 = StringCipher.Encrypt(getRegistryValue("Software\\Microsoft\\Windows NT\\CurrentVersion", "ProductId"), GetSystemUIDCipher());
			}
			gClass.SubmitChanges();
		}
		return productkeyCheckHelper(required);
	}

	public static string productkeyCheckHelper(bool required = true)
	{
		try
		{
			GClass6 gClass = new GClass6();
			Terminal terminal = gClass.Terminals.Where((Terminal x) => x.SystemName == Environment.MachineName).FirstOrDefault();
			if (terminal == null)
			{
				return "No Product Key";
			}
			string text = StringCipher.Decrypt(terminal.String_0, GetSystemUIDCipher());
			if (string.IsNullOrEmpty(text) || text == "false")
			{
				new frmMessageBox(Resources.Unable_to_validate_license, Resources.Fatal_Error).ShowDialog();
				Application.Exit();
			}
			ValidateProductKeyPostData validateProductKeyPostData = new ValidateProductKeyPostData();
			validateProductKeyPostData.product_key = terminal.ProductKey;
			validateProductKeyPostData.system_id = StringCipher.Decrypt(terminal.String_0, GetSystemUIDCipher());
			validateProductKeyPostData.OSver = getRegistryValue("Software\\Microsoft\\Windows NT\\CurrentVersion", "ProductName");
			validateProductKeyPostData.expire_date = DateTime.Now;
			if (!string.IsNullOrEmpty(terminal.InstallationToken) && !string.IsNullOrEmpty(terminal.InstallationID))
			{
				try
				{
					DateTime value = DateTime.ParseExact(new CryptoHelper().Decrypt(terminal.InstallationToken, terminal.InstallationID).Split(';')[2], "MM/dd/yyyy", CultureInfo.CurrentCulture);
					validateProductKeyPostData.expire_date = value;
				}
				catch
				{
				}
			}
			ValidateProductKeyResponse validateProductKeyResponse = SyncMethods.ValidateProductKey(validateProductKeyPostData);
			if (validateProductKeyResponse.code == 200)
			{
				terminal.InstallationID = validateProductKeyResponse.install_id;
				terminal.InstallationToken = validateProductKeyResponse.install_token;
				Helper.SubmitChangesWithCatch(gClass);
				return string.Empty;
			}
			if (validateProductKeyResponse.code == 201)
			{
				return string.Empty;
			}
			return required ? validateProductKeyResponse.message : string.Empty;
		}
		catch (Exception ex)
		{
			DebugMethods.ShowExceptionTextFile(ex);
			return required ? Resources.Unable_to_contact_server_check : string.Empty;
		}
	}

	public static bool isNumberInRange(decimal value, decimal min, decimal max)
	{
		if (value >= min && value <= max)
		{
			return true;
		}
		return false;
	}

	public static string GetSystemUIDCipher()
	{
		return new DeviceIdBuilder().AddProcessorId().AddMotherboardSerialNumber().AddSystemDriveSerialNumber()
			.ToString() + "Efwp6omJGeZudEmKVjZIRKGqm1OsXbSSIl9EI1OoJ9B412ypvzAYNBtAzTttUlb3";
	}

	public static void ProcessPayout(Form mainForm)
	{
		GClass6 gClass = new GClass6();
		string[] itemList = (from r in gClass.Reasons
			where r.ReasonType == "payout"
			select r into d
			select d.Value).ToArray();
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.ItemSelector();
		MemoryLoadedObjects.ItemSelector.LoadForm(itemList, _withCustom: true, "Select Payout Reason");
		if (MemoryLoadedObjects.ItemSelector.ShowDialog(mainForm) != DialogResult.OK)
		{
			return;
		}
		string singleSelectedItem = MemoryLoadedObjects.ItemSelector.SingleSelectedItem;
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Payout Amount", 2, 10, string.Empty);
		if (MemoryLoadedObjects.Numpad.ShowDialog(mainForm) != DialogResult.OK)
		{
			return;
		}
		InHouseTransactionMethods.AddTransaction(MemoryLoadedObjects.Numpad.numberEntered, singleSelectedItem);
		new NotificationLabel(mainForm, "Payout Saved", NotificationTypes.Success).Show();
		if (SettingsHelper.GetSettingValueByKey("print_payout") == "ON")
		{
			_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
			CS_0024_003C_003E8__locals0.EmpID = Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString());
			string text = "";
			Employee employee = gClass.Employees.Where((Employee a) => a.EmployeeID == CS_0024_003C_003E8__locals0.EmpID).FirstOrDefault();
			if (employee != null)
			{
				text = employee.FirstName + " " + employee.LastName;
			}
			PrintHelper printHelper = new PrintHelper();
			string text2 = "<p><strong> PAYOUT SLIP</strong></p>";
			text2 = text2 + "<span> PAYOUT AMOUNT : $" + MemoryLoadedObjects.Numpad.numberEntered.ToString("0.00") + "</span><br>";
			text2 = text2 + "<span>DATE & TIME : " + DateTime.Now.ToString() + "</span><br>";
			text2 = text2 + "<span>EMPLOYEE : " + text + "</span><br>";
			text2 = text2 + "<span>REASON : " + singleSelectedItem + "</span>";
			printHelper.PrintString(text2, 20);
		}
	}

	public static bool CheckItemDisableSOldOut(Form parentForm, Item item, CustomListViewTelerik radListItems, decimal qtyOnChange = 0m, decimal previousQty = 0m)
	{
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.item = item;
		string message = CS_0024_003C_003E8__locals0.item.ItemName.Replace(" & ", " && ").ToUpper() + Resources._is_sold_out_Please_update_you;
		if (CS_0024_003C_003E8__locals0.item.TrackInventory && CS_0024_003C_003E8__locals0.item.DisableSoldOutItems)
		{
			if (CS_0024_003C_003E8__locals0.item.InventoryCount <= 0m)
			{
				new NotificationLabel(parentForm, message, NotificationTypes.Warning).Show();
				return false;
			}
			decimal num = default(decimal);
			foreach (ListViewDataItem item2 in radListItems.Items.Where((ListViewDataItem a) => a[1].ToString().ToUpper() == CS_0024_003C_003E8__locals0.item.ItemName.ToUpper()))
			{
				if (!item2.Font.Strikeout && (item2.SubItems[23] == null || string.IsNullOrEmpty(item2.SubItems[23].ToString()) || (item2.SubItems[23] != null && !Convert.ToBoolean(item2.SubItems[23].ToString()))))
				{
					decimal num2 = ((item2[0].ToString() == "") ? 1m : MathHelper.FractionToDecimal(item2[0].ToString()));
					num += num2;
				}
			}
			if (qtyOnChange > 0m)
			{
				num = num + (qtyOnChange - previousQty) - 1m;
			}
			if (num >= CS_0024_003C_003E8__locals0.item.InventoryCount)
			{
				new NotificationLabel(parentForm, message, NotificationTypes.Warning).Show();
				return false;
			}
		}
		GClass6 gClass = new GClass6();
		List<MaterialsInItem> list = gClass.MaterialsInItems.Where((MaterialsInItem m) => m.ItemID == CS_0024_003C_003E8__locals0.item.ItemID).ToList();
		if (list.Count > 0)
		{
			using List<MaterialsInItem>.Enumerator enumerator2 = list.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				_003C_003Ec__DisplayClass9_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass9_1();
				CS_0024_003C_003E8__locals1.matInItem = enumerator2.Current;
				_003C_003Ec__DisplayClass9_2 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_2();
				_003C_003Ec__DisplayClass9_.material = MemoryLoadedData.all_active_items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals1.matInItem.ItemMaterialID).FirstOrDefault();
				if (_003C_003Ec__DisplayClass9_.material == null || !_003C_003Ec__DisplayClass9_.material.TrackInventory || !_003C_003Ec__DisplayClass9_.material.DisableSoldOutItems)
				{
					continue;
				}
				message = "Ingredient " + _003C_003Ec__DisplayClass9_.material.ItemName.Replace(" & ", " && ").ToUpper() + " in item " + CS_0024_003C_003E8__locals0.item.ItemName.ToUpper() + Resources._is_out_of_stock_Please_update;
				if (!(_003C_003Ec__DisplayClass9_.material.InventoryCount <= 0m))
				{
					decimal num3 = default(decimal);
					using (IEnumerator<ListViewDataItem> enumerator = radListItems.Items.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass9_3 _003C_003Ec__DisplayClass9_2 = new _003C_003Ec__DisplayClass9_3();
							_003C_003Ec__DisplayClass9_2.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass9_;
							_003C_003Ec__DisplayClass9_2.rvi = enumerator.Current;
							_003C_003Ec__DisplayClass9_4 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass9_4();
							CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2 = _003C_003Ec__DisplayClass9_2;
							decimal num4 = ((CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.rvi[0].ToString() == "") ? 1m : MathHelper.FractionToDecimal(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.rvi[0].ToString()));
							CS_0024_003C_003E8__locals2.otherItem = MemoryLoadedData.all_active_items.Where((Item a) => a.ItemID.ToString() == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.rvi.SubItems[4].ToString()).FirstOrDefault();
							if (CS_0024_003C_003E8__locals2.otherItem == null)
							{
								continue;
							}
							MaterialsInItem materialsInItem = gClass.MaterialsInItems.Where((MaterialsInItem a) => a.ItemMaterialID == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.material.ItemID && a.ItemID == CS_0024_003C_003E8__locals2.otherItem.ItemID).FirstOrDefault();
							if (materialsInItem != null)
							{
								if (qtyOnChange == 0m)
								{
									num3 += num4 * materialsInItem.Quantity.Value;
								}
								else
								{
									num3 += qtyOnChange * materialsInItem.Quantity.Value;
								}
							}
						}
					}
					decimal num5 = ((qtyOnChange == 0m) ? CS_0024_003C_003E8__locals1.matInItem.Quantity.Value : 0m);
					if (num3 + num5 > _003C_003Ec__DisplayClass9_.material.InventoryCount)
					{
						new NotificationLabel(parentForm, message, NotificationTypes.Warning).Show();
						return false;
					}
					continue;
				}
				new NotificationLabel(parentForm, message, NotificationTypes.Warning).Show();
				return false;
			}
		}
		return true;
	}

	public static void NotifyCustomer(Form frm, string orderNumber, string cellphone, string orderType, bool suppressAlreadySentNotification = false, int tries = 1)
	{
		_003C_003Ec__DisplayClass10_0 _003C_003Ec__DisplayClass10_ = new _003C_003Ec__DisplayClass10_0();
		_003C_003Ec__DisplayClass10_.orderNumber = orderNumber;
		_003C_003Ec__DisplayClass10_.suppressAlreadySentNotification = suppressAlreadySentNotification;
		_003C_003Ec__DisplayClass10_.frm = frm;
		_003C_003Ec__DisplayClass10_.orderType = orderType;
		_003C_003Ec__DisplayClass10_.cellphone = cellphone;
		_003C_003Ec__DisplayClass10_.tries = tries;
		new Thread((ThreadStart)delegate
		{
			try
			{
				if (!_003C_003Ec__DisplayClass10_.orderNumber.Contains("SKIP") && !_003C_003Ec__DisplayClass10_.orderNumber.Contains("UBER"))
				{
					_003C_003Ec__DisplayClass10_.orderType = _003C_003Ec__DisplayClass10_.orderType.ToUpper();
					if (!_003C_003Ec__DisplayClass10_.orderType.Contains(OrderTypes.PickUp.ToUpper()) && !_003C_003Ec__DisplayClass10_.orderType.Contains(OrderTypes.PickUpOnline.ToUpper()))
					{
						if (!_003C_003Ec__DisplayClass10_.suppressAlreadySentNotification)
						{
							_003C_003Ec__DisplayClass10_.frm.Invoke((Action)delegate
							{
								new NotificationLabel(_003C_003Ec__DisplayClass10_.frm, "Please choose a Pick-Up/Pick-Up-Online orders.", NotificationTypes.Notification);
							});
						}
					}
					else if (SettingsHelper.GetSettingValueByKey("sms") == "Enabled")
					{
						if (_003C_003Ec__DisplayClass10_.cellphone.Length >= 10 && _003C_003Ec__DisplayClass10_.cellphone.Substring(0, 4) != "1234" && _003C_003Ec__DisplayClass10_.cellphone.Substring(0, 1) != "0")
						{
							GClass6 gClass = new GClass6();
							List<Order> list = gClass.Orders.Where((Order x) => x.OrderNumber == _003C_003Ec__DisplayClass10_.orderNumber && x.Void == false && x.CustomerNotified == false).ToList();
							if (list.Any())
							{
								string source = list.FirstOrDefault().Source;
								if (!string.IsNullOrEmpty(source) && !source.Contains("Hippos") && !source.Contains("Moduurn"))
								{
									foreach (Order item in list)
									{
										item.CustomerNotified = true;
									}
									Helper.SubmitChangesWithCatch(gClass);
								}
								else
								{
									string token = SyncMethods.GetToken();
									string message = SettingsHelper.GetSettingValueByKey("sms_message_order_ready").Replace("<company_name>", CompanyHelper.CompanyDataSetup.Name).Replace("<company_phone>", CompanyHelper.CompanyDataSetup.Phone);
									foreach (Order item2 in list)
									{
										item2.CustomerNotified = true;
									}
									Helper.SubmitChangesWithCatch(gClass);
									if (NotificationMethods.SendSMS(token, _003C_003Ec__DisplayClass10_.cellphone, message))
									{
										foreach (Order item3 in list)
										{
											item3.CustomerNotified = true;
										}
										Helper.SubmitChangesWithCatch(gClass);
										_003C_003Ec__DisplayClass10_.frm.Invoke((Action)delegate
										{
											new NotificationLabel(_003C_003Ec__DisplayClass10_.frm, Resources.Text_message_notification_sent, NotificationTypes.Success).Show();
											MakeOrderIsModified(_003C_003Ec__DisplayClass10_.frm, _003C_003Ec__DisplayClass10_.orderNumber);
										});
									}
									else
									{
										_003C_003Ec__DisplayClass10_.frm.Invoke((Action)delegate
										{
											new NotificationLabel(_003C_003Ec__DisplayClass10_.frm, Resources.Could_not_send_text_message_no + _003C_003Ec__DisplayClass10_.cellphone, NotificationTypes.Warning).Show();
										});
									}
								}
							}
							else if (!_003C_003Ec__DisplayClass10_.suppressAlreadySentNotification)
							{
								_003C_003Ec__DisplayClass10_.frm.Invoke((Action)delegate
								{
									new NotificationLabel(_003C_003Ec__DisplayClass10_.frm, "Customer has already been notified.", NotificationTypes.Notification).Show();
								});
							}
						}
						else if (!_003C_003Ec__DisplayClass10_.suppressAlreadySentNotification && _003C_003Ec__DisplayClass10_.cellphone.Length >= 8)
						{
							_003C_003Ec__DisplayClass10_.frm.Invoke((Action)delegate
							{
								new NotificationLabel(_003C_003Ec__DisplayClass10_.frm, "Invalid phone number, not enough digits.", NotificationTypes.Warning).Show();
							});
						}
					}
					else if (!_003C_003Ec__DisplayClass10_.suppressAlreadySentNotification)
					{
						_003C_003Ec__DisplayClass10_.frm.Invoke((Action)delegate
						{
							new NotificationLabel(_003C_003Ec__DisplayClass10_.frm, "You do not have an SMS add-on subscription.  Please contact Hippos to enable the service.", NotificationTypes.Notification).Show();
						});
					}
				}
				else if (!_003C_003Ec__DisplayClass10_.suppressAlreadySentNotification)
				{
					_003C_003Ec__DisplayClass10_.frm.Invoke((Action)delegate
					{
						new NotificationLabel(_003C_003Ec__DisplayClass10_.frm, "Skip/Uber customers cannot be notified.", NotificationTypes.Notification).Show();
					});
				}
			}
			catch (Exception ex)
			{
				LogHelper.WriteLog(ex.Message + " " + ex.StackTrace, LogTypes.error_log);
				_003C_003Ec__DisplayClass10_.tries++;
				if (_003C_003Ec__DisplayClass10_.tries <= 3)
				{
					NotifyCustomer(_003C_003Ec__DisplayClass10_.frm, _003C_003Ec__DisplayClass10_.orderNumber, _003C_003Ec__DisplayClass10_.cellphone, _003C_003Ec__DisplayClass10_.orderType, _003C_003Ec__DisplayClass10_.suppressAlreadySentNotification, _003C_003Ec__DisplayClass10_.tries);
				}
			}
		}).Start();
	}

	public static void MakeOrderIsModified(Form frm, string orderNumber)
	{
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals0.orderNumber = orderNumber;
		if (frm is frmQuickService)
		{
			frmQuickService obj = frm as frmQuickService;
			OrderResult orderResult = obj.multipleBillsToCompare.Where((OrderResult a) => a.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber).FirstOrDefault();
			if (orderResult != null)
			{
				orderResult.IsModified = true;
			}
			obj.LoadFormProcedure();
		}
		else if (frm is frmMultiBills)
		{
			frmMultiBills obj2 = frm as frmMultiBills;
			OrderResult orderResult2 = obj2.multipleBillsToCompare.Where((OrderResult a) => a.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber).FirstOrDefault();
			if (orderResult2 != null)
			{
				orderResult2.IsModified = true;
			}
			obj2.LoadFormProcedure();
		}
	}

	public static string GetOrderFlagString(byte orderFlag)
	{
		return orderFlag switch
		{
			1 => "NEW ONLINE", 
			2 => "NEW", 
			4 => "CANCELLED", 
			5 => "DUPLICATE", 
			3 => "MODIFIED", 
			6 => "PENDING SAVE", 
			_ => "", 
		};
	}

	public static Dictionary<int, string> GenDateRangeFilters()
	{
		return new Dictionary<int, string>
		{
			{
				1,
				Resources.Today
			},
			{ -1, "Tomorrow" },
			{ -7, "Next 7 Days" },
			{ 2, "Yesterday" },
			{ 7, "Last 7 Days" },
			{ 30, "Last Month" },
			{ 90, "Last 3 Months" },
			{ 9999, "ALL" }
		};
	}

	public static void SetSystemTimeZone(string timeZoneId)
	{
		Process process = Process.Start(new ProcessStartInfo
		{
			FileName = "c:\\windows\\system32\\tzutil.exe",
			Arguments = "/s \"" + timeZoneId + "\"",
			UseShellExecute = false,
			CreateNoWindow = true
		});
		if (process != null)
		{
			process.WaitForExit();
			TimeZoneInfo.ClearCachedData();
		}
	}
}
