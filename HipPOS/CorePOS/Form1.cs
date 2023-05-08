using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace CorePOS;

public class Form1 : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public int caretIndex;

		public _003C_003Ec__DisplayClass4_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CradAutoCompleteBox1_KeyPress_003Eb__0(TextBlockElement x)
		{
			if (caretIndex >= x.Offset)
			{
				return caretIndex <= x.Offset + x.Length;
			}
			return false;
		}
	}

	private List<string> list_2;

	private List<string> list_3;

	private IContainer icontainer_1;

	private RadAutoCompleteBox radAutoCompleteBox1;

	private Windows8Theme windows8Theme_0;

	private ComboBox comboBox1;

	public Form1()
	{
		Class26.Ggkj0JxzN9YmC();
		list_2 = new List<string>();
		list_3 = new List<string>();
		base._002Ector();
		InitializeComponent_1();
		radAutoCompleteBox1.EnableTheming = true;
		radAutoCompleteBox1.ThemeClassName = windows8Theme_0.ThemeName;
		radAutoCompleteBox1.ShowRemoveButton = false;
		radAutoCompleteBox1.ShowClearButton = false;
		radAutoCompleteBox1.TextBlockFormatting += radAutoCompleteBox1_TextBlockFormatting;
		list_2.Add("TEST1");
		list_2.Add("Marco");
		list_2.Add("Daren");
		list_3.Add("Jonathan");
		list_3.Add("Thien");
		list_3.Add("TEST2");
		radAutoCompleteBox1.AutoCompleteDataSource = list_2;
		radAutoCompleteBox1.KeyPress += radAutoCompleteBox1_KeyPress;
		radAutoCompleteBox1.ListElement.VisualItemFormatting += method_3;
		radAutoCompleteBox1.ListElement.AutoSizeItems = true;
		radAutoCompleteBox1.MaxDropDownItemCount = 10;
		radAutoCompleteBox1.DropDownMinSize = new Size(radAutoCompleteBox1.Width, 300);
		comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
	}

	private void radAutoCompleteBox1_TextChanged(object sender, EventArgs e)
	{
	}

	private void radAutoCompleteBox1_KeyPress(object sender, KeyPressEventArgs e)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.caretIndex = radAutoCompleteBox1.TextBoxElement.CaretIndex;
		TextBlockElement textBlockElement = radAutoCompleteBox1.TextBoxElement.ViewElement.Children.OfType<TextBlockElement>().LastOrDefault((TextBlockElement x) => CS_0024_003C_003E8__locals0.caretIndex >= x.Offset && CS_0024_003C_003E8__locals0.caretIndex <= x.Offset + x.Length);
		if (textBlockElement != null)
		{
			if ((textBlockElement.Text + e.KeyChar).ToUpper().Contains("JO"))
			{
				radAutoCompleteBox1.AutoCompleteDataSource = null;
				radAutoCompleteBox1.AutoCompleteMode = AutoCompleteMode.None;
				radAutoCompleteBox1.AutoCompleteDataSource = list_3;
				radAutoCompleteBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
			}
			else
			{
				radAutoCompleteBox1.AutoCompleteDataSource = null;
			}
		}
	}

	private void method_3(object sender, VisualItemFormattingEventArgs e)
	{
		e.VisualItem.Font = new Font(radAutoCompleteBox1.Font.Name, 28f, FontStyle.Regular);
	}

	private void radAutoCompleteBox1_TextBlockFormatting(object sender, TextBlockFormattingEventArgs e)
	{
		if (e.TextBlock is TokenizedTextBlockElement tokenizedTextBlockElement)
		{
			tokenizedTextBlockElement.BackColor = Color.White;
			tokenizedTextBlockElement.BorderColor = Color.White;
			tokenizedTextBlockElement.ForeColor = Color.Black;
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
		radAutoCompleteBox1 = new RadAutoCompleteBox();
		windows8Theme_0 = new Windows8Theme();
		comboBox1 = new ComboBox();
		((ISupportInitialize)radAutoCompleteBox1).BeginInit();
		SuspendLayout();
		radAutoCompleteBox1.Font = new Font("Microsoft Sans Serif", 32f);
		radAutoCompleteBox1.Location = new Point(92, 51);
		radAutoCompleteBox1.Name = "radAutoCompleteBox1";
		radAutoCompleteBox1.Size = new Size(502, 65);
		radAutoCompleteBox1.TabIndex = 0;
		radAutoCompleteBox1.Text = "Test";
		radAutoCompleteBox1.TextChanged += radAutoCompleteBox1_TextChanged;
		comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
		comboBox1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		comboBox1.FormattingEnabled = true;
		comboBox1.Items.AddRange(new object[4] { "Daren", "Marco", "Thien", "Jonathan" });
		comboBox1.Location = new Point(207, 277);
		comboBox1.Name = "comboBox1";
		comboBox1.Size = new Size(302, 33);
		comboBox1.TabIndex = 2;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(800, 450);
		base.Controls.Add(comboBox1);
		base.Controls.Add(radAutoCompleteBox1);
		base.Name = "Form1";
		base.Opacity = 1.0;
		Text = "Form1";
		((ISupportInitialize)radAutoCompleteBox1).EndInit();
		ResumeLayout(performLayout: false);
	}
}
