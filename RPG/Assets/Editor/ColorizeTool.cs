#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;



public class ColorizeTool : EditorWindow
{
    [MenuItem("Tool/Colorizator")]

    
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ColorizeTool));
    }
private Color _objectColor;
    GameObject obj = null;
    private void OnGUI()
    {
       obj = EditorGUILayout.ObjectField(obj, typeof(GameObject), true) as GameObject;
        _objectColor = RGBSlider(new Rect(10, 50, 200, 20), _objectColor);
        if (obj != null) obj.GetComponent<Renderer>().sharedMaterial.color = _objectColor;
    }
    Color RGBSlider(Rect screenRect, Color rgb)
    {
        rgb.r = labelSlider(screenRect, rgb.r, 1.0f, "Red");
        screenRect.y += 20;
        rgb.g = labelSlider(screenRect, rgb.g, 1.0f, "Green");
        screenRect.y += 20;
        rgb.b = labelSlider(screenRect, rgb.b, 1.0f, "Blue");
        screenRect.y += 20;
        rgb.a = labelSlider(screenRect, rgb.a, 1.0f, "Alfa");
        return rgb;
    }

    float labelSlider(Rect screenRect, float sliderValue, float sliderMax, string labelText)
    {
        GUI.Label(screenRect, labelText);
        screenRect.x += screenRect.width;
        sliderValue = GUI.HorizontalSlider(screenRect, sliderValue, 0.0f, sliderMax);
        return sliderValue;
    }

}
#endif