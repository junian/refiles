using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace CorePOS;

public class RoundButton : Button
{
	private Container container_0;

	private Pen JguFaCsIhWu;

	private SolidBrush solidBrush_0;

	private SolidBrush solidBrush_1;

	private Point point_0;

	private Color color_0;

	[CompilerGenerated]
	private string string_0;

	public string Status
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

	public Color HoverColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	public RoundButton()
	{
		Class26.Ggkj0JxzN9YmC();
		point_0 = new Point(0, 0);
		color_0 = Color.FromKnownColor(KnownColor.ControlLight);
		// base._002Ector();
		method_0();
		JguFaCsIhWu = new Pen(BackColor);
		solidBrush_1 = new SolidBrush(BackColor);
		solidBrush_0 = new SolidBrush(ForeColor);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && container_0 != null)
		{
			container_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_0()
	{
		base.ForeColorChanged += RoundButton_ForeColorChanged;
		base.MouseEnter += RoundButton_MouseEnter;
		base.BackColorChanged += RoundButton_BackColorChanged;
		base.MouseLeave += RoundButton_MouseLeave;
		base.MouseDown += RoundButton_MouseDown;
	}

	protected override void OnPaint(PaintEventArgs pe)
	{
		Graphics graphics = pe.Graphics;
		method_1(graphics);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddEllipse(0, 0, base.ClientSize.Width, base.ClientSize.Height);
		base.Region = new Region(graphicsPath);
	}

	private void method_1(Graphics graphics_0)
	{
		graphics_0.DrawEllipse(JguFaCsIhWu, 0, 0, base.ClientSize.Width, base.ClientSize.Height);
		graphics_0.FillEllipse(solidBrush_1, 0, 0, base.ClientSize.Width, base.ClientSize.Height);
		method_2(graphics_0);
	}

	private void method_2(Graphics graphics_0)
	{
		TextRenderer.DrawText(graphics_0, Text, Font, base.ClientRectangle, ForeColor, Color.Transparent);
	}

	private void RoundButton_MouseEnter(object sender, EventArgs e)
	{
		if (base.Tag != null)
		{
			if (base.Tag.ToString().Split(';')[1] == "selected")
			{
				JguFaCsIhWu.Color = Color.FromArgb(84, 156, 216);
				solidBrush_1.Color = Color.FromArgb(84, 156, 216);
			}
			else
			{
				JguFaCsIhWu.Color = color_0;
				solidBrush_1.Color = color_0;
			}
			Invalidate();
		}
	}

	private void RoundButton_MouseLeave(object sender, EventArgs e)
	{
		if (base.Tag != null)
		{
			JguFaCsIhWu.Color = BackColor;
			solidBrush_1.Color = BackColor;
			Invalidate();
		}
	}

	private void RoundButton_BackColorChanged(object sender, EventArgs e)
	{
		JguFaCsIhWu.Color = BackColor;
		solidBrush_1.Color = BackColor;
	}

	private void RoundButton_ForeColorChanged(object sender, EventArgs e)
	{
		solidBrush_0.Color = ForeColor;
	}

	private void RoundButton_MouseDown(object sender, EventArgs e)
	{
		if (base.Tag != null)
		{
			if (base.Tag.ToString().Split(';')[1] == "selected")
			{
				JguFaCsIhWu.Color = Color.FromArgb(145, 173, 197);
				solidBrush_1.Color = Color.FromArgb(145, 173, 197);
			}
			Invalidate();
		}
	}
}
