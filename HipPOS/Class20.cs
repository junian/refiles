using System;
using System.ComponentModel;
using System.Drawing;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

internal class Class20 : RadDropDownList
{
	private Windows8Theme windows8Theme_0;

	public Class20()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		method_3();
		base.ListElement.ItemHeight = 28;
		base.ListElement.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		base.EnableKineticScrolling = true;
		base.VisualListItemFormatting += Class20_VisualListItemFormatting;
		((BorderPrimitive)base.DropDownListElement.Children[0]).Visibility = ElementVisibility.Collapsed;
		ThemeName = windows8Theme_0.ThemeName;
		DropDownStyle = RadDropDownStyle.DropDownList;
		base.DropDownListElement.ListElement.EnableKineticScrolling = true;
		base.DropDownListElement.ListElement.VScrollBar.MinSize = new Size(30, base.DropDownListElement.ListElement.VScrollBar.Size.Height);
	}

	private void Class20_VisualListItemFormatting(object sender, VisualItemFormattingEventArgs e)
	{
		e.VisualItem.MouseEnter -= method_2;
		e.VisualItem.MouseLeave -= method_1;
		e.VisualItem.MouseEnter += method_2;
		e.VisualItem.MouseLeave += method_1;
		e.VisualItem.Click += method_0;
		if (e.VisualItem.Selected)
		{
			e.VisualItem.BackColor = Color.Transparent;
			e.VisualItem.BorderColor = Color.Transparent;
		}
		else
		{
			e.VisualItem.ResetValue(VisualElement.BackColorProperty, ValueResetFlags.Local);
			e.VisualItem.ResetValue(LightVisualElement.BorderColorProperty, ValueResetFlags.Local);
		}
	}

	private void method_0(object sender, EventArgs e)
	{
		(sender as RadListVisualItem).Select();
	}

	private void method_1(object sender, EventArgs e)
	{
		RadListVisualItem radListVisualItem = sender as RadListVisualItem;
		if (radListVisualItem != null && !radListVisualItem.Selected)
		{
			radListVisualItem.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
			radListVisualItem.ResetValue(VisualElement.ForeColorProperty, ValueResetFlags.Local);
			radListVisualItem.ResetValue(VisualElement.BackColorProperty, ValueResetFlags.Local);
		}
		if (radListVisualItem.Selected)
		{
			radListVisualItem.BackColor = Color.Transparent;
			radListVisualItem.BorderColor = Color.Transparent;
			radListVisualItem.ForeColor = Color.Black;
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		if (sender is RadListVisualItem radListVisualItem)
		{
			radListVisualItem.GradientStyle = GradientStyles.Solid;
			radListVisualItem.BackColor = Color.FromArgb(1, 110, 211);
			radListVisualItem.ForeColor = Color.White;
		}
	}

	private void method_3()
	{
		windows8Theme_0 = new Windows8Theme();
		((ISupportInitialize)this).BeginInit();
		SuspendLayout();
		((ISupportInitialize)this).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
