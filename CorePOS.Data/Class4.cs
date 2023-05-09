using System;
using System.Reflection;

internal class Class4
{
	internal delegate void Delegate1(object o);

	internal static Module module_0;

	internal static void Iq4RKAOONt3CE(int typemdt)
	{
		Type type = module_0.ResolveType(33554432 + typemdt);
		FieldInfo[] fields = type.GetFields();
		foreach (FieldInfo fieldInfo in fields)
		{
			MethodInfo method = (MethodInfo)module_0.ResolveMethod(fieldInfo.MetadataToken + 100663296);
			fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
		}
	}

	public Class4()
	{
		Class5.qrSRKAOzgGGAb();
		// base._002Ector();
	}

	static Class4()
	{
		Class5.qrSRKAOzgGGAb();
		module_0 = typeof(Class4).Assembly.ManifestModule;
	}
}
