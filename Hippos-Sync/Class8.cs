using System;
using System.Reflection;

internal class Class8
{
	internal delegate void Delegate2(object o);

	internal static Module module_0;

	internal static void G9GvJsaarfFV6(int typemdt)
	{
		Type type = module_0.ResolveType(33554432 + typemdt);
		FieldInfo[] fields = type.GetFields();
		foreach (FieldInfo fieldInfo in fields)
		{
			MethodInfo method = (MethodInfo)module_0.ResolveMethod(fieldInfo.MetadataToken + 100663296);
			fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
		}
	}

	public Class8()
	{
		Class9.HjKvJsazVZwlF();
		base._002Ector();
	}

	static Class8()
	{
		Class9.HjKvJsazVZwlF();
		module_0 = typeof(Class8).Assembly.ManifestModule;
	}
}
