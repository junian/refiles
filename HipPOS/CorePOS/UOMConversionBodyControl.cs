using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls.UI;
using UnitsNet;

namespace CorePOS;

public class UOMConversionBodyControl : UserControl
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public short BaseUnitId;

		public UOMConversionBodyControl _003C_003E4__this;

		public _003C_003Ec__DisplayClass14_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	private int int_0;

	private short short_0;

	private short short_1;

	private string string_0;

	private string string_1;

	private decimal decimal_0;

	private decimal decimal_1;

	private int? nullable_0;

	private GClass6 gclass6_0;

	private frmUOMConversions frmUOMConversions_0;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	[CompilerGenerated]
	private EventHandler eventHandler_1;

	private IContainer icontainer_0;

	private RadTextBoxControl txtFactor;

	private RadTextBoxControl txtSample;

	private Class19 ddlOperator;

	private PictureBox btnRemove;

	private Class19 ddlUOMs;

	public event EventHandler btnRemoveClick
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler txtFactorChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public UOMConversionBodyControl(FlowLayoutPanel _Panel, GClass7 _conv, frmUOMConversions _parent)
	{
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		base._002Ector();
		InitializeComponent();
		int_0 = _conv.Id;
		short_0 = _conv.ToUnitId;
		string_0 = ((_conv.Id == 0) ? "" : _conv.UOM1.Name);
		string_1 = _conv.Operator;
		decimal_0 = _conv.Factor;
		nullable_0 = _conv.ItemID;
		short_1 = _conv.BaseUnitId;
		frmUOMConversions_0 = _parent;
	}

	private void UOMConversionBodyControl_Load(object sender, EventArgs e)
	{
		method_0();
		ddlOperator.SelectedIndex = ((!(string_1 == "*")) ? 1 : 0);
		ddlUOMs.SelectedValue = (int)short_0;
		txtFactor.Text = MathHelper.RemoveTrailingZeros(decimal_0.ToString("0.000000"));
	}

	private void method_0()
	{
		ddlUOMs.DisplayMember = "Value";
		ddlUOMs.ValueMember = "Key";
		ddlUOMs.DataSource = new BindingSource(new UOMMethods().GetAllUOMsList(), null);
	}

	public string ChangeSampleQuantity(decimal? BaseSampleValue)
	{
		if (BaseSampleValue.HasValue)
		{
			decimal_1 = BaseSampleValue.Value;
		}
		if (!decimal.TryParse(txtFactor.Text, out var result))
		{
			return "no_value";
		}
		if (ddlOperator.SelectedIndex == 0)
		{
			decimal num = decimal_1 * result;
			txtSample.Text = MathHelper.RemoveTrailingZeros(num.ToString("0.000000"));
			return txtSample.Text + " " + ddlUOMs.Text;
		}
		if (Convert.ToDecimal(txtFactor.Text) == 0m)
		{
			return "divzero";
		}
		decimal num2 = decimal_1 / result;
		txtSample.Text = MathHelper.RemoveTrailingZeros(num2.ToString("0.000000"));
		return txtSample.Text + " " + ddlUOMs.Text;
	}

	public bool Save(short BaseUnitId)
	{
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass14_0();
		CS_0024_003C_003E8__locals0.BaseUnitId = BaseUnitId;
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		if (ddlUOMs.SelectedValue == null)
		{
			new NotificationLabel(frmUOMConversions_0, Resources.Please_select_a_UOM_to_convert, NotificationTypes.Notification).Show();
			return false;
		}
		if (string.IsNullOrEmpty(txtFactor.Text))
		{
			new NotificationLabel(frmUOMConversions_0, Resources.Please_enter_a_value_for_facto, NotificationTypes.Notification).Show();
			return false;
		}
		GClass6 gClass = new GClass6();
		GClass7 gClass2;
		if (int_0 != 0)
		{
			gClass2 = gClass.UOMUnitsConversions.Where((GClass7 a) => a.BaseUnitId == CS_0024_003C_003E8__locals0.BaseUnitId && a.Id == int_0).FirstOrDefault();
		}
		else
		{
			gClass2 = new GClass7();
			gClass.UOMUnitsConversions.InsertOnSubmit(gClass2);
		}
		gClass2.BaseUnitId = short_1;
		gClass2.Operator = ((ddlOperator.SelectedIndex == 0) ? "*" : "/");
		gClass2.Factor = Convert.ToDecimal(txtFactor.Text);
		gClass2.ToUnitId = Convert.ToInt16(ddlUOMs.SelectedValue);
		gClass2.ItemID = nullable_0;
		Helper.SubmitChangesWithCatch(gClass);
		return true;
	}

	private void btnRemove_Click(object sender, EventArgs e)
	{
		if (eventHandler_0 != null)
		{
			eventHandler_0(int_0, e);
			Dispose();
		}
	}

	private void txtFactor_TextChanged(object sender, EventArgs e)
	{
		if (eventHandler_1 != null)
		{
			eventHandler_1(this, e);
		}
	}

	private void txtFactor_KeyPress(object sender, KeyPressEventArgs e)
	{
		TextFilters.NumbersWithSingleDecimalPoint(sender, e);
	}

	private void ddlUOMs_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (ddlUOMs.SelectedValue != null)
		{
			string text = (from x in gclass6_0.UOMs
				where x.UOMID == short_1
				select x into y
				select y.Name).FirstOrDefault();
			string text2 = (from x in gclass6_0.UOMs
				where x.UOMID.ToString() == ddlUOMs.SelectedValue.ToString()
				select x into y
				select y.Name).FirstOrDefault();
			double num = 0.0;
			try
			{
				num = UnitConverter.ConvertByName((byte)1, "Mass", text, text2);
			}
			catch
			{
			}
			if (num > 1.0)
			{
				txtFactor.Text = MathHelper.RemoveTrailingZeros(num.ToString("0.000000"));
				ddlOperator.SelectedIndex = 0;
				txtFactor.Enabled = false;
			}
			else if (num <= 1.0 && num > 0.0)
			{
				num = UnitConverter.ConvertByName((byte)1, "Mass", text2, text);
				txtFactor.Text = MathHelper.RemoveTrailingZeros(num.ToString("0.000000"));
				ddlOperator.SelectedIndex = 1;
				txtFactor.Enabled = false;
			}
			else
			{
				txtFactor.Enabled = true;
				RadTextBoxControl radTextBoxControl = txtSample;
				string text3 = (txtFactor.Text = string.Empty);
				radTextBoxControl.Text = text3;
			}
			frmUOMConversions_0.triggerCalculations();
		}
	}

	private void ddlOperator_SelectedIndexChanged(object sender, EventArgs e)
	{
		frmUOMConversions_0.triggerCalculations();
	}

	private void txtFactor_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Factor, 4, 8, txtFactor.Text, Resources.Conversion_Factor_is_past_the_);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtFactor.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
			ChangeSampleQuantity(null);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.UOMConversionBodyControl));
		this.txtFactor = new Telerik.WinControls.UI.RadTextBoxControl();
		this.txtSample = new Telerik.WinControls.UI.RadTextBoxControl();
		this.btnRemove = new System.Windows.Forms.PictureBox();
		this.ddlUOMs = new Class19();
		this.ddlOperator = new Class19();
		((System.ComponentModel.ISupportInitialize)this.txtFactor).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSample).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.btnRemove).BeginInit();
		base.SuspendLayout();
		this.txtFactor.BackColor = System.Drawing.Color.White;
		resources.ApplyResources(this.txtFactor, "txtFactor");
		this.txtFactor.ForeColor = System.Drawing.SystemColors.ControlText;
		this.txtFactor.Name = "txtFactor";
		this.txtFactor.RootElement.PositionOffset = new System.Drawing.SizeF(0f, 0f);
		this.txtFactor.TextChanged += new System.EventHandler(txtFactor_TextChanged);
		this.txtFactor.Click += new System.EventHandler(txtFactor_Click);
		this.txtFactor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtFactor_KeyPress);
		((Telerik.WinControls.UI.RadTextBoxControlElement)this.txtFactor.GetChildAt(0)).BorderWidth = 0f;
		((Telerik.WinControls.UI.TextBoxViewElement)this.txtFactor.GetChildAt(0).GetChildAt(0)).PositionOffset = new System.Drawing.SizeF(5f, 5f);
		this.txtSample.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
		resources.ApplyResources(this.txtSample, "txtSample");
		this.txtSample.ForeColor = System.Drawing.SystemColors.ControlText;
		this.txtSample.Name = "txtSample";
		this.txtSample.RootElement.PositionOffset = new System.Drawing.SizeF(0f, 0f);
		((Telerik.WinControls.UI.RadTextBoxControlElement)this.txtSample.GetChildAt(0)).BorderWidth = 0f;
		((Telerik.WinControls.UI.TextBoxViewElement)this.txtSample.GetChildAt(0).GetChildAt(0)).PositionOffset = new System.Drawing.SizeF(5f, 5f);
		this.btnRemove.BackColor = System.Drawing.Color.Transparent;
		resources.ApplyResources(this.btnRemove, "btnRemove");
		this.btnRemove.Name = "btnRemove";
		this.btnRemove.TabStop = false;
		this.btnRemove.Click += new System.EventHandler(btnRemove_Click);
		this.ddlUOMs.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ddlUOMs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		resources.ApplyResources(this.ddlUOMs, "ddlUOMs");
		this.ddlUOMs.ForeColor = System.Drawing.SystemColors.WindowText;
		this.ddlUOMs.Items.AddRange(new object[2]
		{
			resources.GetString("ddlUOMs.Items"),
			resources.GetString("ddlUOMs.Items1")
		});
		this.ddlUOMs.Name = "ddlUOMs";
		this.ddlUOMs.SelectedIndexChanged += new System.EventHandler(ddlUOMs_SelectedIndexChanged);
		this.ddlOperator.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ddlOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		resources.ApplyResources(this.ddlOperator, "ddlOperator");
		this.ddlOperator.ForeColor = System.Drawing.SystemColors.WindowText;
		this.ddlOperator.Items.AddRange(new object[2]
		{
			resources.GetString("ddlOperator.Items"),
			resources.GetString("ddlOperator.Items1")
		});
		this.ddlOperator.Name = "ddlOperator";
		this.ddlOperator.SelectedIndexChanged += new System.EventHandler(ddlOperator_SelectedIndexChanged);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		this.BackColor = System.Drawing.Color.FromArgb(35, 39, 56);
		base.Controls.Add(this.ddlUOMs);
		base.Controls.Add(this.btnRemove);
		base.Controls.Add(this.ddlOperator);
		base.Controls.Add(this.txtSample);
		base.Controls.Add(this.txtFactor);
		resources.ApplyResources(this, "$this");
		base.Name = "UOMConversionBodyControl";
		base.Load += new System.EventHandler(UOMConversionBodyControl_Load);
		((System.ComponentModel.ISupportInitialize)this.txtFactor).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSample).EndInit();
		((System.ComponentModel.ISupportInitialize)this.btnRemove).EndInit();
		base.ResumeLayout(false);
	}
}
