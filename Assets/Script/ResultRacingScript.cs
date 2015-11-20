using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ResultRacingScript : MonoBehaviour
{
    public int widht;
    public int height;

    private Rect windowRect;
    private SortedList res;
    private bool resultwindow = false;
    private GUIStyle style;
    private float time = 0;

    void Start()
    {
        res = new SortedList();
        windowRect = new Rect(Screen.width / 2 - widht / 2, Screen.height / 2 - height / 2, widht, height);
        style = new GUIStyle();
        style.fontSize = 22;
        style.normal.textColor = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "you")
        {
            res.Add(time, "you");
            resultwindow = true;
        }
        if (col.tag == "zombie")
        {
            res.Add(time, "zombie");
        }
        if (col.tag == "girl")
        {
            res.Add(time, "girl");
        }
    }

    void OnGUI()
    {
        if (resultwindow)
        {
            GUI.Window(0, windowRect, DoMyWindow, "result");
        }
    }
    void DoMyWindow(int windowID)
    {
        if (GUI.Button(new Rect(50, 250, 100, 30), "restar"))
        {
            Application.LoadLevel(1);
        }
            GUI.Label(new Rect(10, 20, 20, 20), String.Format("1 - {0,5:f2} - {1}", res.GetKey(0), res.GetByIndex(0)), style);
        if (res.Count >= 2)
        {
            GUI.Label(new Rect(10, 50, 20, 20), String.Format("2 - {0,5:f2} - {1}", res.GetKey(1), res.GetByIndex(1)), style);
        }
        if (res.Count == 3)
        {
            GUI.Label(new Rect(10, 80, 20, 20), String.Format("3 - {0,5:f2} - {1}", res.GetKey(2), res.GetByIndex(2)), style);
        }      
    }
}
