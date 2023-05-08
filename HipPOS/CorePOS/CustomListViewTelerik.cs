using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class CustomListViewTelerik : RadListView
{
	public CustomListViewTelerik()
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		Class26.Ggkj0JxzN9YmC();
		((RadListView)this)._002Ector();
		((RadListView)this).set_ViewType((ListViewType)2);
		((RadListView)this).set_AllowArbitraryItemHeight(true);
		((RadListView)this).set_ShowGridLines(true);
		((RadListView)this).set_ShowColumnHeaders(false);
		((RadListView)this).set_FullRowSelect(true);
		((RadListView)this).set_EnableKineticScrolling(true);
		((RadListView)this).set_AllowRemove(false);
		((RadListView)this).set_AllowEdit(false);
		((RadListView)this).add_CellCreating(new ListViewCellElementCreatingEventHandler(CustomListViewTelerik_CellCreating));
		((RadListView)this).add_VisualItemFormatting(new ListViewVisualItemEventHandler(CustomListViewTelerik_VisualItemFormatting));
	}

	private void CustomListViewTelerik_CellCreating(object sender, ListViewCellElementCreatingEventArgs e)
	{
		((LightVisualElement)e.get_CellElement()).set_TextWrap(true);
		((UIItemBase)e.get_CellElement()).set_BorderColor(Color.FromArgb(235, 235, 235));
		((UIItemBase)e.get_CellElement()).set_BorderWidth(1f);
	}

	private void CustomListViewTelerik_VisualItemFormatting(object sender, ListViewVisualItemEventArgs e)
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		((UIItemBase)e.get_VisualItem()).set_GradientStyle((GradientStyles)0);
		((RadElement)e.get_VisualItem()).set_Padding(new Padding(0, 5, 0, 5));
		if (e.get_VisualItem() is BaseListViewGroupVisualItem)
		{
			((LightVisualElement)e.get_VisualItem()).set_DrawImage(false);
			((LightVisualElement)e.get_VisualItem()).set_DrawBackgroundImage(false);
			((LightVisualElement)e.get_VisualItem()).set_ShowKeyboardCues(false);
			((LightVisualElement)e.get_VisualItem()).set_DisableHTMLRendering(true);
			((LightVisualElement)e.get_VisualItem()).set_ShowHorizontalLine(false);
		}
		else if (e.get_VisualItem().get_Selected())
		{
			((VisualElement)e.get_VisualItem()).set_BackColor(Color.FromArgb(1, 110, 211));
			((VisualElement)e.get_VisualItem()).set_ForeColor(Color.White);
		}
		else
		{
			((RadObject)e.get_VisualItem()).ResetValue(VisualElement.ForeColorProperty, (ValueResetFlags)8);
			((RadObject)e.get_VisualItem()).ResetValue(VisualElement.BackColorProperty, (ValueResetFlags)8);
		}
	}
}
