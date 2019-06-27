using System;
using System.Collections.Generic;
using JfranMora;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace JfranMora.Inspector.Editor
{
	public static class SceneValidator
	{
		private static List<Type> observedTypesDB = new List<Type>();

		public static void Init()
		{
			UpdateObservedTypesDB();
		}
		
		public static bool ValidateScene()
		{
			bool isValid = true;

			var objects = Utils.GetObjectsFromTypeList(observedTypesDB);
			for (var i = 0; i < objects.Count; i++)
			{
				var obj = objects[i];				
				if (!Utils.IsValidObject(obj))
				{
					EditorGUIUtility.PingObject(obj);

					Debug.LogErrorFormat("<b>[FieldValidator]</b> Validation error: {0}", obj);
					isValid = false;
				}
				
				// TODO: Add progress bar?
			}

			if (!isValid)
			{
				Debug.LogError("<b>[FieldValidator]</b> Scene is not valid!");
			}

			Debug.LogWarningFormat("<b>[FieldValidator]</b> Checked {0} components", objects.Count);

			return isValid;
		}

		public static List<Object> GetNotValidObjects()
		{
			var result = new List<Object>();

			var objects = Utils.GetObjectsFromTypeList(observedTypesDB);
			foreach (var obj in objects)
			{
				if (!Utils.IsValidObject(obj))
				{
					result.Add(obj);
				}
			}

			return result;
		}

		private static void UpdateObservedTypesDB()
		{
			observedTypesDB = Utils.GetTypesWithAttribute<RequiredFieldAttribute>();
		}
	}
}