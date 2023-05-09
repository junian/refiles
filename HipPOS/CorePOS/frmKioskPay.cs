using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;

namespace CorePOS;

public class frmKioskPay : frmMasterForm
{
	private string string_0;

	private decimal decimal_0;

	private decimal decimal_1;

	private short short_0;

	private decimal decimal_2;

	private List<ProcessorPaymentTypeWithId> list_2;

	private IContainer icontainer_1;

	internal Button btnPayDebitCredit;

	internal Button rObFnjnrakV;

	private Label label1;

	private Label mXfFnHewUt8;

	internal Button btnStartOver;

	internal Button KqrFnJxavoe;

	public frmKioskPay(string _orderNumber, decimal _orderTotal)
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
		string_0 = _orderNumber;
		decimal_0 = _orderTotal;
	}

	private void frmKioskPay_Load(object sender, EventArgs e)
	{
		short.TryParse(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString(), out short_0);
		list_2 = new List<ProcessorPaymentTypeWithId>();
		mXfFnHewUt8.Text = $"{decimal_0:C}";
	}

	private void rObFnjnrakV_Click(object sender, EventArgs e)
	{
		method_3();
		new frmKioskPayFinish(string_0).ShowDialog();
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void method_3()
	{
		PrintHelper.GenerateReceipt(string_0, printPaymentTransaction: true, 1, null, tipFlag: false, email: false, MemoryLoadedObjects.this_terminal.DefaultPrinter);
	}

	private void btnPayDebitCredit_Click(object sender, EventArgs e)
	{
		method_4("Debit/Credit");
	}

	private void method_4(string string_1)
	{
		decimal num = decimal_0 - decimal_2;
		SettingsHelper.GetSettingValueByKey("use_payment_processor");
		Terminal terminal = new GClass6().Terminals.Where((Terminal x) => x.SystemName.Equals(Environment.MachineName)).FirstOrDefault();
		if (terminal == null || string.IsNullOrEmpty(terminal.PaymentMerchantID) || string.IsNullOrEmpty(terminal.PaymentProviderName) || string.IsNullOrEmpty(terminal.PaymentTerminalAddress) || string.IsNullOrEmpty(terminal.PaymentTerminalModel) || terminal.PaymentTerminalPort <= 0)
		{
			return;
		}
		bool flag = false;
		int num2 = (int)(num * 100m);
		List<PaymentTransactionObject> trans_objects = new List<PaymentTransactionObject>();
		if (terminal.PaymentProviderName == PaymentProviderNames.FirstData)
		{
			UIPaymentHelper.ProcessFirstData(this, terminal, "sale", num2, string_0, "", null, out trans_objects);
		}
		else if (terminal.PaymentProviderName == PaymentProviderNames.Moneris || terminal.PaymentProviderName == PaymentProviderNames.Elavon)
		{
			UIPaymentHelper.ProcessIngenico(terminal.PaymentProviderName, this, terminal, "sale", num2, string_0, "", null, out trans_objects);
		}
		foreach (PaymentTransactionObject item in trans_objects)
		{
			flag = true;
			if (!string.IsNullOrEmpty(item.customerreceipt) && (item.customerreceipt.ToUpper().Contains("NOT COMPLETED") || item.customerreceipt.ToUpper().Contains("DECLINED") || item.customerreceipt.ToUpper().Contains("*CANCELLED*") || !item.merchantreceipt.ToUpper().Contains("APPROVED")))
			{
				flag = false;
			}
			if (flag)
			{
				decimal num3 = Convert.ToDecimal(item.totalamount) / 100m;
				decimal_2 += num3;
				string text = Guid.NewGuid().ToString();
				num3 = Convert.ToDecimal($"{num3:0.00}");
				decimal decimal_ = num3 - (decimal)num2 / 100m;
				new ListViewItem(new string[3]
				{
					string_1,
					"$" + num3,
					text
				});
				list_2.Add(new ProcessorPaymentTypeWithId
				{
					PaymentTypeName = string_1,
					Amount = num3,
					Id = text
				});
				method_5(decimal_);
			}
			else
			{
				new NotificationLabel(this, Resources.Payment_terminal_settings_have, NotificationTypes.Warning).Show();
			}
		}
	}

	private void method_5(decimal decimal_3)
	{
		GClass6 gClass = new GClass6();
		string text = "";
		foreach (ProcessorPaymentTypeWithId item in list_2)
		{
			text = text + item.PaymentTypeName + "=" + item.Amount + "|";
		}
		foreach (Order item2 in gClass.Orders.Where((Order o) => o.OrderNumber == string_0))
		{
			item2.PaymentMethods = text;
			item2.TipAmount = decimal_3;
			item2.TipRecorded = decimal_3 > 0m;
			item2.Paid = true;
			item2.DatePaid = DateTime.Now;
			item2.Synced = false;
			Helper.SubmitChangesWithCatch(gClass);
		}
		method_3();
		new frmKioskPayFinish(string_0).ShowDialog();
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void btnStartOver_Click(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		IQueryable<Order> queryable = gClass.Orders.Where((Order o) => o.OrderNumber == string_0);
		Employee employee = gClass.Employees.Where((Employee x) => x.EmployeeID == short_0).FirstOrDefault();
		string voidBy = employee.FirstName + " " + employee.LastName;
		foreach (Order item in queryable)
		{
			item.Void = true;
			item.VoidBy = voidBy;
			Helper.SubmitChangesWithCatch(gClass);
		}
		base.DialogResult = DialogResult.OK;
		Close();
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmKioskPay));
		btnPayDebitCredit = new Button();
		rObFnjnrakV = new Button();
		label1 = new Label();
		mXfFnHewUt8 = new Label();
		btnStartOver = new Button();
		KqrFnJxavoe = new Button();
		SuspendLayout();
		componentResourceManager.ApplyResources(btnPayDebitCredit, "btnPayDebitCredit");
		btnPayDebitCredit.BackColor = Color.Transparent;
		btnPayDebitCredit.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnPayDebitCredit.FlatAppearance.BorderSize = 0;
		btnPayDebitCredit.FlatAppearance.MouseDownBackColor = Color.FromArgb(55, 61, 85);
		btnPayDebitCredit.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 61, 85);
		btnPayDebitCredit.ForeColor = Color.White;
		btnPayDebitCredit.Name = "btnPayDebitCredit";
		btnPayDebitCredit.UseVisualStyleBackColor = false;
		btnPayDebitCredit.Click += btnPayDebitCredit_Click;
		componentResourceManager.ApplyResources(rObFnjnrakV, "btnPayAtCounter");
		rObFnjnrakV.BackColor = Color.Transparent;
		rObFnjnrakV.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		rObFnjnrakV.FlatAppearance.BorderSize = 0;
		rObFnjnrakV.FlatAppearance.MouseDownBackColor = Color.FromArgb(55, 61, 85);
		rObFnjnrakV.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 61, 85);
		rObFnjnrakV.ForeColor = Color.White;
		rObFnjnrakV.Name = "btnPayAtCounter";
		rObFnjnrakV.UseVisualStyleBackColor = false;
		rObFnjnrakV.Click += rObFnjnrakV_Click;
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		componentResourceManager.ApplyResources(mXfFnHewUt8, "lblAmountDue");
		mXfFnHewUt8.ForeColor = Color.FromArgb(255, 255, 128);
		mXfFnHewUt8.Name = "lblAmountDue";
		componentResourceManager.ApplyResources(btnStartOver, "btnStartOver");
		btnStartOver.BackColor = Color.Transparent;
		btnStartOver.DialogResult = DialogResult.OK;
		btnStartOver.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnStartOver.FlatAppearance.BorderSize = 0;
		btnStartOver.FlatAppearance.MouseDownBackColor = Color.FromArgb(55, 61, 85);
		btnStartOver.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 61, 85);
		btnStartOver.ForeColor = Color.White;
		btnStartOver.Name = "btnStartOver";
		btnStartOver.UseVisualStyleBackColor = false;
		btnStartOver.Click += btnStartOver_Click;
		componentResourceManager.ApplyResources(KqrFnJxavoe, "btnGoBack");
		KqrFnJxavoe.BackColor = Color.Transparent;
		KqrFnJxavoe.DialogResult = DialogResult.OK;
		KqrFnJxavoe.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		KqrFnJxavoe.FlatAppearance.BorderSize = 0;
		KqrFnJxavoe.FlatAppearance.MouseDownBackColor = Color.FromArgb(55, 61, 85);
		KqrFnJxavoe.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 61, 85);
		KqrFnJxavoe.ForeColor = Color.White;
		KqrFnJxavoe.Name = "btnGoBack";
		KqrFnJxavoe.UseVisualStyleBackColor = false;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(KqrFnJxavoe);
		base.Controls.Add(btnStartOver);
		base.Controls.Add(mXfFnHewUt8);
		base.Controls.Add(label1);
		base.Controls.Add(btnPayDebitCredit);
		base.Controls.Add(rObFnjnrakV);
		base.Name = "frmKioskPay";
		base.Opacity = 1.0;
		base.WindowState = FormWindowState.Maximized;
		base.Load += frmKioskPay_Load;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
