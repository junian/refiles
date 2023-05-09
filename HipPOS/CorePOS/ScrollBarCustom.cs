using System.Drawing;
using System.Windows.Forms;

namespace CorePOS;

public class ScrollBarCustom : VScrollBar
{
	private Control control_0;

	public ScrollBarCustom(Control control, int width, int height)
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		method_2();
		base.Size = new Size(width, height);
		control_0 = control;
		base.Location = new Point(control.Right - width, control.Location.Y);
		base.Scroll += ScrollBarCustom_Scroll;
		control.MouseWheel += method_0;
		if (control.Parent != null)
		{
			control.Parent.Controls.Add(this);
		}
		base.Name = "customVScrollBar1";
		base.Visible = true;
		BringToFront();
		method_1();
	}

	private void ScrollBarCustom_Scroll(object sender, ScrollEventArgs e)
	{
		method_1();
	}

	private void method_0(object sender, MouseEventArgs e)
	{
		int num = 1;
		if (control_0 is Panel || control_0 is FlowLayoutPanel)
		{
			num = 5;
		}
		if (e.Delta > 0)
		{
			int num2 = base.Value - num;
			if (base.Minimum <= num2 && base.Maximum >= num2)
			{
				base.Value -= num;
			}
		}
		else
		{
			int num3 = base.Value + num;
			if (base.Minimum <= num3 && base.Maximum >= num3)
			{
				base.Value += num;
			}
		}
		method_1();
	}

	private void method_1()
	{
		if (control_0 is ListView)
		{
			ListView listView = control_0 as ListView;
			if (listView.Items.Count > 0)
			{
				listView.TopItem = listView.Items[base.Value];
			}
			base.Minimum = 0;
			base.Maximum = listView.Items.Count;
		}
		else if (control_0 is DataGridView)
		{
			DataGridView dataGridView = control_0 as DataGridView;
			if (dataGridView.Rows.Count > 0)
			{
				if (base.Maximum > base.Value)
				{
					dataGridView.FirstDisplayedScrollingRowIndex = base.Value;
				}
				base.Minimum = 0;
				base.Maximum = dataGridView.Rows.Count;
			}
		}
		else if (control_0 is Panel)
		{
			Panel panel = control_0 as Panel;
			base.Minimum = panel.VerticalScroll.Minimum;
			base.Maximum = panel.VerticalScroll.Maximum;
			base.LargeChange = panel.VerticalScroll.LargeChange;
			panel.VerticalScroll.Value = base.Value;
		}
		else if (control_0 is FlowLayoutPanel)
		{
			FlowLayoutPanel flowLayoutPanel = control_0 as FlowLayoutPanel;
			base.Minimum = flowLayoutPanel.VerticalScroll.Minimum;
			base.Maximum = flowLayoutPanel.VerticalScroll.Maximum;
			base.LargeChange = flowLayoutPanel.VerticalScroll.LargeChange;
			flowLayoutPanel.VerticalScroll.Value = base.Value;
		}
	}

	private void method_2()
	{
	}
}
