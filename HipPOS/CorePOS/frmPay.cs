using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Methods.PaymentProcessors;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;
using Newtonsoft.Json;

namespace CorePOS;

public class frmPay : frmMasterForm
{
	private decimal decimal_0;

	private decimal decimal_1;

	private decimal decimal_2;

	private decimal decimal_3;

	private decimal decimal_4;

	private DataManager dataManager_0;

	private decimal decimal_5;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private List<Item> list_2;

	private List<ProcessorPaymentTypeWithId> list_3;

	private short short_0;

	private int int_0;

	private string string_4;

	private string string_5;

	private string string_6;

	private string string_7;

	private decimal decimal_6;

	private decimal decimal_7;

	private decimal decimal_8;

	private decimal decimal_9;

	private string string_8;

	private int? nullable_0;

	private int int_1;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private decimal decimal_10;

	private List<decimal> list_4;

	private decimal decimal_11;

	private List<GiftCardDetails> list_5;

	private string string_9;

	private bool bool_6;

	private string string_10;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private bool bool_13;

	private int int_2;

	private string string_11;

	private string string_12;

	private string string_13;

	private string string_14;

	private frmOrderEntry frmOrderEntry_0;

	private GClass6 gclass6_0;

	private Terminal terminal_0;

	private List<PaymentType> list_6;

	private decimal decimal_12;

	private decimal decimal_13;

	private int int_3;

	private IList<Stream> ilist_0;

	private IContainer icontainer_1;

	internal Button btnCancel;

	internal Label lblEmployee;

	internal Label Label9;

	internal TextBox txtChange;

	internal TextBox txtAmountDue;

	internal Button btnDone;

	internal Label Label6;

	internal Label Label5;

	internal ListView lstTenderTypes;

	internal ColumnHeader columnHeader_0;

	internal ColumnHeader columnHeader_1;

	internal Button btnDiscount;

	internal Button btnChangeEmployee;

	internal Button btnRemove;

	private Panel panel1;

	private Label lblWindowTitle;

	internal Button btnTaxDiscount;

	private Label label1;

	private Label sideLabel;

	internal Class18 txtInput;

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

	internal Button button3;

	internal Button Button7;

	internal Button Button6;

	internal Button btnExactChange;

	internal Button btnClear;

	private Panel pnlReceipt;

	private Label label16;

	internal Label lblDiscount;

	internal Label label12;

	internal Label lblTotal;

	internal Label lblTotalTax;

	internal Label lblSubTotal;

	internal Label label13;

	internal Label label14;

	internal Label label15;

	private Label label10;

	private Label label8;

	private Label label7;

	internal ListView lstItems;

	private ColumnHeader columnHeader_2;

	internal ColumnHeader columnHeader_3;

	private ColumnHeader columnHeader_4;

	private ColumnHeader columnHeader_5;

	private Label lblTrainingMode;

	private Label label2;

	private Label label3;

	internal Button btnPrintBill;

	internal Button button5;

	internal Label lblTotalGratuity;

	internal Label lblGratuity;

	internal Label label17;

	internal Label label18;

	internal Label lblTransactionFee;

	internal Label label11;

	private FlowLayoutPanel pnlTenderTypes;

	internal Button button9;

	internal Button btnOrderNotes;

	internal TextBox txtAmountDueRounded;

	internal Label lblAmountDueRounded;

	internal Button btnRemoveGratuity;

	public frmPay()
	{
		Class26.Ggkj0JxzN9YmC();
		string_4 = "";
		string_5 = "";
		string_6 = string.Empty;
		string_7 = string.Empty;
		string_8 = "";
		list_4 = new List<decimal>();
		list_5 = new List<GiftCardDetails>();
		string_9 = "VISA, MASTERCARD, MC, AMEX, AMERICAN EXPRESS, JCB, DISCOVER CARD, UNION PAY, DINERS CLUB";
		string_10 = string.Empty;
		string_11 = "Interac";
		string_12 = "en-US";
		string_13 = "$";
		string_14 = ".";
		gclass6_0 = new GClass6();
		decimal_12 = -1m;
		decimal_13 = -1m;
		base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		int num = 0;
		list_6 = gclass6_0.PaymentTypes.OrderBy((PaymentType x) => x.SortOrder).ToList();
		foreach (PaymentType item in list_6)
		{
			for (int i = 0; i < 14; i++)
			{
				if (num != item.SortOrder)
				{
					method_23(num);
					num++;
					continue;
				}
				method_22(item.Name, item.OpenCashDrawer, item.UsePaymentTerminal);
				num++;
				break;
			}
		}
		foreach (Button item2 in pnlTenderTypes.Controls.OfType<Button>().Cast<Control>().ToList())
		{
			if (!string.IsNullOrEmpty(item2.Text))
			{
				item2.EnabledChanged += btnDone_EnabledChanged;
			}
		}
	}

	public void LoadForm(frmOrderEntry frmOE, List<Item> itemList, decimal subTotal, decimal totalTax, string _customer = "", string _orderType = "Dine In", string _orderNum = "", string _customerInfo = "", string _customerInfoName = "", string _customerInfoPhone = "", decimal _discount = 0m, string _discountReason = "", decimal _discountPercentage = 0m)
	{
		list_6 = gclass6_0.PaymentTypes.OrderBy((PaymentType x) => x.SortOrder).ToList();
		string_12 = Thread.CurrentThread.CurrentCulture.Name;
		string_13 = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol;
		if (string.IsNullOrEmpty(string_13))
		{
			string_13 = "$";
		}
		string_14 = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
		if (string.IsNullOrEmpty(string_14))
		{
			string_14 = ".";
		}
		decimal_11 = (decimal_10 = (decimal_6 = (decimal_7 = (decimal_8 = 0m))));
		string_4 = (string_8 = (string_5 = (string_6 = (string_10 = ""))));
		btnCancel.Enabled = true;
		bool_5 = false;
		frmOrderEntry_0 = frmOE;
		txtInput.method_1(TextBoxTypes.numpad);
		if (string_12.Equals("fr-CA"))
		{
			sideLabel.Location = new Point(620, 342);
			txtInput.Location = new Point(407, 342);
		}
		list_4 = new List<decimal>();
		bool_0 = false;
		bool_13 = false;
		string_1 = string.Empty;
		list_2 = itemList;
		string_2 = _customer;
		string_3 = _orderType;
		dataManager_0 = new DataManager();
		decimal_1 = subTotal;
		decimal_3 = totalTax;
		decimal_5 = default(decimal);
		decimal_2 = _discount;
		decimal_12 = (decimal_13 = -1m);
		if (decimal_2 > 0m)
		{
			btnDiscount.Text = Resources.REMOVE_DISCOUNT;
		}
		else
		{
			btnDiscount.Text = Resources.DISCOUNT;
		}
		string_4 = _discountReason;
		string_5 = _customerInfo;
		string_6 = _customerInfoName;
		string_7 = _customerInfoPhone;
		list_3 = new List<ProcessorPaymentTypeWithId>();
		lstItems.Items.Clear();
		lstTenderTypes.Items.Clear();
		if (_orderNum != string.Empty)
		{
			string_0 = _orderNum;
		}
		if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			lblTrainingMode.Visible = true;
		}
		else
		{
			lblTrainingMode.Visible = false;
		}
		method_3();
		decimal_0 = subTotal;
		decimal_2 = Math.Round(dataManager_0.CalculateOrderDiscount(itemList, subTotal, _discountPercentage), 2, MidpointRounding.AwayFromZero);
		bool_6 = ((SettingsHelper.GetSettingValueByKey("gift_card_payment") == "ON") ? true : false);
		bool_7 = ((SettingsHelper.GetSettingValueByKey("loyalty_card_payment") == "ON") ? true : false);
		bool_9 = SettingsHelper.GetCardProcessorSettingActiveOnly("Ackroo", "gift_card_json") != null;
		bool_10 = SettingsHelper.GetCardProcessorSettingActiveOnly("Ackroo", "loyalty_card_json") != null;
		bool_11 = SettingsHelper.GetCardProcessorSettingActiveOnly("TapMango", "gift_card_json") != null;
		bool_12 = SettingsHelper.GetCardProcessorSettingActiveOnly("TapMango", "loyalty_card_json") != null;
		bool_4 = ((SettingsHelper.GetSettingValueByKey("auto_tip_cash_back") == "ON") ? true : false);
		bool_8 = ((SettingsHelper.GetSettingValueByKey("coin_system") == "ON") ? true : false);
		lblAmountDueRounded.Visible = bool_8;
		txtAmountDueRounded.Visible = bool_8;
		if (SettingsHelper.GetSettingValueByKey("auto_gratuity") == "ON")
		{
			bool_3 = true;
		}
		else
		{
			bool_3 = false;
		}
		string settingValueByKey = SettingsHelper.GetSettingValueByKey("auto_gratuity_count");
		int num = (int_0 = GuestMethods.GetCurrentTableGuestCapacity(string_2.Replace("Table ", "")));
		if (bool_3 && num >= Convert.ToInt32(settingValueByKey) && string_3 == OrderTypes.DineIn)
		{
			lblGratuity.Visible = true;
			lblTotalGratuity.Visible = true;
			label18.Visible = true;
			label17.Visible = true;
			decimal_8 = OrderMethods.ComputeAutoGratuity(string_0, string_12);
			btnChangeEmployee.Location = new Point(0, 712);
			btnChangeEmployee.Size = new Size(113, 55);
		}
		else
		{
			btnChangeEmployee.Location = new Point(0, 667);
			btnChangeEmployee.Size = new Size(113, 100);
			lblGratuity.Visible = false;
			lblTotalGratuity.Visible = false;
			label18.Visible = false;
			label17.Visible = false;
			lstItems.Height = lblSubTotal.Height * 2 + 1 + 385;
			lblTransactionFee.Location = new Point(lblSubTotal.Location.X, lstItems.Bottom + 1);
			label11.Location = new Point(label11.Location.X, lstItems.Bottom + 1);
			lblSubTotal.Location = new Point(lblSubTotal.Location.X, lblTransactionFee.Bottom + 1);
			label15.Location = new Point(label15.Location.X, lblTransactionFee.Bottom + 1);
			lblDiscount.Location = new Point(lblDiscount.Location.X, lblSubTotal.Bottom + 1);
			label12.Location = new Point(label12.Location.X, lblSubTotal.Bottom + 1);
			lblTotalTax.Location = new Point(lblTotalTax.Location.X, lblDiscount.Bottom + 1);
			label14.Location = new Point(label14.Location.X, lblDiscount.Bottom + 1);
			lblTotal.Location = new Point(lblTotal.Location.X, lblTotalTax.Bottom + 1);
			label13.Location = new Point(label13.Location.X, lblTotalTax.Bottom + 1);
			if (string_3 != OrderTypes.DeliveryOnline && string_3 != OrderTypes.PickUpOnline && string_3 != OrderTypes.TakeOutOnline && string_3 != OrderTypes.PickUpCurbsideOnline)
			{
				IQueryable<Order> queryable = gclass6_0.Orders.Where((Order o) => o.OrderNumber == string_0);
				queryable.ToList();
				foreach (Order item in queryable)
				{
					item.TipRecorded = true;
					item.TipAmount = 0m;
					item.TipDesc = "";
				}
				Helper.SubmitChangesWithCatch(gclass6_0);
			}
		}
		IvtFeqSdpCc();
		txtInput.Text = txtAmountDue.Text.RemoveAllNonNumeric();
		method_5(bool_14: true);
		if (SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Dine In" && string_3 == OrderTypes.DineIn)
		{
			bool_1 = ((SettingsHelper.GetSettingValueByKey("auto_clear_table") == "ON") ? true : false);
		}
		else
		{
			bool_1 = ((SettingsHelper.GetSettingValueByKey("auto_clear_orders") == "ON") ? true : false);
		}
		if (SettingsHelper.GetSettingValueByKey("tip_tracking") == "ON")
		{
			bool_2 = true;
		}
		else
		{
			bool_2 = false;
		}
		if (!string.IsNullOrEmpty(CompanyHelper.CompanyDataSetup.Country) && (CompanyHelper.CompanyDataSetup.Country.ToUpper().Contains("CANADA") || CompanyHelper.CompanyDataSetup.Country.ToUpper() == "CA"))
		{
			string_11 = "Interac";
		}
		else
		{
			string_11 = "Debit";
		}
		short_0 = Convert.ToInt16(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString());
		method_27(short_0);
		terminal_0 = MemoryLoadedObjects.this_terminal;
		if (terminal_0 != null)
		{
			nullable_0 = terminal_0.TerminalID;
		}
		btnOrderNotes.Enabled = true;
		bool_0 = itemList.Where((Item a) => a.ItemName.ToUpper().Contains("GIFT CARD") || a.ItemName.ToUpper().Contains("GIFT CERTIFICATE")).Any();
		if (bool_0 && bool_6)
		{
			new frmMessageBox("Please make sure you have sufficient gift cards on hand before processing payment. Once you swipe the card you will not be able to change the payment type or amount.", "WARNING").ShowDialog();
		}
	}

