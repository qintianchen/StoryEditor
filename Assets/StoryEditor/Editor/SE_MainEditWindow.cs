using UnityEditor;
using UnityEngine;

public static class SE_MainEditWindow
{
	public static void OnGUI()
	{
		DrawGrid(10, 0.2f, Color.gray);
		DrawGrid(200, 0.5f, Color.gray);

		DrawUtilPanel();

		if (SE_Window.isFocused)
		{
			SE_EventHandler.HandleEvent(Event.current);
		}
	}

	private static void DrawUtilPanel()
	{
		float size = 100 * SE_Window.scale;
		if (GUI.Button(new Rect(SE_Window.CollectPostion(new Vector2(70, 70)), SE_Window.CollectSize(100 * Vector2.one)), new GUIContent("中央")))
		{
			// SE_Window.offset = Vector2.zero;
			// GUI.changed = true;
		}
		
		if (GUI.Button(new Rect(Screen.width - 50, 10, 40, 40), SE_Window.focusTex))
		{
			SE_Window.offset = Vector2.zero;
			GUI.changed = true;
		}
	}

	private static void DrawGrid(float gridSpacing, float gridOpacity, Color gridColor)
	{
		gridSpacing *= SE_Window.scale;
		if (gridSpacing <= 0)
		{
			return;
		}

		int widthDivs = Mathf.CeilToInt(SE_Window.instance.position.width / gridSpacing);
		int heightDivs = Mathf.CeilToInt(SE_Window.instance.position.height / gridSpacing);

		// Handles.BeginGUI();
		Handles.color = new Color(gridColor.r, gridColor.g, gridColor.b, gridOpacity);

		float x = SE_Window.offset.x % gridSpacing;
		float y = SE_Window.offset.y % gridSpacing;

		for (int i = 0; i <= widthDivs; i++)
		{
			Handles.DrawLine(
				new Vector3(gridSpacing * i + x, 0, 0),
				new Vector3(gridSpacing * i + x, SE_Window.instance.position.height, 0));
		}

		for (int i = 0; i <= heightDivs; i++)
		{
			Handles.DrawLine(
				new Vector3(0, gridSpacing * i + y, 0),
				new Vector3(SE_Window.instance.position.width, gridSpacing * i + y, 0));
		}

		Handles.color = Color.white;
		// Handles.EndGUI();
	}
}