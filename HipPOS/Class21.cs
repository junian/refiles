using System.Drawing;
using System.Windows.Forms;

internal class Class21 : Label
{
	public TextFormatFlags textFormatFlags_0;

	protected override void OnPaint(PaintEventArgs e)
	{
		Point location = new Point(0, 0);
		string[] array = Text.Split('|');
		if (array.Length > 2)
		{
			Font font = Font;
			Font font2 = new Font(font, FontStyle.Bold | FontStyle.Strikeout);
			Size size = TextRenderer.MeasureText(array[0], font);
			Size size2 = TextRenderer.MeasureText(array[1], font2);
			Size size3 = TextRenderer.MeasureText(array[2], font);
			Rectangle bounds = new Rectangle(location, size);
			Rectangle bounds2 = new Rectangle(bounds.Right - 10, bounds.Top, size2.Width, size2.Height);
			Rectangle bounds3 = new Rectangle(bounds2.Right - 10, bounds2.Top, size3.Width, size3.Height);
			TextRenderer.DrawText(e.Graphics, array[0], font, bounds, ForeColor);
			TextRenderer.DrawText(e.Graphics, array[1], font2, bounds2, ForeColor);
			TextRenderer.DrawText(e.Graphics, array[2], font, bounds3, ForeColor);
		}
		else
		{
			base.OnPaint(e);
		}
	}

	public Class21()
	{
		Class26.Ggkj0JxzN9YmC();
		textFormatFlags_0 = TextFormatFlags.Right;
		base._002Ector();
	}
}
