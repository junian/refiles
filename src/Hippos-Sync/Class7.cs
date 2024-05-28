using System;
using System.Configuration.Install;
using System.Reflection;
using System.ServiceProcess;
using CorePOS.Sync;

internal static class Class7
{
	private static void Main(string[] args)
	{
		if (Environment.UserInteractive)
		{
			if (args.Length == 0)
			{
				return;
			}
			string text = args[0];
			if (!(text == "-install"))
			{
				if (text == "-uninstall")
				{
					ManagedInstallerClass.InstallHelper(new string[2]
					{
						"/u",
						Assembly.GetExecutingAssembly().Location
					});
				}
			}
			else
			{
				ManagedInstallerClass.InstallHelper(new string[1] { Assembly.GetExecutingAssembly().Location });
			}
		}
		else
		{
			ServiceBase.Run(new ServiceBase[1]
			{
				new ServiceHipposSync()
			});
		}
	}
}
