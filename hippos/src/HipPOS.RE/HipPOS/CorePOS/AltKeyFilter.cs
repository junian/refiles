using System.Windows.Forms;

namespace CorePOS;

public class AltKeyFilter : IMessageFilter
{
	public bool PreFilterMessage(ref Message m)
	{
		if (m.Msg == 260)
		{
			return ((int)m.LParam & 0x20000000) != 0;
		}
		return false;
	}

	public AltKeyFilter()
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
	}
}
