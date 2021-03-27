using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicInterface : MonoBehaviour
{
    private GUIStyle _styl;
    [SerializeField] private GUIStyle _button;
    [SerializeField] private GameObject _flashlight = null;
    [SerializeField] private GameObject _sun = null;
    private bool _isVisible = false;
    private string message;
    private bool _teleport = false;



    // Start is called before the first frame update
    private void OnGUI()
    {
        if (!_flashlight.activeSelf && _sun.GetComponent<Light>().intensity < 0.4) GUI.Label(new Rect((Screen.width / 2) - 150, (Screen.height) - 100, 300, 30), "Нажмите L, чтобы включить фонарик");
        if (!_teleport) GUI.Label(new Rect((Screen.width / 2) - 50, (Screen.height) - 100, 300, 30), "Нажмите T, чтобы телепортироваться к пещере");
        if (!_isVisible) return;
        GUI.Box(new Rect((Screen.width/2)-100, (Screen.height / 2)-70, 200, 300), "Menu");
        if (GUI.Button(new Rect((Screen.width / 2) - 50, (Screen.height / 2), 100, 50), "Open", _button)) message = "Open";
        if (GUI.Button(new Rect((Screen.width / 2) - 50, (Screen.height / 2)+70, 100, 50), "Save", _button)) message = "Save";
        if (GUI.Button(new Rect((Screen.width / 2) - 50, (Screen.height / 2) + 140, 100, 50), "Exit", _button)) message = "Exit";
        GUI.Label(new Rect((Screen.width / 2) - 50, (Screen.height / 2) + 210, 100, 30), message);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) _teleport = true;
        if (Input.GetKeyDown(KeyCode.Escape))
            _isVisible = !_isVisible;
        if (_isVisible) Time.timeScale = 0;
        else Time.timeScale = 1;

    }
}
