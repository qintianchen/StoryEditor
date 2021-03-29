using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LearnGUI : EditorWindow
{
    public static LearnGUI instance;
    [MenuItem("Window/测试GUI")]
    static void OpenWindow()
    {
        instance = GetWindow<LearnGUI>();
        instance.titleContent = new GUIContent("测试GUI");
    }

    private static Vector2 scrollPosition;
    private void OnGUI()
    {
        DrawToolBar();
    }
    
    public int toolbarInt = 0;
    public string[] toolbarStrings = new string[] {"Toolbar1", "Toolbar2", "Toolbar3"};
    void DrawToolBar()
    {
        toolbarInt = GUI.Toolbar(new Rect(25, 25, 250, 30), toolbarInt, toolbarStrings);
    }
    
    public Texture aTexture;
    private bool toggleTxt = false;
    private bool toggleImg = false;
    void DrawToggle()
    {
        aTexture = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Textures/floor.jpg");
        if (!aTexture)
        {
            Debug.LogError("Please assign a texture in the inspector.");
            return;
        }

        toggleTxt = GUI.Toggle(new Rect(10, 10, 100, 30), toggleTxt, "A Toggle text");
        toggleImg = GUI.Toggle(new Rect(10, 50, 50, 50), toggleImg, aTexture);
    }
    
    void DrawTextField()
    {
        stringToEdit = "Hello World";
        stringToEdit = GUI.TextField(new Rect(10, 10, 200, 20), stringToEdit, 25);
    }

    public string stringToEdit = "Hello World\nI've got 2 lines...";
    private void DrawTextArea()
    {
        stringToEdit = GUI.TextArea(new Rect(10, 10, 200, 100), stringToEdit, 200);
    }
    
    public static int selGridInt = 0;
    public static string[] selStrings = new string[] {"Grid 1", "Grid 2", "Grid 3", "Grid 4"};
    private void DrawSelectionGrid()
    {
        selGridInt = GUI.SelectionGrid(new Rect(25, 25, 100, 30), selGridInt, selStrings, 2);
    }

    private void DrawRepeatButton()
    {
        btnTexture = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Textures/floor.jpg");
        if (GUI.RepeatButton(new Rect(10, 10, 50, 50), btnTexture))
            Debug.Log("Clicked the button with an image");
    }

    public static string passwordToEdit = "";
    private void DrawPasswordField()
    {
        passwordToEdit = GUI.PasswordField(new Rect(10, 10, 200, 20), passwordToEdit, "*"[0], 25);
    }

    private static void DrawLabel()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Hello World!");
    }

    public static float hSliderValue = 0.5f;
    private void DrawHorizontalSlider()
    {
        hSliderValue = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), hSliderValue, 0.0F, 10.0F);
    }

    private void DrawScrollBar()
    {
        // 不知道为什么不起作用
        // float scrollPos = 0.5f;
        // scrollPos = GUI.HorizontalScrollbar(new Rect(0, 0, 100, 20),  scrollPos, 1.0f, 0.0f, 100.0f, "Scroll");
    }

    public static Texture btnTexture;
    private void DrawButton()
    {
        btnTexture = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Textures/floor.jpg");
        if (GUI.Button(new Rect(10, 10, 50, 50), btnTexture))
            Debug.Log("Clicked the button with an image");
    }

    private void DrawBox()
    {
        var content = new GUIContent("这是Box的内容");
        GUI.Box(new Rect(0, 0, Screen.width/2, Screen.height/2), content);
    }

    private void DrawScrollView()
    {
        scrollPosition = GUI.BeginScrollView(new Rect(10, 10, 100, 200), scrollPosition, new Rect(10, 10, 150, 2600));
        
        for (int i = 0; i < 100; i++)
        {
            GUI.Button(new Rect(0, i * 25 + 10, 100, 20), i.ToString());
        }

        GUI.EndScrollView();
    }
}
