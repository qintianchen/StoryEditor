using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor.SceneManagement;

public class StoryEditorWindow : EditorWindow
{
	private bool ifInit;
	private int selectedSceneIndex = 0;
	private bool ifSceneLoaded = false;

	[MenuItem("Window/剧情编辑器")]
	static void OpenWindow()
	{
		var window = GetWindow<StoryEditorWindow>();
		window.titleContent = new GUIContent("剧情编辑器");
	}

	private void Init()
	{
		if (!ifInit)
		{
			ifInit = true;
		}
	}

	#region 绘制函数

	private void OnGUI()
	{
		Init();

		if (!ifSceneLoaded)
		{
			DrawSceneSelectWindow();
		}
		else
		{
			DrawMainStoryEditorWindow();
		}
	}

	private void DrawMainStoryEditorWindow()
	{
		
	}

	private void DrawSceneSelectWindow()
	{
		var allScenePathList = GetAllScenePathList();
		selectedSceneIndex = EditorGUILayout.Popup("所有场景", selectedSceneIndex, allScenePathList);

		GUILayout.BeginVertical();
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		if (GUILayout.Button("选择场景", GUILayout.Width(100), GUILayout.Height(100)))
		{
			string scenePath = allScenePathList[selectedSceneIndex];
			string selectSceneName = Path.GetFileNameWithoutExtension(scenePath);
			if (selectSceneName != EditorSceneManager.GetActiveScene().name)
			{
				EditorSceneManager.OpenScene(scenePath.Replace("\\", "/"));
			}
			else
			{
				Debug.Log("选择当前场景");
			}

			ifSceneLoaded = true;
		}

		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndVertical();
		
	}

	#endregion

	#region 辅助函数

	private string[] GetAllScenePathList()
	{
		StoryEditorConfig config = AssetDatabase.LoadAssetAtPath<StoryEditorConfig>("Assets/StoryEditor/config.asset");
		if (config == null)
		{
			Debug.LogError("加载编辑器窗口配置失败：Assets/StoryEditor/config.asset");
			return new string[0];
		}

		List<string> result = new List<string>();
		foreach (var folder in config.folderToSearchScene)
		{
			var filePaths = Directory.GetFiles(folder);
			foreach (var path in filePaths)
			{
				var extension = Path.GetExtension(path);
				if (extension == ".unity")
				{
					result.Add(path.Replace("/", "\\"));
				}
			}
		}

		return result.ToArray();
	}

	#endregion

	private void OnDestroy()
	{
		// if (EditorUtility.DisplayDialog("保存确认", "编辑场景还没有保存，是否要退出？", "保存并退出", "退出"))
		// {
		// 	Debug.Log($"保存再退出!");
		// }
		// else
		// {
		// 	Debug.Log($"我不打算保存!");
		// }
	}
}