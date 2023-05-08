using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.CustomControls;
using CorePOS.Data;
using CorePOS.Data.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace CorePOS;

public class frmAddEditPromotions : frmMasterForm
{
	private GClass6 gclass6_0;

	private List<string> list_2;

	private List<string> list_3;

	private Promotion promotion_0;

	private DateTime dateTime_0;

	private DateTime dateTime_1;

	private IContainer icontainer_1;

	private RadToggleSwitch chkSun;

	private RadToggleSwitch chkWed;

	private RadToggleSwitch chkTue;

	private RadToggleSwitch chkMon;

	private RadToggleSwitch chkThu;

	private RadToggleSwitch chkFri;

	private RadToggleSwitch chkSat;

	private Label lblOriginalPrice;

	private Button btnSave;

	private Label label22;

	private Label label20;

	private Label label19;

	private RadToggleSwitch chkDaySale;

	private RadToggleSwitch chkDateRange;

	private Panel panel1;

	private Label label8;

	private Label uqfTqpqWbs;

	private Label label2;

	private Label lblTitle;

	private Label label1;

	private Button btnClose;

	private Label label5;

	private Label label25;

	private RadTextBoxControl txtPromoName;

	private RadTextBoxControl txtPromoCode;

	private Label label26;

	private Label label10;

	private Label label11;

	internal Button btnCopyMon;

	internal Button btnCopyTue;

	private Label label12;

	private Label label13;

	internal Button btnCopyWed;

	private Label label14;

	private Label label15;

	internal Button btnCopyThu;

	private Label label16;

	private Label label27;

	internal Button btnCopyFri;

	private Label label28;

	private Label label29;

	internal Button btnCopySat;

	private Label label30;

	private Label label31;

	internal Button btnCopySun;

	private Label label32;

	private Label label33;

	private Class17 chkDineIn;

	private Label label18;

	private Label label21;

	private Class17 chkTogo;

	private Label label34;

	private Class17 chkPickup;

	private Label label35;

	private Class17 chkDelivery;

	private Label label36;

	private RadTextBoxControl txtBuyQty;

	internal Button btnShowKeyboard_BuyQty;

	private Label label37;

	private Class20 ddlGetIt;

	private Label lblForItemsBelow;

	private Class20 ddlTender;

	internal Button btnShowKeyboard_DiscountAmount;

	private RadTextBoxControl txtDiscountAmount;

	private Label label39;

	private Label label40;

	private Class20 ddlGroup1;

	private Class20 ddlGroup2;

	private Label label41;

	private Panel pnlItems1;

	private VerticalScrollControl scrollItem1;

	private VerticalScrollControl scrollItem2;

	private Panel pnlItems2;

	private RadToggleSwitch chkActive;

	private Label label3;

	internal Button btnShowKeyboard_PromoName;

	internal Button btnShowKeyboard_PromoCode;

	private Label lblDisableGETItems;

	private CustomDateControl startDate;

	private CustomDateControl endDate;

	private CustomTimeControl fromMon;

	private CustomTimeControl toMon;

	private CustomTimeControl fromTue;

	private CustomTimeControl toTue;

	private CustomTimeControl fromWed;

	private CustomTimeControl toWed;

	private CustomTimeControl fromThu;

	private CustomTimeControl toThu;

	private CustomTimeControl fromFri;

	private CustomTimeControl toFri;

	private CustomTimeControl fromSat;

	private CustomTimeControl fromSun;

	private CustomTimeControl toSat;

	private CustomTimeControl toSun;

	public frmAddEditPromotions(int promotion_id = 0)
	{
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.promotion_id = promotion_id;
		base._002Ector();
		InitializeComponent_1();
		startDate.Value = DateTime.Now.Date;
		endDate.Value = DateTime.Now.Date;
		list_2 = new List<string>();
		list_3 = new List<string>();
		scrollItem1.ConnectedPanel = pnlItems1;
		scrollItem2.ConnectedPanel = pnlItems2;
		if (CS_0024_003C_003E8__locals0.promotion_id > 0)
		{
			promotion_0 = gclass6_0.Promotions.Where((Promotion a) => a.PromoId == CS_0024_003C_003E8__locals0.promotion_id).FirstOrDefault();
		}
		startDate.Value = DateTime.Now;
		endDate.Value = DateTime.Now;
		Class17 @class = chkDineIn;
		Class17 class2 = chkTogo;
		Class17 class3 = chkDelivery;
		chkPickup.Checked = true;
		class3.Checked = true;
		class2.Checked = true;
		@class.Checked = true;
	}

