using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace JfranMora
{
	public static class ReflectionUtils
	{
		public static List<Type> GetTypesWithAttribute<T>() where T : Attribute
		{
			var result = new List<Type>();
			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
			{
				foreach (Type type in assembly.GetTypes())
				{
					var fields = GetFieldsWithAttribute(type, typeof(T));
					if (fields != null && fields.Any() && type.IsSubclassOf(typeof(Component)))
					{
						result.Add(type);
					}
				}
			}

			return result;
		}

		public static IEnumerable<FieldInfo> GetFieldsWithAttribute(Type classType, Type attributeType)
		{
			return classType.GetFields().Where(fieldInfo => fieldInfo.GetCustomAttributes(attributeType, false).Length > 0);
		}
	}
}

