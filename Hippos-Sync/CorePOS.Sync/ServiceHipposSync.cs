using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Timers;
using CorePOS.Business.Methods;

namespace CorePOS.Sync;

public class ServiceHipposSync : ServiceBase
{
	private Timer timer_0;

	private IContainer icontainer_0;

	public ServiceHipposSync()
	{
		Class9.HjKvJsazVZwlF();
		timer_0 = new Timer();
		// base._002Ector();
		method_0();
	}

	protected override void OnStart(string[] args)
	{
		try
		{
			new GlobalSyncHelper().StartGlobalSync();
			timer_0.Elapsed += timer_0_Elapsed;
			timer_0.Interval = 10000.0;
			timer_0.Enabled = true;
		}
		catch (Exception ex)
		{
			SyncMethods.WriteToSyncLog(ex.Message + "\n" + ex.StackTrace);
			Stop();
		}
	}

	protected override void OnStop()
	{
		SyncMethods.WriteToSyncLog("Sync service has stopped.");
	}

	private void timer_0_Elapsed(object sender, ElapsedEventArgs e)
	{
		if (Process.GetProcessesByName("Hippos").Count() == 0)
		{
			Stop();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_0()
	{
		icontainer_0 = new Container();
		base.ServiceName = "Hippos Sync Service";
	}
}
