using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace CorePOS.Sync;

[RunInstaller(true)]
public class ProjectInstaller : Installer
{
	private IContainer icontainer_0;

	private ServiceProcessInstaller serviceProcessInstaller_0;

	private ServiceInstaller serviceInstaller_0;

	public ProjectInstaller()
	{
		Class9.HjKvJsazVZwlF();
		// base._002Ector();
		method_0();
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
		serviceProcessInstaller_0 = new ServiceProcessInstaller();
		serviceInstaller_0 = new ServiceInstaller();
		serviceProcessInstaller_0.Account = ServiceAccount.LocalSystem;
		serviceProcessInstaller_0.Password = null;
		serviceProcessInstaller_0.Username = null;
		serviceInstaller_0.ServiceName = "Hippos Sync Service";
		base.Installers.AddRange(new Installer[2] { serviceProcessInstaller_0, serviceInstaller_0 });
	}
}
