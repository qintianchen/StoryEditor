using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class SceneSelectWindow
{
	public static void OnGUI()
	{
		var allScenePathList = StoryEditorWindow.GetAllScenePathList();
		StoryEditorWindow.selectedSceneIndex = EditorGUILayout.Popup("所有场景", StoryEditorWindow.selectedSceneIndex, allScenePathList);

		GUILayout.BeginVertical();
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		if (GUILayout.Button("选择场景", GUILayout.Width(100), GUILayout.Height(100)))
		{
			string scenePath = allScenePathList[StoryEditorWindow.selectedSceneIndex];
			string selectSceneName = Path.GetFileNameWithoutExtension(scenePath);
			if (selectSceneName != EditorSceneManager.GetActiveScene().name)
			{
				EditorSceneManager.OpenScene(scenePath.Replace("\\", "/"));
			}
			else
			{
				Debug.Log("已经处于目标场景");
			}

			StoryEditorWindow.isSceneLoaded = true;
		}

		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndVertical();
	}
}