using System.Windows.Forms;

namespace CorePOS;

public class BufferedPanel : Panel
{
	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams obj = base.CreateParams;
			obj.ExStyle |= 33554432;
			return obj;
		}
	}

	public BufferedPanel()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		DoubleBuffered = true;
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, value: true);
	}
}
