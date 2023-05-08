using System.Drawing;
using System.Windows.Forms;

namespace CorePOS;

public class FadeLabel
{
	public static void Show(string message, Label label, Timer timer, ref int fade)
	{
		label.Text = message;
		label.BackColor = Color.FromArgb(242, 182, 51);
		label.ForeColor = Color.FromArgb(255, 255, 255);
		label.Visible = true;
		timer.Enabled = true;
		fade = 255;
	}

	public static void Tick(Label label, Timer timer, ref int fade)
	{
		fade = ((fade - 5 >= 0) ? (fade - 5) : 0);
		int r = label.BackColor.R;
		int b = label.BackColor.B;
		int g = label.BackColor.G;
		int num = ((label.ForeColor.R - 5 < 35) ? 35 : (label.ForeColor.R - 5));
		int num2 = ((label.ForeColor.B - 5 < 39) ? 39 : (label.ForeColor.B - 5));
		int num3 = ((label.ForeColor.G - 5 < 56) ? 56 : (label.ForeColor.G - 5));
		if (num != 35 && num2 != 39 && num3 != 56)
		{
			label.ForeColor = Color.FromArgb(fade, num, num3, num2);
		}
		else
		{
			label.ForeColor = Color.FromArgb(35, 39, 56);
		}
		label.BackColor = Color.FromArgb(fade, r, g, b);
		if (fade == 0)
		{
			fade = 255;
			timer.Stop();
			label.BackColor = Color.FromArgb(35, 39, 56);
			label.ForeColor = Color.FromArgb(35, 39, 56);
			label.Text = "";
		}
	}

	public FadeLabel()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
	}
}
