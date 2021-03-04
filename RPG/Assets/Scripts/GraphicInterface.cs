using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicInterface : MonoBehaviour
{
    private GUIStyle _styl;
    [SerializeField] private GUIStyle _button;
    private bool _isVisible = false;
    private string message;

    private void Start()
    {
       // _styl.fontSize = 20;
    }

    // Start is called before the first frame update
    private void OnGUI()
    {
       if (!_isVisible) return;
        GUI.Box(new Rect((Screen.width/2)-100, (Screen.height / 2)-70, 200, 300), "Menu");
        if (GUI.Button(new Rect((Screen.width / 2) - 50, (Screen.height / 2), 100, 50), "Open", _button)) message = "Open";
        if (GUI.Button(new Rect((Screen.width / 2) - 50, (Screen.height / 2)+70, 100, 50), "Save", _button)) message = "Save";
        if (GUI.Button(new Rect((Screen.width / 2) - 50, (Screen.height / 2) + 140, 100, 50), "Exit", _button)) message = "Exit";
        GUI.Label(new Rect((Screen.width / 2) - 50, (Screen.height / 2) + 210, 100, 30), message);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            _isVisible = !_isVisible;
        if (_isVisible) Time.timeScale = 0;
        else Time.timeScale = 1;
    }
}
