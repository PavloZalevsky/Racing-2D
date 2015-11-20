using UnityEngine;
using System.Collections;
using System;

public class MenuScripr : MonoBehaviour {

    int width = 120;
    int height = 40;
    private GUIStyle style;

    void Start () {
        style = new GUIStyle();
        style.fontSize = 22;
        style.normal.textColor = Color.green;
    }
	
    void OnGUI()
    {
        if(GUI.Button(new Rect(Screen.width / 2 - width / 2, Screen.height / 2 - height / 2, width, height), "Play"))
        {
            Application.LoadLevel(1);
        }
        GUI.Label(new Rect(10, Screen.height - 40, 600, 20), String.Format("повороти стрілками вліво, вправо ,нітро стрілкою вверх"),style);
    }
}
