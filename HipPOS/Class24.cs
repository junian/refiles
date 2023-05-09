using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

internal class Class24 : Label
{
	[CompilerGenerated]
	private string string_0;

	[SpecialName]
	[CompilerGenerated]
	public string method_0()
	{
		return string_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public void method_1(string string_1)
	{
		string_0 = string_1;
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		int num = base.Padding.Left + base.Margin.Left;
		int num2 = 0;
		if (TextAlign == ContentAlignment.BottomCenter || TextAlign == ContentAlignment.TopCenter || TextAlign == ContentAlignment.MiddleCenter)
		{
			if (TextAlign == ContentAlignment.MiddleCenter)
			{
				num += (base.Width - (int)Font.Size - 2) / 2;
			}
			num2 = (base.Height - method_0().Length * (int)(Font.Size - 1f)) / 2;
		}
		Brush brush = new SolidBrush(ForeColor);
		e.Graphics.TranslateTransform(num, base.Height - num2);
		e.Graphics.RotateTransform(-90f);
		e.Graphics.DrawString(method_0(), Font, brush, 0f, 0f);
		base.OnPaint(e);
	}

	public Class24()
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
	}
}
