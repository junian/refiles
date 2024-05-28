using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CorePOS.Data.Properties;

[CompilerGenerated]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
public sealed class Settings : ApplicationSettingsBase
{
	private static Settings defaultInstance;

	public static Settings Default => defaultInstance;

	[DebuggerNonUserCode]
	[DefaultSettingValue("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\PROJECTS\\DIGITALCRAFT\\CorePOS-Retail\\CorePOS.UI\\data\\CorePOS.mdf;Integrated Security=True")]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	[ApplicationScopedSetting]
	public string CorePOSConnectionString1 => (string)this["CorePOSConnectionString1"];

	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DefaultSettingValue("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=C:\\PROJECTS\\DIGITALCRAFT\\COREPOS-RETAIL\\COREPOS.UI\\DATA\\COREPOS.MDF;Integrated Security=True")]
	[DebuggerNonUserCode]
	[ApplicationScopedSetting]
	public string C__PROJECTS_DIGITALCRAFT_COREPOS_RETAIL_COREPOS_UI_DATA_COREPOS_MDFConnectionString => (string)this["C__PROJECTS_DIGITALCRAFT_COREPOS_RETAIL_COREPOS_UI_DATA_COREPOS_MDFConnectionString"];

	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	[ApplicationScopedSetting]
	public bool isCurrentlyTrainingMode => (bool)this["isCurrentlyTrainingMode"];

	[DebuggerNonUserCode]
	[DefaultSettingValue("0")]
	[ApplicationScopedSetting]
	public int LoggedInEmployeeID => (int)this["LoggedInEmployeeID"];

	[DefaultSettingValue("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Project\\Hippos\\CorePOS-Retail\\CorePOS.UI\\data\\CorePOS.mdf;Integrated Security=True")]
	[DebuggerNonUserCode]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	[ApplicationScopedSetting]
	public string CorePOSConnectionString => (string)this["CorePOSConnectionString"];

	[DebuggerNonUserCode]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	[ApplicationScopedSetting]
	[DefaultSettingValue("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Projects\\CorePOS-Retail\\CorePOS.UI\\data\\CorePOS.mdf;Integrated Security=True")]
	public string CorePOSConnectionString2 => (string)this["CorePOSConnectionString2"];

	[DefaultSettingValue("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\PROJECTS\\DIGITALCRAFT\\CorePOS-Restaurant\\CorePOS.UI\\data\\CorePOS.mdf;Integrated Security=True")]
	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	public string CorePOSConnectionString3 => (string)this["CorePOSConnectionString3"];

	[DebuggerNonUserCode]
	[ApplicationScopedSetting]
	[DefaultSettingValue("Data Source=hq.digitalcraft.ca,45865;Initial Catalog=RestaurantPOS-HipPOS;User ID=hippos_dbuser")]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	public string RestaurantPOS_HipPOSConnectionString => (string)this["RestaurantPOS_HipPOSConnectionString"];

	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DebuggerNonUserCode]
	[ApplicationScopedSetting]
	[DefaultSettingValue("Data Source=hq.digitalcraft.ca,45865;Initial Catalog=RestaurantPOS-HipPOS;User ID=hippos_dbuser;Password=Digital1!")]
	public string RestaurantPOS_HipPOSConnectionString1 => (string)this["RestaurantPOS_HipPOSConnectionString1"];

	[DebuggerNonUserCode]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DefaultSettingValue("Data Source=192.168.75.35,45865;Initial Catalog=RestaurantPOS-HipPOS;User ID=sa")]
	[ApplicationScopedSetting]
	public string RestaurantPOS_HipPOSConnectionString2 => (string)this["RestaurantPOS_HipPOSConnectionString2"];

	[ApplicationScopedSetting]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DebuggerNonUserCode]
	[DefaultSettingValue("Data Source=192.168.75.35,45865;Initial Catalog=RestaurantPOS-HipPOS;User ID=sa;Password=D!gitaL16!")]
	public string RestaurantPOS_HipPOSConnectionString3 => (string)this["RestaurantPOS_HipPOSConnectionString3"];

	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DefaultSettingValue("Data Source=hq.digitalcraft.ca,45865;Initial Catalog=RestaurantPOS-HipPOS;User ID=hippos_dbuser;Password=Digital1!")]
	public string RestaurantPOS_HipPOSConnectionString4 => (string)this["RestaurantPOS_HipPOSConnectionString4"];

	[DebuggerNonUserCode]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	[ApplicationScopedSetting]
	[DefaultSettingValue("Data Source=hq.digitalcraft.ca,45865;Initial Catalog=RestaurantPOS-HipPOS;Persist Security Info=True;User ID=hippos_dbuser;Password=Digital1!")]
	public string RestaurantPOS_HipPOSConnectionString5 => (string)this["RestaurantPOS_HipPOSConnectionString5"];

	[ApplicationScopedSetting]
	[DefaultSettingValue("1.09.2")]
	[DebuggerNonUserCode]
	public string AppVersion => (string)this["AppVersion"];

	[DefaultSettingValue("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Projects\\CorePOS-Retail\\CorePOS.UI\\data\\CorePOS.mdf;Integrated Security=True;Connect Timeout=30")]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DebuggerNonUserCode]
	[ApplicationScopedSetting]
	public string CorePOSConnectionString4 => (string)this["CorePOSConnectionString4"];

	[DefaultSettingValue("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Projects\\CorePOS-Restaurant\\CorePOS.UI\\data\\RestaurantPOS-HipPOS.mdf;Integrated Security=True;Connect Timeout=30")]
	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	public string RestaurantPOS_HipPOSConnectionString6 => (string)this["RestaurantPOS_HipPOSConnectionString6"];

	[DebuggerNonUserCode]
	[ApplicationScopedSetting]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DefaultSettingValue("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Projects\\CorePOS-Restaurant\\CorePOS.UI\\data\\RestaurantPOS-HipPOS.mdf;Integrated Security=True;Connect Timeout=30")]
	public string RestaurantPOS_HipPOSConnectionString7 => (string)this["RestaurantPOS_HipPOSConnectionString7"];

	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DefaultSettingValue("Data Source=hq.digitalcraft.ca,45865;Persist Security Info=True;User ID=hippos_dbuser;Password=Digital1!")]
	[DebuggerNonUserCode]
	[ApplicationScopedSetting]
	public string DataSourceConnectionString => (string)this["DataSourceConnectionString"];

	[DefaultSettingValue("")]
	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	public string ConnectionString => (string)this["ConnectionString"];

	[DefaultSettingValue("Data Source=hq.digitalcraft.ca,45865;Initial Catalog=RestaurantPOS-HipPOS;Persist Security Info=True;User ID=hippos_dbuser;Password=Digital1!")]
	[ApplicationScopedSetting]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DebuggerNonUserCode]
	public string RestaurantPOS_HipPOSConnectionString8 => (string)this["RestaurantPOS_HipPOSConnectionString8"];

	[DebuggerNonUserCode]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DefaultSettingValue("Data Source=hq.digitalcraft.ca,45865;Initial Catalog=RestaurantPOS-HipPOS;Persist Security Info=True;User ID=hippos_dbuser;Password=Digital1!")]
	[ApplicationScopedSetting]
	public string RestaurantPOS_HipPOSConnectionString9 => (string)this["RestaurantPOS_HipPOSConnectionString9"];

	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("Data Source=hq.digitalcraft.ca,45865;Initial Catalog=RestaurantPOS-HipPOS;User ID=hippos_dbuser;Password=Digital1!")]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	public string RestaurantPOS_HipPOSConnectionString10 => (string)this["RestaurantPOS_HipPOSConnectionString10"];

	[DefaultSettingValue("Data Source=192.168.2.22,47865;Initial Catalog=Hippos-Mashawi;User ID=sa;Password=1Hippos!")]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DebuggerNonUserCode]
	[ApplicationScopedSetting]
	public string RestaurantPOS_HipPOSConnectionString11 => (string)this["RestaurantPOS_HipPOSConnectionString11"];

	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DefaultSettingValue("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Hippos.mdf;Integrated Security=True;Connect Timeout=30")]
	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	public string HipposConnectionString => (string)this["HipposConnectionString"];

	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DefaultSettingValue("Data Source=192.168.75.36,46865;Initial Catalog=Hippos-KimBao;Persist Security Info=True;User ID=sa")]
	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	public string Hippos_KimBaoConnectionString => (string)this["Hippos_KimBaoConnectionString"];

	[DefaultSettingValue("Data Source=192.168.75.36,46865;Initial Catalog=Hippos-KimBao;Persist Security Info=True;User ID=sa;Password=1HungryHippos!")]
	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	public string Hippos_KimBaoConnectionString1 => (string)this["Hippos_KimBaoConnectionString1"];

	[DefaultSettingValue("Data Source=192.168.75.37,47865;Initial Catalog=Hippos-DevRest;User ID=hippos_dbuser;Password=6Hippos!")]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	public string Hippos_DevRestConnectionString => (string)this["Hippos_DevRestConnectionString"];

	[DefaultSettingValue("Data Source=192.168.2.22,47865;Initial Catalog=Hippos-Mashawi;User ID=sa")]
	[ApplicationScopedSetting]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DebuggerNonUserCode]
	public string Hippos_MashawiConnectionString => (string)this["Hippos_MashawiConnectionString"];

	[SpecialSetting(SpecialSetting.ConnectionString)]
	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("Data Source=192.168.75.37,47865;Initial Catalog=Hippos-DevRest;User ID=hippos_dbuser")]
	public string Hippos_DevRestConnectionString1 => (string)this["Hippos_DevRestConnectionString1"];

	[ApplicationScopedSetting]
	[DefaultSettingValue("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"T:\\Hippos Visual Studio\\data\\Restaurant\\RestaurantPOS-HipPOS.mdf\";Integrated Security=True;Connect Timeout=30")]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DebuggerNonUserCode]
	public string RestaurantPOS_HipPOSConnectionString12 => (string)this["RestaurantPOS_HipPOSConnectionString12"];

	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DefaultSettingValue("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\RestaurantPOS-HipPOS.mdf;Integrated Security=True;Connect Timeout=30")]
	[DebuggerNonUserCode]
	[ApplicationScopedSetting]
	public string RestaurantPOS_HipPOSConnectionString13 => (string)this["RestaurantPOS_HipPOSConnectionString13"];

	[DebuggerNonUserCode]
	[ApplicationScopedSetting]
	[DefaultSettingValue("False")]
	public bool isHipposServersOnline => (bool)this["isHipposServersOnline"];

	[ApplicationScopedSetting]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DebuggerNonUserCode]
	[DefaultSettingValue("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\RestaurantPOS-HipPOS.mdf;Integrated Security=True;Connect Timeout=30")]
	public string DevRestConnectionString => (string)this["DevRestConnectionString"];

	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DefaultSettingValue("Data Source=192.168.75.35,45865;Initial Catalog=GStreetPizza;User ID=sa;Password=1Hippos!")]
	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	public string GStreetPizzaConnectionString => (string)this["GStreetPizzaConnectionString"];

	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DefaultSettingValue("Data Source=192.168.75.35,45865;Initial Catalog=DevRest;Persist Security Info=True;User ID=sa;Password=1Hippos!")]
	public string DevRestConnectionString1 => (string)this["DevRestConnectionString1"];

	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DefaultSettingValue("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\RestaurantPOS-HipPOS.mdf;Integrated Security=True;Connect Timeout=30")]
	public string DevRestConnectionString2 => (string)this["DevRestConnectionString2"];

	[ApplicationScopedSetting]
	[DefaultSettingValue("0")]
	[DebuggerNonUserCode]
	public int CurrentTerminalID => (int)this["CurrentTerminalID"];

	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DefaultSettingValue("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Paisano;Integrated Security=True")]
	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	public string PaisanoConnectionString => (string)this["PaisanoConnectionString"];

	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DefaultSettingValue("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=\"T:\\HIPPOS VISUAL STUDIO\\DATA\\RESTAURANT\\RESTAURANTPOS-HIPPOS.MDF\";Integrated Security=True")]
	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	public string T__HIPPOS_VISUAL_STUDIO_DATA_RESTAURANT_RESTAURANTPOS_HIPPOS_MDFConnectionString => (string)this["T__HIPPOS_VISUAL_STUDIO_DATA_RESTAURANT_RESTAURANTPOS_HIPPOS_MDFConnectionString"];

	[DefaultSettingValue("False")]
	[DebuggerNonUserCode]
	[ApplicationScopedSetting]
	public bool isPaymentTerminalConnected => (bool)this["isPaymentTerminalConnected"];

	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DefaultSettingValue("Data Source=192.168.75.35,45865;Initial Catalog=BBoyz-LionHead;User ID=sa;Password=1Hippos!")]
	[DebuggerNonUserCode]
	[ApplicationScopedSetting]
	public string BBoyz_LionHeadConnectionString => (string)this["BBoyz_LionHeadConnectionString"];

	public Settings()
	{
		Class5.qrSRKAOzgGGAb();
		// base._002Ector();
	}

	static Settings()
	{
		Class5.qrSRKAOzgGGAb();
		defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
