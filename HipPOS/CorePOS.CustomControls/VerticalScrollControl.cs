using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace CorePOS.CustomControls;

public class VerticalScrollControl : UserControl
{
	[CompilerGenerated]
	private Panel panel_0;

	[CompilerGenerated]
	private CustomListViewTelerik customListViewTelerik_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	[CompilerGenerated]
	private EventHandler eventHandler_1;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	private int int_2;

	private IContainer icontainer_0;

	internal Button btnPageUp;

	internal Button btnPageDown;

	internal Button btnDown;

	internal Button btnUp;

	private FlowLayoutPanel pnlButtons;

	public Panel ConnectedPanel
	{
		[CompilerGenerated]
		get
		{
			return panel_0;
		}
		[CompilerGenerated]
		set
		{
			panel_0 = value;
		}
	}

	public CustomListViewTelerik ConnectedRadListView
	{
		[CompilerGenerated]
		get
		{
			return customListViewTelerik_0;
		}
		[CompilerGenerated]
		set
		{
			customListViewTelerik_0 = value;
		}
	}

	public string ButtonStyle
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

	public EventHandler ButtonDownEventOverride
	{
		[CompilerGenerated]
		get
		{
			return eventHandler_0;
		}
		[CompilerGenerated]
		set
		{
			eventHandler_0 = value;
		}
	}

	public EventHandler ButtonLastEventOverride
	{
		[CompilerGenerated]
		get
		{
			return eventHandler_1;
		}
		[CompilerGenerated]
		set
		{
			eventHandler_1 = value;
		}
	}

	public int inputedHeight
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public int inputedWidth
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public VerticalScrollControl()
	{
		Class26.Ggkj0JxzN9YmC();
		int_2 = 120;
		base._002Ector();
		InitializeComponent();
		base.Height = 407;
		inputedHeight = 0;
		inputedWidth = 0;
		ButtonStyle = ScrollButtonStyle.FourButtons;
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		using Pen pen = new Pen(Color.Aqua);
		Size size = new Size(base.Width, base.Height);
		e.Graphics.DrawRectangle(pen, new Rectangle(base.Location, size));
	}

	private void VerticalScrollControl_Load(object sender, EventArgs e)
	{
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Expected O, but got Unknown
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		int num = 4;
		if (ButtonStyle == ScrollButtonStyle.TwoButtons)
		{
			Button button = btnPageUp;
			btnPageDown.Visible = false;
			button.Visible = false;
			num = 2;
		}
		int num2 = pnlButtons.Height / num;
		foreach (Button control in pnlButtons.Controls)
		{
			control.Height = num2;
		}
		if (ConnectedPanel != null)
		{
			base.Height = ConnectedPanel.Height;
		}
		if (ConnectedRadListView != null)
		{
			base.Height = ((Control)(object)ConnectedRadListView).Height;
		}
		if (inputedHeight > 0)
		{
			base.Height = inputedHeight;
		}
		int num3 = base.Height / num;
		btnPageUp.Height = num3;
		btnUp.Height = num3;
		btnDown.Height = num3;
		btnPageDown.Height = num3;
		btnPageUp.Location = new Point(0, 0);
		btnUp.Location = new Point(0, btnPageUp.Bottom + 1);
		btnDown.Location = new Point(0, btnUp.Bottom + 1);
		btnPageDown.Location = new Point(0, btnDown.Bottom + 1);
		if (ConnectedPanel != null)
		{
			EnableDisableButtonsByScrollPanel();
			ConnectedPanel.Scroll += method_0;
			ConnectedPanel.ControlAdded += method_1;
		}
		if (ConnectedRadListView != null)
		{
			EnableDisableButtonsByScrollListView();
			((RadListView)ConnectedRadListView).add_CurrentItemChanged(new ListViewItemEventHandler(method_2));
			((ScrollableControl)(object)ConnectedRadListView).Scroll += method_3;
			((RadListView)ConnectedRadListView).get_Items().add_CollectionChanged(new NotifyCollectionChangedEventHandler(method_4));
		}
		btnDown.Click += ButtonDownEventOverride;
		btnPageDown.Click += ButtonLastEventOverride;
	}

