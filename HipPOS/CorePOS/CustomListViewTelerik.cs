using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class CustomListViewTelerik : RadListView
{
	public CustomListViewTelerik()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		ViewType = ListViewType.DetailsView;
		AllowArbitraryItemHeight = true;
		ShowGridLines = true;
		ShowColumnHeaders = false;
		FullRowSelect = true;
		base.EnableKineticScrolling = true;
		base.AllowRemove = false;
		AllowEdit = false;
		CellCreating += CustomListViewTelerik_CellCreating;
		base.VisualItemFormatting += CustomListViewTelerik_VisualItemFormatting;
	}

	private void CustomListViewTelerik_CellCreating(object sender, ListViewCellElementCreatingEventArgs e)
	{
		e.CellElement.TextWrap = true;
		e.CellElement.BorderColor = Color.FromArgb(235, 235, 235);
		e.CellElement.BorderWidth = 1f;
	}

	private void CustomListViewTelerik_VisualItemFormatting(object sender, ListViewVisualItemEventArgs e)
	{
		e.VisualItem.GradientStyle = GradientStyles.Solid;
		e.VisualItem.Padding = new Padding(0, 5, 0, 5);
		if (e.VisualItem is BaseListViewGroupVisualItem)
		{
			e.VisualItem.DrawImage = false;
			e.VisualItem.DrawBackgroundImage = false;
			e.VisualItem.ShowKeyboardCues = false;
			e.VisualItem.DisableHTMLRendering = true;
			e.VisualItem.ShowHorizontalLine = false;
		}
		else if (e.VisualItem.Selected)
		{
			e.VisualItem.BackColor = Color.FromArgb(1, 110, 211);
			e.VisualItem.ForeColor = Color.White;
		}
		else
		{
			e.VisualItem.ResetValue(VisualElement.ForeColorProperty, ValueResetFlags.Style);
			e.VisualItem.ResetValue(VisualElement.BackColorProperty, ValueResetFlags.Style);
		}
	}
}
