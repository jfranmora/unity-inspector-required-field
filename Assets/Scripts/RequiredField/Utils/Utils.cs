using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

namespace JfranMora.RequiredField
{
	public static class Utils
	{
		public static bool IsValidObject(Object obj)
		{
			foreach (var field in obj.GetType().GetFields())
			{
				var attributes = field.GetCustomAttributes(typeof(RequiredFieldAttribute));
				if (attributes.Any())
				{
					if (ReferenceEquals(field.GetValue(obj), null) || field.GetValue(obj).ToString().Equals("null"))
					{
						return false;
					}
				}
			}

			return true;
		}

		public static List<Object> GetObjectsFromTypeList(IEnumerable<Type> types)
		{
			var result = new List<Object>();

			foreach (var type in types)
			{
				result.AddRange(Object.FindObjectsOfType(type));
			}

			return result;
		}

		public static List<Type> GetTypesWithAttribute<T>() where T : Attribute
		{
			var result = new List<Type>();
			foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
			{
				foreach (var type in assembly.GetTypes())
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

		private static IEnumerable<FieldInfo> GetFieldsWithAttribute(Type classType, Type attributeType)
		{
			return classType
				.GetFields()
				.Where(fieldInfo => fieldInfo.GetCustomAttributes(attributeType, false).Length > 0);
		}
	}
}