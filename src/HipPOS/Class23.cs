using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CorePOS;

internal static class Class23
{
	[STAThread]
	private static void Main()
	{
		if (!Debugger.IsAttached)
		{
			Application.ThreadException += smethod_0;
		}
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Class26.Ggkj0JxzN9YmC();
		Screen[] array = Screen.AllScreens.OrderBy((Screen x) => x.Bounds.X).ToArray();
		AppSettings.ScreenCount = array.Count();
		AppSettings.MainScreen = Screen.PrimaryScreen;
		if (AppSettings.ScreenCount >= 2)
		{
			for (int i = 0; i < array.Count(); i++)
			{
				if (array[i] != AppSettings.MainScreen)
				{
					if (array[i] == AppSettings.SecondaryScreen || AppSettings.SecondaryScreen != null)
					{
						AppSettings.ThirdScreen = array[i];
						break;
					}
					AppSettings.SecondaryScreen = array[i];
				}
			}
		}
		Application.AddMessageFilter(new AltKeyFilter());
		frmLoader frmLoader = new frmLoader();
		Application.Run(frmLoader);
		if (frmLoader.listener != null)
		{
			frmLoader.listener.Server.Close();
			frmLoader.listener.Stop();
		}
		if (frmLoader.http_listener != null)
		{
			frmLoader.http_listener.Abort();
			frmLoader.http_listener.Close();
		}
	}

	private static void smethod_0(object sender, ThreadExceptionEventArgs e)
	{
		new frmSendErrorLog(e).Show();
	}
}
