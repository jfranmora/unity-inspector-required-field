using UnityEditor;

namespace JfranMora.RequiredField.Editor
{
	public static class RequiredFieldEditor
	{
		[InitializeOnLoadMethod]
		public static void Initialize()
		{
			if (EditorApplication.isPlaying) return;

			SceneValidator.Init();
			EditorApplication.update += Update;
		}

		private static void Update()
		{
			// Detect when Unity Editor is going to Play mode
			if (EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
			{
				if (!SceneValidator.ValidateScene())
				{
					EditorApplication.isPlaying = false;
				}
			}
		}
	}
}