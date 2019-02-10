using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace JfranMora.Editor
{
	public static class RequiredFieldEditor
	{
		private static List<Type> observedTypes = new List<Type>();
		private static bool _initialized;

		[InitializeOnLoadMethod]
		public static void Initialize()
		{
			if (EditorApplication.isPlaying) return;

			BuildObservedTypes();

			if (!_initialized)
			{
				EditorApplication.update += Update;
				_initialized = true;
			}
		}

		private static void Update()
		{
			if (!EditorApplication.isPlaying && EditorApplication.isPlayingOrWillChangePlaymode)
			{
				if (!IsSceneValid())
				{
					EditorApplication.isPlaying = false;
				}
			}
		}

		private static void BuildObservedTypes()
		{
			observedTypes = ReflectionUtils.GetTypesWithAttribute<RequiredFieldAttribute>();
		}

		private static bool IsSceneValid()
		{
			bool isValid = true;
			int validated = 0;

			foreach (var type in observedTypes)
			{
				var objects = GameObject.FindObjectsOfType(type);
				foreach (var obj in objects)
				{
					if (!IsValidObject(obj))
					{
						EditorGUIUtility.PingObject(obj);

						Debug.LogErrorFormat("<b>[FieldValidator]</b> Validation error: {0}", obj);
						isValid = false;
					}
				}

				validated += objects.Length;
			}

			if (!isValid)
			{
				Debug.LogError("<b>[FieldValidator]</b> Scene is not valid!");
			}
			
			Debug.LogWarningFormat("<b>[FieldValidator]</b> Checked {0} components", validated);

			return isValid;
		}

		private static bool IsValidObject(object obj)
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
	}
}