	public void RefreshSize()
	{
		int num = 4;
		if (ButtonStyle == ScrollButtonStyle.TwoButtons)
		{
			Button button = btnPageUp;
			btnPageDown.Visible = false;
			button.Visible = false;
			num = 2;
		}
		if (inputedHeight > 0)
		{
			base.Height = inputedHeight;
		}
		int num2 = base.Height / num;
		btnPageUp.Height = num2;
		btnUp.Height = num2;
		btnDown.Height = num2;
		btnPageDown.Height = num2;
		btnPageUp.Location = new Point(0, 0);
		btnUp.Location = new Point(0, btnPageUp.Bottom + 1);
		btnDown.Location = new Point(0, btnUp.Bottom + 1);
		btnPageDown.Location = new Point(0, btnDown.Bottom + 1);
	}

	private void method_0(object sender, ScrollEventArgs e)
	{
		EnableDisableButtonsByScrollPanel();
	}

	private void method_1(object sender, ControlEventArgs e)
	{
		EnableDisableButtonsByScrollPanel();
	}

	private void method_2(object sender, EventArgs e)
	{
		EnableDisableButtonsByScrollListView();
	}

	private void method_3(object sender, ScrollEventArgs e)
	{
		EnableDisableButtonsByScrollListView();
	}

	private void method_4(object sender, NotifyCollectionChangedEventArgs e)
	{
		EnableDisableButtonsByScrollListView();
	}

	public void EnableDisableButtonsByScrollPanel()
	{
		int value = ConnectedPanel.VerticalScroll.Value;
		int maximum = ConnectedPanel.VerticalScroll.Maximum;
		bool visible = ConnectedPanel.VerticalScroll.Visible;
		if (value == 0 && !visible)
		{
			btnPageUp.Enabled = false;
			btnUp.Enabled = false;
			btnDown.Enabled = false;
			btnPageDown.Enabled = false;
		}
		else if (value == 0 && visible)
		{
			btnPageUp.Enabled = false;
			btnUp.Enabled = false;
			btnDown.Enabled = true;
			btnPageDown.Enabled = true;
		}
		else if (value == maximum - ConnectedPanel.VerticalScroll.LargeChange + 1)
		{
			btnPageUp.Enabled = true;
			btnUp.Enabled = true;
			btnDown.Enabled = false;
			btnPageDown.Enabled = false;
		}
		else
		{
			btnPageUp.Enabled = true;
			btnUp.Enabled = true;
			btnDown.Enabled = true;
			btnPageDown.Enabled = true;
		}
	}

	public void EnableDisableButtonsByScrollListView()
	{
		if (ConnectedRadListView != null)
		{
			int value = ((ScrollViewElement<VirtualizedStackContainer<ListViewDataItem>>)(object)((RadListView)ConnectedRadListView).get_ListViewElement().get_ViewElement()).get_VScrollBar().get_Value();
			int maximum = ((ScrollViewElement<VirtualizedStackContainer<ListViewDataItem>>)(object)((RadListView)ConnectedRadListView).get_ListViewElement().get_ViewElement()).get_VScrollBar().get_Maximum();
			int largeChange = ((ScrollViewElement<VirtualizedStackContainer<ListViewDataItem>>)(object)((RadListView)ConnectedRadListView).get_ListViewElement().get_ViewElement()).get_VScrollBar().get_LargeChange();
			if (value == 0 && maximum + 1 == largeChange)
			{
				btnPageUp.Enabled = false;
				btnUp.Enabled = false;
				btnDown.Enabled = false;
				btnPageDown.Enabled = false;
			}
			else if (value == 0 && maximum + 1 > largeChange)
			{
				btnPageUp.Enabled = false;
				btnUp.Enabled = false;
				btnDown.Enabled = true;
				btnPageDown.Enabled = true;
			}
			else if (maximum - value + 1 <= largeChange)
			{
				btnPageUp.Enabled = true;
				btnUp.Enabled = true;
				btnDown.Enabled = false;
				btnPageDown.Enabled = false;
			}
			else
			{
				btnPageUp.Enabled = true;
				btnUp.Enabled = true;
				btnDown.Enabled = true;
				btnPageDown.Enabled = true;
			}
		}
	}

