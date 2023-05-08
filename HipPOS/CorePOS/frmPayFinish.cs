using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.CommonForms;
using CorePOS.Data;
using CorePOS.Properties;

namespace CorePOS;

public class frmPayFinish : frmMasterForm
{
	private string string_0;

	private decimal decimal_0;

	private decimal decimal_1;

	private decimal IhwFuSuegrG;

	private string string_1;

	private IContainer icontainer_1;

	internal Button btnDone;

	internal TextBox txtChange;

	internal Label Label6;

	internal Button btnPrintReceipt;

	internal Button btnEmailReceipt;

	internal Button btnGoBack;

	internal Button btnOpenRegister;

	internal Button vHtFuopxEtd;

	private Panel panel1;

	internal Label lblTip;

	public frmPayFinish(decimal changeAmount, string orderNumber, string paymentTypes, decimal tip, string approvalcode, decimal autoGratuity, decimal giftCardBalance, decimal loyaltyCardBalance, bool hasGiftCardItem)
	{
		Class26.Ggkj0JxzN9YmC();
		decimal_1 = -1m;
		IhwFuSuegrG = -1m;
		string_1 = "";
		base._002Ector();
		InitializeComponent_1();
		string_1 = paymentTypes;
		new FormHelper().ResizeButtonFonts(this, 1.5f);
		if (Thread.CurrentThread.CurrentCulture.Name.Equals("fr-CA"))
		{
			vHtFuopxEtd.Font = new Font(vHtFuopxEtd.Font.FontFamily, vHtFuopxEtd.Font.Size - 0.75f);
		}
		txtChange.Text = changeAmount.ToString("0.00");
		string_0 = orderNumber;
		if (tip > 0m)
		{
			lblTip.Text = Resources.Tip + tip.ToString("$0.00");
		}
		string_0 = orderNumber;
		decimal_0 = autoGratuity;
		decimal_1 = giftCardBalance;
		IhwFuSuegrG = loyaltyCardBalance;
		bool flag = ((SettingsHelper.GetSettingValueByKey("gift_card_payment") == "ON") ? true : false);
		GClass6 gClass = new GClass6();
		if ((from x in gClass.TransactionReceipts
			where x.OrderNumber == string_0
			select x into y
			orderby y.DateCreated descending
			select y).FirstOrDefault() == null && ((!paymentTypes.ToUpper().Contains(Resources.Gift_Certificate.ToUpper()) && !paymentTypes.ToUpper().Contains("GIFT CARD")) || !flag) && !hasGiftCardItem)
		{
			btnGoBack.Enabled = true;
		}
		else
		{
			btnGoBack.Enabled = false;
		}
		gClass.Dispose();
	}

	private void btnDone_Click(object sender, EventArgs e)
	{
		string_0 = null;
		base.DialogResult = DialogResult.OK;
		Close();
		GC.Collect();
	}

	private void btnPrintReceipt_Click(object sender, EventArgs e)
	{
		PrintHelper.GenerateReceipt(string_0, printPaymentTransaction: true, 1, null, tipFlag: false, email: false, MemoryLoadedObjects.this_terminal.DefaultPrinter, decimal_1, IhwFuSuegrG);
	}

	private void btnEmailReceipt_Click(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		foreach (Setting item2 in gClass.Settings.Where((Setting s) => s.Key.Contains("smtp")).ToList())
		{
			if (string.IsNullOrEmpty(item2.Value))
			{
				new frmMessageBox("SMTP settings has not been configure you will be able to assign an order but not email the receipt.", Resources.No_Email_Settings).ShowDialog(this);
				break;
			}
		}
		if (SettingsHelper.GetSettingValueByKey("member_assign") == "ON")
		{
			_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
			CS_0024_003C_003E8__locals0.orders = gClass.Orders.Where((Order o) => o.OrderNumber == string_0);
			if (CS_0024_003C_003E8__locals0.orders.Count() > 0 && CS_0024_003C_003E8__locals0.orders.FirstOrDefault().CustomerID.HasValue)
			{
				Customer customer = gClass.Customers.Where((Customer a) => a.CustomerID == CS_0024_003C_003E8__locals0.orders.FirstOrDefault().CustomerID.Value).FirstOrDefault();
				if (customer != null && !string.IsNullOrEmpty(customer.CustomerEmail))
				{
					CompanySetup companySetup = gClass.CompanySetups.FirstOrDefault();
					string item = Resources.Hi + customer.CustomerName + Resources._br_br_Thank_you_for_shopping_ + companySetup.Name + Resources._As_you_have_requested_attache;
					List<string> list = new List<string>();
					list.Add(string_0);
					list.Add(customer.CustomerEmail);
					list.Add(item);
					frmLoading frmLoading = new frmLoading("SENDING EMAIL...", "sendEmail", list);
					frmLoading.ShowDialog(this);
					if (frmLoading.DialogResult == DialogResult.OK)
					{
						new frmMessageBox(Resources.Customer_info_saved_receipt_se).ShowDialog(this);
						Close();
					}
					else
					{
						new frmMessageBox(Resources.An_error_occued_while_sending_the_email_please).ShowDialog(this);
					}
					base.DialogResult = DialogResult.None;
					return;
				}
			}
		}
		new frmCustomers(null, string_0, null, save_send: true).ShowDialog(this);
		base.DialogResult = DialogResult.None;
	}

