using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Properties;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
[DebuggerNonUserCode]
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
				resourceManager_0 = new ResourceManager("CorePOS.Business.Properties.Resources", typeof(Resources).Assembly);
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

	public static string _Add_New => ResourceManager.GetString("_Add_New", cultureInfo_0);

	public static string _Select_A_Group_To_Edit => ResourceManager.GetString("_Select_A_Group_To_Edit", cultureInfo_0);

	public static string _Show_All_Ingredients => ResourceManager.GetString("_Show_All_Ingredients", cultureInfo_0);

	public static string _Show_All_Items => ResourceManager.GetString("_Show_All_Items", cultureInfo_0);

	public static string DELIVER_TO => ResourceManager.GetString("DELIVER_TO", cultureInfo_0);

	public static string Mail_address_from_and_to_can_t => ResourceManager.GetString("Mail_address_from_and_to_can_t", cultureInfo_0);

	public static string Mail_Smtpserver_can_t_be_empty => ResourceManager.GetString("Mail_Smtpserver_can_t_be_empty", cultureInfo_0);

	public static string Sync_failed => ResourceManager.GetString("Sync_failed", cultureInfo_0);

	public static string Unable_to_contact_server_check => ResourceManager.GetString("Unable_to_contact_server_check", cultureInfo_0);

	internal Resources()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