	private void btnPageUp_Click(object sender, EventArgs e)
	{
		if (ConnectedPanel != null)
		{
			ConnectedPanel.VerticalScroll.Value = ConnectedPanel.VerticalScroll.Minimum;
			ConnectedPanel.VerticalScroll.Value = ConnectedPanel.VerticalScroll.Minimum;
			EnableDisableButtonsByScrollPanel();
		}
		if (ConnectedRadListView != null && ((RadListView)ConnectedRadListView).get_Items().get_Count() > 0)
		{
			((VirtualizedScrollPanel<ListViewDataItem, BaseListViewVisualItem>)(object)((RadListView)ConnectedRadListView).get_ListViewElement().get_ViewElement()).get_Scroller().ScrollToItem(((RadListView)ConnectedRadListView).get_Items().get_Item(0));
			EnableDisableButtonsByScrollListView();
		}
	}

	private void btnPageDown_Click(object sender, EventArgs e)
	{
		if (ConnectedPanel != null)
		{
			ConnectedPanel.VerticalScroll.Value = ConnectedPanel.VerticalScroll.Maximum;
			ConnectedPanel.VerticalScroll.Value = ConnectedPanel.VerticalScroll.Maximum;
			EnableDisableButtonsByScrollPanel();
		}
		if (ConnectedRadListView != null && ((RadListView)ConnectedRadListView).get_Items().get_Count() > 0)
		{
			((VirtualizedScrollPanel<ListViewDataItem, BaseListViewVisualItem>)(object)((RadListView)ConnectedRadListView).get_ListViewElement().get_ViewElement()).get_Scroller().ScrollToItem(((IEnumerable<ListViewDataItem>)((RadListView)ConnectedRadListView).get_Items()).Last());
			EnableDisableButtonsByScrollListView();
		}
	}

	private void btnUp_Click(object sender, EventArgs e)
	{
		try
		{
			if (ConnectedPanel != null)
			{
				ConnectedPanel.VerticalScroll.Value = ConnectedPanel.VerticalScroll.Value - ConnectedPanel.Height / 2;
				ConnectedPanel.VerticalScroll.Value = ConnectedPanel.VerticalScroll.Value - ConnectedPanel.Height / 2;
				EnableDisableButtonsByScrollPanel();
			}
			if (ConnectedRadListView != null)
			{
				if (((ScrollViewElement<VirtualizedStackContainer<ListViewDataItem>>)(object)((RadListView)ConnectedRadListView).get_ListViewElement().get_ViewElement()).get_VScrollBar().get_Value() < int_2)
				{
					((ScrollViewElement<VirtualizedStackContainer<ListViewDataItem>>)(object)((RadListView)ConnectedRadListView).get_ListViewElement().get_ViewElement()).get_VScrollBar().set_Value(0);
				}
				else
				{
					RadScrollBarElement vScrollBar = ((ScrollViewElement<VirtualizedStackContainer<ListViewDataItem>>)(object)((RadListView)ConnectedRadListView).get_ListViewElement().get_ViewElement()).get_VScrollBar();
					vScrollBar.set_Value(vScrollBar.get_Value() - int_2);
				}
				EnableDisableButtonsByScrollListView();
			}
		}
		catch
		{
			if (ConnectedPanel != null)
			{
				ConnectedPanel.VerticalScroll.Value = ConnectedPanel.VerticalScroll.Minimum;
				ConnectedPanel.VerticalScroll.Value = ConnectedPanel.VerticalScroll.Minimum;
				EnableDisableButtonsByScrollPanel();
			}
		}
	}

