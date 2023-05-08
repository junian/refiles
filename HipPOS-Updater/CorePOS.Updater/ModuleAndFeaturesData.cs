using System.Runtime.CompilerServices;

namespace CorePOS.Updater;

public class ModuleAndFeaturesData
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private string string_2;

	public string ModuleName
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public string ControlName
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public string Description
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	public ModuleAndFeaturesData(string ModuleName, string ControlName, string Description)
	{
		Class13.FLcy5UmzUUEfT();
		base._002Ector();
		this.ModuleName = ModuleName;
		this.ControlName = ControlName;
		this.Description = Description;
	}
}