	private void frmAddEditPromotions_Load(object sender, EventArgs e)
	{
		method_3();
		((RadDropDownList)ddlGetIt).get_Items().Add("IT");
		for (int i = 1; i <= 10; i++)
		{
			((RadDropDownList)ddlGetIt).get_Items().Add(i.ToString());
		}
		((RadDropDownList)ddlGetIt).set_SelectedIndex(0);
		((RadDropDownList)ddlTender).get_Items().Add("%");
		((RadDropDownList)ddlTender).get_Items().Add("$");
		((RadDropDownList)ddlTender).set_SelectedIndex(0);
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		if (promotion_0 != null)
		{
			((Control)(object)txtPromoName).Text = promotion_0.PromoName;
			((Control)(object)txtPromoCode).Text = promotion_0.PromoCode;
			chkActive.set_Value(promotion_0.Active);
			if (promotion_0.StartDate.HasValue)
			{
				chkDateRange.set_Value(true);
				startDate.Value = promotion_0.StartDate.Value;
				endDate.Value = promotion_0.EndDate.Value;
			}
			if (!string.IsNullOrEmpty(promotion_0.DayTimeOfWeek))
			{
				chkDaySale.set_Value(true);
				string[] array = promotion_0.DayTimeOfWeek.Split('|');
				foreach (string obj in array)
				{
					_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
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
			if (!string.IsNullOrEmpty(promotion_0.OrderTypes))
			{
				string[] source = promotion_0.OrderTypes.Split(',');
				if (!source.Contains(OrderTypes.DineIn))
				{
					chkDineIn.Checked = false;
				}
				if (!source.Contains(OrderTypes.ToGo))
				{
					chkTogo.Checked = false;
				}
				if (!source.Contains(OrderTypes.PickUp))
				{
					chkPickup.Checked = false;
				}
				if (!source.Contains(OrderTypes.Delivery))
				{
					chkDelivery.Checked = false;
				}
			}
			((Control)(object)txtBuyQty).Text = promotion_0.BuyQty.Value.ToString("0.##");
			if (!string.IsNullOrEmpty(promotion_0.String_0))
			{
				list_2 = promotion_0.String_0.Split(',').ToList();
				if (promotion_0.String_0 == "-1")
				{
					list.Add("-1");
				}
				else
				{
					ItemsInGroup itemsInGroup = MemoryLoadedData.ListOfItemsInGroupMemory.Where((ItemsInGroup itemsInGroup_0) => itemsInGroup_0.ItemID.ToString() == list_2[0]).FirstOrDefault();
					if (itemsInGroup != null)
					{
						((RadDropDownList)ddlGroup1).set_SelectedValue((object)itemsInGroup.GroupID.ToString());
					}
				}
			}
			((RadDropDownList)ddlGetIt).set_SelectedValue((object)promotion_0.GetQtyString);
			if (!string.IsNullOrEmpty(promotion_0.String_1))
			{
				list_3 = promotion_0.String_1.Split(',').ToList();
				if (promotion_0.String_1 == "-1")
				{
					list2.Add("-1");
				}
				else
				{
					ItemsInGroup itemsInGroup2 = MemoryLoadedData.ListOfItemsInGroupMemory.Where((ItemsInGroup itemsInGroup_0) => itemsInGroup_0.ItemID.ToString() == list_3[0]).FirstOrDefault();
					if (itemsInGroup2 != null)
					{
						((RadDropDownList)ddlGroup2).set_SelectedValue((object)itemsInGroup2.GroupID.ToString());
					}
				}
			}
			((Control)(object)txtDiscountAmount).Text = (promotion_0.GetDiscountAmount.HasValue ? promotion_0.GetDiscountAmount.Value.ToString("0.####") : "0");
			((RadDropDownList)ddlTender).set_SelectedValue((object)promotion_0.GetDiscountUOM);
		}
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		dictionary.Add(-1, "** ALL ITEMS IN ALL GROUPS **");
		if (((RadDropDownList)ddlGroup1).get_SelectedIndex() == 0)
		{
			method_5(pnlItems1, dictionary, list);
		}
		if (((RadDropDownList)ddlGroup2).get_SelectedIndex() == 0)
		{
			method_5(pnlItems2, dictionary, list2);
		}
	}

	private void method_3()
	{
		Dictionary<string, string> groups = AdminMethods.getGroups(ItemClassifications.Product, withShowItems: false);
		((RadDropDownList)ddlGroup1).set_DisplayMember("Value");
		((RadDropDownList)ddlGroup1).set_ValueMember("Key");
		((RadDropDownList)ddlGroup1).set_DataSource((object)new BindingSource(groups, null));
		((RadDropDownList)ddlGroup1).set_SelectedIndex(0);
		((RadDropDownList)ddlGroup2).set_DisplayMember("Value");
		((RadDropDownList)ddlGroup2).set_ValueMember("Key");
		((RadDropDownList)ddlGroup2).set_DataSource((object)new BindingSource(groups, null));
		((RadDropDownList)ddlGroup2).set_SelectedIndex(0);
	}

	private void method_4(Panel panel_0, KeyValuePair<string, string> keyValuePair_0, List<string> list_4)
	{
		List<Item> list = new List<Item>();
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		if (keyValuePair_0.Key == "0")
		{
			dictionary.Add(-1, "** ALL ITEMS IN ALL GROUPS **");
			list = AdminMethods.getNonAssociatedItems(ItemClassifications.Product).ToList();
		}
		else
		{
			list = AdminMethods.getItemsFromGroup(Convert.ToInt16(keyValuePair_0.Key)).ToList();
		}
		if (list.Count > 0)
		{
			dictionary.Add(0, "** SELECT ALL ITEMS BELOW**");
			foreach (Item item in list)
			{
				dictionary.Add(item.ItemID, item.ItemName);
			}
		}
		method_5(panel_0, dictionary, list_4);
	}

	private void method_5(Panel panel_0, Dictionary<int, string> dictionary_0, List<string> list_4)
	{
		ControlHelpers.ClearControlsInPanel(panel_0);
		int num = 0;
		List<int> list = new List<int>();
		if (list_4 != null && list_4.Count > 0)
		{
			list = list_4.Select((string a) => Convert.ToInt32(a)).ToList();
		}
		foreach (KeyValuePair<int, string> item in dictionary_0)
		{
			Class17 @class = new Class17();
			@class.Name = item.Value;
			@class.Tag = item.Key;
			@class.Text = panel_0.Name;
			@class.Location = new Point(10, 40 * num + 10);
			if (list != null && list.Contains(item.Key))
			{
				@class.Checked = true;
			}
			else
			{
				@class.Checked = false;
			}
			@class.CheckedChanged += method_6;
			panel_0.Controls.Add(@class);
			Label label = new Label();
			label.Name = "lbl" + item.Value;
			label.Text = item.Value;
			label.Location = new Point(50, 40 * num + 10);
			label.Size = new Size(panel_0.Width - 70, 30);
			label.Font = new Font(lblTitle.Font.FontFamily, 13f, FontStyle.Regular);
			label.ForeColor = Color.Black;
			label.BackColor = Color.White;
			label.TextAlign = ContentAlignment.MiddleLeft;
			panel_0.Controls.Add(label);
			num++;
		}
	}

	private void method_6(object sender, EventArgs e)
	{
		Class17 @class = sender as Class17;
		string text = @class.Tag.ToString();
		if (text == "0")
		{
			foreach (Control control3 in @class.Parent.Controls)
			{
				if (control3 is Class17 && control3.Tag.ToString() != "0")
				{
					Class17 class2 = control3 as Class17;
					if (control3.Tag.ToString() == "-1")
					{
						if (@class.Checked)
						{
							class2.Checked = false;
						}
					}
					else if (class2.Checked != @class.Checked)
					{
						class2.Checked = @class.Checked;
					}
				}
			}
			return;
		}
		if (text == "-1")
		{
			if (@class.Checked)
			{
				foreach (Control control4 in @class.Parent.Controls)
				{
					if (control4 is Class17 && control4.Tag.ToString() != "-1")
					{
						(control4 as Class17).Checked = false;
					}
				}
				if (@class.Text == pnlItems1.Name)
				{
					list_2.Clear();
					list_2.Add(text);
					((RadDropDownList)ddlGetIt).set_SelectedIndex(0);
				}
				else if (@class.Text == pnlItems2.Name)
				{
					list_3.Clear();
					list_3.Add(text);
				}
			}
			else if (@class.Text == pnlItems1.Name)
			{
				if (list_2.Contains("-1"))
				{
					list_2.Remove("-1");
				}
			}
			else if (@class.Text == pnlItems2.Name && list_3.Contains("-1"))
			{
				list_3.Remove("-1");
			}
			return;
		}
		if (@class.Text == pnlItems1.Name)
		{
			if (list_2.Contains("-1"))
			{
				list_2.Remove("-1");
			}
		}
		else if (@class.Text == pnlItems2.Name && list_3.Contains("-1"))
		{
			list_3.Remove("-1");
		}
		if (@class.Checked)
		{
			if (@class.Text == pnlItems1.Name)
			{
				if (!list_2.Contains(text))
				{
					list_2.Add(text);
				}
			}
			else if (@class.Text == pnlItems2.Name && !list_3.Contains(text))
			{
				list_3.Add(text);
			}
		}
		else if (@class.Text == pnlItems1.Name)
		{
			if (list_2.Contains(text))
			{
				list_2.Remove(text);
			}
		}
		else if (@class.Text == pnlItems2.Name && list_3.Contains(text))
		{
			list_3.Remove(text);
		}
	}

	private void btnCopyMon_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass12_0();
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

	private void ddlGroup1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
	{
		method_4(pnlItems1, (KeyValuePair<string, string>)((RadDropDownList)ddlGroup1).get_SelectedItem().get_DataBoundItem(), list_2);
	}

	private void ddlGroup2_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
	{
		method_4(pnlItems2, (KeyValuePair<string, string>)((RadDropDownList)ddlGroup2).get_SelectedItem().get_DataBoundItem(), list_3);
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Expected O, but got Unknown
		_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass15_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		if (!string.IsNullOrEmpty(((Control)(object)txtPromoName).Text) && (string.IsNullOrEmpty(((Control)(object)txtPromoName).Text) || !string.IsNullOrEmpty(((Control)(object)txtPromoName).Text.Replace(" ", string.Empty))))
		{
			if (!string.IsNullOrEmpty(((Control)(object)txtPromoCode).Text) && (string.IsNullOrEmpty(((Control)(object)txtPromoCode).Text) || !string.IsNullOrEmpty(((Control)(object)txtPromoCode).Text.Replace(" ", string.Empty))))
			{
				if (!chkDateRange.get_Value() && !chkDaySale.get_Value())
				{
					new NotificationLabel(this, "Please Turn ON Date Range and/or Day Sale.", NotificationTypes.Warning).Show();
					return;
				}
				if (chkDateRange.get_Value())
				{
					if (startDate.Value > endDate.Value)
					{
						new NotificationLabel(this, "Please input a valid date range.", NotificationTypes.Warning).Show();
						return;
					}
					if (endDate.Value.Date < DateTime.Now.Date)
					{
						new NotificationLabel(this, "Please input an end date later or equal than today.", NotificationTypes.Warning).Show();
						return;
					}
				}
				List<string> list = new List<string>();
				if (chkDineIn.Checked)
				{
					list.Add(OrderTypes.DineIn);
				}
				if (chkTogo.Checked)
				{
					list.Add(OrderTypes.ToGo);
				}
				if (chkPickup.Checked)
				{
					list.Add(OrderTypes.PickUp);
				}
				if (chkDelivery.Checked)
				{
					list.Add(OrderTypes.Delivery);
				}
				if (list.Count == 0)
				{
					new NotificationLabel(this, "Please check at least 1 order type", NotificationTypes.Warning).Show();
				}
				else if (((Control)(object)txtBuyQty).Text == "0")
				{
					new NotificationLabel(this, "Buy qty cannot be 0", NotificationTypes.Warning).Show();
				}
				else if (list_2 != null && (list_2 == null || list_2.Count != 0))
				{
					if (((Control)(object)ddlGetIt).Text != "IT" && (list_3 == null || (list_3 != null && list_3.Count == 0)))
					{
						new NotificationLabel(this, "Please choose any GET item/s", NotificationTypes.Warning).Show();
					}
					else if (!string.IsNullOrEmpty(((Control)(object)txtDiscountAmount).Text) && (string.IsNullOrEmpty(((Control)(object)txtDiscountAmount).Text) || !(Convert.ToDecimal(((Control)(object)txtDiscountAmount).Text) == 0m)))
					{
						CS_0024_003C_003E8__locals0.promoId = 0;
						if (promotion_0 != null)
						{
							CS_0024_003C_003E8__locals0.promoId = promotion_0.PromoId;
						}
						if (MemoryLoadedObjects.all_promotions.Where((Promotion a) => a.PromoId != CS_0024_003C_003E8__locals0.promoId && (a.PromoName.ToUpper() == ((Control)(object)CS_0024_003C_003E8__locals0._003C_003E4__this.txtPromoName).Text.ToUpper() || a.PromoCode.ToUpper() == ((Control)(object)CS_0024_003C_003E8__locals0._003C_003E4__this.txtPromoCode).Text.ToUpper())).FirstOrDefault() != null)
						{
							new NotificationLabel(this, "Promotion name/code already exist please change name/code.", NotificationTypes.Warning).Show();
							return;
						}
						List<string> list2 = new List<string>();
						if (chkDaySale.get_Value())
						{
							foreach (Control control in panel1.Controls)
							{
								RadToggleSwitch val = (RadToggleSwitch)control;
								if (val.get_Value())
								{
									_003C_003Ec__DisplayClass15_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass15_1();
									string text = ((Control)(object)val).Text.ToUpper();
									CS_0024_003C_003E8__locals1.shortenedDayString = ((Control)(object)val).Name.Replace("chk", string.Empty);
									DateTimePicker dateTimePicker = (from a in base.Controls.OfType<DateTimePicker>()
										where a.Name.Contains(CS_0024_003C_003E8__locals1.shortenedDayString) && a.Name.Contains("from")
										select a).FirstOrDefault();
									DateTimePicker dateTimePicker2 = (from a in base.Controls.OfType<DateTimePicker>()
										where a.Name.Contains(CS_0024_003C_003E8__locals1.shortenedDayString) && a.Name.Contains("to")
										select a).FirstOrDefault();
									if (dateTimePicker.Value > dateTimePicker2.Value)
									{
										new NotificationLabel(this, "From Time cannot be greater than To Time", NotificationTypes.Warning).Show();
										return;
									}
									list2.Add(text + "-" + dateTimePicker.Value.ToString("HH:mm") + "-" + dateTimePicker2.Value.ToString("HH:mm"));
								}
							}
						}
						int num = Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString());
						if (promotion_0 == null)
						{
							promotion_0 = new Promotion();
							promotion_0.DateCreated = DateTime.Now;
							if (num > 0)
							{
								promotion_0.UserCreated = num;
							}
							gclass6_0.Promotions.InsertOnSubmit(promotion_0);
						}
						promotion_0.PromoName = ((Control)(object)txtPromoName).Text;
						promotion_0.PromoCode = ((Control)(object)txtPromoCode).Text;
						promotion_0.Active = chkActive.get_Value();
						if (chkDateRange.get_Value())
						{
							promotion_0.StartDate = startDate.Value.Date;
							promotion_0.EndDate = endDate.Value.Date;
						}
						else
						{
							promotion_0.StartDate = null;
							promotion_0.EndDate = null;
						}
						if (chkDaySale.get_Value())
						{
							if (list2.Count > 0)
							{
								promotion_0.DayTimeOfWeek = string.Join("|", list2);
							}
							else
							{
								promotion_0.DayTimeOfWeek = "";
							}
						}
						else
						{
							promotion_0.DayTimeOfWeek = "";
						}
						if (list.Count > 0)
						{
							promotion_0.OrderTypes = string.Join(",", list);
						}
						else
						{
							promotion_0.OrderTypes = "";
						}
						promotion_0.BuyQty = Convert.ToDecimal(((Control)(object)txtBuyQty).Text);
						promotion_0.String_0 = string.Join(",", list_2);
						promotion_0.GetQtyString = ((Control)(object)ddlGetIt).Text;
						promotion_0.String_1 = string.Join(",", list_3);
						promotion_0.GetDiscountAmount = Convert.ToDecimal(((Control)(object)txtDiscountAmount).Text);
						promotion_0.GetDiscountUOM = ((Control)(object)ddlTender).Text;
						promotion_0.Synced = false;
						promotion_0.DateModified = DateTime.Now;
						promotion_0.IsDeleted = false;
						if (num > 0)
						{
							promotion_0.UserModified = num;
						}
						Helper.SubmitChangesWithCatch(gclass6_0);
						new NotificationLabel(this, "Promotion Saved.", NotificationTypes.Success).Show();
						MemoryLoadedObjects.RefreshPromotions();
						base.DialogResult = DialogResult.None;
					}
					else
					{
						new NotificationLabel(this, "Discount amount cannot be 0", NotificationTypes.Warning).Show();
					}
				}
				else
				{
					new NotificationLabel(this, "Please choose any BUY item/s", NotificationTypes.Warning).Show();
				}
			}
			else
			{
				new NotificationLabel(this, "Please enter a promo code.", NotificationTypes.Warning).Show();
			}
		}
		else
		{
			new NotificationLabel(this, "Please enter a promo name.", NotificationTypes.Warning).Show();
		}
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void txtPromoName_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData("Enter Promo Name", 0, 256, ((Control)(object)txtPromoName).Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtPromoName).Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void txtPromoCode_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData("Enter Promo Code", 0, 256, ((Control)(object)txtPromoCode).Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtPromoCode).Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void txtBuyQty_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Buy Qty", 2, 8, ((Control)(object)txtBuyQty).Text, "", allowNegative: false, useNotifLabel: true);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtBuyQty).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void LukTxymxj4(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Discount Amount", 2, 8, ((Control)(object)txtDiscountAmount).Text, "", allowNegative: false, useNotifLabel: true);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtDiscountAmount).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void ddlGetIt_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
	{
		if (((RadDropDownList)ddlGetIt).get_SelectedIndex() == 0)
		{
			lblForItemsBelow.Text = "FOR";
			lblDisableGETItems.Visible = true;
		}
		else
		{
			lblForItemsBelow.Text = "OF THE ITEMS BELOW FOR";
			lblDisableGETItems.Visible = false;
		}
	}

	private void ddlTender_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
	{
		method_7();
	}

	private void txtDiscountAmount_TextChanged(object sender, EventArgs e)
	{
		method_7();
	}