	private void btnDown_Click(object sender, EventArgs e)
	{
		try
		{
			if (ConnectedPanel != null)
			{
				ConnectedPanel.VerticalScroll.Value = ConnectedPanel.VerticalScroll.Value + ConnectedPanel.Height / 2;
				ConnectedPanel.VerticalScroll.Value = ConnectedPanel.VerticalScroll.Value + ConnectedPanel.Height / 2;
				EnableDisableButtonsByScrollPanel();
			}
			if (ConnectedRadListView != null)
			{
				if (((RadListView)ConnectedRadListView).get_Items().get_Count() > 0 && ((ScrollViewElement<VirtualizedStackContainer<ListViewDataItem>>)(object)((RadListView)ConnectedRadListView).get_ListViewElement().get_ViewElement()).get_VScrollBar().get_Value() + int_2 < ((ScrollViewElement<VirtualizedStackContainer<ListViewDataItem>>)(object)((RadListView)ConnectedRadListView).get_ListViewElement().get_ViewElement()).get_VScrollBar().get_Maximum())
				{
					RadScrollBarElement vScrollBar = ((ScrollViewElement<VirtualizedStackContainer<ListViewDataItem>>)(object)((RadListView)ConnectedRadListView).get_ListViewElement().get_ViewElement()).get_VScrollBar();
					vScrollBar.set_Value(vScrollBar.get_Value() + int_2);
				}
				else
				{
					((VirtualizedScrollPanel<ListViewDataItem, BaseListViewVisualItem>)(object)((RadListView)ConnectedRadListView).get_ListViewElement().get_ViewElement()).get_Scroller().ScrollToItem(((IEnumerable<ListViewDataItem>)((RadListView)ConnectedRadListView).get_Items()).Last());
				}
				EnableDisableButtonsByScrollListView();
			}
		}
		catch
		{
			if (ConnectedPanel != null)
			{
				ConnectedPanel.VerticalScroll.Value = ConnectedPanel.VerticalScroll.Maximum;
				ConnectedPanel.VerticalScroll.Value = ConnectedPanel.VerticalScroll.Maximum;
				EnableDisableButtonsByScrollPanel();
			}
		}
	}