	private void IvtFeqSdpCc(bool bool_14 = false)
	{
		if (list_3.Select((ProcessorPaymentTypeWithId a) => a.PaymentTypeName).Contains(Resources.CashBack) && bool_4)
		{
			Label6.Text = Resources.Tip;
		}
		else
		{
			Label6.Text = Resources.Change;
		}
		decimal_1 = Math.Round(decimal_1, 2);
		decimal_10 = Math.Round(decimal_10, 2);
		lblTransactionFee.Text = decimal_10.ToString("0.00", Thread.CurrentThread.CurrentCulture);
		lblDiscount.Text = decimal_2.ToString("0.00", Thread.CurrentThread.CurrentCulture);
		lblSubTotal.Text = decimal_1.ToString("0.00", Thread.CurrentThread.CurrentCulture);
		decimal taxWithRounding = TaxMethods.GetTaxWithRounding(list_2);
		taxWithRounding = (decimal_3 = Math.Round(taxWithRounding, 2, MidpointRounding.AwayFromZero));
		lblTotalTax.Text = taxWithRounding.ToString("0.00", Thread.CurrentThread.CurrentCulture);
		lblTotal.Text = (decimal_10 + decimal_1 - decimal_2 + taxWithRounding).ToString("0.00", Thread.CurrentThread.CurrentCulture);
		lblGratuity.Text = decimal_8.ToString("0.00", Thread.CurrentThread.CurrentCulture);
		lblTotalGratuity.Text = (decimal_10 + decimal_1 - decimal_2 + taxWithRounding + decimal_8).ToString("0.00", Thread.CurrentThread.CurrentCulture);
		decimal_4 = decimal_10 + decimal_1 + decimal_8 + taxWithRounding - decimal_2 - decimal_5;
		if (decimal_4 > 0m)
		{
			txtAmountDue.Text = decimal_4.ToString("0.00", Thread.CurrentThread.CurrentCulture);
			txtAmountDueRounded.Text = OrderMethods.GetCoinSystemRoundedValue(decimal_4).ToString("0.00", Thread.CurrentThread.CurrentCulture);
		}
		else
		{
			txtAmountDue.Text = 0.ToString("0.00", Thread.CurrentThread.CurrentCulture);
			txtAmountDueRounded.Text = 0.ToString("0.00", Thread.CurrentThread.CurrentCulture);
		}
		if (decimal_4 < 0m)
		{
			if (bool_14)
			{
				txtChange.Text = (-OrderMethods.GetCoinSystemRoundedValue(decimal_4)).ToString("0.00", Thread.CurrentThread.CurrentCulture);
			}
			else
			{
				txtChange.Text = (-decimal_4).ToString("0.00", Thread.CurrentThread.CurrentCulture);
			}
		}
		else
		{
			txtChange.Text = 0.ToString("0.00", Thread.CurrentThread.CurrentCulture);
		}
		if (string_12.Equals("fr-CA"))
		{
			lblDiscount.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
			lblSubTotal.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
			lblTotalTax.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
			lblTotal.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
			lblGratuity.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
			lblTotalGratuity.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
			lblTransactionFee.Text += " $";
			lblDiscount.Text += " $";
			lblSubTotal.Text += " $";
			lblTotalTax.Text += " $";
			lblTotal.Text += " $";
			lblGratuity.Text += " $";
			lblTotalGratuity.Text += " $";
			txtAmountDue.Text += " $";
			txtAmountDueRounded.Text += " $";
			txtChange.Text += " $";
		}
		else
		{
			lblTransactionFee.Text = "$" + lblTransactionFee.Text;
			lblDiscount.Text = "$" + lblDiscount.Text;
			lblSubTotal.Text = "$" + lblSubTotal.Text;
			lblTotalTax.Text = "$" + lblTotalTax.Text;
			lblTotal.Text = "$" + lblTotal.Text;
			lblGratuity.Text = "$" + lblGratuity.Text;
			lblTotalGratuity.Text = "$" + lblTotalGratuity.Text;
			txtAmountDue.Text = "$" + txtAmountDue.Text;
			txtAmountDueRounded.Text = "$" + txtAmountDueRounded.Text;
			txtChange.Text = "$" + txtChange.Text;
		}
		if (string_3 != OrderTypes.Catering)
		{
			if (decimal_4 <= 0m)
			{
				btnDone.Enabled = true;
			}
			else
			{
				btnDone.Enabled = false;
			}
		}
		else if (list_3 != null && list_3.Count > 0)
		{
			btnDone.Enabled = true;
		}
		else
		{
			btnDone.Enabled = false;
		}
		if (decimal_4 > 0m)
		{
			txtInput.Text = decimal_4.ToString("0.00", Thread.CurrentThread.CurrentCulture);
		}
		else
		{
			txtInput.Text = 0.ToString("0.00", Thread.CurrentThread.CurrentCulture);
		}
	}

	private void method_3()
	{
		lstItems.Items.Clear();
		foreach (Item item in list_2)
		{
			ListViewItem listViewItem = new ListViewItem(new string[6]
			{
				(item.InventoryCount < 1m) ? ((!item.UOM.isFractional) ? MathHelper.DecimalToFraction(item.InventoryCount) : MathHelper.RemoveTrailingZeros(item.InventoryCount.ToString())) : MathHelper.RemoveTrailingZeros(item.InventoryCount.ToString()),
				item.ItemName,
				item.ItemPrice.ToString("0.00##"),
				(item.ItemPrice * item.InventoryCount).ToString("0.00"),
				item.ItemID.ToString(),
				item.SortOrder.ToString()
			});
			FormHelper.ChangeOrderEntryLVWinformsCellByIdentifier(lstItems, listViewItem, lstItems.Font.Size, item.ItemClassification);
			lstItems.Items.Add(listViewItem);
		}
		method_4();
	}

	private void method_4()
	{
		Order order = new GClass6().Orders.Where((Order o) => o.OrderNumber == string_0).FirstOrDefault();
		if (order == null || string.IsNullOrEmpty(order.PaymentMethods) || !(order.PaymentMethods != "SAVED ORDER"))
		{
			return;
		}
		string[] array = order.PaymentMethods.Split('|');
		foreach (string text in array)
		{
			if (!string.IsNullOrEmpty(text))
			{
				string[] array2 = text.Split('=');
				if (array2.Length > 1)
				{
					string text2 = Guid.NewGuid().ToString();
					decimal num = Convert.ToDecimal(array2[1]);
					lstTenderTypes.Items.Add(new ListViewItem(new string[4]
					{
						array2[0],
						$"{num:C}",
						text2,
						"PaymentReceived"
					}));
					list_3.Add(new ProcessorPaymentTypeWithId
					{
						PaymentTypeName = array2[0],
						Amount = num,
						Id = text2,
						PaymentReceived = true
					});
					decimal_5 += num;
				}
			}
		}
		IvtFeqSdpCc();
	}

	private void method_5(bool bool_14)
	{
		if (this.button5.Enabled == bool_14)
		{
			return;
		}
		foreach (Button item in pnlTenderTypes.Controls.OfType<Button>().Cast<Control>().ToList())
		{
			try
			{
				item.Enabled = bool_14;
			}
			catch
			{
			}
		}
		Button button2 = btnExactChange;
		Button button3 = this.button5;
		Button button4 = this.button3;
		Button button5 = Button6;
		Button button6 = Button7;
		bool flag2 = (button9.Enabled = bool_14);
		bool flag4 = (button6.Enabled = flag2);
		bool flag6 = (button5.Enabled = flag4);
		bool flag8 = (button4.Enabled = flag6);
		bool enabled = (button3.Enabled = flag8);
		button2.Enabled = enabled;
	}

