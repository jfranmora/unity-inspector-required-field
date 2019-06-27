using UnityEditor;
using UnityEngine;

namespace JfranMora.Inspector.Editor
{
	[CustomPropertyDrawer(typeof(RequiredFieldAttribute))]
	public class RequiredFieldDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			if (IsObject(property))
			{
				var color = GUI.backgroundColor;
				GUI.backgroundColor = property.objectReferenceInstanceIDValue == 0 ? new Color(.8f, .2f, .2f) : color;
				EditorGUI.PropertyField(position, property, label);
				GUI.backgroundColor = color;
			}
			else
			{
				EditorGUI.PropertyField(position, property, label);
			}
		}

		private Object temp;

		private bool IsObject(SerializedProperty property)
		{
			try
			{
				return property.type.Contains("PPtr");
			}
			catch
			{
				return false;
			}
		}
	}
}