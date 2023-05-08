namespace CorePOS;

public static class CustomMessageBox
{
	public static void Show(string Message, string Title = null, string Buttons = "Ok")
	{
		new frmMessageBox(Message, Title, Buttons).Show();
	}
}
