using UnityEditor;
using UnityEngine;

namespace JfranMora.Inspector.Editor
{
	public class SceneValidatorWindow : EditorWindow
	{
		[MenuItem("Window/JfranMora/Scene Validator")]
		static void Init()
		{
			SceneValidatorWindow window = (SceneValidatorWindow) GetWindow(typeof(SceneValidatorWindow));
			window.titleContent = new GUIContent("Scene validator");
			window.Show();
		}

		private void OnGUI()
		{
			var invalid = SceneValidator.GetNotValidObjects();
			foreach (var obj in invalid)
			{
				if (GUILayout.Button(obj.name))
				{
					EditorGUIUtility.PingObject(obj);
				}
			}
		}
	}
}