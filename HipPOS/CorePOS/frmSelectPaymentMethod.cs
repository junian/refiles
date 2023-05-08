using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Data;

namespace CorePOS;

public class frmSelectPaymentMethod : frmMasterForm
{
	[CompilerGenerated]
	private string string_0;

	private int int_0;

	private List<string> nOfFgAiybAp;

	private IContainer icontainer_1;

	private Label lblTitle;

	internal Button btnCancel;

	private FlowLayoutPanel pnlTenderTypes;

	public string returnPaymentMethod
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

	public frmSelectPaymentMethod(string _title = "Select Payment Method", bool showCancelButton = false, List<string> paymentMethodsFilter = null)
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		lblTitle.Text = _title;
		if (!showCancelButton)
		{
			btnCancel.Visible = false;
			base.Height -= btnCancel.Height;
		}
		nOfFgAiybAp = paymentMethodsFilter;
	}

	private void frmSelectPaymentMethod_Load(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		int num = 0;
		List<PaymentType> list = gClass.PaymentTypes.OrderBy((PaymentType x) => x.SortOrder).ToList();
		if (nOfFgAiybAp != null)
		{
			list = list.Where((PaymentType paymentType_0) => nOfFgAiybAp.Contains(paymentType_0.Name.ToUpper()) || paymentType_0.Name.ToUpper() == "CASH" || paymentType_0.Name.ToUpper() == "OTHER" || (nOfFgAiybAp.Contains("INTERAC") && paymentType_0.Name.ToUpper() == "DEBIT")).ToList();
		}
		foreach (PaymentType item in list)
		{
			for (int i = 0; i < 14; i++)
			{
				if (num != item.SortOrder)
				{
					method_5(num);
					num++;
					continue;
				}
				method_4(item.Name, item.OpenCashDrawer, item.UsePaymentTerminal);
				num++;
				break;
			}
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
	}

	private void method_3(object sender, EventArgs e)
	{
		Button button = sender as Button;
		returnPaymentMethod = button.Text;
		base.DialogResult = DialogResult.OK;
	}

	private void method_4(string string_1, bool bool_0, bool bool_1)
	{
		Button button = new Button();
		button.BackColor = Color.FromArgb(50, 119, 155);
		button.FlatStyle = FlatStyle.Flat;
		button.FlatAppearance.BorderColor = Color.Black;
		button.FlatAppearance.BorderSize = 0;
		button.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		button.ForeColor = Color.White;
		button.Name = "btn" + string_1 + "_" + (bool_0 ? "YES" : "NO") + "_" + (bool_1 ? "YES" : "NO");
		button.Text = string_1.ToUpper();
		button.Size = new Size(145, 63);
		button.UseVisualStyleBackColor = false;
		button.Margin = new Padding(1, 0, 0, 1);
		button.Padding = new Padding(0, 0, 0, 0);
		button.Click += method_3;
		pnlTenderTypes.Controls.Add(button);
	}

	private void method_5(int int_1)
	{
		Button button = new Button();
		button.BackColor = Color.FromArgb(35, 39, 56);
		button.FlatStyle = FlatStyle.Flat;
		button.Enabled = false;
		button.FlatAppearance.BorderSize = 0;
		button.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 39, 56);
		button.Name = "btnPlaceHolder_" + int_0;
		button.Text = string.Empty;
		button.Size = new Size(145, 60);
		button.UseVisualStyleBackColor = false;
		button.Margin = new Padding(1, 0, 0, 1);
		button.Padding = new Padding(0, 0, 0, 0);
		pnlTenderTypes.Controls.Add(button);
		pnlTenderTypes.Controls.SetChildIndex(button, int_1);
		int_0++;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSelectPaymentMethod));
		btnCancel = new Button();
		lblTitle = new Label();
		pnlTenderTypes = new FlowLayoutPanel();
		SuspendLayout();
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderColor = Color.Black;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = Color.White;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		componentResourceManager.ApplyResources(lblTitle, "lblTitle");
		lblTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblTitle.ForeColor = Color.White;
		lblTitle.Name = "lblTitle";
		componentResourceManager.ApplyResources(pnlTenderTypes, "pnlTenderTypes");
		pnlTenderTypes.Name = "pnlTenderTypes";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(btnCancel);
		base.Controls.Add(pnlTenderTypes);
		base.Controls.Add(lblTitle);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmSelectPaymentMethod";
		base.Opacity = 1.0;
		base.Load += frmSelectPaymentMethod_Load;
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private bool method_6(PaymentType paymentType_0)
	{
		if (!nOfFgAiybAp.Contains(paymentType_0.Name.ToUpper()) && !(paymentType_0.Name.ToUpper() == "CASH") && !(paymentType_0.Name.ToUpper() == "OTHER"))
		{
			if (nOfFgAiybAp.Contains("INTERAC"))
			{
				return paymentType_0.Name.ToUpper() == "DEBIT";
			}
			return false;
		}
		return true;
	}
}
