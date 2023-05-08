using System;
using System.Linq;
using System.Reflection;

namespace CorePOS.Business.Methods;

public static class Reflection
{
	public static void CopyProperties(this object source, object destination)
	{
		_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass0_0();
		if (source != null && destination != null)
		{
			CS_0024_003C_003E8__locals0.typeDest = destination.GetType();
			{
				foreach (var item in from srcProp in source.GetType().GetProperties()
					let targetProperty = CS_0024_003C_003E8__locals0.typeDest.GetProperty(srcProp.Name)
					where srcProp.CanRead && targetProperty != null && targetProperty.GetSetMethod(nonPublic: true) != null && !targetProperty.GetSetMethod(nonPublic: true).IsPrivate && (targetProperty.GetSetMethod().Attributes & MethodAttributes.Static) == 0 && targetProperty.PropertyType.IsAssignableFrom(srcProp.PropertyType)
					select new
					{
						sourceProperty = srcProp,
						targetProperty = targetProperty
					})
				{
					item.targetProperty.SetValue(destination, item.sourceProperty.GetValue(source, null), null);
				}
				return;
			}
		}
		throw new Exception("Source or/and Destination Objects are null");
	}
}