	private void btnDiscount_Click(object sender, EventArgs e)
	{
		if (AuthMethods.EmployeeAuthenticateControlDifferentForm(this, "frmOrderEntry", "btnOrderDiscount") == null)
		{
			return;
		}
		if (lstTenderTypes.Items.Count > 0)
		{
			if (new frmMessageBox(Resources.Tender_types_will_be_cleared_d, Resources.Information, CustomMessageBoxButtons.YesNo).ShowDialog() != DialogResult.Yes)
			{
				return;
			}
			lstTenderTypes.Items.Clear();
			list_3.Clear();
			decimal_5 = (decimal_6 = 0m);
			method_4();
			IvtFeqSdpCc();
			method_5(!(txtInput.Text.ToDecimalWithCleanUp() == 0m));
		}
		GClass6 gClass = new GClass6();
		IQueryable<Order> source = gClass.Orders.Where((Order o) => o.OrderNumber == string_0);
		if (btnDiscount.Text == Resources.DISCOUNT)
		{
			frmDiscount frmDiscount2 = new frmDiscount(decimal_1, DiscountTypes.Order);
			if (frmDiscount2.ShowDialog(this) == DialogResult.OK)
			{
				string_4 = frmDiscount2.discountReason;
				decimal_2 = dataManager_0.CalculateOrderDiscount(list_2, decimal_1, frmDiscount2.percentDiscount);
			}
			if (decimal_2 > 0m)
			{
				btnDiscount.Text = Resources.REMOVE_DISCOUNT;
			}
			IvtFeqSdpCc();
		}
		else
		{
			decimal_2 = default(decimal);
			using (List<Item>.Enumerator enumerator = list_2.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass61_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass61_0();
					CS_0024_003C_003E8__locals0.item = enumerator.Current;
					Order order = source.Where((Order x) => x.ItemID == CS_0024_003C_003E8__locals0.item.ItemID && ((object)x.OrderId).ToString() == CS_0024_003C_003E8__locals0.item.Temp).FirstOrDefault();
					if (order == null)
					{
						continue;
					}
					decimal discountFromDiscountDescription = OrderHelper.GetDiscountFromDiscountDescription(order.DiscountDesc, DiscountTypes.Promo);
					if (order.Qty > 0m)
					{
						Item oneItem = dataManager_0.getOneItem(CS_0024_003C_003E8__locals0.item.ItemID);
						Promotion promotion = MemoryLoadedObjects.all_active_promotions.Where((Promotion a) => a.GetDiscountUOM == "@" && a.String_0 == CS_0024_003C_003E8__locals0.item.ItemID.ToString() && a.GetQtyString == "IT" && PromotionMethods.IsPromotionTime(a, DateTime.Now)).FirstOrDefault();
						if (promotion != null && oneItem.OnSale)
						{
							if (!(promotion.GetDiscountAmount.Value == order.ItemSellPrice) && !(order.Discount + order.ItemSellPrice == oneItem.ItemPrice))
							{
								CS_0024_003C_003E8__locals0.item.ItemPrice = order.ItemSellPrice + order.Discount / order.Qty;
							}
							else
							{
								CS_0024_003C_003E8__locals0.item.ItemPrice = promotion.GetDiscountAmount.Value / order.Qty;
							}
						}
						else if (discountFromDiscountDescription > 0m)
						{
							CS_0024_003C_003E8__locals0.item.ItemPrice = order.ItemSellPrice / order.Qty;
						}
						else
						{
							CS_0024_003C_003E8__locals0.item.ItemPrice = order.ItemSellPrice + order.Discount / order.Qty;
						}
					}
					else
					{
						CS_0024_003C_003E8__locals0.item.ItemPrice = 0m;
					}
					CS_0024_003C_003E8__locals0.item.ItemCost = ((CS_0024_003C_003E8__locals0.item.ItemCost == -1m) ? (-1m) : CS_0024_003C_003E8__locals0.item.ItemPrice);
					CS_0024_003C_003E8__locals0.item.Barcode = "";
				}
			}
			string_4 = "";
			btnDiscount.Text = Resources.DISCOUNT;
			IvtFeqSdpCc();
		}
		Order order2 = source.FirstOrDefault();
		bool isDiscount = ((decimal_2 > 0m) ? true : false);
		if (order2 != null)
		{
			foreach (Item item in list_2)
			{
				item.ItemCost = -1m;
			}
			new OrderMethods(gClass).SaveOrder(list_2, string_0, order2.Customer, order2.OrderType, order2.CustomerID.Value, "SAVED ORDER", 0m, 0m, isPaid: false, string_5, string_4, string_6, string_7, 1, isDiscount, string_8, Convert.ToInt16(order2.SeatNum), null, null, 0, null, "", GratuityRemoved: false, 0);
		}
		else
		{
			new OrderMethods(gClass).SaveOrder(list_2, string_0, string_2, string_3, order2.CustomerID.Value, "SAVED ORDER", 0m, 0m, isPaid: false, string_5, string_4, string_6, string_7, 1, isDiscount, string_8, 0, null, null, 0, null, "", GratuityRemoved: false, 0);
		}
		if (!bool_13)
		{
			string settingValueByKey = SettingsHelper.GetSettingValueByKey("auto_gratuity_count");
			int currentTableGuestCapacity = GuestMethods.GetCurrentTableGuestCapacity(string_2.Replace("Table ", ""));
			if (bool_3 && currentTableGuestCapacity >= Convert.ToInt32(settingValueByKey) && string_3 == OrderTypes.DineIn)
			{
				decimal_8 = OrderMethods.ComputeAutoGratuity(string_0, string_12);
			}
		}
		IvtFeqSdpCc();
		txtInput.Text = txtAmountDue.Text.RemoveAllNonNumeric();
		frmOrderEntry_0.loadOrderByOrderNumber(string_0);
	}

	private void method_6(string string_15, bool bool_14)
	{
		_003C_003Ec__DisplayClass62_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass62_0();
		CS_0024_003C_003E8__locals0.payType = string_15;
		OrderMethods.LogOrderAudit(string_0, "Manual Payment Processing Initiated: " + CS_0024_003C_003E8__locals0.payType);
		if (CS_0024_003C_003E8__locals0.payType.ToUpper() != Resources.CASH0.ToUpper() && CS_0024_003C_003E8__locals0.payType.ToUpper() != "SKIP THE DISHES" && CS_0024_003C_003E8__locals0.payType.ToUpper() != "UBER EATS".ToUpper())
		{
			method_9(CS_0024_003C_003E8__locals0.payType);
		}
		else if (CS_0024_003C_003E8__locals0.payType.ToUpper() == Resources.CASH0.ToUpper() && list_3.Select((ProcessorPaymentTypeWithId a) => a.PaymentTypeName).All((string a) => a == "CASH"))
		{
			method_10();
		}
		if (list_3.Count >= 6)
		{
			new frmMessageBox("You can only add up to 5 payment methods", "Exceeding Payment Methods").ShowDialog();
			return;
		}
		decimal_5 += txtInput.Text.ToDecimalWithCleanUp();
		string text = Guid.NewGuid().ToString();
		decimal num = Convert.ToDecimal($"{txtInput.Text.RemoveAllNonNumeric():0.00}");
		decimal num2 = num;
		if (bool_8 && txtInput.Text.ToDecimalWithCleanUp() == txtAmountDue.Text.ToDecimalWithCleanUp() && CS_0024_003C_003E8__locals0.payType.ToUpper() == Resources.CASH0.ToUpper())
		{
			num2 = txtAmountDueRounded.Text.ToDecimalWithCleanUp();
		}
		bool bool_15 = ((CS_0024_003C_003E8__locals0.payType.ToUpper() == "CASH") ? true : false);
		IvtFeqSdpCc(bool_15);
		decimal num3 = txtChange.Text.ToDecimalWithCleanUp();
		if (CS_0024_003C_003E8__locals0.payType.ToUpper() == Resources.CASH0)
		{
			bool flag = false;
			foreach (ListViewItem item in lstTenderTypes.Items)
			{
				if (item.SubItems.Count > 3 && item.SubItems[0].Text == CS_0024_003C_003E8__locals0.payType.ToUpper() && item.SubItems[3].Text != "PaymentReceived")
				{
					item.SubItems[1].Text = $"{decimal.Parse(item.SubItems[1].Text, NumberStyles.Currency) + num:C}";
					list_3.Where((ProcessorPaymentTypeWithId x) => x.PaymentTypeName == CS_0024_003C_003E8__locals0.payType).FirstOrDefault().Amount += num - num3;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				lstTenderTypes.Items.Add(new ListViewItem(new string[3]
				{
					CS_0024_003C_003E8__locals0.payType,
					$"{num:C}",
					text
				}));
				list_3.Add(new ProcessorPaymentTypeWithId
				{
					PaymentTypeName = CS_0024_003C_003E8__locals0.payType,
					Amount = num - num3,
					Id = text
				});
			}
			if (bool_8)
			{
				decimal_6 += num2;
			}
			else
			{
				decimal_6 += num;
			}
			if (num3 > 0m)
			{
				decimal_7 = num3;
			}
		}
		else
		{
			lstTenderTypes.Items.Add(new ListViewItem(new string[3]
			{
				CS_0024_003C_003E8__locals0.payType,
				$"{num:C}",
				text
			}));
			list_3.Add(new ProcessorPaymentTypeWithId
			{
				PaymentTypeName = CS_0024_003C_003E8__locals0.payType,
				Amount = num,
				Id = text
			});
			if (num3 > 0m)
			{
				list_3.Add(new ProcessorPaymentTypeWithId
				{
					PaymentTypeName = Resources.CashBack,
					Amount = -txtChange.Text.ToDecimalWithCleanUp(),
					Id = text
				});
			}
		}
		if (bool_14 || txtAmountDue.Text.ToDecimalWithCleanUp() < 0m)
		{
			bool_5 = true;
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		bool bool_ = false;
		bool bool_2 = false;
		string[] array = button.Name.ToString().Split('_');
		if (array.Length > 2)
		{
			bool_ = ((array[1] == "YES") ? true : false);
			bool_2 = ((array[2] == "YES") ? true : false);
		}
		if (button.Text.ToUpper() == "GIFT CARD" && bool_6)
		{
			if (bool_9)
			{
				method_12();
			}
			else
			{
				method_8(button.Text.ToUpper(), bool_, bool_2);
			}
		}
		else if (button.Text.ToUpper() == "LOYALTY CARD" && bool_7)
		{
			if (bool_10)
			{
				method_13();
			}
			else
			{
				method_8(button.Text.ToUpper(), bool_, bool_2);
			}
		}
		else
		{
			method_8(button.Text.ToUpper(), bool_, bool_2);
		}
	}

	private void method_8(string string_15, bool bool_14, bool bool_15, string string_16 = "")
	{
		try
		{
			if (txtInput.Text.ToDecimalWithCleanUp() == txtAmountDueRounded.Text.ToDecimalWithCleanUp() && bool_8 && string_15.ToUpper() == "CASH")
			{
				txtInput.Text = txtAmountDue.Text.ToDecimalWithCleanUp().ToString();
			}
			decimal num = Convert.ToDecimal($"{txtInput.Text.RemoveAllNonNumeric():0.00}");
			if (num <= 0m)
			{
				new NotificationLabel(this, Resources.Invalid_amount_entered, NotificationTypes.Notification).Show();
				return;
			}
			decimal num2 = txtAmountDue.Text.ToDecimalWithCleanUp();
			if (num > num2 * 10m && num > lblTotal.Text.ToDecimalWithCleanUp() && new frmMessageBox(Resources.You_have_entered_a_value_great, Resources.Confirmation, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.No)
			{
				return;
			}
			bool flag = false;
			string settingValueByKey = SettingsHelper.GetSettingValueByKey("use_payment_processor");
			if (string_15.ToUpper() == PaymentTypes.LOYALTY_CARD && bool_7)
			{
				CardProcessorObject cardProcessorSettingActiveOnly = SettingsHelper.GetCardProcessorSettingActiveOnly("Ackroo", "loyalty_card_json");
				if (cardProcessorSettingActiveOnly != null && cardProcessorSettingActiveOnly.Processor == "Ackroo")
				{
					AckrooCardResponse ackrooCardResponse = AckrooMethods.CheckCardBalance(string_16);
					if (!string.IsNullOrEmpty(ackrooCardResponse.error))
					{
						new NotificationLabel(this, ackrooCardResponse.error, NotificationTypes.Warning).Show();
						return;
					}
					if (Convert.ToDecimal(ackrooCardResponse.loyalty) == 0m)
					{
						new NotificationLabel(this, "You have a 0.00 balance on your loyalty card.", NotificationTypes.Notification).Show();
						return;
					}
					if (new frmMessageBox("You have $" + ackrooCardResponse.loyalty + " available on this card. Do you want to use it?", "Point Balance", CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.No)
					{
						return;
					}
					if (Convert.ToDecimal(ackrooCardResponse.loyalty) < num)
					{
						num = Convert.ToDecimal(ackrooCardResponse.loyalty);
					}
					decimal_5 += num;
					string text = Guid.NewGuid().ToString();
					ListViewItem value = new ListViewItem(new string[3]
					{
						"Ackroo".ToUpper() + " LOYALTY CARD",
						string_13 + num,
						text
					});
					lstTenderTypes.Items.Add(value);
					IvtFeqSdpCc();
					txtChange.Text.ToDecimalWithCleanUp();
					list_3.Add(new ProcessorPaymentTypeWithId
					{
						PaymentTypeName = string_15,
						Amount = num,
						Id = text,
						CardNumber = string_16
					});
					flag = true;
					btnCancel.Enabled = false;
				}
				else
				{
					method_6(string_15, bool_14);
				}
			}
			else if (string_15.ToUpper() == PaymentTypes.GIFT_CARD && bool_6)
			{
				CardProcessorObject cardProcessorSettingActiveOnly2 = SettingsHelper.GetCardProcessorSettingActiveOnly("Ackroo", "gift_card_json");
				if (cardProcessorSettingActiveOnly2 != null && cardProcessorSettingActiveOnly2.Processor == "Ackroo")
				{
					if (string.IsNullOrEmpty(string_16))
					{
						return;
					}
					AckrooCardResponse ackrooCardResponse2 = AckrooMethods.CheckCardBalance(string_16);
					decimal num3 = Convert.ToDecimal(ackrooCardResponse2.gift);
					if (!string.IsNullOrEmpty(ackrooCardResponse2.error))
					{
						new NotificationLabel(this, ackrooCardResponse2.error, NotificationTypes.Warning).Show();
						return;
					}
					if (num3 == 0m)
					{
						new NotificationLabel(this, "Insufficient funds, card has $" + ackrooCardResponse2.gift, NotificationTypes.Warning).Show();
						return;
					}
					if (new frmMessageBox("You have $" + ackrooCardResponse2.gift + " available on this card. Do you want to use it?", "Gift Card Balance", CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.No)
					{
						return;
					}
					if (num3 < num)
					{
						num = num3;
					}
					decimal_5 += num;
					string text2 = Guid.NewGuid().ToString();
					ListViewItem value2 = new ListViewItem(new string[3]
					{
						"Ackroo".ToUpper() + " GIFT CARD",
						string_13 + num,
						text2
					});
					lstTenderTypes.Items.Add(value2);
					IvtFeqSdpCc();
					txtChange.Text.ToDecimalWithCleanUp();
					list_3.Add(new ProcessorPaymentTypeWithId
					{
						PaymentTypeName = string_15,
						Amount = num,
						Id = text2,
						CardNumber = string_16
					});
					flag = true;
					btnCancel.Enabled = false;
				}
				else
				{
					method_6(string_15, bool_14);
				}
			}
			else if (!(settingValueByKey == "OFF") && bool_15)
			{
				if (terminal_0 == null || !nullable_0.HasValue)
				{
					new NotificationLabel(this, "Could not load terminal data, please restart hippos.", NotificationTypes.Warning).Show();
					return;
				}
				if (!string.IsNullOrEmpty(terminal_0.PaymentMerchantID) && !string.IsNullOrEmpty(terminal_0.PaymentProviderName) && !string.IsNullOrEmpty(terminal_0.PaymentTerminalAddress) && !string.IsNullOrEmpty(terminal_0.PaymentTerminalModel) && terminal_0.PaymentTerminalPort > 0)
				{
					switch (new frmPaymentEntryMethodSelection().ShowDialog())
					{
					case DialogResult.No:
						method_6(string_15, bool_14);
						flag = true;
						break;
					case DialogResult.Yes:
					{
						txtInput.Text = num.ToString("0.00");
						decimal_11 = num;
						method_9(string_15);
						if (decimal_10 > 0m)
						{
							num2 = txtAmountDue.Text.ToDecimalWithCleanUp();
							num = Convert.ToDecimal($"{txtInput.Text.RemoveAllNonNumeric():0.00}");
						}
						int total_due = (int)(num * 100m);
						List<PaymentTransactionObject> trans_objects = new List<PaymentTransactionObject>();
						if (terminal_0.PaymentProviderName == PaymentProviderNames.FirstData)
						{
							UIPaymentHelper.ProcessFirstData(this, terminal_0, "sale", total_due, string_0, string_15, null, out trans_objects);
						}
						else
						{
							UIPaymentHelper.ProcessIngenico(terminal_0.PaymentProviderName, this, terminal_0, "sale", total_due, string_0, string_15, null, out trans_objects);
						}
						decimal num4 = default(decimal);
						decimal num5 = default(decimal);
						decimal num6 = default(decimal);
						decimal tipAmount = default(decimal);
						decimal num7 = default(decimal);
						if (trans_objects != null && trans_objects.Count > 0)
						{
							bool flag2 = false;
							foreach (PaymentTransactionObject item in trans_objects)
							{
								flag = true;
								if (!string.IsNullOrEmpty(item.merchantreceipt) && !string.IsNullOrEmpty(item.totalamount))
								{
									if (flag && !string.IsNullOrEmpty(item.merchantreceipt) && (item.merchantreceipt.ToUpper().Contains("NOT COMPLETED") || item.merchantreceipt.ToUpper().Contains("DECLINED") || item.merchantreceipt.ToUpper().Contains("*CANCELLED*") || !item.merchantreceipt.ToUpper().Contains("APPROVED")))
									{
										flag = false;
									}
									if (flag && !string.IsNullOrEmpty(item.totalamount) && Convert.ToDecimal(item.totalamount) / 100m <= 0m)
									{
										flag = false;
									}
								}
								else
								{
									flag = false;
								}
								if (flag)
								{
									flag2 = true;
									num4 = Convert.ToDecimal(item.amount) / 100m;
									num5 += ((!string.IsNullOrEmpty(item.cashback_amount)) ? (Convert.ToDecimal(item.cashback_amount) / 100m) : 0m);
									num6 += ((!string.IsNullOrEmpty(item.surcharge_amount)) ? (Convert.ToDecimal(item.surcharge_amount) / 100m) : 0m);
									num7 = Convert.ToDecimal(item.totalamount) / 100m;
									tipAmount += Convert.ToDecimal(item.tip_amount) / 100m;
									if (!(num7 == 0m))
									{
										decimal num8 = ((num4 > 0m) ? num4 : num7);
										decimal_5 += num8;
										string text3 = Guid.NewGuid().ToString();
										if (bool_4 && num7 - num2 - decimal_10 - num6 > 0m)
										{
											tipAmount = num7 - num2 - decimal_10 - num6;
										}
										if (item != null && item.merchantreceipt != null && !item.merchantreceipt.ToUpper().Contains(string_15.ToUpper()))
										{
											string_15 = UIPaymentHelper.GetActualPaymentMethod(string_15, item.merchantreceipt);
										}
										ListViewItem value3 = new ListViewItem(new string[4]
										{
											string_15,
											string_13 + num8,
											text3,
											"true"
										});
										lstTenderTypes.Items.Add(value3);
										IvtFeqSdpCc();
										decimal num9 = txtChange.Text.ToDecimalWithCleanUp();
										list_3.Add(new ProcessorPaymentTypeWithId
										{
											PaymentTypeName = string_15,
											Amount = num8,
											Id = text3,
											PaymentReceived = true,
											TipAmount = tipAmount
										});
										if (num6 > 0m)
										{
											decimal_10 += num6;
											list_3.Add(new ProcessorPaymentTypeWithId
											{
												PaymentTypeName = "TERMINAL FEE",
												Amount = num6,
												Id = text3
											});
										}
										if (num9 > 0m || num5 > 0m)
										{
											if (num5 > 0m && !bool_4)
											{
												list_3.Add(new ProcessorPaymentTypeWithId
												{
													PaymentTypeName = Resources.CashBack.ToUpper(),
													Amount = -num5,
													Id = text3
												});
											}
											if (num5 == 0m && num6 == 0m && !bool_4)
											{
												list_3.Add(new ProcessorPaymentTypeWithId
												{
													PaymentTypeName = Resources.CashBack.ToUpper(),
													Amount = -txtChange.Text.ToDecimalWithCleanUp(),
													Id = text3
												});
											}
										}
										btnCancel.Enabled = false;
										if (bool_14 && !bool_5)
										{
											bool_5 = true;
										}
										if (txtAmountDue.Text.ToDecimalWithCleanUp() <= 0m)
										{
											decimal_9 = list_3.Sum((ProcessorPaymentTypeWithId a) => a.TipAmount);
											IvtFeqSdpCc();
											method_14(decimal_9, item.approvalcode);
											return;
										}
										continue;
									}
									method_10();
									new NotificationLabel(this, "User Has Cancelled The Transaction.", NotificationTypes.Notification).Show();
									return;
								}
								if (item != null && (item == null || !(item.responsecode == "56")) && (item == null || !string.IsNullOrEmpty(item.responsecode) || !(item.rawdata != HipposTransactionErrorMessages.staff_cancelled)))
								{
									if (item != null && !string.IsNullOrEmpty(item.rawdata) && item.rawdata == HipposTransactionErrorMessages.staff_cancelled)
									{
										new NotificationLabel(this, "STAFF CANCELLED", NotificationTypes.Notification).Show();
									}
									else if (item == null || string.IsNullOrEmpty(item.responsecode))
									{
										new PrintHelper().PrintString(item.customerreceipt, 9, null, "Courier New");
									}
								}
								else
								{
									if (new frmMessageBox("Hippos has lost connection with the payment terminal.  Was the transaction successful?", "Payment terminal lost connection", CustomMessageBoxButtons.YesNo).ShowDialog(this) != DialogResult.Yes)
									{
										OrderMethods.LogOrderAudit(string_0, "Hippos has lost connection with the payment terminal. Was the transaction successful? selected NO");
										return;
									}
									OrderMethods.LogOrderAudit(string_0, "Hippos has lost connection with the payment terminal. Was the transaction successful? selected YES");
									method_6(string_15, bool_14);
									flag = true;
								}
								if (!flag2)
								{
									method_10();
								}
								IvtFeqSdpCc();
							}
						}
						else
						{
							method_10();
						}
						break;
					}
					}
				}
				else
				{
					new NotificationLabel(this, Resources.Payment_Terminal_settings_has_not, NotificationTypes.Warning).Show();
					method_6(string_15, bool_14);
					flag = true;
				}
			}
			else
			{
				method_6(string_15, bool_14);
				flag = true;
			}
			if (flag)
			{
				bool bool_16 = ((string_15.ToUpper() == "CASH") ? true : false);
				IvtFeqSdpCc(bool_16);
				if (txtAmountDue.Text.ToDecimalWithCleanUp() == 0m && SettingsHelper.GetSettingValueByKey("payfinish_screen") == "ON")
				{
					method_14();
				}
			}
		}
		catch (Exception ex)
		{
			new NotificationLabel(this, "An error Occurred with the Payment Process. Please try again.", NotificationTypes.Warning).Show();
			NotificationMethods.sendCrash(AppSettings.AppVersion, Environment.OSVersion.VersionString, ex);
			DebugMethods.ShowExceptionTextFile(ex);
		}
	}

	private void method_9(string string_15)
	{
		CardTransactionFeeObject cardTransactionFeeObject = (string_15.Contains("DEBIT") ? SettingsHelper.GetTransactionFeeSetting("Debit") : SettingsHelper.GetTransactionFeeSetting("Credit"));
		if (cardTransactionFeeObject.Amount > 0m)
		{
			decimal num = txtInput.Text.ToDecimalWithCleanUp();
			decimal num2 = default(decimal);
			num2 = ((cardTransactionFeeObject.TenderType != '%') ? cardTransactionFeeObject.Amount : (num * (cardTransactionFeeObject.Amount / 100m)));
			decimal num3 = num + num2;
			if (num3 > Convert.ToDecimal(txtInput.Text))
			{
				txtInput.Text = num3.ToString("0.00");
			}
			num2 = Math.Round(num2, 2);
			list_4.Add(num2);
			decimal_10 += num2;
			if (decimal_10 > 0m)
			{
				new NotificationLabel(this, "Please notify the customer that there will be a $" + decimal_10.ToString("0.00") + " CARD transaction fee for this order.", NotificationTypes.Notification).Show();
			}
			decimal_10 = Math.Round(decimal_10, 2);
		}
	}

	private void method_10()
	{
		if (decimal_10 > 0m)
		{
			decimal_10 = default(decimal);
			txtInput.Text = decimal_11.ToString("0.00");
			decimal num = txtInput.Text.ToDecimalWithCleanUp();
			if (num > Convert.ToDecimal(txtInput.Text))
			{
				txtInput.Text = num.ToString("0.00");
			}
		}
		list_4.Clear();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		if (list_5.Count > 0)
		{
			if (new frmMessageBox("You have already funded " + list_5.Count + " gift card(s).  Cancelling this order will not remove the funds from the gift card(s).  Are you sure you want to proceed?", "Are You Sure?", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
			{
				list_5.Clear();
				if ((int)CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] != int_2 && SettingsHelper.GetSettingValueByKey("workflow_prompt_cashout_pin") == "ON")
				{
					CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = int_2;
				}
				Hide();
			}
		}
		else
		{
			if ((int)CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] != int_2 && SettingsHelper.GetSettingValueByKey("workflow_prompt_cashout_pin") == "ON")
			{
				CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = int_2;
			}
			Hide();
		}
	}

	private void method_11()
	{
		frmGiftCardPrompt frmGiftCardPrompt2 = new frmGiftCardPrompt("ENTER CARD NUMBER", GCAndLoyalty: true);
		if (frmGiftCardPrompt2.ShowDialog(this) == DialogResult.OK)
		{
			if (frmGiftCardPrompt2.CardType == 1)
			{
				method_8(PaymentTypes.GIFT_CARD, bool_14: false, bool_15: false, frmGiftCardPrompt2.CardNumber);
			}
			else
			{
				method_8(PaymentTypes.LOYALTY_CARD, bool_14: false, bool_15: false, frmGiftCardPrompt2.CardNumber);
			}
		}
	}

	private void method_12()
	{
		frmGiftCardPrompt frmGiftCardPrompt2 = new frmGiftCardPrompt("ENTER GIFT CARD NUMBER");
		if (frmGiftCardPrompt2.ShowDialog(this) == DialogResult.OK)
		{
			method_8(PaymentTypes.GIFT_CARD, bool_14: false, bool_15: false, frmGiftCardPrompt2.CardNumber);
		}
	}

	private void method_13()
	{
		frmGiftCardPrompt frmGiftCardPrompt2 = new frmGiftCardPrompt("ENTER LOYALTY CARD NUMBER");
		if (frmGiftCardPrompt2.ShowDialog(this) == DialogResult.OK)
		{
			method_8(PaymentTypes.LOYALTY_CARD, bool_14: false, bool_15: false, frmGiftCardPrompt2.CardNumber);
		}
	}

	private void btnDone_Click(object sender, EventArgs e)
	{
		try
		{
			method_14();
		}
		catch (Exception ex)
		{
			new NotificationLabel(this, "An error Occurred with the Payment Process. Please try again.", NotificationTypes.Warning).Show();
			NotificationMethods.sendCrash(AppSettings.AppVersion, Environment.OSVersion.VersionString, ex);
			DebugMethods.ShowExceptionTextFile(ex);
		}
	}

	private void method_14(decimal tip = 0m, string string_15 = null)
	{
		if (bool_12)
		{
			decimal num = list_3.Where((ProcessorPaymentTypeWithId a) => !a.PaymentTypeName.ToUpper().Contains("LOYALTY") && !a.PaymentTypeName.ToUpper().Contains(PaymentTypes.GIFT_CARD)).Sum((ProcessorPaymentTypeWithId a) => a.Amount);
			num -= decimal_8 + decimal_3;
			string text = ((list_3.Where((ProcessorPaymentTypeWithId a) => a.PaymentTypeName.ToUpper().Contains("CASH")).Count() > 0) ? "CASH" : null);
			if (text == null)
			{
				text = ((list_3.Where((ProcessorPaymentTypeWithId a) => a.PaymentTypeName.ToUpper().Contains("DEBIT") || a.PaymentTypeName.ToUpper().Contains("CREDIT") || a.PaymentTypeName.ToUpper().Contains("MASTERCARD") || a.PaymentTypeName.ToUpper().Contains("VISA") || a.PaymentTypeName.ToUpper().Contains("AMERICAN EXPRESS") || a.PaymentTypeName.ToUpper().Contains("AMEX")).Count() > 0) ? "CREDIT" : "OTHER");
			}
			if (num > 0m)
			{
				if (!TapMangoHelper.ProcessTapMangoLoyalty(this, text, num, string_0))
				{
					base.DialogResult = DialogResult.None;
					return;
				}
				TapMangoHelper.RedeemLoyalty();
			}
		}
		if (!method_17())
		{
			base.DialogResult = DialogResult.None;
			return;
		}
		if (!method_16())
		{
			base.DialogResult = DialogResult.None;
			return;
		}
		if (!method_18())
		{
			base.DialogResult = DialogResult.None;
			return;
		}
		string text2 = "";
		decimal num2 = txtChange.Text.ToDecimalWithCleanUp();
		bool isPaid = true;
		if (decimal_4 > 0m)
		{
			isPaid = false;
		}
		foreach (ProcessorPaymentTypeWithId item in list_3)
		{
			if (item.PaymentTypeName.ToUpper().Contains(Resources.CashBack.ToUpper()) && bool_4)
			{
				tip += Math.Abs(item.Amount);
				continue;
			}
			if (string_3 == OrderTypes.Catering && !item.PaymentTypeName.Contains("]"))
			{
				item.PaymentTypeName = "[" + DateTime.Now.ToShortDateString() + "]" + item.PaymentTypeName;
			}
			text2 = text2 + item.PaymentTypeName + "=" + item.Amount + "|";
		}
		gclass6_0 = new GClass6();
		List<Order> list = gclass6_0.Orders.Where((Order o) => o.OrderNumber == string_0).ToList();
		Order order = list.FirstOrDefault();
		bool isDiscount = ((decimal_2 > 0m) ? true : false);
		if (order != null)
		{
			short seatNum = (short)((!(order.SeatNum != string.Empty)) ? 1 : Convert.ToInt16(order.SeatNum));
			new OrderMethods().SaveOrder(list_2, string_0, order.Customer, order.OrderType, order.CustomerID.HasValue ? order.CustomerID.Value : 0, text2, decimal_6, decimal_7, isPaid, string_5, string_4, string_6, string_7, 1, isDiscount, string_8, seatNum, nullable_0, list_4, short_0, null, "", bool_13, 0);
		}
		else
		{
			new OrderMethods().SaveOrder(list_2, string_0, string_2, string_3, order.CustomerID.HasValue ? order.CustomerID.Value : 0, text2, decimal_6, decimal_7, isPaid, string_5, string_4, string_6, string_7, 1, isDiscount, string_8, 0, nullable_0, list_4, short_0, null, "", bool_13, 0);
		}
		foreach (Order item2 in list)
		{
			item2.UserCashout = short_0;
		}
		if (!bool_2 && !bool_3)
		{
			foreach (Order item3 in list)
			{
				item3.TipRecorded = true;
				item3.TipAmount = 0m;
				item3.TipDesc = "";
			}
		}
		else
		{
			method_19(tip, string_15);
		}
		if (!bool_1 && (!bool_3 || !lblGratuity.Visible) && !(SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Quick Service"))
		{
			Helper.SubmitChangesWithCatch(gclass6_0);
		}
		else
		{
			if (SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Dine In")
			{
				GuestMethods.setGuestPerBill(list, (short)order.GuestCount, gclass6_0);
			}
			else
			{
				foreach (Order item4 in list)
				{
					item4.TipRecorded = true;
					if (bool_1 || (SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Quick Service" && (item4.OrderType == OrderTypes.DineIn || item4.OrderType == OrderTypes.ToGo)))
					{
						item4.DateCleared = DateTime.Now;
					}
				}
				Helper.SubmitChangesWithCatch(gclass6_0);
			}
			if ((from x in new GClass6().Orders.Where((Order o) => o.Customer == string_2 && o.OrderType == OrderTypes.DineIn && (o.Paid == false || (o.Paid == true && o.DateCleared == null)) && o.Void == false && o.DateCreated.Value > DateTime.Now.AddDays(-1.0)).ToList()
				select x.OrderNumber).Distinct().ToList().Count == 0)
			{
				GuestMethods.UpdateTableGuestCapacity(string_2.Replace("Table", string.Empty).Trim(), 0, 0);
				GuestMethods.AssignEmployeeTable(string_2.Replace("Table", string.Empty).Trim(), 0);
			}
		}
		string orderTicketNumber = order.OrderTicketNumber;
		if (SettingsHelper.GetSettingValueByKey("print_orderticket") == "ON" && !string.IsNullOrEmpty(orderTicketNumber))
		{
			new PrintHelper().PrintString("*** " + orderTicketNumber + " ***", 25, null, "Arial", isBold: true, isHTML: false);
		}
		else if (SettingsHelper.GetSettingValueByKey("auto_print_receipt") == "ON")
		{
			bool flag = false;
			using (List<string>.Enumerator enumerator3 = list_3.Select((ProcessorPaymentTypeWithId x) => x.PaymentTypeName.ToUpper()).ToList().GetEnumerator())
			{
				while (enumerator3.MoveNext())
				{
					_003C_003Ec__DisplayClass72_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass72_0();
					CS_0024_003C_003E8__locals0.paid_pt = enumerator3.Current;
					if (list_6.Where((PaymentType x) => x.PrintReceipt && x.Name.ToUpper() == CS_0024_003C_003E8__locals0.paid_pt.ToUpper()).Count() > 0)
					{
						flag = true;
						continue;
					}
					foreach (string item5 in from b in list_6
						where b.PrintReceipt
						select b into x
						select x.Name.ToUpper())
					{
						if (!item5.Contains("DEBIT") || (!(CS_0024_003C_003E8__locals0.paid_pt == "INTERAC") && !(CS_0024_003C_003E8__locals0.paid_pt == "DEBIT")))
						{
							if (item5.Contains("CREDIT") && string_9.Contains(CS_0024_003C_003E8__locals0.paid_pt))
							{
								flag = true;
								break;
							}
							continue;
						}
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				PrintHelper.GenerateReceipt(string_0, printPaymentTransaction: true, 1, null, tipFlag: false, email: false, MemoryLoadedObjects.this_terminal.DefaultPrinter, decimal_12, decimal_13);
			}
		}
		if (!string.IsNullOrEmpty(order.Source) && order.Source.Contains("Hippos") && (order.OrderType == OrderTypes.DeliveryOnline || order.OrderType == OrderTypes.TakeOutOnline || order.OrderType == OrderTypes.PickUpOnline))
		{
			SyncMethods.UpdateOrderStatusInOrdering(order.OrderNumber, "Paid", "", text2);
		}
		if ((order.OrderType == OrderTypes.DineIn || order.OrderType == OrderTypes.ToGo) && SettingsHelper.GetSettingValueByKey("print_chit_cashout") == "ON")
		{
			new OrderHelper().OrderPrintMadeCheck("", string_0, string_3, string_6, string_2, lblEmployee.Text.Replace("EMPLOYEE:", ""), list.Count());
		}
		if (bool_5)
		{
			GClass8.OpenCashDrawer();
		}
		OrderMethods.LogOrderAudit(string_0, "Order PAID, Payment Method -> " + text2);
		if (SettingsHelper.GetSettingValueByKey("payfinish_screen") == "ON")
		{
			bool flag2 = true;
			if (SettingsHelper.GetSettingValueByKey("payfinish_screen_ifchange") == "ON" && num2 == 0m)
			{
				flag2 = false;
			}
			decimal num3 = num2;
			if (bool_4)
			{
				num3 = num2 - tip;
			}
			if (MemoryLoadedObjects.OrderEntrySecondScreen != null)
			{
				MemoryLoadedObjects.OrderEntrySecondScreen.ShowCustomerTenderChange($"{num3:C}");
			}
			if (flag2)
			{
				frmPayFinish obj = new frmPayFinish((num3 > 0m) ? num3 : 0m, string_0, text2.ToUpper(), tip, string_15, decimal_8, decimal_12, decimal_13, bool_0);
				switch (obj.ShowDialog(this))
				{
				case DialogResult.OK:
					method_15();
					base.DialogResult = DialogResult.OK;
					Hide();
					break;
				case DialogResult.Cancel:
					method_5(bool_14: false);
					base.DialogResult = DialogResult.None;
					OrderMethods.UnpaidAnOrder(string_0, tip);
					OrderMethods.LogOrderAudit(string_0, "Order Cancelled Payment");
					GuestMethods.UpdateTableGuestCapacity(string_2.Replace("Table", string.Empty).Trim(), int_0, short_0);
					GuestMethods.AssignEmployeeTable(string_2.Replace("Table", string.Empty).Trim(), short_0);
					break;
				}
				obj.Dispose();
			}
			else
			{
				method_15();
				base.DialogResult = DialogResult.OK;
				Hide();
			}
		}
		else
		{
			method_15();
			base.DialogResult = DialogResult.OK;
			Hide();
		}
		if (Application.OpenForms["frmMultiBills"] is frmMultiBills frmMultiBills2 && frmMultiBills2.screenOrderType == OrderTypes.PickUp)
		{
			frmMultiBills2.LoadFormProcedure();
		}
		if ((int)CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] != int_2 && SettingsHelper.GetSettingValueByKey("workflow_prompt_cashout_pin") == "ON")
		{
			CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = int_2;
		}
		list_5.Clear();
	}

	private bool method_15()
	{
		if (SettingsHelper.GetSettingValueByKey("safe_drop_setting") == "ON" && list_3.Count > 0 && list_3.Where((ProcessorPaymentTypeWithId a) => a.PaymentTypeName.ToUpper() == "CASH").Count() > 0)
		{
			_003C_003Ec__DisplayClass73_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass73_0();
			new GClass6();
			CS_0024_003C_003E8__locals0.billGreaterAmount = Convert.ToInt32(SettingsHelper.GetSettingValueByKey("safe_drop_bill"));
			int num = Convert.ToInt32(SettingsHelper.GetSettingValueByKey("safe_drop_til"));
			if (CS_0024_003C_003E8__locals0.billGreaterAmount > 0 || num > 0)
			{
				decimal totalAmountInTil = OrderMethods.GetTotalAmountInTil();
				bool flag = false;
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				decimal[] source = new decimal[5] { 100m, 50m, 20m, 10m, 5m };
				foreach (ListViewItem item in lstTenderTypes.Items)
				{
					string text = Convert.ToDecimal(item.SubItems[1].Text.RemoveAllNonNumeric()).ToString("0");
					if (item.SubItems[0].Text.ToUpper() == "CASH" && source.Contains(Convert.ToDecimal(text)))
					{
						if (dictionary.ContainsKey(text))
						{
							int num2 = Convert.ToInt32(dictionary[text]);
							dictionary[text] = (num2 + 1).ToString();
						}
						else
						{
							dictionary.Add(text, "1");
						}
					}
				}
				if (CS_0024_003C_003E8__locals0.billGreaterAmount > 0 && dictionary.Where((KeyValuePair<string, string> a) => Convert.ToInt32(a.Key) >= CS_0024_003C_003E8__locals0.billGreaterAmount).Count() > 0)
				{
					flag = true;
				}
				else if (num > 0 && totalAmountInTil > (decimal)num)
				{
					flag = true;
				}
				if (flag)
				{
					GClass8.OpenCashDrawer();
					if (new frmCashCounter(totalAmountInTil, dictionary).ShowDialog(this) == DialogResult.OK)
					{
						new NotificationLabel(this, "Safe Drop Added", NotificationTypes.Success).Show();
						return true;
					}
					return false;
				}
			}
		}
		return true;
	}

	private bool method_16()
	{
		GClass6 gClass = new GClass6();
		if (bool_6)
		{
			CardProcessorObject cardProcessorSettingActiveOnly = SettingsHelper.GetCardProcessorSettingActiveOnly("Ackroo", "gift_card_json");
			if (cardProcessorSettingActiveOnly != null)
			{
				if (cardProcessorSettingActiveOnly.Processor == "Ackroo" && list_3.Where((ProcessorPaymentTypeWithId a) => a.PaymentTypeName == "GIFT CARD").Count() > 0)
				{
					using var enumerator = (from a in list_3
						where a.PaymentTypeName == "GIFT CARD" && !a.PaymentReceived
						group a by a.CardNumber into a
						select new
						{
							CardNumber = a.Key,
							Amount = a.Sum((ProcessorPaymentTypeWithId b) => b.Amount)
						}).GetEnumerator();
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass75_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass75_0();
						CS_0024_003C_003E8__locals0.pm = enumerator.Current;
						AckrooGiftCardREDEEMResponse ackrooGiftCardREDEEMResponse = AckrooMethods.RedeemCard(CS_0024_003C_003E8__locals0.pm.CardNumber, CS_0024_003C_003E8__locals0.pm.Amount);
						if (string.IsNullOrEmpty(ackrooGiftCardREDEEMResponse.error))
						{
							GiftCardTransactionLog entity = new GiftCardTransactionLog
							{
								OrderNumber = string_0,
								DateCreated = DateTime.Now,
								Type = "reponse",
								Data = JsonConvert.SerializeObject((object)ackrooGiftCardREDEEMResponse),
								ProcessorName = "Ackroo".ToUpper() + " GIFT CARD"
							};
							gClass.GiftCardTransactionLogs.InsertOnSubmit(entity);
							Helper.SubmitChangesWithCatch(gClass);
							btnCancel.Enabled = false;
							ProcessorPaymentTypeWithId processorPaymentTypeWithId = list_3.Where((ProcessorPaymentTypeWithId x) => x.CardNumber == CS_0024_003C_003E8__locals0.pm.CardNumber).FirstOrDefault();
							if (processorPaymentTypeWithId != null)
							{
								processorPaymentTypeWithId.PaymentReceived = true;
								foreach (ListViewItem item in lstTenderTypes.Items)
								{
									if (item.SubItems[0].Text == processorPaymentTypeWithId.PaymentTypeName && processorPaymentTypeWithId.Id == item.SubItems[2].Text)
									{
										item.SubItems[3].Text = "true";
									}
								}
							}
							AckrooCardResponse ackrooCardResponse = AckrooMethods.CheckCardBalance(CS_0024_003C_003E8__locals0.pm.CardNumber);
							decimal_12 = Convert.ToDecimal(ackrooCardResponse.gift);
							continue;
						}
						new NotificationLabel(this, "AckrooReturned Error: " + ackrooGiftCardREDEEMResponse.error, NotificationTypes.Warning).Show();
						new frmMessageBox("Ackroo Returned Error: " + ackrooGiftCardREDEEMResponse.error, "Ackroo Error").ShowDialog();
						return false;
					}
				}
				if (bool_0 && cardProcessorSettingActiveOnly != null && cardProcessorSettingActiveOnly.Processor == "Ackroo" && !method_20(gClass))
				{
					base.DialogResult = DialogResult.None;
					return false;
				}
			}
		}
		return true;
	}

	private bool method_17()
	{
		GClass6 gClass = new GClass6();
		if (bool_7)
		{
			CardProcessorObject cardProcessorSettingActiveOnly = SettingsHelper.GetCardProcessorSettingActiveOnly("Ackroo", "loyalty_card_json");
			if (cardProcessorSettingActiveOnly != null && list_3.Where((ProcessorPaymentTypeWithId a) => a.PaymentTypeName == "LOYALTY CARD").Count() > 0 && cardProcessorSettingActiveOnly.Processor == "Ackroo")
			{
				using var enumerator = (from a in list_3
					where a.PaymentTypeName == "LOYALTY CARD"
					group a by a.CardNumber into a
					select new
					{
						CardNumber = a.Key,
						Amount = a.Sum((ProcessorPaymentTypeWithId b) => b.Amount)
					}).GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass77_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass77_0();
					CS_0024_003C_003E8__locals0.pm = enumerator.Current;
					AckrooGiftCardREDEEMResponse ackrooGiftCardREDEEMResponse = AckrooMethods.RedeemLoyaltyPoints(CS_0024_003C_003E8__locals0.pm.CardNumber, CS_0024_003C_003E8__locals0.pm.Amount);
					if (string.IsNullOrEmpty(ackrooGiftCardREDEEMResponse.error))
					{
						GiftCardTransactionLog entity = new GiftCardTransactionLog
						{
							OrderNumber = string_0,
							DateCreated = DateTime.Now,
							Type = "reponse",
							Data = JsonConvert.SerializeObject((object)ackrooGiftCardREDEEMResponse),
							ProcessorName = "Ackroo".ToUpper() + " LOYALTY CARD",
							EncryptedCardNumber = StringCipher.Encrypt(CS_0024_003C_003E8__locals0.pm.CardNumber, "DigitalCraftHipPOS")
						};
						gClass.GiftCardTransactionLogs.InsertOnSubmit(entity);
						Helper.SubmitChangesWithCatch(gClass);
						btnCancel.Enabled = false;
						ProcessorPaymentTypeWithId processorPaymentTypeWithId = list_3.Where((ProcessorPaymentTypeWithId x) => x.CardNumber == CS_0024_003C_003E8__locals0.pm.CardNumber).FirstOrDefault();
						if (processorPaymentTypeWithId != null)
						{
							processorPaymentTypeWithId.PaymentReceived = true;
							foreach (ListViewItem item in lstTenderTypes.Items)
							{
								if (item.SubItems[0].Text == processorPaymentTypeWithId.PaymentTypeName && processorPaymentTypeWithId.Id == item.SubItems[2].Text)
								{
									item.SubItems[3].Text = "true";
								}
							}
						}
						AckrooCardResponse ackrooCardResponse = AckrooMethods.CheckCardBalance(CS_0024_003C_003E8__locals0.pm.CardNumber);
						decimal_13 = Convert.ToDecimal(ackrooCardResponse.loyalty);
						continue;
					}
					string text = ackrooGiftCardREDEEMResponse.error;
					if (text.Contains("LoyaltyAmountLessThreshold"))
					{
						text = "The Ackroo Loyalty amount is less than the minimum amount allowed. Enter an amount greater than 5$";
					}
					else if (ackrooGiftCardREDEEMResponse.error == "LoyaltyRedemptionNowAllowedCardNotRegistered")
					{
						ackrooGiftCardREDEEMResponse.error = "Customer needs to sign up for an account to redeem their loyalty points. ";
					}
					new NotificationLabel(this, "Ackroo Returned Error: " + text, NotificationTypes.Warning).Show();
					new frmMessageBox("Ackroo Returned Error: " + text, "Ackroo Error").ShowDialog();
					return false;
				}
			}
		}
		return true;
	}

	private bool method_18()
	{
		if (bool_7)
		{
			CardProcessorObject cardProcessorSettingActiveOnly = SettingsHelper.GetCardProcessorSettingActiveOnly("Ackroo", "loyalty_card_json");
			if (cardProcessorSettingActiveOnly != null && cardProcessorSettingActiveOnly.Processor == "Ackroo")
			{
				decimal num = default(decimal);
				GClass6 gClass = new GClass6();
				using (IEnumerator<Order> enumerator = gClass.Orders.Where((Order o) => o.OrderNumber == string_0).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass78_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass78_0();
						CS_0024_003C_003E8__locals0.order = enumerator.Current;
						Item item = MemoryLoadedData.all_active_items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals0.order.ItemID).FirstOrDefault();
						if (item != null && item.LoyaltyRedemption && CS_0024_003C_003E8__locals0.order.SubTotal > 0m)
						{
							num += CS_0024_003C_003E8__locals0.order.SubTotal;
						}
					}
				}
				if (num > 0m)
				{
					frmGiftCardPrompt frmGiftCardPrompt2 = new frmGiftCardPrompt("PAYMENT DONE: Enter Loyalty Card", GCAndLoyalty: false, "NO CARD");
					frmGiftCardPrompt2.ShowDialog(this);
					if (frmGiftCardPrompt2.DialogResult == DialogResult.OK)
					{
						AckrooGiftCardFUNDResponse ackrooGiftCardFUNDResponse = AckrooMethods.FundLoyaltyPoints(frmGiftCardPrompt2.CardNumber, num);
						if (!string.IsNullOrEmpty(ackrooGiftCardFUNDResponse.error))
						{
							new NotificationLabel(this, "Ackroo Returned Error: " + ackrooGiftCardFUNDResponse.error, NotificationTypes.Warning).Show();
							new frmMessageBox("Ackroo Returned Error: " + ackrooGiftCardFUNDResponse.error, "Ackroo Error").ShowDialog();
							return false;
						}
						GiftCardTransactionLog entity = new GiftCardTransactionLog
						{
							OrderNumber = string_0,
							DateCreated = DateTime.Now,
							Type = "reponse",
							Data = JsonConvert.SerializeObject((object)ackrooGiftCardFUNDResponse),
							ProcessorName = "Ackroo".ToUpper() + " LOYALTY CARD EARNED",
							EncryptedCardNumber = StringCipher.Encrypt(frmGiftCardPrompt2.CardNumber, "DigitalCraftHipPOS")
						};
						gClass.GiftCardTransactionLogs.InsertOnSubmit(entity);
						Helper.SubmitChangesWithCatch(gClass);
						AckrooCardResponse ackrooCardResponse = AckrooMethods.CheckCardBalance(frmGiftCardPrompt2.CardNumber);
						decimal_13 = Convert.ToDecimal(ackrooCardResponse.loyalty);
					}
				}
			}
		}
		return true;
	}

	private void method_19(decimal decimal_14, string string_15)
	{
		if (!(decimal_14 > 0m) && MemoryLoadedObjects.all_tip_sharing.Where((CustomTipSharing a) => a.TipShareType == 2).Count() <= 0)
		{
			return;
		}
		GClass6 gClass = new GClass6();
		List<Order> list = gClass.Orders.Where((Order o) => o.OrderNumber == string_0).ToList();
		decimal num = list.Where((Order a) => !a.Void && a.Paid).Sum((Order a) => a.SubTotal);
		foreach (Order item in list)
		{
			if (decimal_14 > 0m)
			{
				item.Synced = false;
				item.TipAmount += decimal_14;
				item.TipDesc = OrderHelper.UpdateDiscountFromDiscountDescription(item.TipDesc, TipTypes.Cash, decimal_14);
			}
			List<string> list2 = new List<string>();
			foreach (CustomTipSharing item2 in MemoryLoadedObjects.all_tip_sharing.Where((CustomTipSharing a) => a.Percentage > 0m))
			{
				decimal num2 = item.TipAmount * item2.Percentage / 100m;
				if (num2 > 0m && item2.TipShareType == 1 && decimal_14 > 0m)
				{
					list2.Add(item2.TipName + "=" + num2.ToString("0.00") + "=" + item2.Percentage.ToString("0.##"));
				}
				else if (item2.TipShareType == 2)
				{
					num2 = num * item2.Percentage / 100m;
					list2.Add(item2.TipName + "=" + num2.ToString("0.00") + "=" + item2.Percentage.ToString("0.##"));
				}
			}
			if (decimal_14 > 0m || (list2 != null && list2.Count > 0))
			{
				item.TipShareDesc = string.Join("|", list2);
				item.TipRecorded = true;
				if (bool_1 && (item.OrderType.Equals(OrderTypes.PickUp) || item.OrderType.Equals(OrderTypes.Delivery)))
				{
					item.DateCleared = DateTime.Now;
				}
				if (!string.IsNullOrEmpty(string_15))
				{
					item.TransactionApprovalCode = string_15;
				}
			}
		}
		Helper.SubmitChangesWithCatch(gClass);
	}

	private bool method_20(GClass6 gclass6_1)
	{
		List<Order> list = (from o in gclass6_1.Orders
			where o.Void == false && o.OrderNumber == string_0 && o.ItemName.ToUpper().Contains("GIFT CARD")
			select o into x
			orderby x.DateCreated
			select x).ToList();
		bool flag = false;
		bool flag2 = false;
		decimal num = default(decimal);
		int num2 = (int)list.Sum((Order a) => a.Qty);
		string text = "1st";
		if (list_5.Count >= num2)
		{
			return true;
		}
		foreach (Order item in list)
		{
			int num3 = 0;
			if (!string.IsNullOrEmpty(item.Instructions))
			{
				num3 = item.Instructions.Split(new string[1] { " ****" }, StringSplitOptions.None).Length - 1;
			}
			flag = false;
			flag2 = false;
			num = item.SubTotal / item.Qty;
			for (int i = num3; i < (int)item.Qty; i++)
			{
				do
				{
					_003C_003Ec__DisplayClass80_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass80_0();
					text = (((int)item.Qty == 1) ? string.Empty : (i + 1 + HelperMethods.ToOrdinal(i + 1).ToUpper()));
					CS_0024_003C_003E8__locals0.gcPrompt = new frmGiftCardPrompt("Please enter/swipe " + text + " card for " + $"{item.SubTotal / item.Qty:C}" + " gift card purchase.");
					CS_0024_003C_003E8__locals0.gcPrompt.ShowDialog(this);
					if (CS_0024_003C_003E8__locals0.gcPrompt.DialogResult == DialogResult.OK)
					{
						if (list_5.Where((GiftCardDetails o) => o.CardNumber == CS_0024_003C_003E8__locals0.gcPrompt.CardNumber).FirstOrDefault() != null)
						{
							if (new frmMessageBox("This gift card # " + CS_0024_003C_003E8__locals0.gcPrompt.CardNumber + " was already funded for this order, do you want to continue to fund this card?", "ALREADY USED", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.No)
							{
								flag = false;
								flag2 = false;
							}
							else
							{
								flag2 = true;
							}
						}
						else
						{
							flag2 = true;
						}
						if (!flag2)
						{
							flag = false;
							continue;
						}
						AckrooGiftCardFUNDResponse ackrooGiftCardFUNDResponse = AckrooMethods.FundCard(CS_0024_003C_003E8__locals0.gcPrompt.CardNumber, num);
						if (!string.IsNullOrEmpty(ackrooGiftCardFUNDResponse.error))
						{
							new NotificationLabel(this, ackrooGiftCardFUNDResponse.error, NotificationTypes.Warning).Show();
							new frmMessageBox("There was a problem loading gift card #: " + CS_0024_003C_003E8__locals0.gcPrompt.CardNumber + ", please try another card.", "Error Loading Card").ShowDialog();
							flag = false;
							flag2 = false;
							continue;
						}
						GiftCardTransactionLog entity = new GiftCardTransactionLog
						{
							OrderNumber = string_0,
							DateCreated = DateTime.Now,
							Type = "reponse",
							Data = JsonConvert.SerializeObject((object)ackrooGiftCardFUNDResponse),
							ProcessorName = "Ackroo".ToUpper() + " FUND GIFT CARD",
							EncryptedCardNumber = StringCipher.Encrypt(CS_0024_003C_003E8__locals0.gcPrompt.CardNumber, "DigitalCraftHipPOS")
						};
						list_5.Add(new GiftCardDetails
						{
							CardNumber = CS_0024_003C_003E8__locals0.gcPrompt.CardNumber,
							Amount = num
						});
						item.Instructions = item.ItemName + " ****" + CS_0024_003C_003E8__locals0.gcPrompt.CardNumber.Substring(Math.Max(0, CS_0024_003C_003E8__locals0.gcPrompt.CardNumber.Length - 4));
						gclass6_1.GiftCardTransactionLogs.InsertOnSubmit(entity);
						Helper.SubmitChangesWithCatch(gclass6_1);
						flag = true;
						continue;
					}
					return false;
				}
				while (!flag);
			}
		}
		Helper.SubmitChangesWithCatch(gclass6_1);
		return true;
	}

	private void btnDone_EnabledChanged(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (!string.IsNullOrEmpty(button.Text))
		{
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
	}

	private Stream method_21(string string_15, string string_16, Encoding encoding_0, string string_17, bool bool_14)
	{
		Stream stream = new MemoryStream();
		ilist_0.Add(stream);
		return stream;
	}

	private void frmPay_Load(object sender, EventArgs e)
	{
		int_2 = Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString());
		btnRemove.Enabled = false;
		Button29.Text = string_14;
	}

	public bool EmployeeLogIn(string prompt)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(prompt);
		MemoryLoadedObjects.Numpad.showRememberMe = false;
		bool flag = false;
		while (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			Employee employee = UserMethods.AuthenticateUser(Convert.ToString(MemoryLoadedObjects.Numpad.valueEntered));
			if (employee == null)
			{
				new frmMessageBox(Resources.Invalid_PIN_entered).ShowDialog(this);
				MemoryLoadedObjects.Numpad.TextInput = string.Empty;
				if (flag)
				{
					return false;
				}
				continue;
			}
			flag = true;
			lblEmployee.Text = employee.FirstName + " " + employee.LastName;
			short_0 = (short)employee.EmployeeID;
			CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = employee.EmployeeID;
			return true;
		}
		flag = true;
		return false;
	}

	private void method_22(string string_15, bool bool_14, bool bool_15)
	{
		Button button = new Button();
		button.BackColor = Color.FromArgb(50, 119, 155);
		button.FlatStyle = FlatStyle.Flat;
		button.FlatAppearance.BorderColor = Color.Black;
		button.FlatAppearance.BorderSize = 0;
		button.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		button.ForeColor = Color.White;
		button.Name = "btn" + string_15 + "_" + (bool_14 ? "YES" : "NO") + "_" + (bool_15 ? "YES" : "NO");
		button.Text = string_15.ToUpper();
		button.Size = new Size(125, 63);
		button.UseVisualStyleBackColor = false;
		button.Margin = new Padding(1, 0, 0, 1);
		button.Padding = new Padding(0, 0, 0, 0);
		button.Click += method_7;
		pnlTenderTypes.Controls.Add(button);
	}

	private void method_23(int int_4)
	{
		Button button = new Button();
		button.BackColor = Color.FromArgb(35, 39, 56);
		button.FlatStyle = FlatStyle.Flat;
		button.Enabled = false;
		button.FlatAppearance.BorderSize = 0;
		button.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 39, 56);
		button.Name = "btnPlaceHolder_" + int_1;
		button.Text = string.Empty;
		button.Size = new Size(125, 60);
		button.UseVisualStyleBackColor = false;
		button.Margin = new Padding(1, 0, 0, 1);
		button.Padding = new Padding(0, 0, 0, 0);
		pnlTenderTypes.Controls.Add(button);
		pnlTenderTypes.Controls.SetChildIndex(button, int_4);
		int_1++;
	}

	private void btnRemove_Click(object sender, EventArgs e)
	{
		if (lstTenderTypes.SelectedItems.Count == 0 && lstTenderTypes.Items.Count != 1)
		{
			new frmMessageBox(Resources.Please_select_a_Tender_Type_to, Resources._Error).ShowDialog(this);
			return;
		}
		_003C_003Ec__DisplayClass89_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass89_0();
		if (lstTenderTypes.Items.Count == 1)
		{
			lstTenderTypes.Items[0].Selected = true;
		}
		string text = lstTenderTypes.SelectedItems[0].Text;
		CS_0024_003C_003E8__locals0.selectedId = lstTenderTypes.SelectedItems[0].SubItems[2].Text;
		if (lstTenderTypes.SelectedItems[0].SubItems.Count > 3 && lstTenderTypes.SelectedItems[0].SubItems[3] != null)
		{
			new NotificationLabel(this, "Cannot remove.  Payment has already been collected/received for the selected tender.", NotificationTypes.Notification).Show();
			return;
		}
		list_3.RemoveAll((ProcessorPaymentTypeWithId u) => u.Id == CS_0024_003C_003E8__locals0.selectedId);
		string text2 = lstTenderTypes.SelectedItems[0].SubItems[1].Text.RemoveAllNonNumeric();
		if (text2.Contains("("))
		{
			text2 = "-" + text2.Replace("(", string.Empty).Replace(")", string.Empty);
		}
		decimal num = Convert.ToDecimal(text2);
		decimal num2 = Convert.ToDecimal(100);
		if (text.ToUpper() != Resources.CASH0 && text.ToUpper() != "SKIP THE DISHES" && text.ToUpper() != "UBER EATS".ToUpper())
		{
			CardTransactionFeeObject cardTransactionFeeObject = (text.ToUpper().Contains("DEBIT") ? SettingsHelper.GetTransactionFeeSetting("Debit") : SettingsHelper.GetTransactionFeeSetting("Credit"));
			decimal num3 = default(decimal);
			num3 = ((cardTransactionFeeObject.TenderType != '%') ? cardTransactionFeeObject.Amount : (num - num2 * num / (cardTransactionFeeObject.Amount + num2)));
			decimal_10 -= num3;
			if (decimal_10 <= 0m)
			{
				decimal_10 = default(decimal);
			}
			decimal_10 = Math.Round(decimal_10, 2);
			list_4.Remove(num3);
		}
		decimal_5 -= num;
		lstTenderTypes.SelectedItems[0].Remove();
		IvtFeqSdpCc();
		if (text.ToUpper() == Resources.Cash.ToUpper())
		{
			decimal_6 -= num;
			decimal_7 -= num;
			if (decimal_7 <= 0m)
			{
				decimal_7 = default(decimal);
			}
		}
		method_5(!(txtInput.Text.ToDecimalWithCleanUp() == 0m));
		if (lstTenderTypes.Items.Count == 0)
		{
			btnCancel.Enabled = true;
		}
	}

	private void lstTenderTypes_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (lstTenderTypes.SelectedIndices.Count > 0)
		{
			btnRemove.Enabled = true;
		}
		else
		{
			btnRemove.Enabled = false;
		}
	}

	private void txtInput_TextChanged(object sender, EventArgs e)
	{
	}

	private void method_24(decimal decimal_14)
	{
		txtInput.Text = decimal_14.ToString("0.00");
		PaymentType paymentType = list_6.Where((PaymentType x) => x.Name.ToUpper() == "CASH").FirstOrDefault();
		if (paymentType != null)
		{
			method_8(paymentType.Name.ToUpper(), paymentType.OpenCashDrawer, paymentType.UsePaymentTerminal);
		}
	}

	private void method_25(Button button_0)
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
			if (txtInput.Text != string.Empty && txtInput.Text.ToDecimalWithCleanUp() > 1000000m)
			{
				new frmMessageBox(Resources.Tender_input_too_large).ShowDialog();
				return;
			}
			char c = '-';
			c = Convert.ToChar(Button29.Text);
			if (button_0.Text == c.ToString() && string_10.Contains(c))
			{
				return;
			}
			string_10 += button_0.Text;
			if (c != '-')
			{
				if (!string_10.Contains(c))
				{
					txtInput.Text = (Convert.ToDecimal(string_10) / 100m).ToString("0.00");
				}
				else if (string_10.Split(c)[1].Length <= 2)
				{
					txtInput.Text = string_10;
				}
			}
			else if (!string_10.Contains(c))
			{
				txtInput.Text = (Convert.ToDecimal(string_10) / 100m).ToString("0.00");
			}
			else if (string_10.Split(c)[1].Length <= 2)
			{
				txtInput.Text = string_10;
			}
		}
		catch
		{
			txtInput.Text = string.Empty;
		}
	}

	private void Button6_Click(object sender, EventArgs e)
	{
		method_24(50m);
	}

	private void Button7_Click(object sender, EventArgs e)
	{
		method_24(20m);
	}

	private void button3_Click(object sender, EventArgs e)
	{
		method_24(10m);
	}

	private void button5_Click(object sender, EventArgs e)
	{
		method_24(5m);
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		method_25((Button)sender);
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		method_25((Button)sender);
	}

	private void Button4_Click(object sender, EventArgs e)
	{
		method_25((Button)sender);
	}

	private void Button20_Click(object sender, EventArgs e)
	{
		method_25((Button)sender);
	}

	private void Button19_Click(object sender, EventArgs e)
	{
		method_25((Button)sender);
	}

	private void Button18_Click(object sender, EventArgs e)
	{
		method_25((Button)sender);
	}

	private void Button28_Click(object sender, EventArgs e)
	{
		method_25((Button)sender);
	}

	private void Button27_Click(object sender, EventArgs e)
	{
		method_25((Button)sender);
	}

	private void Button26_Click(object sender, EventArgs e)
	{
		method_25((Button)sender);
	}

	private void Button0_Click(object sender, EventArgs e)
	{
		method_25((Button)sender);
	}

	private void Button8_Click(object sender, EventArgs e)
	{
		char c = '-';
		if (string_10.Contains("."))
		{
			c = '.';
		}
		else if (string_10.Contains(","))
		{
			c = ',';
		}
		if (c != '-')
		{
			if (string.IsNullOrEmpty(txtInput.Text.Split(c)[1]))
			{
				method_25((Button)sender);
			}
		}
		else
		{
			method_25((Button)sender);
		}
	}

	private void Button29_Click(object sender, EventArgs e)
	{
		if (!string_10.Contains(".") && !string_10.Contains(","))
		{
			method_25((Button)sender);
		}
	}

	private void btnClear_Click(object sender, EventArgs e)
	{
		txtInput.Text = 0.ToString("0.00");
		txtInput.Select();
		string_10 = string.Empty;
	}

	private void method_26(object sender, PaintEventArgs e)
	{
	}

	private void button9_Click(object sender, EventArgs e)
	{
		method_24(100m);
	}

	private void btnOrderNotes_Click(object sender, EventArgs e)
	{
		gclass6_0 = new GClass6();
		List<Order> list = gclass6_0.Orders.Where((Order o) => o.OrderNumber == string_0).ToList();
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter + "Order Notes", 0, 128, "", multiline: true);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			foreach (Order item in list)
			{
				item.OrderNotes = MemoryLoadedObjects.Keyboard.textEntered;
			}
			gclass6_0.SubmitChanges();
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnRemoveGratuity_Click(object sender, EventArgs e)
	{
		bool_13 = true;
		decimal_8 = default(decimal);
		IvtFeqSdpCc();
		IQueryable<Order> source = gclass6_0.Orders.Where((Order o) => o.OrderNumber == string_0);
		source.ToList();
		foreach (Order item in source.ToList())
		{
			item.TipRecorded = true;
			item.TipAmount = 0m;
		}
		Helper.SubmitChangesWithCatch(gclass6_0);
	}

	private void btnExactChange_Click(object sender, EventArgs e)
	{
		txtInput.Text = txtAmountDue.Text.RemoveAllNonNumeric();
	}

	private void btnPrintBill_Click(object sender, EventArgs e)
	{
		string settingValueByKey = SettingsHelper.GetSettingValueByKey("print_gratuity_info");
		string settingValueByKey2 = SettingsHelper.GetSettingValueByKey("auto_gratuity");
		if (!string.IsNullOrEmpty(settingValueByKey) && settingValueByKey.ToUpper().Equals("ON") && settingValueByKey2.ToUpper().Equals("OFF"))
		{
			PrintHelper.GenerateReceipt(string_0, printPaymentTransaction: true, 1, null, tipFlag: true, email: false, MemoryLoadedObjects.this_terminal.DefaultPrinter);
		}
		else
		{
			PrintHelper.GenerateReceipt(string_0, printPaymentTransaction: true, 1, null, tipFlag: false, email: false, MemoryLoadedObjects.this_terminal.DefaultPrinter);
		}
	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{
	}

	private void btnTaxDiscount_Click(object sender, EventArgs e)
	{
		if (lstTenderTypes.Items.Count > 0)
		{
			if (new frmMessageBox(Resources.Tender_types_will_be_cleared_d, Resources.Information, CustomMessageBoxButtons.YesNo).ShowDialog() != DialogResult.Yes)
			{
				return;
			}
			lstTenderTypes.Items.Clear();
			list_3.Clear();
			decimal_5 = (decimal_6 = 0m);
			IvtFeqSdpCc();
		}
		GClass6 gClass = new GClass6();
		User user = gClass.Users.Where((User w) => w.EmployeeID == short_0).FirstOrDefault();
		if (user == null)
		{
			return;
		}
		if (user.Role.RoleName == Roles.employee)
		{
			EmployeeLogIn(Resources.NOT_LOGGED_IN_Enter_Employee_P);
			if (gClass.Users.Where((User w) => w.EmployeeID == short_0).FirstOrDefault().Role.RoleName == Roles.employee)
			{
				new frmMessageBox(Resources.Please_Enter_an_Admin_PIN, Resources.Error_Permission).ShowDialog(this);
				return;
			}
		}
		Dictionary<string, string> taxRules = TaxMethods.getTaxRules();
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.ItemSelector();
		MemoryLoadedObjects.ItemSelector.LoadForm(taxRules.Values.ToArray(), _withCustom: false, Resources.Select_a_Tax_Rule);
		if (MemoryLoadedObjects.ItemSelector.ShowDialog(this) == DialogResult.OK)
		{
			_003C_003Ec__DisplayClass118_0 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass118_0();
			List<Item> source = MemoryLoadedData.all_items.Where((Item item_0) => list_2.Select((Item b) => b.ItemID).Contains(item_0.ItemID)).ToList();
			CS_0024_003C_003E8__locals1.ruleName = MemoryLoadedObjects.ItemSelector.SingleSelectedItem;
			string[] itemList = (from a in gClass.Reasons
				where a.ReasonType == "tax change"
				select a into d
				select d.Value).ToArray();
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.ItemSelector();
			MemoryLoadedObjects.ItemSelector.LoadForm(itemList, _withCustom: true, Resources.Select_a_Tax_Change_Reasons);
			if (MemoryLoadedObjects.ItemSelector.ShowDialog(this) == DialogResult.OK)
			{
				string_8 = MemoryLoadedObjects.ItemSelector.SingleSelectedItem;
				TaxRule taxRule = gClass.TaxRules.Where((TaxRule t) => t.RuleName == CS_0024_003C_003E8__locals1.ruleName).FirstOrDefault();
				if (taxRule != null)
				{
					using List<Item>.Enumerator enumerator = list_2.GetEnumerator();
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass118_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass118_1();
						CS_0024_003C_003E8__locals0.item = enumerator.Current;
						Item item = source.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals0.item.ItemID).FirstOrDefault();
						if (item != null && item.TaxRule.TaxRuleOperations.FirstOrDefault().Tax.Percentage > 0m)
						{
							CS_0024_003C_003E8__locals0.item.TaxRule = taxRule;
						}
					}
				}
				IvtFeqSdpCc();
			}
		}
		Order order = gClass.Orders.Where((Order o) => o.OrderNumber == string_0).FirstOrDefault();
		bool isDiscount = ((decimal_2 > 0m) ? true : false);
		if (order != null)
		{
			new OrderMethods().SaveOrder(list_2, string_0, order.Customer, order.OrderType, order.CustomerID.Value, "SAVED ORDER", 0m, 0m, isPaid: false, string_5, string_4, string_6, string_7, 1, isDiscount, string_8, Convert.ToInt16(order.SeatNum), null, null, 0, null, "", GratuityRemoved: false, 0);
		}
		else
		{
			new OrderMethods().SaveOrder(list_2, string_0, string_2, string_3, order.CustomerID.Value, "SAVED ORDER", 0m, 0m, isPaid: false, string_5, string_4, string_6, string_7, 1, isDiscount, string_8, 0, null, null, 0, null, "", GratuityRemoved: false, 0);
		}
		if (!bool_13)
		{
			string settingValueByKey = SettingsHelper.GetSettingValueByKey("auto_gratuity_count");
			int currentTableGuestCapacity = GuestMethods.GetCurrentTableGuestCapacity(string_2.Replace("Table ", ""));
			if (bool_3 && currentTableGuestCapacity >= Convert.ToInt32(settingValueByKey) && string_3 == OrderTypes.DineIn)
			{
				decimal_8 = OrderMethods.ComputeAutoGratuity(string_0, string_12);
			}
		}
		IvtFeqSdpCc();
		txtInput.Text = txtAmountDue.Text.RemoveAllNonNumeric();
	}

	private void method_27(short short_1)
	{
		Employee userByID = UserMethods.GetUserByID(short_1);
		if (userByID != null)
		{
			lblEmployee.Text = userByID.FirstName + " " + userByID.LastName;
		}
	}

	private void btnChangeEmployee_Click(object sender, EventArgs e)
	{
		EmployeeLogIn("Enter Employee PIN");
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmPay));
		panel1 = new Panel();
		btnChangeEmployee = new Button();
		btnRemoveGratuity = new Button();
		txtAmountDueRounded = new TextBox();
		lblAmountDueRounded = new Label();
		btnOrderNotes = new Button();
		button9 = new Button();
		pnlTenderTypes = new FlowLayoutPanel();
		button5 = new Button();
		btnPrintBill = new Button();
		label2 = new Label();
		label3 = new Label();
		pnlReceipt = new Panel();
		lblTransactionFee = new Label();
		label11 = new Label();
		lblTotalGratuity = new Label();
		lblGratuity = new Label();
		label17 = new Label();
		label18 = new Label();
		label16 = new Label();
		lblDiscount = new Label();
		lblTotal = new Label();
		lblTotalTax = new Label();
		label12 = new Label();
		lblSubTotal = new Label();
		lblTrainingMode = new Label();
		label13 = new Label();
		label14 = new Label();
		label15 = new Label();
		label10 = new Label();
		label8 = new Label();
		label7 = new Label();
		lstItems = new ListView();
		columnHeader_2 = new ColumnHeader();
		columnHeader_3 = new ColumnHeader();
		columnHeader_4 = new ColumnHeader();
		columnHeader_5 = new ColumnHeader();
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
		sideLabel = new Label();
		txtInput = new Class18();
		label1 = new Label();
		btnTaxDiscount = new Button();
		lblWindowTitle = new Label();
		btnDiscount = new Button();
		btnRemove = new Button();
		lstTenderTypes = new ListView();
		columnHeader_0 = new ColumnHeader();
		columnHeader_1 = new ColumnHeader();
		btnDone = new Button();
		lblEmployee = new Label();
		btnCancel = new Button();
		txtAmountDue = new TextBox();
		Label6 = new Label();
		Label5 = new Label();
		txtChange = new TextBox();
		Label9 = new Label();
		panel1.SuspendLayout();
		pnlReceipt.SuspendLayout();
		SuspendLayout();
		panel1.BorderStyle = BorderStyle.FixedSingle;
		panel1.Controls.Add(btnChangeEmployee);
		panel1.Controls.Add(btnRemoveGratuity);
		panel1.Controls.Add(txtAmountDueRounded);
		panel1.Controls.Add(lblAmountDueRounded);
		panel1.Controls.Add(btnOrderNotes);
		panel1.Controls.Add(button9);
		panel1.Controls.Add(pnlTenderTypes);
		panel1.Controls.Add(button5);
		panel1.Controls.Add(btnPrintBill);
		panel1.Controls.Add(label2);
		panel1.Controls.Add(label3);
		panel1.Controls.Add(pnlReceipt);
		panel1.Controls.Add(btnClear);
		panel1.Controls.Add(button3);
		panel1.Controls.Add(Button7);
		panel1.Controls.Add(Button6);
		panel1.Controls.Add(btnExactChange);
		panel1.Controls.Add(Button8);
		panel1.Controls.Add(Button29);
		panel1.Controls.Add(Button26);
		panel1.Controls.Add(Button27);
		panel1.Controls.Add(Button28);
		panel1.Controls.Add(Button18);
		panel1.Controls.Add(Button19);
		panel1.Controls.Add(Button20);
		panel1.Controls.Add(Button0);
		panel1.Controls.Add(Button4);
		panel1.Controls.Add(Button2);
		panel1.Controls.Add(Button1);
		panel1.Controls.Add(sideLabel);
		panel1.Controls.Add(txtInput);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(btnTaxDiscount);
		panel1.Controls.Add(lblWindowTitle);
		panel1.Controls.Add(btnDiscount);
		panel1.Controls.Add(btnRemove);
		panel1.Controls.Add(lstTenderTypes);
		panel1.Controls.Add(btnDone);
		panel1.Controls.Add(lblEmployee);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(txtAmountDue);
		panel1.Controls.Add(Label6);
		panel1.Controls.Add(Label5);
		panel1.Controls.Add(txtChange);
		panel1.Controls.Add(Label9);
		componentResourceManager.ApplyResources(panel1, "panel1");
		panel1.Name = "panel1";
		panel1.Paint += panel1_Paint;
		btnChangeEmployee.BackColor = Color.FromArgb(255, 192, 128);
		btnChangeEmployee.FlatAppearance.BorderColor = Color.Black;
		btnChangeEmployee.FlatAppearance.BorderSize = 0;
		btnChangeEmployee.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnChangeEmployee, "btnChangeEmployee");
		btnChangeEmployee.ForeColor = Color.White;
		btnChangeEmployee.Name = "btnChangeEmployee";
		btnChangeEmployee.UseVisualStyleBackColor = false;
		btnChangeEmployee.Click += btnChangeEmployee_Click;
		btnRemoveGratuity.BackColor = Color.FromArgb(198, 129, 71);
		btnRemoveGratuity.FlatAppearance.BorderColor = Color.Black;
		btnRemoveGratuity.FlatAppearance.BorderSize = 0;
		btnRemoveGratuity.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnRemoveGratuity, "btnRemoveGratuity");
		btnRemoveGratuity.ForeColor = Color.White;
		btnRemoveGratuity.Name = "btnRemoveGratuity";
		btnRemoveGratuity.UseVisualStyleBackColor = false;
		btnRemoveGratuity.Click += btnRemoveGratuity_Click;
		txtAmountDueRounded.BackColor = Color.FromArgb(35, 39, 56);
		txtAmountDueRounded.BorderStyle = BorderStyle.None;
		txtAmountDueRounded.Cursor = Cursors.Default;
		componentResourceManager.ApplyResources(txtAmountDueRounded, "txtAmountDueRounded");
		txtAmountDueRounded.ForeColor = Color.White;
		txtAmountDueRounded.Name = "txtAmountDueRounded";
		txtAmountDueRounded.ReadOnly = true;
		componentResourceManager.ApplyResources(lblAmountDueRounded, "lblAmountDueRounded");
		lblAmountDueRounded.ForeColor = Color.White;
		lblAmountDueRounded.Name = "lblAmountDueRounded";
		componentResourceManager.ApplyResources(btnOrderNotes, "btnOrderNotes");
		btnOrderNotes.BackColor = Color.FromArgb(198, 129, 71);
		btnOrderNotes.FlatAppearance.BorderColor = Color.Black;
		btnOrderNotes.FlatAppearance.BorderSize = 0;
		btnOrderNotes.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnOrderNotes.ForeColor = Color.White;
		btnOrderNotes.Name = "btnOrderNotes";
		btnOrderNotes.UseVisualStyleBackColor = false;
		btnOrderNotes.EnabledChanged += btnDone_EnabledChanged;
		btnOrderNotes.Click += btnOrderNotes_Click;
		button9.BackColor = Color.FromArgb(100, 203, 116);
		button9.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		button9.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button9, "button9");
		button9.ForeColor = Color.White;
		button9.Name = "button9";
		button9.UseVisualStyleBackColor = false;
		button9.EnabledChanged += btnDone_EnabledChanged;
		button9.Click += button9_Click;
		componentResourceManager.ApplyResources(pnlTenderTypes, "pnlTenderTypes");
		pnlTenderTypes.Name = "pnlTenderTypes";
		button5.BackColor = Color.FromArgb(55, 141, 80);
		button5.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		button5.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button5, "button5");
		button5.ForeColor = Color.White;
		button5.Name = "button5";
		button5.UseVisualStyleBackColor = false;
		button5.EnabledChanged += btnDone_EnabledChanged;
		button5.Click += button5_Click;
		btnPrintBill.BackColor = Color.FromArgb(214, 142, 81);
		btnPrintBill.FlatAppearance.BorderColor = Color.Black;
		btnPrintBill.FlatAppearance.BorderSize = 0;
		btnPrintBill.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnPrintBill, "btnPrintBill");
		btnPrintBill.ForeColor = Color.White;
		btnPrintBill.Name = "btnPrintBill";
		btnPrintBill.UseVisualStyleBackColor = false;
		btnPrintBill.Click += btnPrintBill_Click;
		label2.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		label3.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		pnlReceipt.Controls.Add(lblTransactionFee);
		pnlReceipt.Controls.Add(label11);
		pnlReceipt.Controls.Add(lblTotalGratuity);
		pnlReceipt.Controls.Add(lblGratuity);
		pnlReceipt.Controls.Add(label17);
		pnlReceipt.Controls.Add(label18);
		pnlReceipt.Controls.Add(label16);
		pnlReceipt.Controls.Add(lblDiscount);
		pnlReceipt.Controls.Add(lblTotal);
		pnlReceipt.Controls.Add(lblTotalTax);
		pnlReceipt.Controls.Add(label12);
		pnlReceipt.Controls.Add(lblSubTotal);
		pnlReceipt.Controls.Add(lblTrainingMode);
		pnlReceipt.Controls.Add(label13);
		pnlReceipt.Controls.Add(label14);
		pnlReceipt.Controls.Add(label15);
		pnlReceipt.Controls.Add(label10);
		pnlReceipt.Controls.Add(label8);
		pnlReceipt.Controls.Add(label7);
		pnlReceipt.Controls.Add(lstItems);
		componentResourceManager.ApplyResources(pnlReceipt, "pnlReceipt");
		pnlReceipt.Name = "pnlReceipt";
		componentResourceManager.ApplyResources(lblTransactionFee, "lblTransactionFee");
		lblTransactionFee.BackColor = Color.LightGray;
		lblTransactionFee.ForeColor = Color.Black;
		lblTransactionFee.Name = "lblTransactionFee";
		componentResourceManager.ApplyResources(label11, "label11");
		label11.BackColor = Color.Gray;
		label11.ForeColor = Color.White;
		label11.Name = "label11";
		componentResourceManager.ApplyResources(lblTotalGratuity, "lblTotalGratuity");
		lblTotalGratuity.BackColor = Color.LightGray;
		lblTotalGratuity.ForeColor = Color.Black;
		lblTotalGratuity.Name = "lblTotalGratuity";
		componentResourceManager.ApplyResources(lblGratuity, "lblGratuity");
		lblGratuity.BackColor = Color.LightGray;
		lblGratuity.ForeColor = Color.Black;
		lblGratuity.Name = "lblGratuity";
		componentResourceManager.ApplyResources(label17, "label17");
		label17.BackColor = Color.Gray;
		label17.ForeColor = Color.White;
		label17.Name = "label17";
		componentResourceManager.ApplyResources(label18, "label18");
		label18.BackColor = Color.Gray;
		label18.ForeColor = Color.White;
		label18.Name = "label18";
		label16.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label16, "label16");
		label16.ForeColor = Color.White;
		label16.Name = "label16";
		componentResourceManager.ApplyResources(lblDiscount, "lblDiscount");
		lblDiscount.BackColor = Color.LightGray;
		lblDiscount.ForeColor = Color.Black;
		lblDiscount.Name = "lblDiscount";
		componentResourceManager.ApplyResources(lblTotal, "lblTotal");
		lblTotal.BackColor = Color.LightGray;
		lblTotal.ForeColor = Color.Black;
		lblTotal.Name = "lblTotal";
		componentResourceManager.ApplyResources(lblTotalTax, "lblTotalTax");
		lblTotalTax.BackColor = Color.LightGray;
		lblTotalTax.ForeColor = Color.Black;
		lblTotalTax.Name = "lblTotalTax";
		componentResourceManager.ApplyResources(label12, "label12");
		label12.BackColor = Color.Gray;
		label12.ForeColor = Color.White;
		label12.Name = "label12";
		componentResourceManager.ApplyResources(lblSubTotal, "lblSubTotal");
		lblSubTotal.BackColor = Color.LightGray;
		lblSubTotal.ForeColor = Color.Black;
		lblSubTotal.Name = "lblSubTotal";
		componentResourceManager.ApplyResources(lblTrainingMode, "lblTrainingMode");
		lblTrainingMode.BackColor = Color.FromArgb(193, 57, 43);
		lblTrainingMode.ForeColor = Color.White;
		lblTrainingMode.Name = "lblTrainingMode";
		componentResourceManager.ApplyResources(label13, "label13");
		label13.BackColor = Color.Gray;
		label13.ForeColor = Color.White;
		label13.Name = "label13";
		componentResourceManager.ApplyResources(label14, "label14");
		label14.BackColor = Color.Gray;
		label14.ForeColor = Color.White;
		label14.Name = "label14";
		componentResourceManager.ApplyResources(label15, "label15");
		label15.BackColor = Color.Gray;
		label15.ForeColor = Color.White;
		label15.Name = "label15";
		label10.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label10, "label10");
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		label8.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label8, "label8");
		label8.ForeColor = Color.White;
		label8.Name = "label8";
		label7.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label7, "label7");
		label7.ForeColor = Color.White;
		label7.Name = "label7";
		componentResourceManager.ApplyResources(lstItems, "lstItems");
		lstItems.BorderStyle = BorderStyle.None;
		lstItems.Columns.AddRange(new ColumnHeader[4] { columnHeader_2, columnHeader_3, columnHeader_4, columnHeader_5 });
		lstItems.FullRowSelect = true;
		lstItems.GridLines = true;
		lstItems.HeaderStyle = ColumnHeaderStyle.None;
		lstItems.HideSelection = false;
		lstItems.MultiSelect = false;
		lstItems.Name = "lstItems";
		lstItems.TileSize = new Size(50, 200);
		lstItems.UseCompatibleStateImageBehavior = false;
		lstItems.View = View.Details;
		componentResourceManager.ApplyResources(columnHeader_2, "ItemQty");
		componentResourceManager.ApplyResources(columnHeader_3, "ItemName");
		componentResourceManager.ApplyResources(columnHeader_4, "itemSubPrice");
		componentResourceManager.ApplyResources(columnHeader_5, "ItemSubTotal");
		btnClear.BackColor = Color.FromArgb(77, 174, 225);
		btnClear.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnClear.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnClear, "btnClear");
		btnClear.ForeColor = Color.White;
		btnClear.Name = "btnClear";
		btnClear.UseVisualStyleBackColor = false;
		btnClear.Click += btnClear_Click;
		button3.BackColor = Color.FromArgb(55, 141, 80);
		button3.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		button3.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button3, "button3");
		button3.ForeColor = Color.White;
		button3.Name = "button3";
		button3.UseVisualStyleBackColor = false;
		button3.EnabledChanged += btnDone_EnabledChanged;
		button3.Click += button3_Click;
		Button7.BackColor = Color.FromArgb(65, 168, 95);
		Button7.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button7.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button7, "Button7");
		Button7.ForeColor = Color.White;
		Button7.Name = "Button7";
		Button7.UseVisualStyleBackColor = false;
		Button7.EnabledChanged += btnDone_EnabledChanged;
		Button7.Click += Button7_Click;
		Button6.BackColor = Color.FromArgb(70, 203, 116);
		Button6.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button6.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button6, "Button6");
		Button6.ForeColor = Color.White;
		Button6.Name = "Button6";
		Button6.UseVisualStyleBackColor = false;
		Button6.EnabledChanged += btnDone_EnabledChanged;
		Button6.Click += Button6_Click;
		btnExactChange.BackColor = Color.SandyBrown;
		btnExactChange.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnExactChange.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnExactChange, "btnExactChange");
		btnExactChange.ForeColor = Color.White;
		btnExactChange.Name = "btnExactChange";
		btnExactChange.UseVisualStyleBackColor = false;
		btnExactChange.EnabledChanged += btnDone_EnabledChanged;
		btnExactChange.Click += btnExactChange_Click;
		Button8.BackColor = Color.FromArgb(118, 130, 130);
		Button8.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button8.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button8, "Button8");
		Button8.ForeColor = Color.White;
		Button8.Name = "Button8";
		Button8.UseVisualStyleBackColor = false;
		Button8.Click += Button8_Click;
		Button29.BackColor = Color.FromArgb(118, 130, 130);
		Button29.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button29.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button29, "Button29");
		Button29.ForeColor = Color.White;
		Button29.Name = "Button29";
		Button29.UseVisualStyleBackColor = false;
		Button29.Click += Button29_Click;
		Button26.BackColor = Color.FromArgb(132, 146, 146);
		Button26.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button26.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button26, "Button26");
		Button26.ForeColor = Color.White;
		Button26.Name = "Button26";
		Button26.UseVisualStyleBackColor = false;
		Button26.Click += Button26_Click;
		Button27.BackColor = Color.FromArgb(132, 146, 146);
		Button27.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button27.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button27, "Button27");
		Button27.ForeColor = Color.White;
		Button27.Name = "Button27";
		Button27.UseVisualStyleBackColor = false;
		Button27.Click += Button27_Click;
		Button28.BackColor = Color.FromArgb(132, 146, 146);
		Button28.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button28.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button28, "Button28");
		Button28.ForeColor = Color.White;
		Button28.Name = "Button28";
		Button28.UseVisualStyleBackColor = false;
		Button28.Click += Button28_Click;
		Button18.BackColor = Color.FromArgb(150, 166, 166);
		Button18.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button18.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button18, "Button18");
		Button18.ForeColor = Color.White;
		Button18.Name = "Button18";
		Button18.UseVisualStyleBackColor = false;
		Button18.Click += Button18_Click;
		Button19.BackColor = Color.FromArgb(150, 166, 166);
		Button19.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button19.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button19, "Button19");
		Button19.ForeColor = Color.White;
		Button19.Name = "Button19";
		Button19.UseVisualStyleBackColor = false;
		Button19.Click += Button19_Click;
		Button20.BackColor = Color.FromArgb(150, 166, 166);
		Button20.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button20.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button20, "Button20");
		Button20.ForeColor = Color.White;
		Button20.Name = "Button20";
		Button20.UseVisualStyleBackColor = false;
		Button20.Click += Button20_Click;
		Button0.BackColor = Color.FromArgb(118, 130, 130);
		Button0.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button0.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button0, "Button0");
		Button0.ForeColor = Color.White;
		Button0.Name = "Button0";
		Button0.UseVisualStyleBackColor = false;
		Button0.Click += Button0_Click;
		Button4.BackColor = Color.FromArgb(164, 181, 181);
		Button4.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button4.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button4, "Button4");
		Button4.ForeColor = Color.White;
		Button4.Name = "Button4";
		Button4.UseVisualStyleBackColor = false;
		Button4.Click += Button4_Click;
		Button2.BackColor = Color.FromArgb(164, 181, 181);
		Button2.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button2.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button2, "Button2");
		Button2.ForeColor = Color.White;
		Button2.Name = "Button2";
		Button2.UseVisualStyleBackColor = false;
		Button2.Click += Button2_Click;
		Button1.BackColor = Color.FromArgb(164, 181, 181);
		Button1.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		Button1.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button1, "Button1");
		Button1.ForeColor = Color.White;
		Button1.Name = "Button1";
		Button1.UseVisualStyleBackColor = false;
		Button1.Click += Button1_Click;
		sideLabel.BackColor = Color.White;
		componentResourceManager.ApplyResources(sideLabel, "sideLabel");
		sideLabel.ForeColor = Color.Black;
		sideLabel.Name = "sideLabel";
		txtInput.BorderStyle = BorderStyle.None;
		componentResourceManager.ApplyResources(txtInput, "txtInput");
		txtInput.Name = "txtInput";
		txtInput.method_1("keyboard");
		txtInput.TextChanged += txtInput_TextChanged;
		label1.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		btnTaxDiscount.BackColor = Color.FromArgb(66, 153, 199);
		btnTaxDiscount.FlatAppearance.BorderColor = Color.Black;
		btnTaxDiscount.FlatAppearance.BorderSize = 0;
		btnTaxDiscount.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnTaxDiscount, "btnTaxDiscount");
		btnTaxDiscount.ForeColor = Color.White;
		btnTaxDiscount.Name = "btnTaxDiscount";
		btnTaxDiscount.UseVisualStyleBackColor = false;
		btnTaxDiscount.Click += btnTaxDiscount_Click;
		componentResourceManager.ApplyResources(lblWindowTitle, "lblWindowTitle");
		lblWindowTitle.BackColor = Color.FromArgb(147, 101, 184);
		lblWindowTitle.ForeColor = Color.White;
		lblWindowTitle.Name = "lblWindowTitle";
		btnDiscount.BackColor = Color.FromArgb(176, 124, 219);
		btnDiscount.FlatAppearance.BorderColor = Color.Black;
		btnDiscount.FlatAppearance.BorderSize = 0;
		btnDiscount.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnDiscount, "btnDiscount");
		btnDiscount.ForeColor = Color.White;
		btnDiscount.Name = "btnDiscount";
		btnDiscount.UseVisualStyleBackColor = false;
		btnDiscount.Click += btnDiscount_Click;
		btnRemove.BackColor = Color.SandyBrown;
		btnRemove.FlatAppearance.BorderColor = Color.Black;
		btnRemove.FlatAppearance.BorderSize = 0;
		btnRemove.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnRemove, "btnRemove");
		btnRemove.ForeColor = Color.White;
		btnRemove.Name = "btnRemove";
		btnRemove.UseVisualStyleBackColor = false;
		btnRemove.EnabledChanged += btnDone_EnabledChanged;
		btnRemove.Click += btnRemove_Click;
		lstTenderTypes.BackColor = Color.FromArgb(255, 255, 192);
		lstTenderTypes.BorderStyle = BorderStyle.None;
		lstTenderTypes.Columns.AddRange(new ColumnHeader[2] { columnHeader_0, columnHeader_1 });
		componentResourceManager.ApplyResources(lstTenderTypes, "lstTenderTypes");
		lstTenderTypes.FullRowSelect = true;
		lstTenderTypes.GridLines = true;
		lstTenderTypes.HeaderStyle = ColumnHeaderStyle.None;
		lstTenderTypes.HideSelection = false;
		lstTenderTypes.MultiSelect = false;
		lstTenderTypes.Name = "lstTenderTypes";
		lstTenderTypes.TileSize = new Size(50, 200);
		lstTenderTypes.UseCompatibleStateImageBehavior = false;
		lstTenderTypes.View = View.Details;
		lstTenderTypes.SelectedIndexChanged += lstTenderTypes_SelectedIndexChanged;
		componentResourceManager.ApplyResources(columnHeader_0, "TenderType");
		componentResourceManager.ApplyResources(columnHeader_1, "ItemPrice");
		btnDone.BackColor = Color.FromArgb(80, 203, 116);
		btnDone.DialogResult = DialogResult.OK;
		btnDone.FlatAppearance.BorderColor = Color.Black;
		btnDone.FlatAppearance.BorderSize = 0;
		btnDone.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnDone, "btnDone");
		btnDone.ForeColor = Color.White;
		btnDone.Name = "btnDone";
		btnDone.UseVisualStyleBackColor = false;
		btnDone.EnabledChanged += btnDone_EnabledChanged;
		btnDone.Click += btnDone_Click;
		componentResourceManager.ApplyResources(lblEmployee, "lblEmployee");
		lblEmployee.ForeColor = Color.FromArgb(235, 107, 86);
		lblEmployee.Name = "lblEmployee";
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.DialogResult = DialogResult.Cancel;
		btnCancel.FlatAppearance.BorderColor = Color.Black;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = Color.White;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		txtAmountDue.BackColor = Color.FromArgb(35, 39, 56);
		txtAmountDue.BorderStyle = BorderStyle.None;
		txtAmountDue.Cursor = Cursors.Default;
		componentResourceManager.ApplyResources(txtAmountDue, "txtAmountDue");
		txtAmountDue.ForeColor = Color.White;
		txtAmountDue.Name = "txtAmountDue";
		txtAmountDue.ReadOnly = true;
		componentResourceManager.ApplyResources(Label6, "Label6");
		Label6.ForeColor = Color.White;
		Label6.Name = "Label6";
		componentResourceManager.ApplyResources(Label5, "Label5");
		Label5.ForeColor = Color.White;
		Label5.Name = "Label5";
		txtChange.BackColor = Color.FromArgb(35, 39, 56);
		txtChange.BorderStyle = BorderStyle.None;
		txtChange.Cursor = Cursors.Default;
		componentResourceManager.ApplyResources(txtChange, "txtChange");
		txtChange.ForeColor = Color.FromArgb(65, 168, 95);
		txtChange.Name = "txtChange";
		txtChange.ReadOnly = true;
		componentResourceManager.ApplyResources(Label9, "Label9");
		Label9.ForeColor = Color.White;
		Label9.Name = "Label9";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(panel1);
		ForeColor = Color.Black;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmPay";
		base.Opacity = 1.0;
		base.WindowState = FormWindowState.Maximized;
		base.Load += frmPay_Load;
		base.Controls.SetChildIndex(panel1, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		panel1.ResumeLayout(performLayout: false);
		panel1.PerformLayout();
		pnlReceipt.ResumeLayout(performLayout: false);
		pnlReceipt.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private bool method_28(Item item_0)
	{
		return list_2.Select((Item b) => b.ItemID).Contains(item_0.ItemID);
	}
}
