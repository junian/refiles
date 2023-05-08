using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace CorePOS.Updater.Properties;

[DebuggerNonUserCode]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
[CompilerGenerated]
public class Resources
{
	private static ResourceManager resourceManager_0;

	private static CultureInfo cultureInfo_0;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static ResourceManager ResourceManager
	{
		get
		{
			if (resourceManager_0 == null)
			{
				resourceManager_0 = new ResourceManager("CorePOS.Updater.Properties.Resources", typeof(Resources).Assembly);
			}
			return resourceManager_0;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static CultureInfo Culture
	{
		get
		{
			return cultureInfo_0;
		}
		set
		{
			cultureInfo_0 = value;
		}
	}

	public static string _databases => ResourceManager.GetString("_databases", cultureInfo_0);

	public static string _of => ResourceManager.GetString("_of", cultureInfo_0);

	public static string Another_instance_of_Hippos_exe => ResourceManager.GetString("Another_instance_of_Hippos_exe", cultureInfo_0);

	public static string Downloading_Installing => ResourceManager.GetString("Downloading_Installing", cultureInfo_0);

	public static string training => ResourceManager.GetString("training", cultureInfo_0);

	public static string Update_Complete => ResourceManager.GetString("Update_Complete", cultureInfo_0);

	public static string Updating => ResourceManager.GetString("Updating", cultureInfo_0);

	public static string Version => ResourceManager.GetString("Version", cultureInfo_0);

	public static string WARNING => ResourceManager.GetString("WARNING", cultureInfo_0);

	internal Resources()
	{
		Class13.FLcy5UmzUUEfT();
		base._002Ector();
	}
}
