using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

internal class Class20 : RadDropDownList
{
	private Windows8Theme windows8Theme_0;

	public Class20()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		Class26.Ggkj0JxzN9YmC();
		((RadDropDownList)this)._002Ector();
		method_3();
		((RadDropDownList)this).get_ListElement().set_ItemHeight(28);
		((VisualElement)((RadDropDownList)this).get_ListElement()).set_Font(new Font("Microsoft Sans Serif", 12f, FontStyle.Bold));
		((RadDropDownList)this).set_EnableKineticScrolling(true);
		((RadDropDownList)this).add_VisualListItemFormatting(new VisualListItemFormattingEventHandler(Class20_VisualListItemFormatting));
		((RadElement)(BorderPrimitive)((RadElement)((RadDropDownList)this).get_DropDownListElement()).get_Children().get_Item(0)).set_Visibility((ElementVisibility)2);
		((RadControl)this).set_ThemeName(((RadThemeComponentBase)windows8Theme_0).get_ThemeName());
		((RadDropDownList)this).set_DropDownStyle((RadDropDownStyle)2);
		((PopupEditorElement)((RadDropDownList)this).get_DropDownListElement()).get_ListElement().set_EnableKineticScrolling(true);
		((RadElement)((ScrollViewElement<VirtualizedStackContainer<RadListDataItem>>)(object)((PopupEditorElement)((RadDropDownList)this).get_DropDownListElement()).get_ListElement()).get_VScrollBar()).set_MinSize(new Size(30, ((RadElement)((ScrollViewElement<VirtualizedStackContainer<RadListDataItem>>)(object)((PopupEditorElement)((RadDropDownList)this).get_DropDownListElement()).get_ListElement()).get_VScrollBar()).get_Size().Height));
	}

	private void Class20_VisualListItemFormatting(object sender, VisualItemFormattingEventArgs e)
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		((RadElement)e.get_VisualItem()).remove_MouseEnter((EventHandler)method_2);
		((RadElement)e.get_VisualItem()).remove_MouseLeave((EventHandler)method_1);
		((RadElement)e.get_VisualItem()).add_MouseEnter((EventHandler)method_2);
		((RadElement)e.get_VisualItem()).add_MouseLeave((EventHandler)method_1);
		((RadElement)e.get_VisualItem()).add_Click((EventHandler)method_0);
		if (e.get_VisualItem().get_Selected())
		{
			((VisualElement)e.get_VisualItem()).set_BackColor(Color.Transparent);
			((UIItemBase)e.get_VisualItem()).set_BorderColor(Color.Transparent);
		}
		else
		{
			((RadObject)e.get_VisualItem()).ResetValue(VisualElement.BackColorProperty, (ValueResetFlags)32);
			((RadObject)e.get_VisualItem()).ResetValue(LightVisualElement.BorderColorProperty, (ValueResetFlags)32);
		}
	}

	private void method_0(object sender, EventArgs e)
	{
		((RadItem)((sender is RadListVisualItem) ? sender : null)).Select();
	}

	private void method_1(object sender, EventArgs e)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		RadListVisualItem val = (RadListVisualItem)((sender is RadListVisualItem) ? sender : null);
		if (val != null && !val.get_Selected())
		{
			((RadObject)val).ResetValue(LightVisualElement.GradientStyleProperty, (ValueResetFlags)32);
			((RadObject)val).ResetValue(VisualElement.ForeColorProperty, (ValueResetFlags)32);
			((RadObject)val).ResetValue(VisualElement.BackColorProperty, (ValueResetFlags)32);
		}
		if (val.get_Selected())
		{
			((VisualElement)val).set_BackColor(Color.Transparent);
			((UIItemBase)val).set_BorderColor(Color.Transparent);
			((VisualElement)val).set_ForeColor(Color.Black);
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		RadListVisualItem val = (RadListVisualItem)((sender is RadListVisualItem) ? sender : null);
		if (val != null)
		{
			((UIItemBase)val).set_GradientStyle((GradientStyles)0);
			((VisualElement)val).set_BackColor(Color.FromArgb(1, 110, 211));
			((VisualElement)val).set_ForeColor(Color.White);
		}
	}

	private void method_3()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		windows8Theme_0 = new Windows8Theme();
		((ISupportInitialize)this).BeginInit();
		((Control)this).SuspendLayout();
		((ISupportInitialize)this).EndInit();
		((Control)this).ResumeLayout(performLayout: false);
		((Control)this).PerformLayout();
	}
}
