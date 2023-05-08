using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmDiscount : frmMasterForm
{
	[CompilerGenerated]
	private decimal decimal_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private decimal IheFlSkSsro;

	private decimal decimal_1;

	private string string_2;

	private IContainer icontainer_1;

	internal Label Label1;

	internal Button btnDollar;

	internal Button btnPercent;

	internal Button btnCancel;

	internal Button btnShowKeyboard_Input;

	private RadTextBoxControl txtInput;

	public decimal percentDiscount
	{
		[CompilerGenerated]
		get
		{
			return decimal_0;
		}
		[CompilerGenerated]
		set
		{
			decimal_0 = value;
		}
	}

	public string discountType
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

	public string discountReason
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public decimal tenderDiscount
	{
		[CompilerGenerated]
		get
		{
			return IheFlSkSsro;
		}
		[CompilerGenerated]
		set
		{
			IheFlSkSsro = value;
		}
	}

	public frmDiscount(decimal amountTobeDiscount, string DiscountDescType)
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		decimal_1 = amountTobeDiscount;
		string_2 = DiscountDescType;
	}

	private void btnPercent_Click(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		Button button = (Button)sender;
		decimal result = -1m;
		if (((Control)(object)txtInput).Text != string.Empty && decimal.TryParse(((Control)(object)txtInput).Text, out result))
		{
			if (button.Name == "btnPercent")
			{
				if (result > 100m)
				{
					new frmMessageBox(Resources.Discount_cannot_be_more_than_1).ShowDialog(this);
					base.DialogResult = DialogResult.None;
					return;
				}
				percentDiscount = result / Convert.ToDecimal(100);
				tenderDiscount = decimal_1 * result / Convert.ToDecimal(100);
				discountType = DiscountTypes.Percentage;
				base.DialogResult = DialogResult.OK;
			}
			if (button.Name == "btnDollar")
			{
				if (result > decimal_1)
				{
					new frmMessageBox(Resources.Discount_cannot_be_more_than_t).ShowDialog(this);
					base.DialogResult = DialogResult.None;
					return;
				}
				if (decimal_1 > 0m)
				{
					percentDiscount = result / decimal_1;
					tenderDiscount = result;
				}
				discountType = DiscountTypes.DollarAmount;
				base.DialogResult = DialogResult.OK;
			}
			string[] itemList = (from a in gClass.Reasons
				where a.ReasonType == "discount"
				select a into d
				select d.Value).ToArray();
			bool withCustom = ((SettingsHelper.GetSettingValueByKey("enable_custom_discount") == "ON") ? true : false);
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.ItemSelector();
			MemoryLoadedObjects.ItemSelector.LoadForm(itemList, withCustom, Resources.Select_a_Discount_Reasons);
			if (MemoryLoadedObjects.ItemSelector.ShowDialog(this) == DialogResult.OK)
			{
				discountReason = MemoryLoadedObjects.ItemSelector.SingleSelectedItem;
				return;
			}
			percentDiscount = 0m;
			base.DialogResult = DialogResult.None;
		}
		else
		{
			new frmMessageBox(Resources.The_input_text_is_not_valid).ShowDialog(this);
			base.DialogResult = DialogResult.None;
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void method_3(object sender, EventArgs e)
	{
	}

	private void method_4(object sender, KeyPressEventArgs e)
	{
		TextFilters.NumbersWithSingleDecimalPoint(sender, e);
	}

	private void btnShowKeyboard_Input_Click(object sender, EventArgs e)
	{
		string title = ((string_2 == DiscountTypes.Item) ? "Enter Item Discount" : Resources.Enter_Order_Discount);
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(title, 2, 6, ((Control)(object)txtInput).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			if (MemoryLoadedObjects.Numpad.numberEntered > 0m)
			{
				((Control)(object)txtInput).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
			}
			else
			{
				new frmMessageBox(Resources.Please_input_a_discount_number).ShowDialog();
			}
			base.DialogResult = DialogResult.None;
		}
		else
		{
			base.DialogResult = DialogResult.Cancel;
			Close();
		}
	}

	private void txtInput_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private void frmDiscount_Load(object sender, EventArgs e)
	{
		btnShowKeyboard_Input_Click(this, null);
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
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmDiscount));
		btnShowKeyboard_Input = new Button();
		btnCancel = new Button();
		Label1 = new Label();
		btnDollar = new Button();
		btnPercent = new Button();
		txtInput = new RadTextBoxControl();
		((ISupportInitialize)txtInput).BeginInit();
		SuspendLayout();
		btnShowKeyboard_Input.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Input.DialogResult = DialogResult.OK;
		btnShowKeyboard_Input.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Input.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Input, "btnShowKeyboard_Input");
		btnShowKeyboard_Input.ForeColor = Color.White;
		btnShowKeyboard_Input.Name = "btnShowKeyboard_Input";
		btnShowKeyboard_Input.Tag = "product";
		btnShowKeyboard_Input.UseVisualStyleBackColor = false;
		btnShowKeyboard_Input.Click += btnShowKeyboard_Input_Click;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderColor = Color.Black;
		btnCancel.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = Color.White;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		Label1.BackColor = Color.FromArgb(156, 89, 184);
		componentResourceManager.ApplyResources(Label1, "Label1");
		Label1.ForeColor = Color.White;
		Label1.Name = "Label1";
		btnDollar.BackColor = Color.FromArgb(50, 119, 155);
		btnDollar.DialogResult = DialogResult.OK;
		btnDollar.FlatAppearance.BorderColor = Color.Black;
		btnDollar.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnDollar, "btnDollar");
		btnDollar.ForeColor = Color.White;
		btnDollar.Name = "btnDollar";
		btnDollar.UseVisualStyleBackColor = false;
		btnDollar.Click += btnPercent_Click;
		btnPercent.BackColor = Color.FromArgb(61, 142, 185);
		btnPercent.DialogResult = DialogResult.OK;
		btnPercent.FlatAppearance.BorderColor = Color.Black;
		btnPercent.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnPercent, "btnPercent");
		btnPercent.ForeColor = Color.White;
		btnPercent.Name = "btnPercent";
		btnPercent.UseVisualStyleBackColor = false;
		btnPercent.Click += btnPercent_Click;
		componentResourceManager.ApplyResources(txtInput, "txtInput");
		((Control)(object)txtInput).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtInput).Name = "txtInput";
		((RadElement)((RadControl)txtInput).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtInput).Click += txtInput_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtInput).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtInput).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add((Control)(object)txtInput);
		base.Controls.Add(btnShowKeyboard_Input);
		base.Controls.Add(btnCancel);
		base.Controls.Add(Label1);
		base.Controls.Add(btnDollar);
		base.Controls.Add(btnPercent);
		ForeColor = Color.FromArgb(40, 40, 40);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmDiscount";
		base.Opacity = 1.0;
		base.Load += frmDiscount_Load;
		((ISupportInitialize)txtInput).EndInit();
		ResumeLayout(performLayout: false);
	}
}
