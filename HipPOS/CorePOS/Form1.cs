using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace CorePOS;

public class Form1 : frmMasterForm
{
	private List<string> list_2;

	private List<string> list_3;

	private IContainer icontainer_1;

	private RadAutoCompleteBox radAutoCompleteBox1;

	private Windows8Theme windows8Theme_0;

	private ComboBox comboBox1;

	public Form1()
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		Class26.Ggkj0JxzN9YmC();
		list_2 = new List<string>();
		list_3 = new List<string>();
		base._002Ector();
		InitializeComponent_1();
		((RadControl)radAutoCompleteBox1).set_EnableTheming(true);
		((RadControl)radAutoCompleteBox1).set_ThemeClassName(((RadThemeComponentBase)windows8Theme_0).get_ThemeName());
		radAutoCompleteBox1.set_ShowRemoveButton(false);
		((RadTextBoxControl)radAutoCompleteBox1).set_ShowClearButton(false);
		((RadTextBoxControl)radAutoCompleteBox1).add_TextBlockFormatting(new TextBlockFormattingEventHandler(radAutoCompleteBox1_TextBlockFormatting));
		list_2.Add("TEST1");
		list_2.Add("Marco");
		list_2.Add("Daren");
		list_3.Add("Jonathan");
		list_3.Add("Thien");
		list_3.Add("TEST2");
		((RadTextBoxControl)radAutoCompleteBox1).set_AutoCompleteDataSource((object)list_2);
		((Control)(object)radAutoCompleteBox1).KeyPress += radAutoCompleteBox1_KeyPress;
		((RadListElement)((RadTextBoxControl)radAutoCompleteBox1).get_ListElement()).add_VisualItemFormatting(new VisualListItemFormattingEventHandler(method_3));
		((VirtualizedScrollPanel<RadListDataItem, RadListVisualItem>)(object)((RadTextBoxControl)radAutoCompleteBox1).get_ListElement()).set_AutoSizeItems(true);
		((RadTextBoxControl)radAutoCompleteBox1).set_MaxDropDownItemCount(10);
		((RadTextBoxControl)radAutoCompleteBox1).set_DropDownMinSize(new Size(((Control)(object)radAutoCompleteBox1).Width, 300));
		comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
	}

	private void radAutoCompleteBox1_TextChanged(object sender, EventArgs e)
	{
	}

	private void radAutoCompleteBox1_KeyPress(object sender, KeyPressEventArgs e)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.caretIndex = ((RadTextBoxControl)radAutoCompleteBox1).get_TextBoxElement().get_CaretIndex();
		TextBlockElement val = ((IEnumerable)((RadElement)((ScrollViewElement<TextBoxViewElement>)(object)((RadTextBoxControl)radAutoCompleteBox1).get_TextBoxElement()).get_ViewElement()).get_Children()).OfType<TextBlockElement>().LastOrDefault((TextBlockElement x) => CS_0024_003C_003E8__locals0.caretIndex >= x.get_Offset() && CS_0024_003C_003E8__locals0.caretIndex <= x.get_Offset() + x.get_Length());
		if (val != null)
		{
			if ((val.get_Text() + e.KeyChar).ToUpper().Contains("JO"))
			{
				((RadTextBoxControl)radAutoCompleteBox1).set_AutoCompleteDataSource((object)null);
				((RadTextBoxControl)radAutoCompleteBox1).set_AutoCompleteMode(AutoCompleteMode.None);
				((RadTextBoxControl)radAutoCompleteBox1).set_AutoCompleteDataSource((object)list_3);
				((RadTextBoxControl)radAutoCompleteBox1).set_AutoCompleteMode(AutoCompleteMode.Suggest);
			}
			else
			{
				((RadTextBoxControl)radAutoCompleteBox1).set_AutoCompleteDataSource((object)null);
			}
		}
	}

	private void method_3(object sender, VisualItemFormattingEventArgs e)
	{
		((VisualElement)e.get_VisualItem()).set_Font(new Font(((Control)(object)radAutoCompleteBox1).Font.Name, 28f, FontStyle.Regular));
	}

	private void radAutoCompleteBox1_TextBlockFormatting(object sender, TextBlockFormattingEventArgs e)
	{
		ITextBlock textBlock = e.get_TextBlock();
		TokenizedTextBlockElement val = (TokenizedTextBlockElement)(object)((textBlock is TokenizedTextBlockElement) ? textBlock : null);
		if (val != null)
		{
			((VisualElement)val).set_BackColor(Color.White);
			((UIItemBase)val).set_BorderColor(Color.White);
			((VisualElement)val).set_ForeColor(Color.Black);
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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		radAutoCompleteBox1 = new RadAutoCompleteBox();
		windows8Theme_0 = new Windows8Theme();
		comboBox1 = new ComboBox();
		((ISupportInitialize)radAutoCompleteBox1).BeginInit();
		SuspendLayout();
		((Control)(object)radAutoCompleteBox1).Font = new Font("Microsoft Sans Serif", 32f);
		((Control)(object)radAutoCompleteBox1).Location = new Point(92, 51);
		((Control)(object)radAutoCompleteBox1).Name = "radAutoCompleteBox1";
		((Control)(object)radAutoCompleteBox1).Size = new Size(502, 65);
		((Control)(object)radAutoCompleteBox1).TabIndex = 0;
		((Control)(object)radAutoCompleteBox1).Text = "Test";
		((Control)(object)radAutoCompleteBox1).TextChanged += radAutoCompleteBox1_TextChanged;
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
		base.Controls.Add((Control)(object)radAutoCompleteBox1);
		base.Name = "Form1";
		base.Opacity = 1.0;
		Text = "Form1";
		((ISupportInitialize)radAutoCompleteBox1).EndInit();
		ResumeLayout(performLayout: false);
	}
}
