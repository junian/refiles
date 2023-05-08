using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace CorePOS;

public class CustomPager : UserControl
{
	[CompilerGenerated]
	private EventHandler eventHandler_0;

	public int rowsPerPage;

	public int currentPage;

	public int lastPage;

	private int int_0;

	private int int_1;

	private IContainer icontainer_0;

	private TableLayoutPanel tableLayoutPanel1;

	private FlowLayoutPanel pnlPager;

	public EventHandler PagerButton_Click
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

	public CustomPager()
	{
		Class26.Ggkj0JxzN9YmC();
		rowsPerPage = 20;
		int_0 = 35;
		int_1 = 50;
		base._002Ector();
		InitializeComponent();
	}

	public void AddPagerButtons()
	{
		int_0 = (int)((double)base.Height * 0.75);
		int_1 = (int)((double)int_0 * 1.5);
		pnlPager.Controls.Clear();
		if (lastPage <= 10)
		{
			for (int i = 0; i < lastPage; i++)
			{
				if (currentPage == i)
				{
					CreateSinglePagerButton((i + 1).ToString(), isCurrentPage: true);
				}
				else
				{
					CreateSinglePagerButton((i + 1).ToString());
				}
			}
			return;
		}
		if (currentPage > 3)
		{
			CreateSinglePagerButton("<<");
		}
		if (currentPage > 1)
		{
			CreateSinglePagerButton("<");
		}
		int num = 5;
		int num2 = currentPage - 2;
		num2 = ((num2 >= 0) ? num2 : 0);
		for (int j = 0; j < lastPage; j++)
		{
			if (num2 <= j && num2 + num > j)
			{
				if (currentPage == j)
				{
					CreateSinglePagerButton((j + 1).ToString(), isCurrentPage: true);
				}
				else
				{
					CreateSinglePagerButton((j + 1).ToString());
				}
			}
		}
		if (currentPage < lastPage - 1)
		{
			CreateSinglePagerButton(">");
		}
		if (currentPage < lastPage - 2)
		{
			CreateSinglePagerButton(">>");
		}
	}

	public void CreateSinglePagerButton(string text, bool isCurrentPage = false)
	{
		Button button = new Button();
		button.Text = text;
		button.TextAlign = ContentAlignment.MiddleCenter;
		button.FlatStyle = FlatStyle.Flat;
		button.Size = new Size(int_1, int_0);
		button.BackColor = (isCurrentPage ? Color.FromArgb(80, 203, 116) : Color.FromArgb(77, 174, 225));
		button.ForeColor = Color.White;
		button.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		button.Click += PagerButton_Click.Invoke;
		button.Margin = new Padding(10, 0, 10, 0);
		pnlPager.Controls.Add(button);
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
		this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.pnlPager = new System.Windows.Forms.FlowLayoutPanel();
		this.tableLayoutPanel1.SuspendLayout();
		base.SuspendLayout();
		this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(35, 39, 56);
		this.tableLayoutPanel1.ColumnCount = 1;
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel1.Controls.Add(this.pnlPager, 0, 0);
		this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
		this.tableLayoutPanel1.Name = "tableLayoutPanel1";
		this.tableLayoutPanel1.RowCount = 1;
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel1.Size = new System.Drawing.Size(1020, 60);
		this.tableLayoutPanel1.TabIndex = 37;
		this.pnlPager.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
		this.pnlPager.AutoSize = true;
		this.pnlPager.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this.pnlPager.BackColor = System.Drawing.Color.FromArgb(35, 39, 56);
		this.pnlPager.Location = new System.Drawing.Point(505, 3);
		this.pnlPager.Name = "pnlPager";
		this.pnlPager.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
		this.pnlPager.Size = new System.Drawing.Size(10, 54);
		this.pnlPager.TabIndex = 221;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(35, 39, 56);
		base.Controls.Add(this.tableLayoutPanel1);
		base.Name = "CustomPager";
		base.Size = new System.Drawing.Size(1021, 62);
		this.tableLayoutPanel1.ResumeLayout(false);
		this.tableLayoutPanel1.PerformLayout();
		base.ResumeLayout(false);
	}
}
