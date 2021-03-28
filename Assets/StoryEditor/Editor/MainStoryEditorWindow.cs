using UnityEditor;
using UnityEngine;

public static class MainStoryEditorWindow
{
	public static void OnGUI()
	{
		DrawGrid(10, 0.2f, Color.gray);
		DrawGrid(200, 0.5f, Color.gray);

		if (StoryEditorWindow.isFocused)
		{
			
		}
	}
	
	private static void DrawGrid(float gridSpacing, float gridOpacity, Color gridColor) {
		int widthDivs = Mathf.CeilToInt(StoryEditorWindow.instance.position.width / gridSpacing);
		int heightDivs = Mathf.CeilToInt(StoryEditorWindow.instance.position.height / gridSpacing);
		
		Handles.BeginGUI();
		Handles.color = new Color(gridColor.r, gridColor.g, gridColor.b, gridOpacity);

		for (int i = 0; i <= widthDivs; i++) {
			Handles.DrawLine(
				new Vector3(gridSpacing * i + StoryEditorWindow.offset.x, 0, 0),
				new Vector3(gridSpacing * i + StoryEditorWindow.offset.x, StoryEditorWindow.instance.position.height, 0));
		}
	
		for (int i = 0; i <= heightDivs; i++) {
			Handles.DrawLine(
				new Vector3(0, gridSpacing * i + StoryEditorWindow.offset.y, 0),
				new Vector3(StoryEditorWindow.instance.position.width, gridSpacing * i + StoryEditorWindow.offset.y, 0));
		}
		
		Handles.color = Color.white;
		Handles.EndGUI();
	}
}