	private void btnUp_EnabledChanged(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (!button.Enabled)
		{
			button.Tag = button.BackColor;
			button.BackColor = Color.Gray;
		}
		else if (button.Tag != null)
		{
			button.BackColor = (Color)button.Tag;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.CustomControls.VerticalScrollControl));
		this.btnPageUp = new System.Windows.Forms.Button();
		this.btnPageDown = new System.Windows.Forms.Button();
		this.btnDown = new System.Windows.Forms.Button();
		this.btnUp = new System.Windows.Forms.Button();
		this.pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
		this.pnlButtons.SuspendLayout();
		base.SuspendLayout();
		this.btnPageUp.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.btnPageUp.BackColor = System.Drawing.Color.FromArgb(53, 152, 220);
		this.btnPageUp.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnPageUp.FlatAppearance.BorderSize = 0;
		this.btnPageUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnPageUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnPageUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
		this.btnPageUp.ForeColor = System.Drawing.Color.White;
		this.btnPageUp.Image = (System.Drawing.Image)resources.GetObject("btnPageUp.Image");
		this.btnPageUp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnPageUp.Location = new System.Drawing.Point(0, 0);
		this.btnPageUp.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
		this.btnPageUp.Name = "btnPageUp";
		this.btnPageUp.Size = new System.Drawing.Size(50, 50);
		this.btnPageUp.TabIndex = 240;
		this.btnPageUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		this.btnPageUp.UseVisualStyleBackColor = false;
		this.btnPageUp.EnabledChanged += new System.EventHandler(btnUp_EnabledChanged);
		this.btnPageUp.Click += new System.EventHandler(btnPageUp_Click);
		this.btnPageDown.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.btnPageDown.BackColor = System.Drawing.Color.FromArgb(53, 152, 220);
		this.btnPageDown.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnPageDown.FlatAppearance.BorderSize = 0;
		this.btnPageDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnPageDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnPageDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
		this.btnPageDown.ForeColor = System.Drawing.Color.White;
		this.btnPageDown.Image = (System.Drawing.Image)resources.GetObject("btnPageDown.Image");
		this.btnPageDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnPageDown.Location = new System.Drawing.Point(0, 153);
		this.btnPageDown.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
		this.btnPageDown.Name = "btnPageDown";
		this.btnPageDown.Size = new System.Drawing.Size(50, 50);
		this.btnPageDown.TabIndex = 243;
		this.btnPageDown.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		this.btnPageDown.UseVisualStyleBackColor = false;
		this.btnPageDown.EnabledChanged += new System.EventHandler(btnUp_EnabledChanged);
		this.btnPageDown.Click += new System.EventHandler(btnPageDown_Click);
		this.btnDown.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.btnDown.BackColor = System.Drawing.Color.FromArgb(53, 152, 220);
		this.btnDown.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnDown.FlatAppearance.BorderSize = 0;
		this.btnDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
		this.btnDown.ForeColor = System.Drawing.Color.White;
		this.btnDown.Image = (System.Drawing.Image)resources.GetObject("btnDown.Image");
		this.btnDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnDown.Location = new System.Drawing.Point(0, 102);
		this.btnDown.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
		this.btnDown.Name = "btnDown";
		this.btnDown.Size = new System.Drawing.Size(50, 50);
		this.btnDown.TabIndex = 242;
		this.btnDown.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		this.btnDown.UseVisualStyleBackColor = false;
		this.btnDown.EnabledChanged += new System.EventHandler(btnUp_EnabledChanged);
		this.btnDown.Click += new System.EventHandler(btnDown_Click);
		this.btnUp.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.btnUp.BackColor = System.Drawing.Color.FromArgb(53, 152, 220);
		this.btnUp.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnUp.FlatAppearance.BorderSize = 0;
		this.btnUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
		this.btnUp.ForeColor = System.Drawing.Color.White;
		this.btnUp.Image = (System.Drawing.Image)resources.GetObject("btnUp.Image");
		this.btnUp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnUp.Location = new System.Drawing.Point(0, 51);
		this.btnUp.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
		this.btnUp.Name = "btnUp";
		this.btnUp.Size = new System.Drawing.Size(50, 50);
		this.btnUp.TabIndex = 241;
		this.btnUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		this.btnUp.UseVisualStyleBackColor = false;
		this.btnUp.EnabledChanged += new System.EventHandler(btnUp_EnabledChanged);
		this.btnUp.Click += new System.EventHandler(btnUp_Click);
		this.pnlButtons.AllowDrop = true;
		this.pnlButtons.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
		this.pnlButtons.BackColor = System.Drawing.Color.Transparent;
		this.pnlButtons.Controls.Add(this.btnPageUp);
		this.pnlButtons.Controls.Add(this.btnUp);
		this.pnlButtons.Controls.Add(this.btnDown);
		this.pnlButtons.Controls.Add(this.btnPageDown);
		this.pnlButtons.Location = new System.Drawing.Point(0, 1);
		this.pnlButtons.Margin = new System.Windows.Forms.Padding(0);
		this.pnlButtons.Name = "pnlButtons";
		this.pnlButtons.Size = new System.Drawing.Size(50, 100);
		this.pnlButtons.TabIndex = 244;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.Transparent;
		base.Controls.Add(this.pnlButtons);
		this.MaximumSize = new System.Drawing.Size(50, 2000);
		this.MinimumSize = new System.Drawing.Size(50, 100);
		base.Name = "VerticalScrollControl";
		base.Size = new System.Drawing.Size(50, 100);
		base.Load += new System.EventHandler(VerticalScrollControl_Load);
		this.pnlButtons.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