	private void method_7()
	{
		if (string.IsNullOrEmpty(((Control)(object)txtDiscountAmount).Text))
		{
			return;
		}
		decimal result = default(decimal);
		if (!decimal.TryParse(((Control)(object)txtDiscountAmount).Text, out result))
		{
			((Control)(object)txtDiscountAmount).Text = "0";
		}
		if (((Control)(object)ddlTender).Text == "%" && result > 100m)
		{
			((Control)(object)txtDiscountAmount).Text = "100";
			new NotificationLabel(this, "Percentage discount cannot be more than 100%.", NotificationTypes.Warning).Show();
		}
		else
		{
			if (!(((Control)(object)ddlTender).Text == "$"))
			{
				return;
			}
			if (((Control)(object)ddlGetIt).Text != "IT" && !list_3.Contains("-1"))
			{
				using (List<string>.Enumerator enumerator = list_3.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass24_0();
						CS_0024_003C_003E8__locals0.getItem = enumerator.Current;
						Item item = MemoryLoadedData.all_active_items.Where((Item a) => a.ItemID.ToString() == CS_0024_003C_003E8__locals0.getItem).FirstOrDefault();
						if (item != null && item.ItemPrice < result)
						{
							((Control)(object)txtDiscountAmount).Text = "0";
							new NotificationLabel(this, "Tender discount cannot be more than item price selected.", NotificationTypes.Warning).Show();
							break;
						}
					}
					return;
				}
			}
			if (!(((Control)(object)ddlGetIt).Text == "IT") || list_3.Contains("-1"))
			{
				return;
			}
			using List<string>.Enumerator enumerator = list_2.GetEnumerator();
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass24_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass24_1();
				CS_0024_003C_003E8__locals1.buyItem = enumerator.Current;
				Item item2 = MemoryLoadedData.all_active_items.Where((Item a) => a.ItemID.ToString() == CS_0024_003C_003E8__locals1.buyItem).FirstOrDefault();
				if (item2 != null && item2.ItemPrice < result)
				{
					((Control)(object)txtDiscountAmount).Text = "0";
					new NotificationLabel(this, "Tender discount cannot be more than item price selected.", NotificationTypes.Warning).Show();
					break;
				}
			}
		}
	}

	private void startDate_ValueChanged(object sender, EventArgs e)
	{
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
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
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
		//IL_089d: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_091b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0948: Unknown result type (might be due to invalid IL or missing references)
		//IL_0975: Unknown result type (might be due to invalid IL or missing references)
		//IL_0996: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff4: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d90: Unknown result type (might be due to invalid IL or missing references)
		//IL_2db1: Unknown result type (might be due to invalid IL or missing references)
		//IL_33db: Unknown result type (might be due to invalid IL or missing references)
		//IL_33f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_340a: Unknown result type (might be due to invalid IL or missing references)
		//IL_342b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3458: Unknown result type (might be due to invalid IL or missing references)
		//IL_3485: Unknown result type (might be due to invalid IL or missing references)
		//IL_34b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_34d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_3560: Unknown result type (might be due to invalid IL or missing references)
		//IL_3578: Unknown result type (might be due to invalid IL or missing references)
		//IL_358f: Unknown result type (might be due to invalid IL or missing references)
		//IL_35b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_35dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_360a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3637: Unknown result type (might be due to invalid IL or missing references)
		//IL_3658: Unknown result type (might be due to invalid IL or missing references)
		//IL_383d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3855: Unknown result type (might be due to invalid IL or missing references)
		//IL_386c: Unknown result type (might be due to invalid IL or missing references)
		//IL_388d: Unknown result type (might be due to invalid IL or missing references)
		//IL_38ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_38e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_3914: Unknown result type (might be due to invalid IL or missing references)
		//IL_3935: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a18: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a30: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a47: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a68: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a95: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ac2: Unknown result type (might be due to invalid IL or missing references)
		//IL_3aef: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b10: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bf3: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c22: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c43: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c70: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3cca: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ceb: Unknown result type (might be due to invalid IL or missing references)
		//IL_3dcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_3de5: Unknown result type (might be due to invalid IL or missing references)
		//IL_3dfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e77: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ea4: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ec5: Unknown result type (might be due to invalid IL or missing references)
		//IL_3fa8: Unknown result type (might be due to invalid IL or missing references)
		//IL_3fc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_3fd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ff8: Unknown result type (might be due to invalid IL or missing references)
		//IL_4025: Unknown result type (might be due to invalid IL or missing references)
		//IL_4052: Unknown result type (might be due to invalid IL or missing references)
		//IL_407f: Unknown result type (might be due to invalid IL or missing references)
		//IL_40a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_4186: Unknown result type (might be due to invalid IL or missing references)
		//IL_419e: Unknown result type (might be due to invalid IL or missing references)
		//IL_41b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_41d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_4203: Unknown result type (might be due to invalid IL or missing references)
		//IL_4230: Unknown result type (might be due to invalid IL or missing references)
		//IL_425d: Unknown result type (might be due to invalid IL or missing references)
		//IL_427e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4364: Unknown result type (might be due to invalid IL or missing references)
		//IL_437c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4393: Unknown result type (might be due to invalid IL or missing references)
		//IL_43b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_43e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_440e: Unknown result type (might be due to invalid IL or missing references)
		//IL_443b: Unknown result type (might be due to invalid IL or missing references)
		//IL_445c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4dbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_4dc8: Expected O, but got Unknown
		//IL_4ebd: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ec7: Expected O, but got Unknown
		//IL_4fbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_4fc6: Expected O, but got Unknown
		//IL_50bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_50c5: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmAddEditPromotions));
		lblDisableGETItems = new Label();
		btnShowKeyboard_PromoCode = new Button();
		btnShowKeyboard_PromoName = new Button();
		chkActive = new RadToggleSwitch();
		label3 = new Label();
		pnlItems1 = new Panel();
		label41 = new Label();
		label40 = new Label();
		label39 = new Label();
		btnShowKeyboard_DiscountAmount = new Button();
		txtDiscountAmount = new RadTextBoxControl();
		lblForItemsBelow = new Label();
		label37 = new Label();
		btnShowKeyboard_BuyQty = new Button();
		txtBuyQty = new RadTextBoxControl();
		label36 = new Label();
		label35 = new Label();
		label34 = new Label();
		label21 = new Label();
		label18 = new Label();
		uqfTqpqWbs = new Label();
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
		label26 = new Label();
		txtPromoCode = new RadTextBoxControl();
		txtPromoName = new RadTextBoxControl();
		label25 = new Label();
		label5 = new Label();
		lblOriginalPrice = new Label();
		btnSave = new Button();
		label22 = new Label();
		label20 = new Label();
		label19 = new Label();
		chkDaySale = new RadToggleSwitch();
		chkDateRange = new RadToggleSwitch();
		panel1 = new Panel();
		chkSun = new RadToggleSwitch();
		chkWed = new RadToggleSwitch();
		chkTue = new RadToggleSwitch();
		chkMon = new RadToggleSwitch();
		chkThu = new RadToggleSwitch();
		chkFri = new RadToggleSwitch();
		chkSat = new RadToggleSwitch();
		label8 = new Label();
		label2 = new Label();
		lblTitle = new Label();
		label1 = new Label();
		btnClose = new Button();
		pnlItems2 = new Panel();
		endDate = new CustomDateControl();
		startDate = new CustomDateControl();
		scrollItem2 = new VerticalScrollControl();
		scrollItem1 = new VerticalScrollControl();
		ddlGroup2 = new Class20();
		ddlGroup1 = new Class20();
		ddlTender = new Class20();
		ddlGetIt = new Class20();
		chkDelivery = new Class17();
		chkPickup = new Class17();
		chkTogo = new Class17();
		chkDineIn = new Class17();
		fromMon = new CustomTimeControl();
		toMon = new CustomTimeControl();
		fromTue = new CustomTimeControl();
		toTue = new CustomTimeControl();
		fromWed = new CustomTimeControl();
		toWed = new CustomTimeControl();
		fromThu = new CustomTimeControl();
		toThu = new CustomTimeControl();
		fromFri = new CustomTimeControl();
		toFri = new CustomTimeControl();
		fromSat = new CustomTimeControl();
		fromSun = new CustomTimeControl();
		toSat = new CustomTimeControl();
		toSun = new CustomTimeControl();
		((ISupportInitialize)chkActive).BeginInit();
		((ISupportInitialize)txtDiscountAmount).BeginInit();
		((ISupportInitialize)txtBuyQty).BeginInit();
		((ISupportInitialize)txtPromoCode).BeginInit();
		((ISupportInitialize)txtPromoName).BeginInit();
		((ISupportInitialize)chkDaySale).BeginInit();
		((ISupportInitialize)chkDateRange).BeginInit();
		panel1.SuspendLayout();
		((ISupportInitialize)chkSun).BeginInit();
		((ISupportInitialize)chkWed).BeginInit();
		((ISupportInitialize)chkTue).BeginInit();
		((ISupportInitialize)chkMon).BeginInit();
		((ISupportInitialize)chkThu).BeginInit();
		((ISupportInitialize)chkFri).BeginInit();
		((ISupportInitialize)chkSat).BeginInit();
		((ISupportInitialize)ddlGroup2).BeginInit();
		((ISupportInitialize)ddlGroup1).BeginInit();
		((ISupportInitialize)ddlTender).BeginInit();
		((ISupportInitialize)ddlGetIt).BeginInit();
		SuspendLayout();
		lblDisableGETItems.BackColor = Color.FromArgb(150, 166, 166);
		lblDisableGETItems.Font = new Font("Microsoft Sans Serif", 18f);
		lblDisableGETItems.ForeColor = Color.White;
		lblDisableGETItems.ImeMode = ImeMode.NoControl;
		lblDisableGETItems.Location = new Point(496, 510);
		lblDisableGETItems.Name = "lblDisableGETItems";
		lblDisableGETItems.Size = new Size(518, 260);
		lblDisableGETItems.TabIndex = 353;
		lblDisableGETItems.TextAlign = ContentAlignment.MiddleCenter;
		lblDisableGETItems.Visible = false;
		btnShowKeyboard_PromoCode.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_PromoCode.DialogResult = DialogResult.OK;
		btnShowKeyboard_PromoCode.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_PromoCode.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_PromoCode.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_PromoCode.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_PromoCode.ForeColor = Color.White;
		btnShowKeyboard_PromoCode.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_PromoCode.Image");
		btnShowKeyboard_PromoCode.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_PromoCode.Location = new Point(600, 79);
		btnShowKeyboard_PromoCode.Margin = new Padding(2);
		btnShowKeyboard_PromoCode.Name = "btnShowKeyboard_PromoCode";
		btnShowKeyboard_PromoCode.Size = new Size(48, 35);
		btnShowKeyboard_PromoCode.TabIndex = 352;
		btnShowKeyboard_PromoCode.UseVisualStyleBackColor = false;
		btnShowKeyboard_PromoCode.Click += txtPromoCode_Click;
		btnShowKeyboard_PromoName.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_PromoName.DialogResult = DialogResult.OK;
		btnShowKeyboard_PromoName.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_PromoName.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_PromoName.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_PromoName.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_PromoName.ForeColor = Color.White;
		btnShowKeyboard_PromoName.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_PromoName.Image");
		btnShowKeyboard_PromoName.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_PromoName.Location = new Point(824, 43);
		btnShowKeyboard_PromoName.Margin = new Padding(2);
		btnShowKeyboard_PromoName.Name = "btnShowKeyboard_PromoName";
		btnShowKeyboard_PromoName.Size = new Size(48, 35);
		btnShowKeyboard_PromoName.TabIndex = 351;
		btnShowKeyboard_PromoName.UseVisualStyleBackColor = false;
		btnShowKeyboard_PromoName.Click += txtPromoName_Click;
		((Control)(object)chkActive).Location = new Point(800, 79);
		((Control)(object)chkActive).Name = "chkActive";
		chkActive.set_OffText("NO");
		chkActive.set_OnText("YES");
		((Control)(object)chkActive).Size = new Size(72, 35);
		((Control)(object)chkActive).TabIndex = 349;
		((Control)(object)chkActive).Tag = "";
		chkActive.set_ToggleStateMode((ToggleStateMode)1);
		((RadToggleSwitchElement)((RadControl)chkActive).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkActive).GetChildAt(0)).set_ThumbOffset(52);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkActive).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_Text("YES");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		label3.BackColor = Color.FromArgb(132, 146, 146);
		label3.Font = new Font("Microsoft Sans Serif", 12f);
		label3.ForeColor = Color.White;
		label3.ImeMode = ImeMode.NoControl;
		label3.Location = new Point(649, 79);
		label3.Margin = new Padding(4, 0, 4, 0);
		label3.MinimumSize = new Size(120, 35);
		label3.Name = "label3";
		label3.Size = new Size(151, 35);
		label3.TabIndex = 350;
		label3.Text = "Active";
		label3.TextAlign = ContentAlignment.MiddleLeft;
		pnlItems1.AutoScroll = true;
		pnlItems1.BackColor = Color.White;
		pnlItems1.Location = new Point(0, 545);
		pnlItems1.Margin = new Padding(10);
		pnlItems1.Name = "pnlItems1";
		pnlItems1.Padding = new Padding(10);
		pnlItems1.Size = new Size(469, 225);
		pnlItems1.TabIndex = 345;
		label41.BackColor = Color.FromArgb(132, 146, 146);
		label41.Font = new Font("Microsoft Sans Serif", 12f);
		label41.ForeColor = Color.White;
		label41.ImeMode = ImeMode.NoControl;
		label41.Location = new Point(496, 510);
		label41.Name = "label41";
		label41.Padding = new Padding(0, 0, 5, 0);
		label41.Size = new Size(119, 34);
		label41.TabIndex = 343;
		label41.Text = "Select Group";
		label41.TextAlign = ContentAlignment.MiddleRight;
		label40.BackColor = Color.FromArgb(132, 146, 146);
		label40.Font = new Font("Microsoft Sans Serif", 12f);
		label40.ForeColor = Color.White;
		label40.ImeMode = ImeMode.NoControl;
		label40.Location = new Point(0, 510);
		label40.Name = "label40";
		label40.Padding = new Padding(0, 0, 5, 0);
		label40.Size = new Size(125, 34);
		label40.TabIndex = 341;
		label40.Text = "Select Group";
		label40.TextAlign = ContentAlignment.MiddleRight;
		label39.BackColor = Color.FromArgb(132, 146, 146);
		label39.Font = new Font("Microsoft Sans Serif", 12f);
		label39.ForeColor = Color.White;
		label39.ImeMode = ImeMode.NoControl;
		label39.Location = new Point(947, 474);
		label39.Name = "label39";
		label39.Padding = new Padding(0, 0, 5, 0);
		label39.Size = new Size(67, 35);
		label39.TabIndex = 340;
		label39.Text = "OFF";
		label39.TextAlign = ContentAlignment.MiddleCenter;
		btnShowKeyboard_DiscountAmount.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_DiscountAmount.DialogResult = DialogResult.OK;
		btnShowKeyboard_DiscountAmount.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_DiscountAmount.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_DiscountAmount.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_DiscountAmount.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_DiscountAmount.ForeColor = Color.White;
		btnShowKeyboard_DiscountAmount.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_DiscountAmount.Image");
		btnShowKeyboard_DiscountAmount.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_DiscountAmount.Location = new Point(839, 474);
		btnShowKeyboard_DiscountAmount.Margin = new Padding(2);
		btnShowKeyboard_DiscountAmount.Name = "btnShowKeyboard_DiscountAmount";
		btnShowKeyboard_DiscountAmount.Size = new Size(48, 35);
		btnShowKeyboard_DiscountAmount.TabIndex = 338;
		btnShowKeyboard_DiscountAmount.UseVisualStyleBackColor = false;
		btnShowKeyboard_DiscountAmount.Click += LukTxymxj4;
		((Control)(object)txtDiscountAmount).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		((Control)(object)txtDiscountAmount).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtDiscountAmount).Location = new Point(761, 474);
		((Control)(object)txtDiscountAmount).Name = "txtDiscountAmount";
		((RadElement)((RadControl)txtDiscountAmount).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtDiscountAmount).Size = new Size(77, 35);
		((Control)(object)txtDiscountAmount).TabIndex = 337;
		((Control)(object)txtDiscountAmount).Tag = "product";
		((Control)(object)txtDiscountAmount).Text = "0";
		txtDiscountAmount.set_TextAlign(HorizontalAlignment.Center);
		((Control)(object)txtDiscountAmount).TextChanged += txtDiscountAmount_TextChanged;
		((Control)(object)txtDiscountAmount).Click += LukTxymxj4;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtDiscountAmount).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtDiscountAmount).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(0f, 5f));
		lblForItemsBelow.BackColor = Color.FromArgb(132, 146, 146);
		lblForItemsBelow.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		lblForItemsBelow.ForeColor = Color.White;
		lblForItemsBelow.ImeMode = ImeMode.NoControl;
		lblForItemsBelow.Location = new Point(655, 474);
		lblForItemsBelow.Name = "lblForItemsBelow";
		lblForItemsBelow.Padding = new Padding(0, 0, 5, 0);
		lblForItemsBelow.Size = new Size(105, 35);
		lblForItemsBelow.TabIndex = 336;
		lblForItemsBelow.Text = "OF THE ITEMS BELOW FOR";
		lblForItemsBelow.TextAlign = ContentAlignment.MiddleRight;
		label37.BackColor = Color.FromArgb(132, 146, 146);
		label37.Font = new Font("Microsoft Sans Serif", 12f);
		label37.ForeColor = Color.White;
		label37.ImeMode = ImeMode.NoControl;
		label37.Location = new Point(496, 474);
		label37.Name = "label37";
		label37.Padding = new Padding(0, 0, 5, 0);
		label37.Size = new Size(90, 35);
		label37.TabIndex = 334;
		label37.Text = "AND GET:";
		label37.TextAlign = ContentAlignment.MiddleRight;
		btnShowKeyboard_BuyQty.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_BuyQty.DialogResult = DialogResult.OK;
		btnShowKeyboard_BuyQty.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_BuyQty.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_BuyQty.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_BuyQty.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_BuyQty.ForeColor = Color.White;
		btnShowKeyboard_BuyQty.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_BuyQty.Image");
		btnShowKeyboard_BuyQty.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_BuyQty.Location = new Point(145, 474);
		btnShowKeyboard_BuyQty.Margin = new Padding(2);
		btnShowKeyboard_BuyQty.Name = "btnShowKeyboard_BuyQty";
		btnShowKeyboard_BuyQty.Size = new Size(48, 35);
		btnShowKeyboard_BuyQty.TabIndex = 333;
		btnShowKeyboard_BuyQty.UseVisualStyleBackColor = false;
		btnShowKeyboard_BuyQty.Click += txtBuyQty_Click;
		((Control)(object)txtBuyQty).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		((Control)(object)txtBuyQty).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtBuyQty).Location = new Point(91, 474);
		((Control)(object)txtBuyQty).Name = "txtBuyQty";
		((RadElement)((RadControl)txtBuyQty).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtBuyQty).Size = new Size(53, 35);
		((Control)(object)txtBuyQty).TabIndex = 332;
		((Control)(object)txtBuyQty).Tag = "product";
		((Control)(object)txtBuyQty).Text = "0";
		txtBuyQty.set_TextAlign(HorizontalAlignment.Center);
		((Control)(object)txtBuyQty).Click += txtBuyQty_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtBuyQty).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtBuyQty).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(0f, 5f));
		label36.BackColor = Color.FromArgb(132, 146, 146);
		label36.Font = new Font("Microsoft Sans Serif", 12f);
		label36.ForeColor = Color.White;
		label36.ImeMode = ImeMode.NoControl;
		label36.Location = new Point(0, 474);
		label36.Name = "label36";
		label36.Padding = new Padding(0, 0, 5, 0);
		label36.Size = new Size(90, 35);
		label36.TabIndex = 331;
		label36.Text = "BUY ANY:";
		label36.TextAlign = ContentAlignment.MiddleRight;
		label35.BackColor = Color.FromArgb(132, 146, 146);
		label35.Font = new Font("Microsoft Sans Serif", 12f);
		label35.ForeColor = Color.White;
		label35.ImeMode = ImeMode.NoControl;
		label35.Location = new Point(485, 442);
		label35.Name = "label35";
		label35.Size = new Size(79, 29);
		label35.TabIndex = 330;
		label35.Text = "Delivery";
		label35.TextAlign = ContentAlignment.MiddleLeft;
		label34.BackColor = Color.FromArgb(132, 146, 146);
		label34.Font = new Font("Microsoft Sans Serif", 12f);
		label34.ForeColor = Color.White;
		label34.ImeMode = ImeMode.NoControl;
		label34.Location = new Point(357, 442);
		label34.Name = "label34";
		label34.Size = new Size(76, 29);
		label34.TabIndex = 328;
		label34.Text = "Pick-Up";
		label34.TextAlign = ContentAlignment.MiddleCenter;
		label21.BackColor = Color.FromArgb(132, 146, 146);
		label21.Font = new Font("Microsoft Sans Serif", 12f);
		label21.ForeColor = Color.White;
		label21.ImeMode = ImeMode.NoControl;
		label21.Location = new Point(245, 442);
		label21.Name = "label21";
		label21.Size = new Size(63, 29);
		label21.TabIndex = 326;
		label21.Text = "To-Go";
		label21.TextAlign = ContentAlignment.MiddleCenter;
		label18.BackColor = Color.FromArgb(132, 146, 146);
		label18.Font = new Font("Microsoft Sans Serif", 12f);
		label18.ForeColor = Color.White;
		label18.ImeMode = ImeMode.NoControl;
		label18.Location = new Point(130, 441);
		label18.Name = "label18";
		label18.Size = new Size(63, 29);
		label18.TabIndex = 324;
		label18.Text = "Dine-In";
		label18.TextAlign = ContentAlignment.MiddleCenter;
		uqfTqpqWbs.BackColor = Color.FromArgb(132, 146, 146);
		uqfTqpqWbs.Font = new Font("Microsoft Sans Serif", 12f);
		uqfTqpqWbs.ForeColor = Color.White;
		uqfTqpqWbs.ImeMode = ImeMode.NoControl;
		uqfTqpqWbs.Location = new Point(-1, 438);
		uqfTqpqWbs.Name = "label6";
		uqfTqpqWbs.Padding = new Padding(0, 0, 5, 0);
		uqfTqpqWbs.Size = new Size(90, 35);
		uqfTqpqWbs.TabIndex = 242;
		uqfTqpqWbs.Text = "FOR:";
		uqfTqpqWbs.TextAlign = ContentAlignment.MiddleRight;
		btnCopySun.BackColor = Color.FromArgb(77, 174, 225);
		btnCopySun.DialogResult = DialogResult.OK;
		btnCopySun.FlatAppearance.BorderColor = Color.Black;
		btnCopySun.FlatAppearance.BorderSize = 0;
		btnCopySun.FlatStyle = FlatStyle.Flat;
		btnCopySun.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		btnCopySun.ForeColor = Color.White;
		btnCopySun.ImeMode = ImeMode.NoControl;
		btnCopySun.Location = new Point(896, 402);
		btnCopySun.MinimumSize = new Size(52, 35);
		btnCopySun.Name = "btnCopySun";
		btnCopySun.Size = new Size(118, 35);
		btnCopySun.TabIndex = 322;
		btnCopySun.Text = "COPY";
		btnCopySun.UseVisualStyleBackColor = false;
		btnCopySun.Click += btnCopyMon_Click;
		label32.BackColor = Color.FromArgb(132, 146, 146);
		label32.Font = new Font("Microsoft Sans Serif", 10f);
		label32.ForeColor = Color.White;
		label32.ImeMode = ImeMode.NoControl;
		label32.Location = new Point(375, 402);
		label32.Name = "label32";
		label32.Size = new Size(98, 35);
		label32.TabIndex = 321;
		label32.Text = "FROM";
		label32.TextAlign = ContentAlignment.MiddleCenter;
		label33.BackColor = Color.FromArgb(132, 146, 146);
		label33.Font = new Font("Microsoft Sans Serif", 10f);
		label33.ForeColor = Color.White;
		label33.ImeMode = ImeMode.NoControl;
		label33.Location = new Point(655, 402);
		label33.Name = "label33";
		label33.Size = new Size(60, 35);
		label33.TabIndex = 320;
		label33.Text = "TO";
		label33.TextAlign = ContentAlignment.MiddleCenter;
		btnCopySat.BackColor = Color.FromArgb(77, 174, 225);
		btnCopySat.DialogResult = DialogResult.OK;
		btnCopySat.FlatAppearance.BorderColor = Color.Black;
		btnCopySat.FlatAppearance.BorderSize = 0;
		btnCopySat.FlatStyle = FlatStyle.Flat;
		btnCopySat.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		btnCopySat.ForeColor = Color.White;
		btnCopySat.ImeMode = ImeMode.NoControl;
		btnCopySat.Location = new Point(896, 366);
		btnCopySat.MinimumSize = new Size(52, 35);
		btnCopySat.Name = "btnCopySat";
		btnCopySat.Size = new Size(118, 35);
		btnCopySat.TabIndex = 317;
		btnCopySat.Text = "COPY";
		btnCopySat.UseVisualStyleBackColor = false;
		btnCopySat.Click += btnCopyMon_Click;
		label30.BackColor = Color.FromArgb(132, 146, 146);
		label30.Font = new Font("Microsoft Sans Serif", 10f);
		label30.ForeColor = Color.White;
		label30.ImeMode = ImeMode.NoControl;
		label30.Location = new Point(375, 366);
		label30.Name = "label30";
		label30.Size = new Size(98, 35);
		label30.TabIndex = 316;
		label30.Text = "FROM";
		label30.TextAlign = ContentAlignment.MiddleCenter;
		label31.BackColor = Color.FromArgb(132, 146, 146);
		label31.Font = new Font("Microsoft Sans Serif", 10f);
		label31.ForeColor = Color.White;
		label31.ImeMode = ImeMode.NoControl;
		label31.Location = new Point(655, 366);
		label31.Name = "label31";
		label31.Size = new Size(60, 35);
		label31.TabIndex = 315;
		label31.Text = "TO";
		label31.TextAlign = ContentAlignment.MiddleCenter;
		btnCopyFri.BackColor = Color.FromArgb(77, 174, 225);
		btnCopyFri.DialogResult = DialogResult.OK;
		btnCopyFri.FlatAppearance.BorderColor = Color.Black;
		btnCopyFri.FlatAppearance.BorderSize = 0;
		btnCopyFri.FlatStyle = FlatStyle.Flat;
		btnCopyFri.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		btnCopyFri.ForeColor = Color.White;
		btnCopyFri.ImeMode = ImeMode.NoControl;
		btnCopyFri.Location = new Point(896, 330);
		btnCopyFri.MinimumSize = new Size(52, 35);
		btnCopyFri.Name = "btnCopyFri";
		btnCopyFri.Size = new Size(118, 35);
		btnCopyFri.TabIndex = 312;
		btnCopyFri.Text = "COPY";
		btnCopyFri.UseVisualStyleBackColor = false;
		btnCopyFri.Click += btnCopyMon_Click;
		label28.BackColor = Color.FromArgb(132, 146, 146);
		label28.Font = new Font("Microsoft Sans Serif", 10f);
		label28.ForeColor = Color.White;
		label28.ImeMode = ImeMode.NoControl;
		label28.Location = new Point(375, 330);
		label28.Name = "label28";
		label28.Size = new Size(98, 35);
		label28.TabIndex = 311;
		label28.Text = "FROM";
		label28.TextAlign = ContentAlignment.MiddleCenter;
		label29.BackColor = Color.FromArgb(132, 146, 146);
		label29.Font = new Font("Microsoft Sans Serif", 10f);
		label29.ForeColor = Color.White;
		label29.ImeMode = ImeMode.NoControl;
		label29.Location = new Point(655, 330);
		label29.Name = "label29";
		label29.Size = new Size(60, 35);
		label29.TabIndex = 310;
		label29.Text = "TO";
		label29.TextAlign = ContentAlignment.MiddleCenter;
		btnCopyThu.BackColor = Color.FromArgb(77, 174, 225);
		btnCopyThu.DialogResult = DialogResult.OK;
		btnCopyThu.FlatAppearance.BorderColor = Color.Black;
		btnCopyThu.FlatAppearance.BorderSize = 0;
		btnCopyThu.FlatStyle = FlatStyle.Flat;
		btnCopyThu.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		btnCopyThu.ForeColor = Color.White;
		btnCopyThu.ImeMode = ImeMode.NoControl;
		btnCopyThu.Location = new Point(896, 294);
		btnCopyThu.MinimumSize = new Size(52, 35);
		btnCopyThu.Name = "btnCopyThu";
		btnCopyThu.Size = new Size(118, 35);
		btnCopyThu.TabIndex = 307;
		btnCopyThu.Text = "COPY";
		btnCopyThu.UseVisualStyleBackColor = false;
		btnCopyThu.Click += btnCopyMon_Click;
		label16.BackColor = Color.FromArgb(132, 146, 146);
		label16.Font = new Font("Microsoft Sans Serif", 10f);
		label16.ForeColor = Color.White;
		label16.ImeMode = ImeMode.NoControl;
		label16.Location = new Point(375, 294);
		label16.Name = "label16";
		label16.Size = new Size(98, 35);
		label16.TabIndex = 306;
		label16.Text = "FROM";
		label16.TextAlign = ContentAlignment.MiddleCenter;
		label27.BackColor = Color.FromArgb(132, 146, 146);
		label27.Font = new Font("Microsoft Sans Serif", 10f);
		label27.ForeColor = Color.White;
		label27.ImeMode = ImeMode.NoControl;
		label27.Location = new Point(655, 294);
		label27.Name = "label27";
		label27.Size = new Size(60, 35);
		label27.TabIndex = 305;
		label27.Text = "TO";
		label27.TextAlign = ContentAlignment.MiddleCenter;
		btnCopyWed.BackColor = Color.FromArgb(77, 174, 225);
		btnCopyWed.DialogResult = DialogResult.OK;
		btnCopyWed.FlatAppearance.BorderColor = Color.Black;
		btnCopyWed.FlatAppearance.BorderSize = 0;
		btnCopyWed.FlatStyle = FlatStyle.Flat;
		btnCopyWed.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		btnCopyWed.ForeColor = Color.White;
		btnCopyWed.ImeMode = ImeMode.NoControl;
		btnCopyWed.Location = new Point(896, 258);
		btnCopyWed.MinimumSize = new Size(52, 35);
		btnCopyWed.Name = "btnCopyWed";
		btnCopyWed.Size = new Size(118, 35);
		btnCopyWed.TabIndex = 302;
		btnCopyWed.Text = "COPY";
		btnCopyWed.UseVisualStyleBackColor = false;
		btnCopyWed.Click += btnCopyMon_Click;
		label14.BackColor = Color.FromArgb(132, 146, 146);
		label14.Font = new Font("Microsoft Sans Serif", 10f);
		label14.ForeColor = Color.White;
		label14.ImeMode = ImeMode.NoControl;
		label14.Location = new Point(375, 258);
		label14.Name = "label14";
		label14.Size = new Size(98, 35);
		label14.TabIndex = 301;
		label14.Text = "FROM";
		label14.TextAlign = ContentAlignment.MiddleCenter;
		label15.BackColor = Color.FromArgb(132, 146, 146);
		label15.Font = new Font("Microsoft Sans Serif", 10f);
		label15.ForeColor = Color.White;
		label15.ImeMode = ImeMode.NoControl;
		label15.Location = new Point(655, 258);
		label15.Name = "label15";
		label15.Size = new Size(60, 35);
		label15.TabIndex = 300;
		label15.Text = "TO";
		label15.TextAlign = ContentAlignment.MiddleCenter;
		btnCopyTue.BackColor = Color.FromArgb(77, 174, 225);
		btnCopyTue.DialogResult = DialogResult.OK;
		btnCopyTue.FlatAppearance.BorderColor = Color.Black;
		btnCopyTue.FlatAppearance.BorderSize = 0;
		btnCopyTue.FlatStyle = FlatStyle.Flat;
		btnCopyTue.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		btnCopyTue.ForeColor = Color.White;
		btnCopyTue.ImeMode = ImeMode.NoControl;
		btnCopyTue.Location = new Point(896, 222);
		btnCopyTue.MinimumSize = new Size(52, 35);
		btnCopyTue.Name = "btnCopyTue";
		btnCopyTue.Size = new Size(118, 35);
		btnCopyTue.TabIndex = 297;
		btnCopyTue.Text = "COPY";
		btnCopyTue.UseVisualStyleBackColor = false;
		btnCopyTue.Click += btnCopyMon_Click;
		label12.BackColor = Color.FromArgb(132, 146, 146);
		label12.Font = new Font("Microsoft Sans Serif", 10f);
		label12.ForeColor = Color.White;
		label12.ImeMode = ImeMode.NoControl;
		label12.Location = new Point(375, 222);
		label12.Name = "label12";
		label12.Size = new Size(98, 35);
		label12.TabIndex = 296;
		label12.Text = "FROM";
		label12.TextAlign = ContentAlignment.MiddleCenter;
		label13.BackColor = Color.FromArgb(132, 146, 146);
		label13.Font = new Font("Microsoft Sans Serif", 10f);
		label13.ForeColor = Color.White;
		label13.ImeMode = ImeMode.NoControl;
		label13.Location = new Point(655, 222);
		label13.Name = "label13";
		label13.Size = new Size(60, 35);
		label13.TabIndex = 295;
		label13.Text = "TO";
		label13.TextAlign = ContentAlignment.MiddleCenter;
		btnCopyMon.BackColor = Color.FromArgb(77, 174, 225);
		btnCopyMon.DialogResult = DialogResult.OK;
		btnCopyMon.FlatAppearance.BorderColor = Color.Black;
		btnCopyMon.FlatAppearance.BorderSize = 0;
		btnCopyMon.FlatStyle = FlatStyle.Flat;
		btnCopyMon.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		btnCopyMon.ForeColor = Color.White;
		btnCopyMon.ImeMode = ImeMode.NoControl;
		btnCopyMon.Location = new Point(896, 186);
		btnCopyMon.MinimumSize = new Size(52, 35);
		btnCopyMon.Name = "btnCopyMon";
		btnCopyMon.Size = new Size(118, 35);
		btnCopyMon.TabIndex = 292;
		btnCopyMon.Text = "COPY";
		btnCopyMon.UseVisualStyleBackColor = false;
		btnCopyMon.Click += btnCopyMon_Click;
		label11.BackColor = Color.FromArgb(132, 146, 146);
		label11.Font = new Font("Microsoft Sans Serif", 10f);
		label11.ForeColor = Color.White;
		label11.ImeMode = ImeMode.NoControl;
		label11.Location = new Point(375, 186);
		label11.Name = "label11";
		label11.Size = new Size(98, 35);
		label11.TabIndex = 291;
		label11.Text = "FROM";
		label11.TextAlign = ContentAlignment.MiddleCenter;
		label10.BackColor = Color.FromArgb(132, 146, 146);
		label10.Font = new Font("Microsoft Sans Serif", 10f);
		label10.ForeColor = Color.White;
		label10.ImeMode = ImeMode.NoControl;
		label10.Location = new Point(655, 186);
		label10.Name = "label10";
		label10.Size = new Size(60, 35);
		label10.TabIndex = 290;
		label10.Text = "TO";
		label10.TextAlign = ContentAlignment.MiddleCenter;
		label26.BackColor = Color.FromArgb(150, 166, 166);
		label26.Font = new Font("Microsoft Sans Serif", 18f);
		label26.ForeColor = Color.White;
		label26.ImeMode = ImeMode.NoControl;
		label26.Location = new Point(0, 115);
		label26.Name = "label26";
		label26.Size = new Size(872, 35);
		label26.TabIndex = 287;
		label26.TextAlign = ContentAlignment.MiddleCenter;
		((Control)(object)txtPromoCode).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		((Control)(object)txtPromoCode).Location = new Point(158, 79);
		txtPromoCode.set_MaxLength(255);
		((Control)(object)txtPromoCode).Name = "txtPromoCode";
		((RadElement)((RadControl)txtPromoCode).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtPromoCode).Size = new Size(441, 35);
		((Control)(object)txtPromoCode).TabIndex = 286;
		((Control)(object)txtPromoCode).Click += txtPromoCode_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtPromoCode).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtPromoCode).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		((Control)(object)txtPromoName).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		((Control)(object)txtPromoName).Location = new Point(158, 43);
		txtPromoName.set_MaxLength(255);
		((Control)(object)txtPromoName).Name = "txtPromoName";
		((RadElement)((RadControl)txtPromoName).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtPromoName).Size = new Size(666, 35);
		((Control)(object)txtPromoName).TabIndex = 284;
		((Control)(object)txtPromoName).Click += txtPromoName_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtPromoName).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtPromoName).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		label25.BackColor = Color.FromArgb(132, 146, 146);
		label25.Font = new Font("Microsoft Sans Serif", 12f);
		label25.ForeColor = Color.White;
		label25.ImeMode = ImeMode.NoControl;
		label25.Location = new Point(-1, 79);
		label25.Name = "label25";
		label25.Padding = new Padding(0, 0, 5, 0);
		label25.Size = new Size(158, 35);
		label25.TabIndex = 283;
		label25.Text = "Promo Code";
		label25.TextAlign = ContentAlignment.MiddleRight;
		label5.BackColor = Color.FromArgb(132, 146, 146);
		label5.Font = new Font("Microsoft Sans Serif", 12f);
		label5.ForeColor = Color.White;
		label5.ImeMode = ImeMode.NoControl;
		label5.Location = new Point(-1, 43);
		label5.Name = "label5";
		label5.Padding = new Padding(0, 0, 5, 0);
		label5.Size = new Size(158, 35);
		label5.TabIndex = 282;
		label5.Text = "Promo Name";
		label5.TextAlign = ContentAlignment.MiddleRight;
		lblOriginalPrice.BackColor = Color.FromArgb(132, 146, 146);
		lblOriginalPrice.Font = new Font("Microsoft Sans Serif", 12f);
		lblOriginalPrice.ForeColor = Color.White;
		lblOriginalPrice.ImeMode = ImeMode.NoControl;
		lblOriginalPrice.Location = new Point(194, 474);
		lblOriginalPrice.Name = "lblOriginalPrice";
		lblOriginalPrice.Padding = new Padding(0, 0, 5, 0);
		lblOriginalPrice.Size = new Size(301, 35);
		lblOriginalPrice.TabIndex = 278;
		lblOriginalPrice.Text = "OF THE ITEMS BELOW";
		lblOriginalPrice.TextAlign = ContentAlignment.MiddleCenter;
		btnSave.BackColor = Color.FromArgb(65, 168, 95);
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatStyle = FlatStyle.Flat;
		btnSave.Font = new Font("Microsoft Sans Serif", 10f);
		btnSave.ForeColor = SystemColors.ButtonFace;
		btnSave.Image = (Image)componentResourceManager.GetObject("btnSave.Image");
		btnSave.ImeMode = ImeMode.NoControl;
		btnSave.Location = new Point(873, 42);
		btnSave.Name = "btnSave";
		btnSave.Size = new Size(141, 71);
		btnSave.TabIndex = 276;
		btnSave.Text = "SAVE";
		btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		label22.BackColor = Color.FromArgb(132, 146, 146);
		label22.Font = new Font("Microsoft Sans Serif", 18f);
		label22.ForeColor = Color.White;
		label22.ImeMode = ImeMode.NoControl;
		label22.Location = new Point(0, 438);
		label22.Name = "label22";
		label22.Size = new Size(1014, 35);
		label22.TabIndex = 272;
		label22.TextAlign = ContentAlignment.MiddleCenter;
		label20.BackColor = Color.FromArgb(150, 166, 166);
		label20.Font = new Font("Microsoft Sans Serif", 18f);
		label20.ForeColor = Color.White;
		label20.ImeMode = ImeMode.NoControl;
		label20.Location = new Point(655, 151);
		label20.Name = "label20";
		label20.Size = new Size(217, 34);
		label20.TabIndex = 269;
		label20.TextAlign = ContentAlignment.MiddleCenter;
		label19.BackColor = Color.FromArgb(150, 166, 166);
		label19.Font = new Font("Microsoft Sans Serif", 18f);
		label19.ForeColor = Color.White;
		label19.ImeMode = ImeMode.NoControl;
		label19.Location = new Point(0, 222);
		label19.Name = "label19";
		label19.Size = new Size(231, 215);
		label19.TabIndex = 268;
		label19.TextAlign = ContentAlignment.MiddleCenter;
		((Control)(object)chkDaySale).Location = new Point(159, 186);
		((Control)(object)chkDaySale).Name = "chkDaySale";
		((Control)(object)chkDaySale).Size = new Size(72, 35);
		((Control)(object)chkDaySale).TabIndex = 265;
		chkDaySale.set_ToggleStateMode((ToggleStateMode)1);
		chkDaySale.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkDaySale).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkDaySale).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkDaySale).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkDaySale).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkDaySale).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkDaySale).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkDaySale).GetChildAt(0).GetChildAt(0)).set_Text("ON");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkDaySale).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		((Control)(object)chkDateRange).Location = new Point(159, 150);
		((Control)(object)chkDateRange).Name = "chkDateRange";
		((Control)(object)chkDateRange).Size = new Size(72, 35);
		((Control)(object)chkDateRange).TabIndex = 264;
		chkDateRange.set_ToggleStateMode((ToggleStateMode)1);
		chkDateRange.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkDateRange).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkDateRange).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkDateRange).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkDateRange).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkDateRange).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkDateRange).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkDateRange).GetChildAt(0).GetChildAt(0)).set_Text("ON");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkDateRange).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		panel1.Controls.Add((Control)(object)chkSun);
		panel1.Controls.Add((Control)(object)chkWed);
		panel1.Controls.Add((Control)(object)chkTue);
		panel1.Controls.Add((Control)(object)chkMon);
		panel1.Controls.Add((Control)(object)chkThu);
		panel1.Controls.Add((Control)(object)chkFri);
		panel1.Controls.Add((Control)(object)chkSat);
		panel1.Location = new Point(232, 185);
		panel1.Margin = new Padding(2);
		panel1.Name = "panel1";
		panel1.Size = new Size(142, 257);
		panel1.TabIndex = 246;
		((Control)(object)chkSun).Font = new Font("Segoe UI", 10f);
		((Control)(object)chkSun).Location = new Point(0, 217);
		((Control)(object)chkSun).Name = "chkSun";
		chkSun.set_OffText("SUNDAY OFF");
		chkSun.set_OnText("SUNDAY ON");
		((Control)(object)chkSun).Size = new Size(142, 35);
		((Control)(object)chkSun).TabIndex = 218;
		((Control)(object)chkSun).Tag = "SundaySale";
		((Control)(object)chkSun).Text = "Sunday";
		chkSun.set_ToggleStateMode((ToggleStateMode)1);
		chkSun.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkSun).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkSun).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkSun).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkSun).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkSun).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkSun).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkSun).GetChildAt(0).GetChildAt(0)).set_Text("SUNDAY ON");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkSun).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		((Control)(object)chkWed).Font = new Font("Segoe UI", 10f);
		((Control)(object)chkWed).Location = new Point(0, 73);
		((Control)(object)chkWed).Name = "chkWed";
		chkWed.set_OffText("WEDNESDAY OFF");
		chkWed.set_OnText("WEDNESDAY ON");
		((Control)(object)chkWed).Size = new Size(142, 35);
		((Control)(object)chkWed).TabIndex = 214;
		((Control)(object)chkWed).Tag = "WednesdaySale";
		((Control)(object)chkWed).Text = "Wednesday";
		chkWed.set_ToggleStateMode((ToggleStateMode)1);
		chkWed.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkWed).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkWed).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkWed).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkWed).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkWed).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkWed).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkWed).GetChildAt(0).GetChildAt(0)).set_Text("WEDNESDAY ON");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkWed).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		((Control)(object)chkTue).Font = new Font("Segoe UI", 10f);
		((Control)(object)chkTue).Location = new Point(0, 37);
		((Control)(object)chkTue).Name = "chkTue";
		chkTue.set_OffText("TUESDAY OFF");
		chkTue.set_OnText("TUESDAY ON");
		((Control)(object)chkTue).Size = new Size(142, 35);
		((Control)(object)chkTue).TabIndex = 213;
		((Control)(object)chkTue).Tag = "TuesdaySale";
		((Control)(object)chkTue).Text = "Tuesday";
		chkTue.set_ToggleStateMode((ToggleStateMode)1);
		chkTue.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkTue).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkTue).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkTue).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTue).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTue).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTue).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkTue).GetChildAt(0).GetChildAt(0)).set_Text("TUESDAY ON");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkTue).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		((Control)(object)chkMon).Font = new Font("Segoe UI", 10f);
		((Control)(object)chkMon).Location = new Point(0, 1);
		((Control)(object)chkMon).Name = "chkMon";
		chkMon.set_OffText("MONDAY OFF");
		chkMon.set_OnText("MONDAY ON");
		((Control)(object)chkMon).Size = new Size(142, 35);
		((Control)(object)chkMon).TabIndex = 212;
		((Control)(object)chkMon).Tag = "MondaySale";
		((Control)(object)chkMon).Text = "Monday";
		chkMon.set_ToggleStateMode((ToggleStateMode)1);
		chkMon.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkMon).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkMon).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkMon).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkMon).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkMon).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkMon).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkMon).GetChildAt(0).GetChildAt(0)).set_Text("MONDAY ON");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkMon).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		((Control)(object)chkThu).Font = new Font("Segoe UI", 10f);
		((Control)(object)chkThu).Location = new Point(0, 109);
		((Control)(object)chkThu).Name = "chkThu";
		chkThu.set_OffText("THURSDAY OFF");
		chkThu.set_OnText("THURSDAY ON");
		((Control)(object)chkThu).Size = new Size(142, 35);
		((Control)(object)chkThu).TabIndex = 215;
		((Control)(object)chkThu).Tag = "ThursdaySale";
		((Control)(object)chkThu).Text = "Thursday";
		chkThu.set_ToggleStateMode((ToggleStateMode)1);
		chkThu.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkThu).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkThu).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkThu).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkThu).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkThu).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkThu).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkThu).GetChildAt(0).GetChildAt(0)).set_Text("THURSDAY ON");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkThu).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		((Control)(object)chkFri).Font = new Font("Segoe UI", 10f);
		((Control)(object)chkFri).Location = new Point(0, 145);
		((Control)(object)chkFri).Name = "chkFri";
		chkFri.set_OffText("FRIDAY OFF");
		chkFri.set_OnText("FRIDAY ON");
		((Control)(object)chkFri).Size = new Size(142, 35);
		((Control)(object)chkFri).TabIndex = 216;
		((Control)(object)chkFri).Tag = "FridaySale";
		((Control)(object)chkFri).Text = "Friday";
		chkFri.set_ToggleStateMode((ToggleStateMode)1);
		chkFri.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkFri).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkFri).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkFri).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkFri).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkFri).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkFri).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkFri).GetChildAt(0).GetChildAt(0)).set_Text("FRIDAY ON");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkFri).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		((Control)(object)chkSat).Font = new Font("Segoe UI", 10f);
		((Control)(object)chkSat).Location = new Point(0, 181);
		((Control)(object)chkSat).Name = "chkSat";
		chkSat.set_OffText("SATURDAY OFF");
		chkSat.set_OnText("SATURDAY ON");
		((Control)(object)chkSat).Size = new Size(142, 35);
		((Control)(object)chkSat).TabIndex = 217;
		((Control)(object)chkSat).Tag = "SaturdaySale";
		((Control)(object)chkSat).Text = "Saturday";
		chkSat.set_ToggleStateMode((ToggleStateMode)1);
		chkSat.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkSat).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkSat).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkSat).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkSat).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkSat).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkSat).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkSat).GetChildAt(0).GetChildAt(0)).set_Text("SATURDAY ON");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkSat).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		label8.BackColor = Color.FromArgb(132, 146, 146);
		label8.Font = new Font("Microsoft Sans Serif", 12f);
		label8.ForeColor = Color.White;
		label8.ImeMode = ImeMode.NoControl;
		label8.Location = new Point(0, 186);
		label8.Name = "label8";
		label8.Padding = new Padding(0, 0, 5, 0);
		label8.Size = new Size(158, 35);
		label8.TabIndex = 245;
		label8.Text = "Day Sale";
		label8.TextAlign = ContentAlignment.MiddleRight;
		label2.BackColor = Color.FromArgb(132, 146, 146);
		label2.Font = new Font("Microsoft Sans Serif", 12f);
		label2.ForeColor = Color.White;
		label2.ImeMode = ImeMode.NoControl;
		label2.Location = new Point(0, 150);
		label2.Name = "label2";
		label2.Padding = new Padding(0, 0, 5, 0);
		label2.Size = new Size(158, 35);
		label2.TabIndex = 238;
		label2.Text = "Date Range";
		label2.TextAlign = ContentAlignment.MiddleRight;
		lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblTitle.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		lblTitle.ForeColor = Color.White;
		lblTitle.ImeMode = ImeMode.NoControl;
		lblTitle.Location = new Point(-7, -4);
		lblTitle.Name = "lblTitle";
		lblTitle.Size = new Size(1021, 46);
		lblTitle.TabIndex = 237;
		lblTitle.Text = "PROMOTION SETUP";
		lblTitle.TextAlign = ContentAlignment.MiddleCenter;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		label1.Font = new Font("Microsoft Sans Serif", 10f);
		label1.ForeColor = Color.White;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(413, 150);
		label1.Name = "label1";
		label1.Size = new Size(60, 35);
		label1.TabIndex = 236;
		label1.Text = "TO";
		label1.TextAlign = ContentAlignment.MiddleCenter;
		btnClose.BackColor = Color.FromArgb(235, 107, 86);
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatStyle = FlatStyle.Flat;
		btnClose.Font = new Font("Microsoft Sans Serif", 10f);
		btnClose.ForeColor = SystemColors.ButtonFace;
		btnClose.Image = (Image)componentResourceManager.GetObject("btnClose.Image");
		btnClose.ImeMode = ImeMode.NoControl;
		btnClose.Location = new Point(873, 114);
		btnClose.Name = "btnClose";
		btnClose.Size = new Size(141, 71);
		btnClose.TabIndex = 235;
		btnClose.Text = "CLOSE";
		btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnClose.UseVisualStyleBackColor = false;
		btnClose.Click += btnClose_Click;
		pnlItems2.AutoScroll = true;
		pnlItems2.BackColor = Color.White;
		pnlItems2.Location = new Point(496, 545);
		pnlItems2.Margin = new Padding(10);
		pnlItems2.Name = "pnlItems2";
		pnlItems2.Padding = new Padding(10);
		pnlItems2.Size = new Size(494, 225);
		pnlItems2.TabIndex = 348;
		endDate.CalendarFont = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
		endDate.Checked = false;
		endDate.CustomFormat = "MM/dd/yyyy";
		endDate.Font = new Font("Microsoft Sans Serif", 18f);
		endDate.Format = DateTimePickerFormat.Short;
		endDate.Location = new Point(474, 151);
		endDate.Name = "endDate";
		endDate.Size = new Size(180, 35);
		endDate.TabIndex = 355;
		endDate.Value = new DateTime(2019, 10, 24, 0, 0, 0, 0);
		startDate.CalendarFont = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, 0);
		startDate.Checked = false;
		startDate.CustomFormat = "MM/dd/yyyy";
		startDate.Font = new Font("Microsoft Sans Serif", 18f);
		startDate.Format = DateTimePickerFormat.Short;
		startDate.Location = new Point(232, 151);
		startDate.Name = "startDate";
		startDate.Size = new Size(180, 35);
		startDate.TabIndex = 354;
		startDate.Value = new DateTime(2019, 10, 24, 0, 0, 0, 0);
		startDate.ValueChanged += startDate_ValueChanged;
		scrollItem2.BackColor = Color.Transparent;
		scrollItem2.ButtonDownEventOverride = null;
		scrollItem2.ButtonLastEventOverride = null;
		scrollItem2.ButtonStyle = "twobuttons";
		scrollItem2.ConnectedPanel = null;
		scrollItem2.ConnectedRadListView = null;
		scrollItem2.inputedHeight = 0;
		scrollItem2.inputedWidth = 0;
		scrollItem2.Location = new Point(964, 545);
		scrollItem2.MaximumSize = new Size(50, 2000);
		scrollItem2.MinimumSize = new Size(50, 100);
		scrollItem2.Name = "scrollItem2";
		scrollItem2.Size = new Size(50, 225);
		scrollItem2.TabIndex = 347;
		scrollItem1.BackColor = Color.Transparent;
		scrollItem1.ButtonDownEventOverride = null;
		scrollItem1.ButtonLastEventOverride = null;
		scrollItem1.ButtonStyle = "twobuttons";
		scrollItem1.ConnectedPanel = null;
		scrollItem1.ConnectedRadListView = null;
		scrollItem1.inputedHeight = 0;
		scrollItem1.inputedWidth = 0;
		scrollItem1.Location = new Point(445, 545);
		scrollItem1.MaximumSize = new Size(50, 2000);
		scrollItem1.MinimumSize = new Size(50, 100);
		scrollItem1.Name = "scrollItem1";
		scrollItem1.Size = new Size(50, 225);
		scrollItem1.TabIndex = 346;
		((Control)(object)ddlGroup2).AutoSize = false;
		((Control)(object)ddlGroup2).BackColor = Color.White;
		((RadDropDownList)ddlGroup2).set_DropDownStyle((RadDropDownStyle)2);
		((RadDropDownList)ddlGroup2).set_EnableKineticScrolling(true);
		((Control)(object)ddlGroup2).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		((Control)(object)ddlGroup2).Location = new Point(616, 510);
		((Control)(object)ddlGroup2).Margin = new Padding(4, 5, 4, 5);
		((Control)(object)ddlGroup2).Name = "ddlGroup2";
		((RadElement)((RadControl)ddlGroup2).get_RootElement()).set_MinSize(new Size(0, 0));
		((Control)(object)ddlGroup2).Size = new Size(398, 34);
		((Control)(object)ddlGroup2).TabIndex = 344;
		((Control)(object)ddlGroup2).Tag = "product";
		((RadControl)ddlGroup2).set_ThemeName("Windows8");
		((RadDropDownList)ddlGroup2).add_SelectedIndexChanged(new PositionChangedEventHandler(ddlGroup2_SelectedIndexChanged));
		((Control)(object)ddlGroup1).AutoSize = false;
		((Control)(object)ddlGroup1).BackColor = Color.White;
		((RadDropDownList)ddlGroup1).set_DropDownStyle((RadDropDownStyle)2);
		((RadDropDownList)ddlGroup1).set_EnableKineticScrolling(true);
		((Control)(object)ddlGroup1).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		((Control)(object)ddlGroup1).Location = new Point(126, 510);
		((Control)(object)ddlGroup1).Margin = new Padding(4, 5, 4, 5);
		((Control)(object)ddlGroup1).Name = "ddlGroup1";
		((RadElement)((RadControl)ddlGroup1).get_RootElement()).set_MinSize(new Size(0, 0));
		((Control)(object)ddlGroup1).Size = new Size(369, 34);
		((Control)(object)ddlGroup1).TabIndex = 342;
		((Control)(object)ddlGroup1).Tag = "product";
		((RadControl)ddlGroup1).set_ThemeName("Windows8");
		((RadDropDownList)ddlGroup1).add_SelectedIndexChanged(new PositionChangedEventHandler(ddlGroup1_SelectedIndexChanged));
		((Control)(object)ddlTender).AutoSize = false;
		((Control)(object)ddlTender).BackColor = Color.White;
		((RadDropDownList)ddlTender).set_DropDownStyle((RadDropDownStyle)2);
		((RadDropDownList)ddlTender).set_EnableKineticScrolling(true);
		((Control)(object)ddlTender).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		((Control)(object)ddlTender).Location = new Point(888, 474);
		((Control)(object)ddlTender).Margin = new Padding(4, 5, 4, 5);
		((Control)(object)ddlTender).Name = "ddlTender";
		((RadElement)((RadControl)ddlTender).get_RootElement()).set_MinSize(new Size(0, 0));
		((Control)(object)ddlTender).Size = new Size(58, 35);
		((Control)(object)ddlTender).TabIndex = 339;
		((Control)(object)ddlTender).Tag = "product";
		((RadControl)ddlTender).set_ThemeName("Windows8");
		((RadDropDownList)ddlTender).add_SelectedIndexChanged(new PositionChangedEventHandler(ddlTender_SelectedIndexChanged));
		((Control)(object)ddlGetIt).AutoSize = false;
		((Control)(object)ddlGetIt).BackColor = Color.White;
		((RadDropDownList)ddlGetIt).set_DropDownStyle((RadDropDownStyle)2);
		((RadDropDownList)ddlGetIt).set_EnableKineticScrolling(true);
		((Control)(object)ddlGetIt).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		((Control)(object)ddlGetIt).Location = new Point(587, 474);
		((Control)(object)ddlGetIt).Margin = new Padding(4, 5, 4, 5);
		((Control)(object)ddlGetIt).Name = "ddlGetIt";
		((RadElement)((RadControl)ddlGetIt).get_RootElement()).set_MinSize(new Size(0, 0));
		((Control)(object)ddlGetIt).Size = new Size(67, 35);
		((Control)(object)ddlGetIt).TabIndex = 335;
		((Control)(object)ddlGetIt).Tag = "product";
		((RadControl)ddlGetIt).set_ThemeName("Windows8");
		((RadDropDownList)ddlGetIt).add_SelectedIndexChanged(new PositionChangedEventHandler(ddlGetIt_SelectedIndexChanged));
		chkDelivery.Location = new Point(446, 441);
		chkDelivery.Name = "chkDelivery";
		chkDelivery.Size = new Size(30, 30);
		chkDelivery.TabIndex = 329;
		chkDelivery.Text = "customCheckbox4";
		chkDelivery.TextAlign = ContentAlignment.MiddleRight;
		chkDelivery.UseVisualStyleBackColor = true;
		chkPickup.Location = new Point(322, 441);
		chkPickup.Name = "chkPickup";
		chkPickup.Size = new Size(30, 30);
		chkPickup.TabIndex = 327;
		chkPickup.Text = "customCheckbox3";
		chkPickup.TextAlign = ContentAlignment.MiddleRight;
		chkPickup.UseVisualStyleBackColor = true;
		chkTogo.Location = new Point(210, 441);
		chkTogo.Name = "chkTogo";
		chkTogo.Size = new Size(30, 30);
		chkTogo.TabIndex = 325;
		chkTogo.Text = "customCheckbox2";
		chkTogo.TextAlign = ContentAlignment.MiddleRight;
		chkTogo.UseVisualStyleBackColor = true;
		chkDineIn.Location = new Point(95, 440);
		chkDineIn.Name = "chkDineIn";
		chkDineIn.Size = new Size(30, 30);
		chkDineIn.TabIndex = 323;
		chkDineIn.Text = "customCheckbox1";
		chkDineIn.TextAlign = ContentAlignment.MiddleRight;
		chkDineIn.UseVisualStyleBackColor = true;
		fromMon.CalendarFont = new Font("Microsoft Sans Serif", 18f);
		fromMon.Font = new Font("Microsoft Sans Serif", 18f);
		fromMon.Format = DateTimePickerFormat.Time;
		fromMon.Location = new Point(474, 186);
		fromMon.Name = "fromMon";
		fromMon.ShowUpDown = true;
		fromMon.Size = new Size(180, 35);
		fromMon.TabIndex = 356;
		toMon.CalendarFont = new Font("Microsoft Sans Serif", 18f);
		toMon.Font = new Font("Microsoft Sans Serif", 18f);
		toMon.Format = DateTimePickerFormat.Time;
		toMon.Location = new Point(716, 186);
		toMon.Name = "toMon";
		toMon.ShowUpDown = true;
		toMon.Size = new Size(180, 35);
		toMon.TabIndex = 357;
		fromTue.CalendarFont = new Font("Microsoft Sans Serif", 18f);
		fromTue.Font = new Font("Microsoft Sans Serif", 18f);
		fromTue.Format = DateTimePickerFormat.Time;
		fromTue.Location = new Point(474, 222);
		fromTue.Name = "fromTue";
		fromTue.ShowUpDown = true;
		fromTue.Size = new Size(180, 35);
		fromTue.TabIndex = 358;
		toTue.CalendarFont = new Font("Microsoft Sans Serif", 18f);
		toTue.Font = new Font("Microsoft Sans Serif", 18f);
		toTue.Format = DateTimePickerFormat.Time;
		toTue.Location = new Point(716, 222);
		toTue.Name = "toTue";
		toTue.ShowUpDown = true;
		toTue.Size = new Size(180, 35);
		toTue.TabIndex = 359;
		fromWed.CalendarFont = new Font("Microsoft Sans Serif", 18f);
		fromWed.Font = new Font("Microsoft Sans Serif", 18f);
		fromWed.Format = DateTimePickerFormat.Time;
		fromWed.Location = new Point(474, 258);
		fromWed.Name = "fromWed";
		fromWed.ShowUpDown = true;
		fromWed.Size = new Size(180, 35);
		fromWed.TabIndex = 360;
		toWed.CalendarFont = new Font("Microsoft Sans Serif", 18f);
		toWed.Font = new Font("Microsoft Sans Serif", 18f);
		toWed.Format = DateTimePickerFormat.Time;
		toWed.Location = new Point(716, 258);
		toWed.Name = "toWed";
		toWed.ShowUpDown = true;
		toWed.Size = new Size(180, 35);
		toWed.TabIndex = 361;
		fromThu.CalendarFont = new Font("Microsoft Sans Serif", 18f);
		fromThu.Font = new Font("Microsoft Sans Serif", 18f);
		fromThu.Format = DateTimePickerFormat.Time;
		fromThu.Location = new Point(474, 294);
		fromThu.Name = "fromThu";
		fromThu.ShowUpDown = true;
		fromThu.Size = new Size(180, 35);
		fromThu.TabIndex = 362;
		toThu.CalendarFont = new Font("Microsoft Sans Serif", 18f);
		toThu.Font = new Font("Microsoft Sans Serif", 18f);
		toThu.Format = DateTimePickerFormat.Time;
		toThu.Location = new Point(716, 294);
		toThu.Name = "toThu";
		toThu.ShowUpDown = true;
		toThu.Size = new Size(180, 35);
		toThu.TabIndex = 363;
		fromFri.CalendarFont = new Font("Microsoft Sans Serif", 18f);
		fromFri.Font = new Font("Microsoft Sans Serif", 18f);
		fromFri.Format = DateTimePickerFormat.Time;
		fromFri.Location = new Point(474, 330);
		fromFri.Name = "fromFri";
		fromFri.ShowUpDown = true;
		fromFri.Size = new Size(180, 35);
		fromFri.TabIndex = 364;
		toFri.CalendarFont = new Font("Microsoft Sans Serif", 18f);
		toFri.Font = new Font("Microsoft Sans Serif", 18f);
		toFri.Format = DateTimePickerFormat.Time;
		toFri.Location = new Point(716, 330);
		toFri.Name = "toFri";
		toFri.ShowUpDown = true;
		toFri.Size = new Size(180, 35);
		toFri.TabIndex = 365;
		fromSat.CalendarFont = new Font("Microsoft Sans Serif", 18f);
		fromSat.Font = new Font("Microsoft Sans Serif", 18f);
		fromSat.Format = DateTimePickerFormat.Time;
		fromSat.Location = new Point(474, 366);
		fromSat.Name = "fromSat";
		fromSat.ShowUpDown = true;
		fromSat.Size = new Size(180, 35);
		fromSat.TabIndex = 366;
		fromSun.CalendarFont = new Font("Microsoft Sans Serif", 18f);
		fromSun.Font = new Font("Microsoft Sans Serif", 18f);
		fromSun.Format = DateTimePickerFormat.Time;
		fromSun.Location = new Point(474, 402);
		fromSun.Name = "fromSun";
		fromSun.ShowUpDown = true;
		fromSun.Size = new Size(180, 35);
		fromSun.TabIndex = 367;
		toSat.CalendarFont = new Font("Microsoft Sans Serif", 18f);
		toSat.Font = new Font("Microsoft Sans Serif", 18f);
		toSat.Format = DateTimePickerFormat.Time;
		toSat.Location = new Point(716, 366);
		toSat.Name = "toSat";
		toSat.ShowUpDown = true;
		toSat.Size = new Size(180, 35);
		toSat.TabIndex = 368;
		toSun.CalendarFont = new Font("Microsoft Sans Serif", 18f);
		toSun.Font = new Font("Microsoft Sans Serif", 18f);
		toSun.Format = DateTimePickerFormat.Time;
		toSun.Location = new Point(716, 402);
		toSun.Name = "toSun";
		toSun.ShowUpDown = true;
		toSun.Size = new Size(180, 35);
		toSun.TabIndex = 369;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(1017, 768);
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
		base.Controls.Add(endDate);
		base.Controls.Add(startDate);
		base.Controls.Add(lblDisableGETItems);
		base.Controls.Add(btnShowKeyboard_PromoCode);
		base.Controls.Add(btnShowKeyboard_PromoName);
		base.Controls.Add((Control)(object)chkActive);
		base.Controls.Add(label3);
		base.Controls.Add(scrollItem2);
		base.Controls.Add(scrollItem1);
		base.Controls.Add(pnlItems1);
		base.Controls.Add((Control)(object)ddlGroup2);
		base.Controls.Add(label41);
		base.Controls.Add((Control)(object)ddlGroup1);
		base.Controls.Add(label40);
		base.Controls.Add(label39);
		base.Controls.Add((Control)(object)ddlTender);
		base.Controls.Add(btnShowKeyboard_DiscountAmount);
		base.Controls.Add((Control)(object)txtDiscountAmount);
		base.Controls.Add(lblForItemsBelow);
		base.Controls.Add((Control)(object)ddlGetIt);
		base.Controls.Add(label37);
		base.Controls.Add(btnShowKeyboard_BuyQty);
		base.Controls.Add((Control)(object)txtBuyQty);
		base.Controls.Add(label36);
		base.Controls.Add(label35);
		base.Controls.Add(chkDelivery);
		base.Controls.Add(label34);
		base.Controls.Add(chkPickup);
		base.Controls.Add(label21);
		base.Controls.Add(chkTogo);
		base.Controls.Add(label18);
		base.Controls.Add(uqfTqpqWbs);
		base.Controls.Add(chkDineIn);
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
		base.Controls.Add(label26);
		base.Controls.Add((Control)(object)txtPromoCode);
		base.Controls.Add((Control)(object)txtPromoName);
		base.Controls.Add(label25);
		base.Controls.Add(label5);
		base.Controls.Add(lblOriginalPrice);
		base.Controls.Add(btnSave);
		base.Controls.Add(label22);
		base.Controls.Add(label20);
		base.Controls.Add(label19);
		base.Controls.Add((Control)(object)chkDaySale);
		base.Controls.Add((Control)(object)chkDateRange);
		base.Controls.Add(panel1);
		base.Controls.Add(label8);
		base.Controls.Add(label2);
		base.Controls.Add(lblTitle);
		base.Controls.Add(label1);
		base.Controls.Add(btnClose);
		base.Controls.Add(pnlItems2);
		base.Name = "frmAddEditPromotions";
		base.Opacity = 1.0;
		Text = "frmAddEditPromotions";
		base.WindowState = FormWindowState.Maximized;
		base.Load += frmAddEditPromotions_Load;
		((ISupportInitialize)chkActive).EndInit();
		((ISupportInitialize)txtDiscountAmount).EndInit();
		((ISupportInitialize)txtBuyQty).EndInit();
		((ISupportInitialize)txtPromoCode).EndInit();
		((ISupportInitialize)txtPromoName).EndInit();
		((ISupportInitialize)chkDaySale).EndInit();
		((ISupportInitialize)chkDateRange).EndInit();
		panel1.ResumeLayout(performLayout: false);
		((ISupportInitialize)chkSun).EndInit();
		((ISupportInitialize)chkWed).EndInit();
		((ISupportInitialize)chkTue).EndInit();
		((ISupportInitialize)chkMon).EndInit();
		((ISupportInitialize)chkThu).EndInit();
		((ISupportInitialize)chkFri).EndInit();
		((ISupportInitialize)chkSat).EndInit();
		((ISupportInitialize)ddlGroup2).EndInit();
		((ISupportInitialize)ddlGroup1).EndInit();
		((ISupportInitialize)ddlTender).EndInit();
		((ISupportInitialize)ddlGetIt).EndInit();
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private bool method_8(ItemsInGroup itemsInGroup_0)
	{
		return itemsInGroup_0.ItemID.ToString() == list_2[0];
	}

	[CompilerGenerated]
	private bool method_9(ItemsInGroup itemsInGroup_0)
	{
		return itemsInGroup_0.ItemID.ToString() == list_3[0];
	}
}
