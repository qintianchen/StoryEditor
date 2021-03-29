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

public class SE_Window : EditorWindow
{
	public static bool isInit;
	public static int selectedSceneIndex = 0;
	public static bool isSceneLoaded = false;
	public static bool isFocused = false;
	public static StoryEditorConfig config;
	public static SE_Window instance;
	public static Vector2 offset = Vector2.zero;
	public static float scale = 1;
	public static Texture focusTex;


	[MenuItem("Window/剧情编辑器")]
	static void OpenWindow()
	{
		instance = GetWindow<SE_Window>();
		instance.titleContent = new GUIContent("剧情编辑器");
		instance.minSize = new Vector2(500, 500);
	}

	private void Init()
	{
		if (!isInit)
		{
			config = AssetDatabase.LoadAssetAtPath<StoryEditorConfig>("Assets/StoryEditor/config.asset");
			focusTex = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Textures/focus.png");
			isInit = true;
		}
	}

	private void OnFocus()
	{
		isFocused = true;
	}

	private void OnLostFocus()
	{
		isFocused = false;
	}
	
	private void OnGUI()
	{
		Init();

		if (!isSceneLoaded)
		{
			SE_SceneSelectWindow.OnGUI();
		}
		else
		{
			SE_MainEditWindow.OnGUI();
		}
	}
	
	#region 辅助函数

	public static string[] GetAllScenePathList()
	{
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

	public static Vector2 CollectPostion(Vector2 pos)
	{
		pos.x = pos.x * scale + offset.x;
		pos.y = pos.y * scale + offset.y;
		return pos;
	}

	public static Vector2 CollectSize(Vector2 size)
	{
		return size * scale;
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