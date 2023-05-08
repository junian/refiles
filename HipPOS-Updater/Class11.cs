using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Updater;

internal static class Class11
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
		Class13.FLcy5UmzUUEfT();
		Application.Run(new frmLoader());
	}

	private static void smethod_0(object sender, ThreadExceptionEventArgs e)
	{
		new frmSendErrorLog(e).Show();
	}
}
