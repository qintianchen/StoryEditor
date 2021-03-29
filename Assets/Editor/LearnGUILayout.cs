using UnityEditor;
using UnityEngine;


public class LearnGUILayout : EditorWindow
{
    [MenuItem("Window/测试Layout")]
    private static void ShowWindow()
    {
        var window = GetWindow<LearnGUILayout>();
        window.titleContent = new GUIContent("测试Layout");
        window.Show();
    }

    private void OnGUI()
    {
        GUI.BeginGroup(new Rect(0, 0, Screen.width, 200));

        GUI.Button(new Rect(0, 180, 100, 100), "按钮");

        GUI.EndGroup();
        // GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height - 200));
        // GUILayout.Button("UP");
        // GUI.Button(new Rect(0, 0, 100, 100), "GUI UP");
        //
        // GUILayout.EndArea();
        //
        //
        // GUILayout.BeginArea(new Rect(0, Screen.height -200, Screen.width, 200));
        // GUILayout.Button("Button");
        //
        // GUILayout.EndArea();
    }
}