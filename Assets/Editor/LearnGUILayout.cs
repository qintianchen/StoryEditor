using UnityEditor;
using UnityEngine;


public class LearnGUILayout : EditorWindow
{
	[MenuItem("Window/测试Layout")]
	private static void ShowWindow()
	{
		var window = GetWindow<LearnGUILayout>();
		window.titleContent = new GUIContent("TITLE");
		window.Show();
	}

	private void OnGUI()
	{
	}
}