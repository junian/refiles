using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Methods.PaymentProcessors;
using CorePOS.Business.Objects;
using CorePOS.Business.Objects.PaymentObjects;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;

namespace CorePOS;

public static class UIPaymentHelper
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public Terminal station;

		public _003C_003Ec__DisplayClass1_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public string orderNumber;

		public _003C_003Ec__DisplayClass2_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_1
	{
		public TransactionReceipt treceipt;

		public _003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass2_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	public static short EmpID;

	public static bool ProcessFirstData(Form sender, Terminal station, string transactiontype, int total_due, string orderNumber, string paymentMethod, string refundNumber, out List<PaymentTransactionObject> trans_objects, bool showForm = true)
	{
		_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass1_0();
		CS_0024_003C_003E8__locals0.station = station;
		try
		{
			GClass6 gClass = new GClass6();
			PaymentTransactionObject paymentTransactionObject = new PaymentTransactionObject();
			if (!(CS_0024_003C_003E8__locals0.station.PaymentTerminalModel == PaymentTerminalModels.Ingenico.iCT250) && !(CS_0024_003C_003E8__locals0.station.PaymentTerminalModel == PaymentTerminalModels.Ingenico.Desk5000))
			{
				CloverTransactionObject.Request request = new CloverTransactionObject.Request();
				request.Amount = total_due;
				request.OrderNumber = orderNumber;
				request.RefundNumber = refundNumber;
				request.RequestType = transactiontype;
				request.FullRefund = false;
				frmWaitingPaymentTerminal frmWaitingPaymentTerminal2 = new frmWaitingPaymentTerminal(PaymentProviderNames.FirstData, CS_0024_003C_003E8__locals0.station.PaymentTerminalModel, CS_0024_003C_003E8__locals0.station.PaymentTerminalAddress, CS_0024_003C_003E8__locals0.station.PaymentTerminalPort, request, paymentMethod);
				if (showForm)
				{
					frmWaitingPaymentTerminal2.ShowDialog();
				}
				else
				{
					frmWaitingPaymentTerminal2.LoadForm();
				}
				trans_objects = frmWaitingPaymentTerminal2.transaction_objects;
				paymentTransactionObject = trans_objects.FirstOrDefault();
				bool flag = false;
				if (paymentTransactionObject != null)
				{
					if (!(paymentTransactionObject.rawdata == "Timed Out") && !(paymentTransactionObject.rawdata == HipposTransactionErrorMessages.staff_cancelled))
					{
						if (paymentTransactionObject.customerreceipt == null)
						{
							paymentTransactionObject.customerreceipt = string.Empty;
						}
						if (paymentTransactionObject.merchantreceipt == null)
						{
							paymentTransactionObject.merchantreceipt = string.Empty;
						}
						RecordPaymentTransaction(paymentTransactionObject, orderNumber, refundNumber);
						if (paymentTransactionObject.responsecode == "00")
						{
							flag = true;
						}
						else
						{
							string message = (paymentTransactionObject.responsecode.Equals("555") ? "Transaction cancelled by customer." : ((paymentTransactionObject.responsecode.Equals("51") || paymentTransactionObject.responsecode.Equals("57")) ? "Transaction was declined." : (paymentTransactionObject.responsecode.Equals("54") ? "Declined: Expired Card" : (paymentTransactionObject.responsecode.Equals("55") ? "Declined: Incorrect PIN." : ((!paymentTransactionObject.responsecode.Equals("56")) ? "Transaction Failed." : "CONNECTION LOST: Please check transaction on Clover.")))));
							new PrintHelper().PrintString(paymentTransactionObject.customerreceipt, 9, null, "Courier New", isBold: false, paymentTransactionObject.customerreceipt.Contains("<br/>"));
							new NotificationLabel(sender, message, NotificationTypes.Warning, 10).Show();
							flag = false;
						}
					}
					else
					{
						flag = false;
					}
					if (!string.IsNullOrEmpty(paymentTransactionObject.merchantreceipt) && SettingsHelper.GetSettingValueByKey("print_merchant_copy") == "ON")
					{
						new PrintHelper().PrintString(paymentTransactionObject.merchantreceipt, 9, null, "Courier New");
					}
				}
				else
				{
					flag = false;
				}
				return flag;
			}
			PaymentTerminalTransactionLog paymentTerminalTransactionLog = (from x in gClass.PaymentTerminalTransactionLogs
				where x.IP == CS_0024_003C_003E8__locals0.station.PaymentTerminalAddress
				select x into y
				orderby y.DateCreated descending
				select y).FirstOrDefault();
			string request2;
			frmWaitingPaymentTerminal frmWaitingPaymentTerminal3;
			if (paymentTerminalTransactionLog != null && ((paymentTerminalTransactionLog.Type == "request" && paymentTerminalTransactionLog.Data.Contains("transactiontype^sale")) || (paymentTerminalTransactionLog.Type == "response" && string.IsNullOrEmpty(paymentTerminalTransactionLog.Data))))
			{
				if (paymentTerminalTransactionLog.Type == "response" && string.IsNullOrEmpty(paymentTerminalTransactionLog.Data))
				{
					paymentTerminalTransactionLog = (from x in gClass.PaymentTerminalTransactionLogs
						where x.IP == CS_0024_003C_003E8__locals0.station.PaymentTerminalAddress && x.Type == "request"
						select x into y
						orderby y.DateCreated descending
						select y).FirstOrDefault();
				}
				if (paymentTerminalTransactionLog.Data != null)
				{
					new NotificationLabel(sender, Resources.Connection_with_pinpad_was_pre, NotificationTypes.Notification).Show();
					string text = (from x in FirstData.MapTransactionString(paymentTerminalTransactionLog.Data)
						where x.Key == "invoicenumber"
						select x into y
						select y.Value).FirstOrDefault();
					if (text == orderNumber)
					{
						request2 = "transactiontype^void^invoicenumber^" + text + "^merchantid^" + CS_0024_003C_003E8__locals0.station.PaymentMerchantID + "^transactiondate^" + DateTime.Now.ToString("MMddyy") + "^transactiontime^" + DateTime.Now.ToString("HHmmss") + "^";
						request2 = FirstData.addStringLength(request2);
						frmWaitingPaymentTerminal3 = new frmWaitingPaymentTerminal(PaymentProviderNames.FirstData, CS_0024_003C_003E8__locals0.station.PaymentTerminalModel, CS_0024_003C_003E8__locals0.station.PaymentTerminalAddress, CS_0024_003C_003E8__locals0.station.PaymentTerminalPort, request2, parseObject: true, orderNumber, paymentMethod);
						frmWaitingPaymentTerminal3.ShowDialog();
						trans_objects = frmWaitingPaymentTerminal3.transaction_objects;
						paymentTransactionObject = trans_objects.FirstOrDefault();
						if (paymentTransactionObject == null)
						{
							new NotificationLabel(sender, Resources.Unable_to_communicate_with_pay, NotificationTypes.Warning).Show();
							return false;
						}
						if (paymentTransactionObject.responsecode.Equals("00"))
						{
							new NotificationLabel(sender, Resources.Previous_transaction_was_voide, NotificationTypes.Notification).Show();
						}
						else
						{
							if (paymentTransactionObject.responsecode == null)
							{
								new NotificationLabel(sender, Resources.No_response_from_the_payment_t, NotificationTypes.Warning).Show();
								return false;
							}
							if (paymentTransactionObject.responsecode.Equals("999"))
							{
								new NotificationLabel(sender, Resources.Unable_to_communicate_with_pay, NotificationTypes.Warning).Show();
								return false;
							}
						}
					}
				}
			}
			request2 = FirstData.FormatTransactionString(transactiontype, total_due.ToString(), orderNumber, EmpID.ToString(), CS_0024_003C_003E8__locals0.station.PaymentMerchantID);
			frmWaitingPaymentTerminal3 = new frmWaitingPaymentTerminal(PaymentProviderNames.FirstData, CS_0024_003C_003E8__locals0.station.PaymentTerminalModel, CS_0024_003C_003E8__locals0.station.PaymentTerminalAddress, CS_0024_003C_003E8__locals0.station.PaymentTerminalPort, request2, parseObject: true, orderNumber, paymentMethod);
			frmWaitingPaymentTerminal3.ShowDialog();
			trans_objects = frmWaitingPaymentTerminal3.transaction_objects;
			paymentTransactionObject = trans_objects.FirstOrDefault();
			if (smethod_0(sender, paymentTransactionObject))
			{
				return false;
			}
			if (paymentTransactionObject.customerreceipt == null)
			{
				paymentTransactionObject.customerreceipt = string.Empty;
			}
			if (paymentTransactionObject.merchantreceipt == null)
			{
				paymentTransactionObject.merchantreceipt = string.Empty;
			}
			paymentTransactionObject.customerreceipt = paymentTransactionObject.customerreceipt.Replace("\u001a", " ").Replace("\u001b\u0017", "  ").Replace("\u001b\u0017\u001b\u001a", "    ")
				.Replace("\u001b", "  ");
			paymentTransactionObject.merchantreceipt = paymentTransactionObject.merchantreceipt.Replace("\u001a", " ").Replace("\u001b\u0017", "  ").Replace("\u001b\u0017\u001b\u001a", "    ")
				.Replace("\u001b", "  ");
			RecordPaymentTransaction(paymentTransactionObject, orderNumber, refundNumber);
			bool flag2 = false;
			if (!paymentTransactionObject.responsecode.Equals("00"))
			{
				string message2 = (paymentTransactionObject.responsecode.Equals("555") ? Resources.Transaction_Cancelled_by_Custo : ((paymentTransactionObject.responsecode.Equals("51") || paymentTransactionObject.responsecode.Equals("57")) ? Resources.Transaction_Was_Declined : (paymentTransactionObject.responsecode.Equals("54") ? Resources.Declined_Expired_Card : ((!paymentTransactionObject.responsecode.Equals("55")) ? Resources.Transaction_Failed : Resources.Declined_Incorrect_PIN))));
				new PrintHelper().PrintString(paymentTransactionObject.customerreceipt, 9, null, "Courier New", isBold: false, paymentTransactionObject.customerreceipt.Contains("<br/>"));
				new NotificationLabel(sender, message2, NotificationTypes.Warning).Show();
				flag2 = false;
			}
			else
			{
				frmWaitingPaymentTerminal3.Dispose();
				GC.Collect();
				flag2 = true;
				if (!string.IsNullOrEmpty(paymentTransactionObject.customerreceipt) && (paymentTransactionObject.merchantreceipt.ToUpper().Contains("NOT COMPLETED") || paymentTransactionObject.merchantreceipt.ToUpper().Contains("DECLINED") || paymentTransactionObject.merchantreceipt.ToUpper().Contains("CANCELLED")))
				{
					flag2 = false;
				}
				if (flag2 && !string.IsNullOrEmpty(paymentTransactionObject.totalamount) && Convert.ToDecimal(paymentTransactionObject.totalamount) / 100m <= 0m)
				{
					flag2 = false;
				}
				if (flag2)
				{
					new NotificationLabel(sender, Resources.Transaction_Approved, NotificationTypes.Success).Show();
				}
				else
				{
					new NotificationLabel(sender, "TRANSACTION NOT COMPLETED", NotificationTypes.Warning, 10).Show();
				}
			}
			if (!string.IsNullOrEmpty(paymentTransactionObject.merchantreceipt) && SettingsHelper.GetSettingValueByKey("print_merchant_copy") == "ON")
			{
				new PrintHelper().PrintString(paymentTransactionObject.merchantreceipt, 9, null, "Courier New");
			}
			return flag2;
		}
		catch
		{
			trans_objects = new List<PaymentTransactionObject>();
			return false;
		}
	}

	public static bool ProcessIngenico(string provider, Form sender, Terminal station, string transactiontype, int total_due, string orderNumber, string paymentMethod, string refundNumber, out List<PaymentTransactionObject> trans_objects, bool showForm = true)
	{
		_003C_003Ec__DisplayClass2_0 _003C_003Ec__DisplayClass2_ = new _003C_003Ec__DisplayClass2_0();
		_003C_003Ec__DisplayClass2_.orderNumber = orderNumber;
		GClass6 gClass = new GClass6();
		string text = Ingenico.FormatTransactionString(transactiontype, total_due.ToString(), (provider == PaymentProviderNames.TD || provider == PaymentProviderNames.Chase) ? null : _003C_003Ec__DisplayClass2_.orderNumber, EmpID.ToString());
		if (transactiontype == PaymentTerminalTransactionTypes.purchase_correction)
		{
			_003C_003Ec__DisplayClass2_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass2_1();
			CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass2_;
			if (provider == PaymentProviderNames.TD || provider == PaymentProviderNames.Chase)
			{
				transactiontype = PaymentTerminalTransactionTypes.void_transaction;
			}
			CS_0024_003C_003E8__locals0.treceipt = (from x in gClass.TransactionReceipts
				where x.OrderNumber == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.orderNumber && x.MerchantReceipt.ToUpper().Contains("APPROVED")
				orderby x.DateCreated descending
				select x).FirstOrDefault();
			if (CS_0024_003C_003E8__locals0.treceipt != null)
			{
				PaymentTerminalTransactionLog paymentTerminalTransactionLog = (from x in gClass.PaymentTerminalTransactionLogs
					where x.OrderNumber == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.orderNumber && x.Data.ToUpper().Contains("^400") && x.DateCreated.Date == CS_0024_003C_003E8__locals0.treceipt.DateCreated.Date
					orderby x.DateCreated descending
					select x).FirstOrDefault();
				if (paymentTerminalTransactionLog != null)
				{
					PaymentTransactionObject paymentTransactionObject = Ingenico.mapObject(provider, paymentTerminalTransactionLog.Data, parseObject: true);
					text = ((provider != PaymentProviderNames.Moneris && provider == PaymentProviderNames.FirstData) ? ("05" + Convert.ToChar(28).ToString() + "005" + paymentTransactionObject.approvalcode.Trim() + Convert.ToChar(28).ToString() + GClass4.invoice_number + CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.orderNumber + (int)Convert.ToChar(28) + "01302") : ((provider == PaymentProviderNames.Moneris) ? (text + Convert.ToChar(28) + "005" + paymentTransactionObject.approvalcode) : ((provider == PaymentProviderNames.TD || provider == PaymentProviderNames.Chase) ? ("05" + Convert.ToChar(28) + "005" + paymentTransactionObject.approvalcode.Trim()) : ("05" + Convert.ToChar(28).ToString() + "005" + paymentTransactionObject.approvalcode.Trim() + Convert.ToChar(28).ToString() + GClass4.invoice_number + CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.orderNumber + (int)Convert.ToChar(28) + "01302"))));
				}
			}
		}
		frmWaitingPaymentTerminal frmWaitingPaymentTerminal2 = new frmWaitingPaymentTerminal(provider, station.PaymentTerminalModel, station.PaymentTerminalAddress, station.PaymentTerminalPort, text, parseObject: true, _003C_003Ec__DisplayClass2_.orderNumber, paymentMethod);
		if (showForm)
		{
			frmWaitingPaymentTerminal2.ShowDialog();
		}
		else
		{
			frmWaitingPaymentTerminal2.LoadForm();
		}
		trans_objects = frmWaitingPaymentTerminal2.transaction_objects;
		bool flag = false;
		foreach (PaymentTransactionObject trans_object in trans_objects)
		{
			if (!smethod_0(sender, trans_object))
			{
				if (trans_object.customerreceipt == null)
				{
					trans_object.customerreceipt = string.Empty;
				}
				if (trans_object.merchantreceipt == null)
				{
					trans_object.merchantreceipt = string.Empty;
				}
				RecordPaymentTransaction(trans_object, _003C_003Ec__DisplayClass2_.orderNumber, refundNumber);
				if (trans_object.transaction_type == "20")
				{
					new NotificationLabel(sender, Resources.Batch_Settlement_Successful, NotificationTypes.Success).Show();
					frmWaitingPaymentTerminal2.Dispose();
					flag = true;
					continue;
				}
				if (!trans_object.responsecode.Equals(IngenicoTransactionStatus.approved) && !trans_object.responsecode.Equals(IngenicoTransactionStatus.partial_approved))
				{
					string message = (trans_object.responsecode.Equals(IngenicoTransactionStatus.declined) ? Resources.Transaction_Was_Declined : (trans_object.responsecode.Equals(IngenicoTransactionStatus.comm_error) ? "COMMUNICATION ERROR" : (trans_object.responsecode.Equals(IngenicoTransactionStatus.cancelled_byuser) ? Resources.Transaction_Cancelled_by_Custo : (trans_object.responsecode.Equals(IngenicoTransactionStatus.timedout_onuser) ? Resources.Transaction_Timed_Out_On_User : (trans_object.responsecode.Equals(IngenicoTransactionStatus.not_completed) ? "NOT COMPLETED" : (trans_object.responsecode.Equals(IngenicoTransactionStatus.batch_empty) ? "BATCH EMPTY" : (trans_object.responsecode.Equals(IngenicoTransactionStatus.declined_by_merchant) ? "DECLINED BY MERCHANT" : (trans_object.responsecode.Equals(IngenicoTransactionStatus.record_not_found) ? "RECORD NOT FOUND" : ((!trans_object.responsecode.Equals(IngenicoTransactionStatus.already_voided)) ? Resources.Transaction_Failed : "TRANSACTION ALREADY VOIDED")))))))));
					if (!string.IsNullOrEmpty(trans_object.customerreceipt))
					{
						new PrintHelper().PrintString(trans_object.customerreceipt, 9, null, "Courier New");
					}
					new NotificationLabel(sender, message, NotificationTypes.Warning, 10).Show();
					flag = false;
				}
				else
				{
					flag = true;
					if (!string.IsNullOrEmpty(trans_object.merchantreceipt) && (trans_object.merchantreceipt.ToUpper().Contains("NOT COMPLETED") || trans_object.merchantreceipt.ToUpper().Contains("DECLINED") || trans_object.merchantreceipt.ToUpper().Contains("CANCELLED")))
					{
						flag = false;
					}
					if (flag && !string.IsNullOrEmpty(trans_object.totalamount) && Convert.ToDecimal(trans_object.totalamount) / 100m <= 0m)
					{
						flag = false;
					}
					if (flag)
					{
						new NotificationLabel(sender, Resources.Transaction_Approved, NotificationTypes.Success).Show();
					}
					else
					{
						new NotificationLabel(sender, "TRANSACTION NOT COMPLETED", NotificationTypes.Warning, 10).Show();
					}
				}
				if (!string.IsNullOrEmpty(trans_object.merchantreceipt) && SettingsHelper.GetSettingValueByKey("print_merchant_copy") == "ON")
				{
					new PrintHelper().PrintString(trans_object.merchantreceipt, 9, null, "Courier New");
				}
				continue;
			}
			return false;
		}
		frmWaitingPaymentTerminal2.Dispose();
		return flag;
	}

	public static bool PingIngenico(string provider, Form sender, Terminal station)
	{
		try
		{
			string request = Ingenico.FormatTransactionString("sale", 0.ToString(), null, EmpID.ToString());
			frmWaitingPaymentTerminal obj = new frmWaitingPaymentTerminal(provider, station.PaymentTerminalModel, station.PaymentTerminalAddress, station.PaymentTerminalPort, request, parseObject: true, null, "");
			obj.ShowDialog();
			PaymentTransactionObject paymentTransactionObject = obj.transaction_objects.FirstOrDefault();
			if (paymentTransactionObject != null && paymentTransactionObject.rawdata != null && paymentTransactionObject.rawdata != HipposTransactionErrorMessages.staff_cancelled)
			{
				return true;
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	private static bool smethod_0(Form form_0, PaymentTransactionObject paymentTransactionObject_0)
	{
		if (paymentTransactionObject_0 == null)
		{
			new NotificationLabel(form_0, Resources.Unable_to_communicate_with_pay, NotificationTypes.Warning).Show();
			return true;
		}
		if (paymentTransactionObject_0.responsecode != null)
		{
			if (paymentTransactionObject_0.responsecode.Equals("999"))
			{
				new NotificationLabel(form_0, Resources.Unable_to_communicate_payment_, NotificationTypes.Warning).Show();
				return true;
			}
		}
		else if (paymentTransactionObject_0.transaction_type != "20")
		{
			new NotificationLabel(form_0, Resources.No_response_from_the_payment_t, NotificationTypes.Warning).Show();
			return true;
		}
		return false;
	}

	public static void RecordPaymentTransaction(PaymentTransactionObject trans_object, string orderNumber, string refundNumber)
	{
		GClass6 gClass = new GClass6();
		TransactionReceipt entity = new TransactionReceipt
		{
			OrderNumber = orderNumber,
			RefundNumber = refundNumber,
			CustomerReceipt = trans_object.customerreceipt,
			MerchantReceipt = trans_object.merchantreceipt,
			DateCreated = DateTime.Now
		};
		gClass.TransactionReceipts.InsertOnSubmit(entity);
		Helper.SubmitChangesWithCatch(gClass);
	}

	public static string GetActualPaymentMethod(string previousPayType, string receipt)
	{
		receipt = receipt.ToUpper();
		string result = previousPayType;
		if (receipt.Contains("VISA"))
		{
			result = "Visa";
		}
		else if (receipt.Contains("INTERAC"))
		{
			result = "Interac";
		}
		else if (!receipt.Contains("AMERICAN EXPRESS") && !receipt.Contains("AMEX"))
		{
			if (receipt.Contains("MASTERCARD"))
			{
				result = "MasterCard";
			}
			else if (receipt.Contains("JCB"))
			{
				result = "JCB";
			}
			else if (receipt.Contains("DISCOVER CARD"))
			{
				result = "Discover Card";
			}
			else if (receipt.Contains("DINERS CLUB"))
			{
				result = "Diners Club";
			}
			else if (receipt.Contains("UNION PAY"))
			{
				result = "Union Pay";
			}
			else if (receipt.Contains("GIFT CARD"))
			{
				result = "Gift Card";
			}
		}
		else
		{
			result = "American Express";
		}
		return result;
	}

	static UIPaymentHelper()
	{
		Class26.Ggkj0JxzN9YmC();
		EmpID = Convert.ToInt16(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"]);
	}
}
