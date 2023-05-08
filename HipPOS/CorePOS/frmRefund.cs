using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
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
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmRefund : frmMasterForm
{
	private GClass6 gclass6_0;

	private DataManager dataManager_0;

	private short short_0;

	private string string_0;

	private string string_1;

	private bool bool_0;

	private bool bool_1;

	private IContainer icontainer_1;

	private Label label1;

	private Label lblOriginalOrder;

	private Label label7;

	private Label label3;

	internal ColumnHeader columnHeader_0;

	internal ColumnHeader columnHeader_1;

	private Label label4;

	private Label label5;

	internal ColumnHeader columnHeader_2;

	internal ColumnHeader columnHeader_3;

	private Label label6;

	internal Button btnRight;

	internal Button btnLeft;

	private Label lblTrainingMode;

	private ColumnHeader columnHeader_4;

	private ColumnHeader columnHeader_5;

	private Panel pnlMain;

	private VScrollBar lstItemsVScroll;

	private VScrollBar lstRefundsVScroll;

	private Label lblWindowTitle;

	private RadTextBoxControl txtSearchBox;

	private Button BtnClose;

	private Button btnSave;

	private Button btnCancel;

	private Button btnSearch;

	private ListView lstItems;

	private ListView lstRefundItems;

	private Button btnShowKeyboard_SearchBox;

	private Label lblEmployee;

	private Label label2;

	private Label label8;

	internal Button btnAllRight;

	public frmRefund()
	{
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		dataManager_0 = new DataManager();
		string_0 = string.Empty;
		string_1 = string.Empty;
		base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			lblTrainingMode.Visible = true;
		}
		else
		{
			lblTrainingMode.Visible = false;
		}
		if (!string.IsNullOrEmpty(txtSearchBox.Text))
		{
			btnSearch.Enabled = true;
		}
		else
		{
			btnSearch.Enabled = false;
		}
		btnCancel.Enabled = false;
		bool_0 = ((SettingsHelper.GetSettingValueByKey("gift_card_payment") == "ON") ? true : false);
		bool_1 = ((SettingsHelper.GetSettingValueByKey("loyalty_card_payment") == "ON") ? true : false);
	}

	public frmRefund(string orderNumber)
	{
		Class26.Ggkj0JxzN9YmC();
		this._002Ector();
		txtSearchBox.Text = orderNumber;
		btnSearch.Enabled = true;
		string_0 = txtSearchBox.Text.Trim();
		method_5();
	}

	private void frmRefund_Load(object sender, EventArgs e)
	{
		base.WindowState = FormWindowState.Maximized;
		pnlMain.Left = (base.ClientSize.Width - pnlMain.Width) / 2;
		pnlMain.Top = (base.ClientSize.Height - pnlMain.Height) / 2;
		btnSave.Enabled = false;
		ImageList imageList = new ImageList();
		imageList.ImageSize = new Size(1, 25);
		lstItems.SmallImageList = imageList;
		if (!string.IsNullOrEmpty(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString()))
		{
			short_0 = Convert.ToInt16(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"]);
			Employee employee = gclass6_0.Employees.Where((Employee x) => x.EmployeeID == short_0).FirstOrDefault();
			if (employee != null)
			{
				lblEmployee.Text = employee.FirstName + " " + employee.LastName;
			}
		}
		method_15();
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		if (lstRefundItems.Items.Count == 0)
		{
			new NotificationLabel(this, Resources.There_are_no_items_to_refund_P, NotificationTypes.Notification).Show();
			return;
		}
		gclass6_0 = new GClass6();
		IQueryable<Order> queryable = from x in new DataManager(gclass6_0).GetOrder(string_0)
			where x.Paid == true && x.Void == false && x.DatePaid.HasValue
			select x;
		if (queryable.Count() <= 0)
		{
			return;
		}
		List<ProcessorPaymentType> paymentTypes = PaymentTypeMethods.GetPaymentTypes(queryable.FirstOrDefault().PaymentMethods);
		if (paymentTypes.Select((ProcessorPaymentType a) => a.PaymentTypeName).Contains(PaymentTypes.GIFT_CARD) && paymentTypes.Count == 1 && bool_0)
		{
			string[] itemList = (from r in gclass6_0.Reasons
				where r.ReasonType == "refund"
				select r into d
				select d.Value).ToArray();
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.ItemSelector();
			MemoryLoadedObjects.ItemSelector.LoadForm(itemList, _withCustom: true, Resources.Select_Refund_Reason);
			if (MemoryLoadedObjects.ItemSelector.ShowDialog(this) == DialogResult.OK)
			{
				method_3(queryable, paymentTypes, PaymentTypes.GIFT_CARD, MemoryLoadedObjects.ItemSelector.SingleSelectedItem);
			}
			return;
		}
		if (paymentTypes.Select((ProcessorPaymentType a) => a.PaymentTypeName).Contains(PaymentTypes.LOYALTY_CARD) && paymentTypes.Count == 1 && bool_1)
		{
			string[] itemList2 = (from r in gclass6_0.Reasons
				where r.ReasonType == "refund"
				select r into d
				select d.Value).ToArray();
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.ItemSelector();
			MemoryLoadedObjects.ItemSelector.LoadForm(itemList2, _withCustom: true, Resources.Select_Refund_Reason);
			if (MemoryLoadedObjects.ItemSelector.ShowDialog(this) == DialogResult.OK)
			{
				method_3(queryable, paymentTypes, PaymentTypes.LOYALTY_CARD, MemoryLoadedObjects.ItemSelector.SingleSelectedItem);
			}
			return;
		}
		Order order = queryable.FirstOrDefault();
		if (gclass6_0.TransactionReceipts.Where((TransactionReceipt x) => x.OrderNumber == string_0 && x.RefundNumber == null && x.MerchantReceipt.Contains("APPROVED")).FirstOrDefault() == null && (order.OrderType == OrderTypes.DeliveryOnline || order.OrderType == OrderTypes.TakeOutOnline || order.OrderType == OrderTypes.PickUpOnline) && order.DateCreated.Value.AddSeconds(5.0) >= order.DatePaid.Value && paymentTypes.Count > 0)
		{
			if (new frmMessageBox("Order Type is an Online Order paid Online, Refund method will use the same payment method used in the order. Do you want to Continue?", "Refund Method", CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
			{
				string[] itemList3 = (from r in gclass6_0.Reasons
					where r.ReasonType == "refund"
					select r into d
					select d.Value).ToArray();
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.ItemSelector();
				MemoryLoadedObjects.ItemSelector.LoadForm(itemList3, _withCustom: true, Resources.Select_Refund_Reason);
				if (MemoryLoadedObjects.ItemSelector.ShowDialog(this) == DialogResult.OK)
				{
					method_3(queryable, paymentTypes, paymentTypes.FirstOrDefault().PaymentTypeName, MemoryLoadedObjects.ItemSelector.SingleSelectedItem, bool_2: true);
				}
			}
			return;
		}
		frmSelectPaymentMethod frmSelectPaymentMethod2 = new frmSelectPaymentMethod(Resources.Select_Refund_Payment, showCancelButton: true, paymentTypes.Select((ProcessorPaymentType a) => a.PaymentTypeName.ToUpper()).ToList());
		if (frmSelectPaymentMethod2.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		string[] itemList4 = (from r in gclass6_0.Reasons
			where r.ReasonType == "refund"
			select r into d
			select d.Value).ToArray();
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.ItemSelector();
		MemoryLoadedObjects.ItemSelector.LoadForm(itemList4, _withCustom: true, Resources.Select_Refund_Reason);
		if (MemoryLoadedObjects.ItemSelector.ShowDialog(this) == DialogResult.OK)
		{
			string text = "";
			if (paymentTypes.Select((ProcessorPaymentType a) => a.PaymentTypeName).Contains(PaymentTypes.GIFT_CARD))
			{
				text = text + "," + PaymentTypes.GIFT_CARD;
			}
			if (paymentTypes.Select((ProcessorPaymentType a) => a.PaymentTypeName).Contains(PaymentTypes.LOYALTY_CARD))
			{
				text = text + "," + PaymentTypes.LOYALTY_CARD;
			}
			method_3(queryable, paymentTypes, frmSelectPaymentMethod2.returnPaymentMethod + text, MemoryLoadedObjects.ItemSelector.SingleSelectedItem);
		}
	}

	private void method_3(IQueryable<Order> iqueryable_0, List<ProcessorPaymentType> list_2, string string_2, string string_3, bool bool_2 = false)
	{
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.orders = iqueryable_0;
		if (string_1 == string.Empty)
		{
			string_1 = OrderMethods.GetNewRefundNumber();
		}
		decimal num = default(decimal);
		decimal num2 = default(decimal);
		decimal num3 = default(decimal);
		bool flag = false;
		CardProcessorObject cardProcessorSettingActiveOnly = SettingsHelper.GetCardProcessorSettingActiveOnly("Ackroo", "loyalty_card_json");
		CardProcessorObject cardProcessorSettingActiveOnly2 = SettingsHelper.GetCardProcessorSettingActiveOnly("Ackroo", "gift_card_json");
		List<AckrooReversalRequest> list = new List<AckrooReversalRequest>();
		List<Refund> list2 = new List<Refund>();
		IEnumerator enumerator = lstRefundItems.Items.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass11_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass11_1();
				CS_0024_003C_003E8__locals1.item = (ListViewItem)enumerator.Current;
				decimal num4 = default(decimal);
				Order order = CS_0024_003C_003E8__locals0.orders.Where((Order o) => ((object)o.OrderId).ToString() == CS_0024_003C_003E8__locals1.item.SubItems[3].Text).FirstOrDefault();
				if (order == null)
				{
					new frmMessageBox(Resources.An_error_has_occurred0, Resources.Fatal_Error0).ShowDialog(this);
					continue;
				}
				if (order.DateRefunded.HasValue)
				{
					new frmMessageBox(Resources.Order_already_refunded, Resources.Refund_Error).ShowDialog(this);
					continue;
				}
				if (order.PaymentMethods.ToUpper().Contains("CASHBACK") && num3 == 0m)
				{
					ProcessorPaymentType processorPaymentType = (from a in PaymentTypeMethods.GetPaymentTypes(order.PaymentMethods)
						where a.PaymentTypeName.ToUpper().Contains("CASHBACK")
						select a).FirstOrDefault();
					if (processorPaymentType != null)
					{
						num3 = Math.Abs(processorPaymentType.Amount);
					}
				}
				Refund refund = new Refund();
				Order order2 = null;
				decimal num5 = MathHelper.FractionToDecimal(CS_0024_003C_003E8__locals1.item.SubItems[0].Text);
				if (num5 == order.Qty)
				{
					order.DateRefunded = DateTime.Now;
					num2 += order.SubTotal;
					num += order.Total;
					num4 = order.Total;
					order.Void = true;
					order.Synced = false;
				}
				else
				{
					order2 = new Order();
					order2.CustomerID = order.CustomerID;
					order2.Customer = order.Customer;
					order2.DateCreated = order.DateCreated;
					order2.DateFilled = order.DateFilled;
					order2.DatePaid = order.DatePaid;
					order2.DateRefunded = DateTime.Now;
					order2.Discount = order.Discount;
					order2.DiscountDesc = order.DiscountDesc;
					order2.GroupName = order.GroupName;
					order2.Instructions = order.Instructions;
					order2.ItemCost = order.ItemCost;
					order2.ItemID = order.ItemID;
					order2.ItemName = order.ItemName;
					order2.ItemPrice = order.ItemPrice;
					order2.ItemSellPrice = order.ItemSellPrice;
					order2.Notified = order.Notified;
					order2.OrderId = Guid.NewGuid();
					order2.OrderNumber = order.OrderNumber;
					order2.OrderType = order.OrderType;
					order2.Paid = order.Paid;
					order2.PaymentMethods = order.PaymentMethods;
					order2.Qty = Convert.ToInt32(num5);
					order2.StationID = order.StationID;
					order2.SubTotal = num5 * order2.ItemSellPrice;
					order2.Synced = false;
					order2.CustomerInfoName = order.CustomerInfoName;
					order2.ItemCourse = order.ItemCourse;
					decimal num6 = ((order.SubTotal != 0m) ? (order.TaxTotal / order.SubTotal) : Convert.ToDecimal(0.13));
					order2.TaxTotal = num6 * order2.SubTotal;
					order2.TaxDesc = "";
					order2.SeatNum = order.SeatNum;
					string[] array = order.TaxDesc.Split('|');
					string text = string.Empty;
					string[] array2 = array;
					foreach (string text2 in array2)
					{
						if (text2 != string.Empty)
						{
							string[] array3 = text2.Split(':');
							decimal num7 = Convert.ToDecimal(array3[1]);
							string text3 = array3[0] + ":" + Math.Round(num7 / Convert.ToDecimal(order.Qty) * num5, 2).ToString("0.00") + "|";
							order2.TaxDesc += text3;
							text = text + array3[0] + ":" + Math.Round(Convert.ToDecimal(array3[1]) / Convert.ToDecimal(order.Qty) * (Convert.ToDecimal(order.Qty) - num5), 2).ToString("0.00") + "|";
						}
					}
					order2.Total = order2.TaxTotal + order2.SubTotal;
					order2.UserCancelled = order.UserCancelled;
					order2.UserCreated = order.UserCreated;
					order2.Void = true;
					order.TaxDesc = text;
					order.Qty -= (decimal)Convert.ToInt32(num5);
					order.SubTotal = Convert.ToDecimal(order.Qty) * order.ItemSellPrice;
					order.TaxTotal = num6 * order.SubTotal;
					order.Total = order.TaxTotal + order.SubTotal;
					order.Synced = false;
					gclass6_0.Orders.InsertOnSubmit(order2);
					num2 += order2.SubTotal;
					num += order2.Total;
					num4 = order2.Total;
				}
				refund.DateCreated = DateTime.Now;
				refund.OrderId = order2?.OrderId ?? order.OrderId;
				refund.Qty = num5;
				refund.RefundID = Guid.NewGuid();
				refund.RefundNumber = string_1;
				refund.EmployeeID = short_0;
				refund.AmountRefunded = num4;
				refund.PaymentMethod = string_2;
				refund.RefundReason = string_3;
				gclass6_0.Refunds.InsertOnSubmit(refund);
				list2.Add(refund);
				if (!order.ItemName.Contains("GIFT CARD") || cardProcessorSettingActiveOnly2 == null || !(cardProcessorSettingActiveOnly2.Processor == "Ackroo"))
				{
					continue;
				}
				for (int j = 1; j <= Convert.ToInt32(order.Qty); j++)
				{
					frmGiftCardPrompt frmGiftCardPrompt2 = new frmGiftCardPrompt();
					if (frmGiftCardPrompt2.ShowDialog(this) != DialogResult.OK)
					{
						return;
					}
					List<GiftCardTransactionLog> list3 = gclass6_0.GiftCardTransactionLogs.Where((GiftCardTransactionLog x) => x.OrderNumber == string_0 && x.ProcessorName != null && x.ProcessorName.Contains("FUND GIFT CARD")).ToList();
					flag = false;
					foreach (GiftCardTransactionLog item in list3)
					{
						if (!(StringCipher.Decrypt(item.EncryptedCardNumber, "DigitalCraftHipPOS") == frmGiftCardPrompt2.CardNumber))
						{
							continue;
						}
						flag = true;
						if (item != null)
						{
							if (Convert.ToDecimal(AckrooMethods.CheckCardBalance(frmGiftCardPrompt2.CardNumber).gift) >= order.ItemSellPrice)
							{
								list.Add(new AckrooReversalRequest
								{
									description = "Customer Refunded Gift Card Purchase.",
									cardnumber = frmGiftCardPrompt2.CardNumber,
									transaction_number = JsonConvert.DeserializeObject<AckrooGiftCardFUNDResponse>(item.Data).transaction_number,
									clerk_id = short_0.ToString()
								});
								break;
							}
							new NotificationLabel(this, "Card with number ending with " + frmGiftCardPrompt2.CardNumber.Substring(frmGiftCardPrompt2.CardNumber.Length - 5, 4) + ", has insufficient balance for a refund.", NotificationTypes.Warning).Show();
							return;
						}
					}
					if (!flag)
					{
						new NotificationLabel(this, "Card with number ending with " + frmGiftCardPrompt2.CardNumber.Substring(frmGiftCardPrompt2.CardNumber.Length - 5, 4) + ", does not match our records.", NotificationTypes.Warning).Show();
					}
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		foreach (AckrooReversalRequest item2 in list)
		{
			if (!string.IsNullOrEmpty(AckrooMethods.ReverseTransaction(item2.transaction_number, "gift_card_json", item2.cardnumber, item2.description, item2.clerk_id).error))
			{
				new frmMessageBox("Unable to refund card with number ending with " + item2.cardnumber.Substring(item2.cardnumber.Length - 5, 4) + ".", "ERROR REVERSING GIFT CARD", CustomMessageBoxButtons.Ok).ShowDialog();
				return;
			}
		}
		if (bool_1)
		{
			GiftCardTransactionLog giftCardTransactionLog = (from a in gclass6_0.GiftCardTransactionLogs
				where a.OrderNumber == string_0 && a.ProcessorName.Contains("LOYALTY CARD EARNED")
				orderby a.DateCreated descending
				select a).FirstOrDefault();
			if (giftCardTransactionLog != null)
			{
				if (cardProcessorSettingActiveOnly != null && giftCardTransactionLog.ProcessorName.Contains("Ackroo") && cardProcessorSettingActiveOnly.Processor == "Ackroo")
				{
					if (string.IsNullOrEmpty(AckrooMethods.ReverseTransaction(JsonConvert.DeserializeObject<AckrooGiftCardFUNDResponse>(giftCardTransactionLog.Data).transaction_number, "loyalty_card_json").error))
					{
						decimal num8 = CS_0024_003C_003E8__locals0.orders.Where((Order a) => a.Void == false).Sum((Order a) => a.SubTotal);
						decimal amount = num8 - num2;
						string text4 = StringCipher.Decrypt(giftCardTransactionLog.EncryptedCardNumber, "DigitalCraftHipPOS");
						AckrooGiftCardFUNDResponse ackrooGiftCardFUNDResponse = AckrooMethods.FundLoyaltyPoints(text4, amount, "Partially refunded amount is only " + num2 + " out of " + num8);
						if (string.IsNullOrEmpty(ackrooGiftCardFUNDResponse.error))
						{
							GiftCardTransactionLog entity = new GiftCardTransactionLog
							{
								OrderNumber = string_0,
								DateCreated = DateTime.Now,
								Type = "reponse",
								Data = JsonConvert.SerializeObject(ackrooGiftCardFUNDResponse),
								ProcessorName = "Ackroo".ToUpper() + " LOYALTY CARD EARNED",
								EncryptedCardNumber = StringCipher.Encrypt(text4, "DigitalCraftHipPOS")
							};
							gclass6_0.GiftCardTransactionLogs.InsertOnSubmit(entity);
						}
					}
				}
				else if (cardProcessorSettingActiveOnly != null && giftCardTransactionLog.ProcessorName.Contains("TapMango") && cardProcessorSettingActiveOnly.Processor == "TapMango")
				{
					string text5 = (string_2.Contains("CASH") ? "CASH" : null);
					if (text5 == null)
					{
						text5 = ((string_2.Contains("DEBIT") || string_2.ToUpper().Contains("CREDIT") || string_2.ToUpper().Contains("MASTERCARD") || string_2.ToUpper().Contains("VISA") || string_2.ToUpper().Contains("AMERICAN EXPRESS") || string_2.ToUpper().Contains("AMEX")) ? "CREDIT" : "OTHER");
					}
					TapMangoMethods.ProcessPayment(Convert.ToInt32(giftCardTransactionLog.Data), -num2, text5);
				}
			}
		}
		bool flag2 = true;
		if (list_2.Select((ProcessorPaymentType a) => a.PaymentTypeName).Contains(PaymentTypes.GIFT_CARD) && bool_0)
		{
			decimal amount2 = (from a in list_2
				where a.PaymentTypeName.Contains(PaymentTypes.GIFT_CARD)
				select a.Amount).FirstOrDefault();
			if (cardProcessorSettingActiveOnly2 != null && cardProcessorSettingActiveOnly2.Processor == "Ackroo")
			{
				frmGiftCardPrompt frmGiftCardPrompt3 = new frmGiftCardPrompt();
				if (frmGiftCardPrompt3.ShowDialog(this) != DialogResult.OK)
				{
					return;
				}
				AckrooMethods.FundCard(frmGiftCardPrompt3.CardNumber, amount2);
			}
		}
		else if (list_2.Select((ProcessorPaymentType a) => a.PaymentTypeName).Contains(PaymentTypes.LOYALTY_CARD) && bool_1)
		{
			decimal amount3 = (from a in list_2
				where a.PaymentTypeName.Contains(PaymentTypes.LOYALTY_CARD)
				select a.Amount).FirstOrDefault();
			CardProcessorObject cardProcessorSettingActiveOnly3 = SettingsHelper.GetCardProcessorSettingActiveOnly("Ackroo", "loyalty_card_json");
			if (cardProcessorSettingActiveOnly3 != null && cardProcessorSettingActiveOnly3.Processor == "Ackroo")
			{
				AckrooMethods.RefundLoyaltyPoints(StringCipher.Decrypt(gclass6_0.GiftCardTransactionLogs.Where((GiftCardTransactionLog a) => a.OrderNumber == CS_0024_003C_003E8__locals0.orders.First().OrderNumber).FirstOrDefault().EncryptedCardNumber, "DigitalCraftHipPOS"), amount3);
			}
		}
		else if (string_2.ToUpper() != Resources.Cash.ToUpper() && string_2.ToUpper() != Resources.Coupon.ToUpper() && string_2.ToUpper() != Resources.Store_Credit.ToUpper() && !bool_2)
		{
			string settingValueByKey = SettingsHelper.GetSettingValueByKey("use_payment_processor");
			if (!string.IsNullOrEmpty(settingValueByKey) && settingValueByKey == "ON")
			{
				List<ProcessorPaymentType> list4 = list_2.Where((ProcessorPaymentType a) => a.PaymentTypeName != "CASH" && a.PaymentTypeName != PaymentTypes.GIFT_CARD && a.PaymentTypeName != PaymentTypes.LOYALTY_CARD).ToList();
				List<ProcessorPaymentType> list5 = new List<ProcessorPaymentType>();
				if (list4.Count > 1)
				{
					foreach (ProcessorPaymentType item3 in list4)
					{
						list5.Add(new ProcessorPaymentType
						{
							PaymentTypeName = item3.PaymentTypeName,
							Amount = item3.Amount
						});
					}
				}
				else
				{
					list5.Add(new ProcessorPaymentType
					{
						PaymentTypeName = string_2,
						Amount = num
					});
				}
				foreach (ProcessorPaymentType item4 in list5)
				{
					decimal amount4 = item4.Amount;
					Terminal this_terminal = MemoryLoadedObjects.this_terminal;
					if (this_terminal == null || string.IsNullOrEmpty(this_terminal.PaymentMerchantID) || string.IsNullOrEmpty(this_terminal.PaymentProviderName) || string.IsNullOrEmpty(this_terminal.PaymentTerminalAddress) || string.IsNullOrEmpty(this_terminal.PaymentTerminalModel) || this_terminal.PaymentTerminalPort <= 0)
					{
						continue;
					}
					List<PaymentTransactionObject> trans_objects = new List<PaymentTransactionObject>();
					string refund2 = PaymentTerminalTransactionTypes.refund;
					string text6 = string.Empty;
					if (this_terminal.PaymentProviderName == PaymentProviderNames.FirstData)
					{
						flag2 = UIPaymentHelper.ProcessFirstData(this, this_terminal, refund2, (int)(amount4 * 100m), string_0, string_2, string_1, out trans_objects);
					}
					else
					{
						int num9 = (int)(amount4 * 100m);
						if (CS_0024_003C_003E8__locals0.orders.Where((Order a) => a.DatePaid.HasValue).Count() > 0)
						{
							if (CS_0024_003C_003E8__locals0.orders.Where((Order a) => a.DatePaid.HasValue).FirstOrDefault().DatePaid.Value.Date == DateTime.Now.Date)
							{
								_003C_003Ec__DisplayClass11_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass11_2();
								CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
								CS_0024_003C_003E8__locals2.treceipt = (from x in gclass6_0.TransactionReceipts
									where x.MerchantReceipt != null && x.OrderNumber == string_0 && x.MerchantReceipt.ToUpper().Contains("APPROVED")
									orderby x.DateCreated descending
									select x).FirstOrDefault();
								PaymentTerminalTransactionLog paymentTerminalTransactionLog = null;
								if (CS_0024_003C_003E8__locals2.treceipt != null)
								{
									paymentTerminalTransactionLog = gclass6_0.PaymentTerminalTransactionLogs.Where((PaymentTerminalTransactionLog x) => x.OrderNumber == null && x.Data != null && x.Data.Substring(0, 2) == "20" && x.DateCreated > CS_0024_003C_003E8__locals2.treceipt.DateCreated).FirstOrDefault();
								}
								if (CS_0024_003C_003E8__locals2.treceipt != null && paymentTerminalTransactionLog == null && !CS_0024_003C_003E8__locals2.treceipt.MerchantReceipt.ToUpper().Contains("CASHBACK") && !CS_0024_003C_003E8__locals2.treceipt.MerchantReceipt.ToUpper().Contains("REMBOURSEMENT") && (this_terminal.PaymentProviderName == PaymentProviderNames.Moneris || this_terminal.PaymentProviderName == PaymentProviderNames.TD || this_terminal.PaymentProviderName == PaymentProviderNames.Chase))
								{
									int num10 = (int)(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.orders.Where((Order x) => !x.DateRefunded.HasValue).Sum((Order x) => x.Total) * 100m);
									refund2 = PaymentTerminalTransactionTypes.purchase_correction;
									flag2 = UIPaymentHelper.ProcessIngenico(this_terminal.PaymentProviderName, this, this_terminal, refund2, num10, string_0, string_2, string_1, out trans_objects);
									TransactionReceipt transactionReceipt = (from x in gclass6_0.TransactionReceipts
										where x.OrderNumber == string_0 && x.RefundNumber == string_1 && x.MerchantReceipt != null && x.MerchantReceipt.Contains("VOID AMOUNT") && x.MerchantReceipt.Contains("APPROVED")
										select x into y
										orderby y.DateCreated descending
										select y).FirstOrDefault();
									if (transactionReceipt != null && transactionReceipt.MerchantReceipt != null && !transactionReceipt.MerchantReceipt.ToUpper().Contains(item4.PaymentTypeName.ToUpper()))
									{
										text6 = UIPaymentHelper.GetActualPaymentMethod(item4.PaymentTypeName, transactionReceipt.MerchantReceipt);
									}
									if (!flag2 && transactionReceipt == null)
									{
										if (gclass6_0.PaymentTerminalTransactionLogs.Where((PaymentTerminalTransactionLog x) => x.OrderNumber == string_0 && x.DateCreated.Date == CS_0024_003C_003E8__locals2.treceipt.DateCreated.Date && x.Data.Length >= 2 && x.Data.Substring(0, 2) == "17").FirstOrDefault() != null)
										{
											refund2 = PaymentTerminalTransactionTypes.refund;
											flag2 = UIPaymentHelper.ProcessIngenico(this_terminal.PaymentProviderName, this, this_terminal, refund2, num9, string_0, string_2, string_1, out trans_objects);
										}
									}
									else
									{
										int num11 = 0;
										if (num10 > num9)
										{
											num11 = num10 - num9;
										}
										if (num3 > 0m)
										{
											num11 += (int)(num3 * 100m);
										}
										if (num11 > 0)
										{
											Thread.Sleep(3000);
											flag2 = UIPaymentHelper.ProcessIngenico(this_terminal.PaymentProviderName, this, this_terminal, PaymentTerminalTransactionTypes.sale, num11, string_0, string_2, string_1, out trans_objects);
										}
									}
								}
								else
								{
									flag2 = UIPaymentHelper.ProcessIngenico(this_terminal.PaymentProviderName, this, this_terminal, refund2, num9, string_0, string_2, string_1, out trans_objects);
								}
							}
							else
							{
								flag2 = UIPaymentHelper.ProcessIngenico(this_terminal.PaymentProviderName, this, this_terminal, refund2, num9, string_0, string_2, string_1, out trans_objects);
							}
						}
					}
					if (!flag2)
					{
						if (new frmMessageBox("Do you want to do a manual Refund?", "Manual Refund", CustomMessageBoxButtons.YesNo).ShowDialog() != DialogResult.No)
						{
							flag2 = true;
							continue;
						}
						gclass6_0 = new GClass6();
						return;
					}
					string text7 = item4.PaymentTypeName.ToUpper();
					if (trans_objects != null && trans_objects.Count > 0)
					{
						PaymentTransactionObject paymentTransactionObject = trans_objects.Where((PaymentTransactionObject x) => x.merchantreceipt.Contains("APPROVED")).FirstOrDefault();
						if (paymentTransactionObject != null && paymentTransactionObject.merchantreceipt != null && !paymentTransactionObject.merchantreceipt.ToUpper().Contains(item4.PaymentTypeName.ToUpper()))
						{
							text7 = UIPaymentHelper.GetActualPaymentMethod(item4.PaymentTypeName, paymentTransactionObject.merchantreceipt);
						}
					}
					foreach (Refund item5 in list2)
					{
						item5.PaymentMethod = (string.IsNullOrEmpty(text6) ? text7 : text6);
					}
				}
			}
		}
		if (flag2)
		{
			method_4(num, string_1);
		}
	}

	private void method_4(decimal decimal_0, string string_2)
	{
		_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass12_0();
		CS_0024_003C_003E8__locals0.refundNumber = string_2;
		Helper.SubmitChangesWithCatch(gclass6_0);
		IQueryable<Refund> queryable = gclass6_0.Refunds.Where((Refund a) => a.RefundNumber == CS_0024_003C_003E8__locals0.refundNumber);
		string paymentMethod = "";
		if (queryable.Count() > 0)
		{
			InventoryMethods inventoryMethods = new InventoryMethods();
			foreach (Refund item2 in queryable)
			{
				_003C_003Ec__DisplayClass12_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass12_1();
				paymentMethod = item2.PaymentMethod;
				CS_0024_003C_003E8__locals1.order = item2.Order;
				Item item = gclass6_0.Items.Where((Item i) => i.ItemID == CS_0024_003C_003E8__locals1.order.ItemID).FirstOrDefault();
				if (item != null && item.TrackInventory && new frmMessageBox(Resources.Do_you_want_to_return_the_item + CS_0024_003C_003E8__locals1.order.ItemName + Resources._back_to_inventory, Resources.Return_Item_To_Inventory, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
				{
					inventoryMethods.AddItemInventory(CS_0024_003C_003E8__locals1.order, "Refunded");
					inventoryMethods.UpdateExpiryItem(CS_0024_003C_003E8__locals1.order.InventoryBatchId, CS_0024_003C_003E8__locals1.order.Qty, toSubtract: false);
				}
			}
		}
		frmRefundFinish frmRefundFinish2 = new frmRefundFinish(decimal_0, CS_0024_003C_003E8__locals0.refundNumber, paymentMethod);
		if (frmRefundFinish2.ShowDialog(this) == DialogResult.OK)
		{
			frmRefundFinish2.Close();
			lstItems.Items.Clear();
			lstRefundItems.Items.Clear();
			btnCancel.Enabled = false;
			btnSearch.Enabled = false;
			txtSearchBox.Text = "";
			btnSave.Enabled = false;
			base.DialogResult = DialogResult.None;
		}
		CS_0024_003C_003E8__locals0.refundNumber = string.Empty;
	}

	private void BtnClose_Click(object sender, EventArgs e)
	{
		AuthMethods.LogOutUser();
		Close();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		if (lstRefundItems.Items.Count == 0 && lstItems.Items.Count == 0)
		{
			btnSave.Enabled = false;
		}
		else if (lstRefundItems.Items.Count == 0)
		{
			method_5();
			btnSave.Enabled = false;
		}
		else if (new frmMessageBox(Resources.Are_you_sure_you_want_to_reset, Resources.Warning_Reset_Info, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
		{
			method_5();
			btnSave.Enabled = false;
		}
		else
		{
			btnSave.Enabled = true;
		}
	}

	private void btnSearch_Click(object sender, EventArgs e)
	{
		string_0 = txtSearchBox.Text.Trim();
		method_5();
	}

	private void method_5()
	{
		DataManager dataManager = new DataManager();
		if (!(txtSearchBox.Text != Resources.Enter_Order_Number_Here) || string.IsNullOrEmpty(txtSearchBox.Text.Trim()))
		{
			return;
		}
		lstItems.Items.Clear();
		lstRefundItems.Items.Clear();
		IQueryable<Order> queryable = from o in gclass6_0.Orders
			where o.OrderNumber == string_0 && o.DateRefunded == null && o.Void == false && o.Paid == true
			select o into a
			orderby a.DatePaid
			select a;
		if (queryable.Count() == 0)
		{
			btnCancel.Enabled = false;
			new frmMessageBox(Resources.Please_scan_or_type_in_exact_o, Resources.Order_Not_Found).ShowDialog(this);
			return;
		}
		lblOriginalOrder.Text = Resources.Original_Order + string_0;
		using (IEnumerator<Order> enumerator = queryable.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass16_0();
				CS_0024_003C_003E8__locals0.order = enumerator.Current;
				Item item = MemoryLoadedData.all_active_items.Where((Item i) => i.ItemID == CS_0024_003C_003E8__locals0.order.ItemID).FirstOrDefault();
				if (item == null)
				{
					item = dataManager.getOneItem(CS_0024_003C_003E8__locals0.order.ItemID);
				}
				if (item != null)
				{
					ListViewItem value = new ListViewItem(new string[7]
					{
						MathHelper.DecimalToFraction(CS_0024_003C_003E8__locals0.order.Qty),
						CS_0024_003C_003E8__locals0.order.ItemName,
						(CS_0024_003C_003E8__locals0.order.ItemSellPrice * Convert.ToDecimal(CS_0024_003C_003E8__locals0.order.Qty)).ToString("0.00"),
						CS_0024_003C_003E8__locals0.order.OrderId.ToString(),
						CS_0024_003C_003E8__locals0.order.ComboID.ToString(),
						CS_0024_003C_003E8__locals0.order.ItemID.ToString(),
						CS_0024_003C_003E8__locals0.order.ShareItemID.ToString()
					});
					lstItems.Items.Add(value);
				}
			}
		}
		method_15();
		btnCancel.Enabled = true;
	}

	private void txtSearchBox_Enter(object sender, EventArgs e)
	{
		if (txtSearchBox.Text == Resources.Enter_Order_Number_Here)
		{
			txtSearchBox.ForeColor = HelperMethods.GetColor("Black");
			txtSearchBox.Text = string.Empty;
		}
	}

	private void txtSearchBox_Leave(object sender, EventArgs e)
	{
		if (txtSearchBox.Text == string.Empty)
		{
			txtSearchBox.ForeColor = HelperMethods.GetColor("Gray");
			txtSearchBox.Text = Resources.Enter_Order_Number_Here;
		}
	}

	private bool method_6(ListView listView_0, Item item_0, ListViewItem listViewItem_0, decimal decimal_0, decimal decimal_1, decimal decimal_2)
	{
		foreach (ListViewItem item in listView_0.Items)
		{
			if (listViewItem_0.SubItems[3].Text == item.SubItems[3].Text && item.SubItems[1].Text == listViewItem_0.SubItems[1].Text)
			{
				decimal_0 = MathHelper.FractionToDecimal(item.SubItems[0].Text) + decimal_2;
				listViewItem_0.Remove();
				item.SubItems[0].Text = decimal_0.ToString();
				item.SubItems[2].Text = (decimal_1 * decimal_0).ToString("0.00");
				return false;
			}
		}
		listViewItem_0.Remove();
		listView_0.Items.Add(listViewItem_0);
		return true;
	}

	private bool method_7(Item item_0, decimal decimal_0, bool bool_2 = false)
	{
		if (item_0 != null && !AdminMethods.isUOMFractional(item_0.UOMID) && Math.Floor(decimal_0) != decimal_0 && !bool_2)
		{
			new frmMessageBox(Resources.The_Item_has_a_Unit_of_Measure, Resources.Error_Decimal_Value).ShowDialog(this);
			return false;
		}
		return true;
	}

	private bool method_8(ListView listView_0, Item item_0, ListViewItem listViewItem_0, decimal decimal_0)
	{
		decimal num = MathHelper.FractionToDecimal(listViewItem_0.SubItems[0].Text);
		decimal num2 = Convert.ToDecimal(listViewItem_0.SubItems[2].Text) / num;
		decimal num3 = default(decimal);
		if (decimal_0 != num)
		{
			num3 = num - decimal_0;
			if (!(num3 < 0m) && !(decimal_0 <= 0m))
			{
				if (num3 > 0m)
				{
					listViewItem_0.SubItems[0].Text = MathHelper.DecimalToFraction(num3);
					listViewItem_0.SubItems[2].Text = Math.Round(num2 * num3, 2).ToString("0.00");
					foreach (ListViewItem item in listView_0.Items)
					{
						if (listViewItem_0.SubItems[3].Text == item.SubItems[3].Text && item.SubItems[1].Text == listViewItem_0.SubItems[1].Text)
						{
							num = MathHelper.FractionToDecimal(item.SubItems[0].Text) + decimal_0;
							item.SubItems[0].Text = MathHelper.DecimalToFraction(num);
							item.SubItems[2].Text = (num2 * num).ToString("0.00");
							return false;
						}
					}
					ListViewItem value = new ListViewItem(new string[6]
					{
						decimal_0.ToString(),
						listViewItem_0.SubItems[1].Text,
						Math.Round(num2 * decimal_0, 2).ToString("0.00"),
						listViewItem_0.SubItems[3].Text,
						listViewItem_0.SubItems[4].Text,
						listViewItem_0.SubItems[5].Text
					});
					listView_0.Items.Add(value);
					return true;
				}
				method_6(listView_0, item_0, listViewItem_0, num, num2, decimal_0);
				return true;
			}
			new frmMessageBox(Resources.Cannot_refund_that_many, "Error").ShowDialog(this);
			return false;
		}
		method_6(listView_0, item_0, listViewItem_0, num, num2, num);
		return true;
	}

	private void method_9(ListViewItem listViewItem_0, decimal decimal_0, decimal decimal_1)
	{
		if (decimal_0 < decimal_1)
		{
			new frmMessageBox(Resources.Cannot_refund_that_many, "Error").ShowDialog(this);
			return;
		}
		List<Item> list = new List<Item>();
		int num = Convert.ToInt32(listViewItem_0.SubItems[4].Text);
		decimal num2 = default(decimal);
		bool flag = true;
		IEnumerator enumerator = lstItems.Items.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass22_0();
				CS_0024_003C_003E8__locals1.eachItem = (ListViewItem)enumerator.Current;
				if (num != Convert.ToInt32(CS_0024_003C_003E8__locals1.eachItem.SubItems[4].Text))
				{
					continue;
				}
				Item item = gclass6_0.Items.Where((Item i) => i.ItemName == CS_0024_003C_003E8__locals1.eachItem.SubItems[1].Text).FirstOrDefault();
				if (item != null)
				{
					num2 = MathHelper.FractionToDecimal(CS_0024_003C_003E8__locals1.eachItem.SubItems[0].Text) / decimal_0;
					bool bool_ = (AdminMethods.CheckIfOrderItemIsShared(CS_0024_003C_003E8__locals1.eachItem.SubItems[3].Text).HasValue ? true : false);
					if (!(flag = method_7(item, decimal_1 * num2, bool_)))
					{
						break;
					}
					list.Add(item);
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		if (!flag)
		{
			return;
		}
		int num3 = 0;
		int num4 = ((lstItems.SelectedIndices.Count != 0) ? lstItems.SelectedIndices[0] : 0);
		enumerator = lstItems.Items.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass22_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass22_1();
				CS_0024_003C_003E8__locals0.eachItem = (ListViewItem)enumerator.Current;
				if (CS_0024_003C_003E8__locals0.eachItem.SubItems[4].Text == listViewItem_0.SubItems[4].Text && (listViewItem_0.SubItems[1].Text.IndexOf("ADD: ") != 0 || num3 == num4))
				{
					Item item2 = list.Where((Item i) => i.ItemName == CS_0024_003C_003E8__locals0.eachItem.SubItems[1].Text).FirstOrDefault();
					if (item2 != null)
					{
						num2 = MathHelper.FractionToDecimal(CS_0024_003C_003E8__locals0.eachItem.SubItems[0].Text) / decimal_0;
						method_8(lstRefundItems, item2, CS_0024_003C_003E8__locals0.eachItem, decimal_1 * num2);
					}
					else
					{
						Item item_ = gclass6_0.Items.Where((Item i) => i.ItemName == CS_0024_003C_003E8__locals0.eachItem.SubItems[1].Text).FirstOrDefault();
						num2 = MathHelper.FractionToDecimal(CS_0024_003C_003E8__locals0.eachItem.SubItems[0].Text) / decimal_0;
						method_8(lstRefundItems, item_, CS_0024_003C_003E8__locals0.eachItem, decimal_1 * num2);
					}
				}
				num3++;
			}
		}
		finally
		{
			IDisposable disposable2 = enumerator as IDisposable;
			if (disposable2 != null)
			{
				disposable2.Dispose();
			}
		}
	}

	private void method_10(ListViewItem listViewItem_0, string string_2, bool bool_2 = false, bool bool_3 = false)
	{
		_003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass23_0();
		CS_0024_003C_003E8__locals0.view = listViewItem_0;
		decimal num = MathHelper.FractionToDecimal(CS_0024_003C_003E8__locals0.view.SubItems[0].Text);
		decimal decimal_ = ((num > 0m) ? (Convert.ToDecimal(CS_0024_003C_003E8__locals0.view.SubItems[2].Text) / num) : 0m);
		Item item = gclass6_0.Items.Where((Item i) => i.ItemID == Convert.ToInt32(CS_0024_003C_003E8__locals0.view.SubItems[5].Text)).FirstOrDefault();
		if (!bool_2 && string_2 == "right")
		{
			if (Convert.ToInt32(CS_0024_003C_003E8__locals0.view.SubItems[5].Text) == -999)
			{
				method_8(lstRefundItems, item, CS_0024_003C_003E8__locals0.view, num);
				return;
			}
			bool flag = (AdminMethods.CheckIfOrderItemIsShared(CS_0024_003C_003E8__locals0.view.SubItems[3].Text).HasValue ? true : false);
			if (bool_3 || flag)
			{
				method_8(lstRefundItems, item, CS_0024_003C_003E8__locals0.view, num);
				return;
			}
			if (num == 1m && method_7(item, num))
			{
				method_8(lstRefundItems, item, CS_0024_003C_003E8__locals0.view, num);
				return;
			}
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
			MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Qty_To_Move, 2, 5, num.ToString());
			if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK && method_7(item, MemoryLoadedObjects.Numpad.numberEntered))
			{
				method_8(lstRefundItems, item, CS_0024_003C_003E8__locals0.view, MemoryLoadedObjects.Numpad.numberEntered);
			}
		}
		else if (bool_2)
		{
			if (string_2 == "left")
			{
				int num2 = 0;
				int num3 = lstRefundItems.SelectedIndices[0];
				{
					IEnumerator enumerator = lstRefundItems.Items.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass23_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass23_1();
							CS_0024_003C_003E8__locals1.eachItem = (ListViewItem)enumerator.Current;
							decimal decimal_2 = MathHelper.FractionToDecimal(CS_0024_003C_003E8__locals1.eachItem.SubItems[0].Text);
							Item item_ = gclass6_0.Items.Where((Item i) => i.ItemName == CS_0024_003C_003E8__locals1.eachItem.SubItems[1].Text).FirstOrDefault();
							if (CS_0024_003C_003E8__locals1.eachItem.SubItems[4].Text == CS_0024_003C_003E8__locals0.view.SubItems[4].Text && (CS_0024_003C_003E8__locals0.view.SubItems[1].Text.IndexOf("ADD: ") != 0 || num2 == num3))
							{
								method_8(lstItems, item_, CS_0024_003C_003E8__locals1.eachItem, decimal_2);
							}
							num2++;
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
				method_15();
				return;
			}
			bool flag2 = (AdminMethods.CheckIfOrderItemIsShared(CS_0024_003C_003E8__locals0.view.SubItems[3].Text).HasValue ? true : false);
			bool flag3 = AdminMethods.CheckIfItemIsMainPackage(item.ItemID);
			if (bool_3 || flag2)
			{
				method_9(CS_0024_003C_003E8__locals0.view, num, num);
				return;
			}
			if (num == 1m)
			{
				if (flag3)
				{
					method_9(CS_0024_003C_003E8__locals0.view, num, num);
				}
				else if (Convert.ToDecimal(CS_0024_003C_003E8__locals0.view.SubItems[2].Text.ToString()) > 0m)
				{
					method_8(lstRefundItems, item, CS_0024_003C_003E8__locals0.view, num);
				}
			}
			else
			{
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
				MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Qty_To_Move, 2, 5, num.ToString());
				if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
				{
					if (flag3)
					{
						method_9(CS_0024_003C_003E8__locals0.view, num, MemoryLoadedObjects.Numpad.numberEntered);
					}
					else if (Convert.ToDecimal(CS_0024_003C_003E8__locals0.view.SubItems[2].Text.ToString()) > 0m)
					{
						method_8(lstRefundItems, item, CS_0024_003C_003E8__locals0.view, MemoryLoadedObjects.Numpad.numberEntered);
					}
				}
			}
		}
		else if (string_2 == "right")
		{
			method_6(lstRefundItems, item, CS_0024_003C_003E8__locals0.view, num, decimal_, num);
		}
		else
		{
			method_6(lstItems, item, CS_0024_003C_003E8__locals0.view, num, decimal_, num);
		}
		method_15();
	}

	private void btnRight_Click(object sender, EventArgs e)
	{
		if (lstItems.SelectedItems.Count != 0)
		{
			ListViewItem listViewItem = lstItems.SelectedItems[0];
			if (listViewItem.SubItems[4].Text != "0")
			{
				method_10(listViewItem, "right", bool_2: true);
				method_13();
			}
			else
			{
				method_10(listViewItem, "right");
				method_13();
			}
		}
		else
		{
			new frmMessageBox(Resources.Select_an_item_from_Original_O).ShowDialog(this);
		}
	}

	private void btnLeft_Click(object sender, EventArgs e)
	{
		if (lstRefundItems.SelectedItems.Count != 0)
		{
			ListViewItem listViewItem = lstRefundItems.SelectedItems[0];
			if (listViewItem.SubItems[4].Text != "0")
			{
				method_10(listViewItem, "left", bool_2: true);
				method_13();
			}
			else
			{
				method_10(listViewItem, "left");
				method_13();
			}
		}
		else
		{
			new frmMessageBox(Resources.Select_an_item_from_To_Be_Refu).ShowDialog(this);
		}
	}

	private void method_11()
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_PIN);
		bool flag = false;
		do
		{
			if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
			{
				flag = true;
				Close();
				continue;
			}
			Employee employee = UserMethods.AuthenticateUser(Convert.ToString(MemoryLoadedObjects.Numpad.valueEntered));
			if (employee != null)
			{
				flag = true;
				CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = employee.EmployeeID;
				if (AuthMethods.isUserAuthenticated("frmRefund"))
				{
					lblEmployee.Text = employee.FirstName + " " + employee.LastName;
					short_0 = (short)employee.EmployeeID;
				}
				else
				{
					Close();
				}
			}
			else
			{
				new frmMessageBox(Resources.Invalid_PIN_entered).ShowDialog(this);
				MemoryLoadedObjects.Numpad.TextInput = string.Empty;
			}
		}
		while (!flag);
	}

	private void method_12(short short_1)
	{
		Employee userByID = UserMethods.GetUserByID(short_1);
		lblEmployee.Text = userByID.FirstName + " " + userByID.LastName;
	}

	private void txtSearchBox_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			btnSearch_Click(sender, null);
		}
	}

	private void txtSearchBox_TextChanged(object sender, EventArgs e)
	{
	}

	private void lstRefundItems_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_13();
	}

	private void method_13()
	{
		if (lstRefundItems.Items.Count != 0)
		{
			btnSave.Enabled = true;
			btnSave.BackColor = Color.FromArgb(47, 204, 113);
		}
		else
		{
			btnSave.Enabled = false;
			btnSave.BackColor = Color.Gray;
		}
	}

	private void btnShowKeyboard_SearchBox_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Search_for_Order, 1, 128, txtSearchBox.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			btnSearch.Enabled = true;
			txtSearchBox.Text = MemoryLoadedObjects.Keyboard.textEntered.Trim();
			string_0 = txtSearchBox.Text.Trim();
			method_5();
		}
		base.DialogResult = DialogResult.None;
	}

	private void method_14()
	{
		lstItemsVScroll.Location = new Point(lstItems.Width - lstItemsVScroll.Width, lstItemsVScroll.Location.Y);
		lstRefundsVScroll.Location = new Point(lstRefundItems.Right - lstItemsVScroll.Width, lstItemsVScroll.Location.Y);
		lstItemsVScroll.Height = lstItems.Height - 2;
		lstRefundsVScroll.Height = lstRefundItems.Height - 2;
		lstItems.Columns[0].Width = ControlHelpers.ControlWidthFixer(lstItems, 1.0);
		lstItems.Columns[1].Width = ControlHelpers.ControlWidthFixer(lstItems, 9.0) - lstItemsVScroll.Width;
		lstItems.Columns[2].Width = ControlHelpers.ControlWidthFixer(lstItems, 2.0);
		lstRefundItems.Columns[0].Width = ControlHelpers.ControlWidthFixer(lstRefundItems, 1.0);
		lstRefundItems.Columns[1].Width = ControlHelpers.ControlWidthFixer(lstRefundItems, 9.0) - lstRefundsVScroll.Width;
		lstRefundItems.Columns[2].Width = ControlHelpers.ControlWidthFixer(lstRefundItems, 2.0);
	}

	private void lstItemsVScroll_Scroll(object sender, ScrollEventArgs e)
	{
		if (lstItems.Items.Count > 0)
		{
			lstItems.TopItem = lstItems.Items[lstItemsVScroll.Value];
		}
	}

	private void method_15()
	{
		lstItemsVScroll.Minimum = 0;
		lstItemsVScroll.Maximum = ((lstItems.Items.Count >= 21) ? lstItems.Items.Count : 0);
		lstItemsVScroll.Value = ((lstItems.Items.Count > 0) ? lstItems.TopItem.Index : 0);
		lstRefundsVScroll.Minimum = 0;
		lstRefundsVScroll.Maximum = ((lstRefundItems.Items.Count >= 21) ? lstRefundItems.Items.Count : 0);
		lstRefundsVScroll.Value = ((lstRefundItems.Items.Count > 0) ? lstRefundItems.TopItem.Index : 0);
	}

	private void lstRefundsVScroll_Scroll(object sender, ScrollEventArgs e)
	{
		if (lstRefundItems.Items.Count > 0)
		{
			lstRefundItems.TopItem = lstRefundItems.Items[lstRefundsVScroll.Value];
		}
	}

	private void txtSearchBox_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private void btnAllRight_Click(object sender, EventArgs e)
	{
		if (lstItems.Items.Count > 0)
		{
			int count = lstItems.Items.Count;
			for (int i = 0; i < count; i++)
			{
				if (lstItems.Items.Count == 0)
				{
					break;
				}
				lstItems.Items[0].Selected = true;
				ListViewItem listViewItem = lstItems.Items[0];
				if (listViewItem.SubItems[4].Text != "0")
				{
					method_10(listViewItem, "right", bool_2: true, bool_3: true);
					method_13();
				}
				else
				{
					method_10(listViewItem, "right", bool_2: false, bool_3: true);
					method_13();
				}
			}
		}
		else
		{
			new NotificationLabel(this, Resources.There_s_nothing_to_move_Please, NotificationTypes.Notification).Show();
		}
	}

	private void btnSave_EnabledChanged(object sender, EventArgs e)
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmRefund));
		pnlMain = new Panel();
		btnAllRight = new Button();
		lblTrainingMode = new Label();
		lstItemsVScroll = new VScrollBar();
		lstItems = new ListView();
		columnHeader_4 = new ColumnHeader();
		columnHeader_0 = new ColumnHeader();
		columnHeader_1 = new ColumnHeader();
		lblEmployee = new Label();
		lblWindowTitle = new Label();
		BtnClose = new Button();
		btnCancel = new Button();
		btnSearch = new Button();
		label1 = new Label();
		btnShowKeyboard_SearchBox = new Button();
		btnSave = new Button();
		txtSearchBox = new RadTextBoxControl();
		btnRight = new Button();
		label6 = new Label();
		lstRefundsVScroll = new VScrollBar();
		lstRefundItems = new ListView();
		columnHeader_5 = new ColumnHeader();
		columnHeader_2 = new ColumnHeader();
		columnHeader_3 = new ColumnHeader();
		label5 = new Label();
		btnLeft = new Button();
		lblOriginalOrder = new Label();
		label4 = new Label();
		label2 = new Label();
		label3 = new Label();
		label7 = new Label();
		label8 = new Label();
		pnlMain.SuspendLayout();
		((ISupportInitialize)txtSearchBox).BeginInit();
		SuspendLayout();
		pnlMain.BackColor = Color.FromArgb(35, 39, 56);
		pnlMain.Controls.Add(btnAllRight);
		pnlMain.Controls.Add(lblTrainingMode);
		pnlMain.Controls.Add(lstItemsVScroll);
		pnlMain.Controls.Add(lstItems);
		pnlMain.Controls.Add(lblEmployee);
		pnlMain.Controls.Add(lblWindowTitle);
		pnlMain.Controls.Add(BtnClose);
		pnlMain.Controls.Add(btnCancel);
		pnlMain.Controls.Add(btnSearch);
		pnlMain.Controls.Add(label1);
		pnlMain.Controls.Add(btnShowKeyboard_SearchBox);
		pnlMain.Controls.Add(btnSave);
		pnlMain.Controls.Add(txtSearchBox);
		pnlMain.Controls.Add(btnRight);
		pnlMain.Controls.Add(label6);
		pnlMain.Controls.Add(lstRefundsVScroll);
		pnlMain.Controls.Add(lstRefundItems);
		pnlMain.Controls.Add(label5);
		pnlMain.Controls.Add(btnLeft);
		pnlMain.Controls.Add(lblOriginalOrder);
		pnlMain.Controls.Add(label4);
		pnlMain.Controls.Add(label2);
		pnlMain.Controls.Add(label3);
		pnlMain.Controls.Add(label7);
		pnlMain.Controls.Add(label8);
		componentResourceManager.ApplyResources(pnlMain, "pnlMain");
		pnlMain.Name = "pnlMain";
		componentResourceManager.ApplyResources(btnAllRight, "btnAllRight");
		btnAllRight.BackColor = Color.Gray;
		btnAllRight.FlatAppearance.BorderColor = Color.Black;
		btnAllRight.FlatAppearance.BorderSize = 0;
		btnAllRight.FlatAppearance.MouseDownBackColor = Color.White;
		btnAllRight.ForeColor = Color.White;
		btnAllRight.Name = "btnAllRight";
		btnAllRight.UseVisualStyleBackColor = false;
		btnAllRight.Click += btnAllRight_Click;
		lblTrainingMode.BackColor = Color.FromArgb(193, 57, 43);
		componentResourceManager.ApplyResources(lblTrainingMode, "lblTrainingMode");
		lblTrainingMode.ForeColor = Color.White;
		lblTrainingMode.Name = "lblTrainingMode";
		componentResourceManager.ApplyResources(lstItemsVScroll, "lstItemsVScroll");
		lstItemsVScroll.Name = "lstItemsVScroll";
		lstItemsVScroll.Scroll += lstItemsVScroll_Scroll;
		lstItems.BackColor = Color.White;
		lstItems.BorderStyle = BorderStyle.None;
		lstItems.Columns.AddRange(new ColumnHeader[3] { columnHeader_4, columnHeader_0, columnHeader_1 });
		componentResourceManager.ApplyResources(lstItems, "lstItems");
		lstItems.FullRowSelect = true;
		lstItems.GridLines = true;
		lstItems.HeaderStyle = ColumnHeaderStyle.None;
		lstItems.MultiSelect = false;
		lstItems.Name = "lstItems";
		lstItems.TileSize = new Size(50, 200);
		lstItems.UseCompatibleStateImageBehavior = false;
		lstItems.View = View.Details;
		componentResourceManager.ApplyResources(columnHeader_4, "ItemQty");
		componentResourceManager.ApplyResources(columnHeader_0, "ItemName");
		componentResourceManager.ApplyResources(columnHeader_1, "ItemPrice");
		componentResourceManager.ApplyResources(lblEmployee, "lblEmployee");
		lblEmployee.BackColor = Color.FromArgb(150, 166, 166);
		lblEmployee.BorderStyle = BorderStyle.FixedSingle;
		lblEmployee.FlatStyle = FlatStyle.Flat;
		lblEmployee.ForeColor = Color.FromArgb(192, 0, 0);
		lblEmployee.Name = "lblEmployee";
		lblWindowTitle.BackColor = Color.FromArgb(147, 101, 184);
		lblWindowTitle.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(lblWindowTitle, "lblWindowTitle");
		lblWindowTitle.ForeColor = Color.White;
		lblWindowTitle.Name = "lblWindowTitle";
		BtnClose.BackColor = Color.FromArgb(235, 107, 86);
		BtnClose.FlatAppearance.BorderColor = Color.Sienna;
		BtnClose.FlatAppearance.BorderSize = 0;
		BtnClose.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(BtnClose, "BtnClose");
		BtnClose.ForeColor = Color.White;
		BtnClose.Name = "BtnClose";
		BtnClose.UseVisualStyleBackColor = false;
		BtnClose.Click += BtnClose_Click;
		btnCancel.BackColor = Color.SandyBrown;
		btnCancel.FlatAppearance.BorderColor = Color.Black;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = Color.White;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.EnabledChanged += btnSave_EnabledChanged;
		btnCancel.Click += btnCancel_Click;
		btnSearch.BackColor = Color.FromArgb(50, 119, 155);
		btnSearch.FlatAppearance.BorderColor = Color.Black;
		btnSearch.FlatAppearance.BorderSize = 0;
		btnSearch.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnSearch, "btnSearch");
		btnSearch.ForeColor = Color.White;
		btnSearch.Name = "btnSearch";
		btnSearch.UseVisualStyleBackColor = false;
		btnSearch.EnabledChanged += btnSave_EnabledChanged;
		btnSearch.Click += btnSearch_Click;
		label1.BackColor = Color.FromArgb(150, 166, 166);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		btnShowKeyboard_SearchBox.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_SearchBox.DialogResult = DialogResult.OK;
		btnShowKeyboard_SearchBox.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_SearchBox.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_SearchBox, "btnShowKeyboard_SearchBox");
		btnShowKeyboard_SearchBox.ForeColor = Color.White;
		btnShowKeyboard_SearchBox.Name = "btnShowKeyboard_SearchBox";
		btnShowKeyboard_SearchBox.UseVisualStyleBackColor = false;
		btnShowKeyboard_SearchBox.Click += btnShowKeyboard_SearchBox_Click;
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderColor = Color.Black;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.ForeColor = Color.White;
		btnSave.Name = "btnSave";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.EnabledChanged += btnSave_EnabledChanged;
		btnSave.Click += btnSave_Click;
		componentResourceManager.ApplyResources(txtSearchBox, "txtSearchBox");
		txtSearchBox.Name = "txtSearchBox";
		txtSearchBox.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtSearchBox.TextChanged += txtSearchBox_TextChanged;
		txtSearchBox.Click += txtSearchBox_Click;
		txtSearchBox.Enter += txtSearchBox_Enter;
		txtSearchBox.KeyUp += txtSearchBox_KeyUp;
		txtSearchBox.Leave += txtSearchBox_Leave;
		((RadTextBoxControlElement)txtSearchBox.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtSearchBox.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(8.888887f, 7.573965f);
		componentResourceManager.ApplyResources(btnRight, "btnRight");
		btnRight.BackColor = Color.Gray;
		btnRight.FlatAppearance.BorderColor = Color.Black;
		btnRight.FlatAppearance.BorderSize = 0;
		btnRight.FlatAppearance.MouseDownBackColor = Color.White;
		btnRight.ForeColor = Color.White;
		btnRight.Name = "btnRight";
		btnRight.UseVisualStyleBackColor = false;
		btnRight.Click += btnRight_Click;
		label6.BackColor = Color.FromArgb(147, 101, 184);
		label6.BorderStyle = BorderStyle.FixedSingle;
		label6.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label6, "label6");
		label6.ForeColor = Color.White;
		label6.Name = "label6";
		componentResourceManager.ApplyResources(lstRefundsVScroll, "lstRefundsVScroll");
		lstRefundsVScroll.Name = "lstRefundsVScroll";
		lstRefundsVScroll.Scroll += lstRefundsVScroll_Scroll;
		lstRefundItems.BackColor = Color.White;
		lstRefundItems.BorderStyle = BorderStyle.None;
		lstRefundItems.Columns.AddRange(new ColumnHeader[3] { columnHeader_5, columnHeader_2, columnHeader_3 });
		componentResourceManager.ApplyResources(lstRefundItems, "lstRefundItems");
		lstRefundItems.FullRowSelect = true;
		lstRefundItems.GridLines = true;
		lstRefundItems.HeaderStyle = ColumnHeaderStyle.None;
		lstRefundItems.MultiSelect = false;
		lstRefundItems.Name = "lstRefundItems";
		lstRefundItems.TileSize = new Size(50, 200);
		lstRefundItems.UseCompatibleStateImageBehavior = false;
		lstRefundItems.View = View.Details;
		lstRefundItems.SelectedIndexChanged += lstRefundItems_SelectedIndexChanged;
		componentResourceManager.ApplyResources(columnHeader_5, "ReItemQty");
		componentResourceManager.ApplyResources(columnHeader_2, "ReItemName");
		componentResourceManager.ApplyResources(columnHeader_3, "ReItemPrice");
		label5.BackColor = Color.FromArgb(61, 142, 185);
		label5.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label5, "label5");
		label5.ForeColor = Color.White;
		label5.Name = "label5";
		componentResourceManager.ApplyResources(btnLeft, "btnLeft");
		btnLeft.BackColor = Color.Gray;
		btnLeft.FlatAppearance.BorderColor = Color.Black;
		btnLeft.FlatAppearance.BorderSize = 0;
		btnLeft.FlatAppearance.MouseDownBackColor = Color.White;
		btnLeft.ForeColor = Color.White;
		btnLeft.Name = "btnLeft";
		btnLeft.UseVisualStyleBackColor = false;
		btnLeft.Click += btnLeft_Click;
		lblOriginalOrder.BackColor = Color.FromArgb(147, 101, 184);
		lblOriginalOrder.BorderStyle = BorderStyle.FixedSingle;
		componentResourceManager.ApplyResources(lblOriginalOrder, "lblOriginalOrder");
		lblOriginalOrder.ForeColor = Color.White;
		lblOriginalOrder.Name = "lblOriginalOrder";
		label4.BackColor = Color.FromArgb(77, 174, 225);
		label4.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		label2.BackColor = Color.FromArgb(77, 174, 225);
		label2.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		label3.BackColor = Color.FromArgb(61, 142, 185);
		label3.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		label7.BackColor = Color.FromArgb(77, 174, 225);
		label7.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label7, "label7");
		label7.ForeColor = Color.White;
		label7.Name = "label7";
		label8.BackColor = Color.FromArgb(77, 174, 225);
		label8.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label8, "label8");
		label8.ForeColor = Color.White;
		label8.Name = "label8";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(pnlMain);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmRefund";
		base.Opacity = 1.0;
		base.ShowInTaskbar = false;
		base.Load += frmRefund_Load;
		pnlMain.ResumeLayout(performLayout: false);
		((ISupportInitialize)txtSearchBox).EndInit();
		ResumeLayout(performLayout: false);
	}
}