	private void btnGoBack_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Admin_or_Manager_PIN);
		bool flag = false;
		while (true)
		{
			if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
			{
				MemoryLoadedObjects.Numpad.DialogResult = DialogResult.None;
				base.DialogResult = DialogResult.None;
				flag = true;
			}
			else
			{
				Employee employee = UserMethods.AuthenticateUser(Convert.ToString(MemoryLoadedObjects.Numpad.valueEntered));
				if (employee != null)
				{
					if (!(employee.Users.FirstOrDefault().Role.RoleName == Roles.admin) && !(employee.Users.FirstOrDefault().Role.RoleName == Roles.manager) && !(employee.Users.FirstOrDefault().Role.RoleName == Roles.supervisor))
					{
						flag = false;
						new frmMessageBox(Resources.Invalid_PIN_entered).ShowDialog(this);
						MemoryLoadedObjects.Numpad.TextInput = string.Empty;
					}
					else
					{
						if ((from x in new GClass6().TransactionReceipts
							where x.OrderNumber == string_0
							select x into y
							orderby y.DateCreated descending
							select y).FirstOrDefault() != null)
						{
							break;
						}
						flag = true;
						base.DialogResult = DialogResult.Cancel;
					}
				}
				else
				{
					flag = false;
					new frmMessageBox(Resources.Invalid_PIN_entered).ShowDialog(this);
					MemoryLoadedObjects.Numpad.TextInput = string.Empty;
				}
			}
			if (flag)
			{
				return;
			}
		}
		new frmMessageBox(Resources.Payment_has_already_been_made_, Resources.Action_Not_Allowed).ShowDialog(this);
		base.DialogResult = DialogResult.None;
		flag = true;
	}

	private void btnOpenRegister_Click(object sender, EventArgs e)
	{
		GClass8.OpenCashDrawer();
	}

	private void vHtFuopxEtd_Click(object sender, EventArgs e)
	{
		string cash = TipTypes.Cash;
		bool flag = true;
		do
		{
			flag = true;
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
			MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Tip_Amount, 2, 8, txtChange.Text);
			if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
			{
				continue;
			}
			decimal numberEntered = MemoryLoadedObjects.Numpad.numberEntered;
			GClass6 gClass = new GClass6();
			IQueryable<Order> queryable = gClass.Orders.Where((Order o) => o.OrderNumber == string_0);
			decimal num = Convert.ToDecimal(0.5) * queryable.Sum((Order s) => s.Total);
			if (numberEntered >= num && new frmMessageBox(Resources.Are_you_sure_you_want_to_enter + $"{numberEntered:C}" + "?", Resources.Tip_Amount, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.No)
			{
				flag = false;
				continue;
			}
			decimal num2 = queryable.Where((Order a) => a.Void == false && a.Paid == true).Sum((Order a) => a.SubTotal);
			foreach (Order item in queryable)
			{
				item.TipAmount = decimal_0 + numberEntered;
				item.TipDesc = OrderHelper.UpdateDiscountFromDiscountDescription("", cash, numberEntered);
				List<string> list = new List<string>();
				foreach (CustomTipSharing item2 in MemoryLoadedObjects.all_tip_sharing.Where((CustomTipSharing a) => a.Percentage > 0m))
				{
					decimal num3 = item.TipAmount * item2.Percentage / 100m;
					if (num3 > 0m && item2.TipShareType == 1)
					{
						list.Add(item2.TipName + "=" + num3.ToString("0.00") + "=" + item2.Percentage.ToString("0.##"));
					}
					else if (item2.TipShareType == 2)
					{
						num3 = num2 * item2.Percentage / 100m;
						list.Add(item2.TipName + "=" + num3.ToString("0.00") + "=" + item2.Percentage.ToString("0.##"));
					}
				}
				item.TipShareDesc = string.Join("|", list);
				item.TipRecorded = true;
				if (item.OrderType.Equals(OrderTypes.PickUp) || item.OrderType.Equals(OrderTypes.Delivery) || item.OrderType.Equals(OrderTypes.ToGo))
				{
					item.DateCleared = DateTime.Now;
				}
				item.Synced = false;
				Helper.SubmitChangesWithCatch(gClass);
			}
			lblTip.Text = Resources.Tip + MemoryLoadedObjects.Numpad.numberEntered.ToString("$0.00");
		}
		while (!flag);
		base.DialogResult = DialogResult.None;
	}

	private void btnGoBack_EnabledChanged(object sender, EventArgs e)
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmPayFinish));
		panel1 = new Panel();
		lblTip = new Label();
		Label6 = new Label();
		txtChange = new TextBox();
		vHtFuopxEtd = new Button();
		btnOpenRegister = new Button();
		btnGoBack = new Button();
		btnEmailReceipt = new Button();
		btnPrintReceipt = new Button();
		btnDone = new Button();
		panel1.SuspendLayout();
		SuspendLayout();
		panel1.BackColor = Color.FromArgb(30, 30, 30);
		panel1.Controls.Add(lblTip);
		panel1.Controls.Add(Label6);
		panel1.Controls.Add(txtChange);
		componentResourceManager.ApplyResources(panel1, "panel1");
		panel1.Name = "panel1";
		componentResourceManager.ApplyResources(lblTip, "lblTip");
		lblTip.ForeColor = Color.White;
		lblTip.Name = "lblTip";
		componentResourceManager.ApplyResources(Label6, "Label6");
		Label6.ForeColor = Color.White;
		Label6.Name = "Label6";
		txtChange.BackColor = Color.FromArgb(30, 30, 30);
		txtChange.BorderStyle = BorderStyle.None;
		componentResourceManager.ApplyResources(txtChange, "txtChange");
		txtChange.ForeColor = Color.FromArgb(244, 156, 20);
		txtChange.Name = "txtChange";
		txtChange.ReadOnly = true;
		vHtFuopxEtd.BackColor = Color.FromArgb(61, 142, 185);
		vHtFuopxEtd.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
		vHtFuopxEtd.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(vHtFuopxEtd, "btnRecordTips");
		vHtFuopxEtd.ForeColor = Color.White;
		vHtFuopxEtd.Name = "btnRecordTips";
		vHtFuopxEtd.UseVisualStyleBackColor = false;
		vHtFuopxEtd.Click += vHtFuopxEtd_Click;
		btnOpenRegister.BackColor = Color.FromArgb(50, 119, 155);
		btnOpenRegister.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
		btnOpenRegister.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnOpenRegister, "btnOpenRegister");
		btnOpenRegister.ForeColor = Color.White;
		btnOpenRegister.Name = "btnOpenRegister";
		btnOpenRegister.UseVisualStyleBackColor = false;
		btnOpenRegister.Click += btnOpenRegister_Click;
		btnGoBack.BackColor = Color.FromArgb(235, 107, 86);
		btnGoBack.DialogResult = DialogResult.Cancel;
		btnGoBack.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
		btnGoBack.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnGoBack, "btnGoBack");
		btnGoBack.ForeColor = Color.White;
		btnGoBack.Name = "btnGoBack";
		btnGoBack.UseVisualStyleBackColor = false;
		btnGoBack.EnabledChanged += btnGoBack_EnabledChanged;
		btnGoBack.Click += btnGoBack_Click;
		btnEmailReceipt.BackColor = Color.FromArgb(42, 99, 129);
		btnEmailReceipt.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
		btnEmailReceipt.FlatAppearance.BorderSize = 0;
		btnEmailReceipt.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnEmailReceipt, "btnEmailReceipt");
		btnEmailReceipt.ForeColor = Color.White;
		btnEmailReceipt.Name = "btnEmailReceipt";
		btnEmailReceipt.UseVisualStyleBackColor = false;
		btnEmailReceipt.Click += btnEmailReceipt_Click;
		btnPrintReceipt.BackColor = Color.FromArgb(77, 174, 225);
		btnPrintReceipt.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
		btnPrintReceipt.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnPrintReceipt, "btnPrintReceipt");
		btnPrintReceipt.ForeColor = Color.White;
		btnPrintReceipt.Name = "btnPrintReceipt";
		btnPrintReceipt.UseVisualStyleBackColor = false;
		btnPrintReceipt.Click += btnPrintReceipt_Click;
		btnDone.BackColor = Color.FromArgb(80, 203, 116);
		btnDone.DialogResult = DialogResult.OK;
		btnDone.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
		btnDone.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnDone, "btnDone");
		btnDone.ForeColor = Color.White;
		btnDone.Name = "btnDone";
		btnDone.UseVisualStyleBackColor = false;
		btnDone.Click += btnDone_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(panel1);
		base.Controls.Add(vHtFuopxEtd);
		base.Controls.Add(btnOpenRegister);
		base.Controls.Add(btnGoBack);
		base.Controls.Add(btnEmailReceipt);
		base.Controls.Add(btnPrintReceipt);
		base.Controls.Add(btnDone);
		ForeColor = Color.White;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmPayFinish";
		base.Opacity = 1.0;
		base.ShowIcon = false;
		base.Controls.SetChildIndex(btnDone, 0);
		base.Controls.SetChildIndex(btnPrintReceipt, 0);
		base.Controls.SetChildIndex(btnEmailReceipt, 0);
		base.Controls.SetChildIndex(btnGoBack, 0);
		base.Controls.SetChildIndex(btnOpenRegister, 0);
		base.Controls.SetChildIndex(vHtFuopxEtd, 0);
		base.Controls.SetChildIndex(panel1, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		panel1.ResumeLayout(performLayout: false);
		panel1.PerformLayout();
		ResumeLayout(performLayout: false);
	}
}
