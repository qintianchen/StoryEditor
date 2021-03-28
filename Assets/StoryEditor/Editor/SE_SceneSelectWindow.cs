using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class SE_SceneSelectWindow
{
	public static void OnGUI()
	{
		var allScenePathList = SE_Window.GetAllScenePathList();
		SE_Window.selectedSceneIndex = EditorGUILayout.Popup("所有场景", SE_Window.selectedSceneIndex, allScenePathList);

		GUILayout.BeginVertical();
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		if (GUILayout.Button("选择场景", GUILayout.Width(100), GUILayout.Height(100)))
		{
			string scenePath = allScenePathList[SE_Window.selectedSceneIndex];
			string selectSceneName = Path.GetFileNameWithoutExtension(scenePath);
			if (selectSceneName != EditorSceneManager.GetActiveScene().name)
			{
				EditorSceneManager.OpenScene(scenePath.Replace("\\", "/"));
			}
			else
			{
				Debug.Log("已经处于目标场景");
			}

			SE_Window.isSceneLoaded = true;
		}

		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndVertical();
	}
}