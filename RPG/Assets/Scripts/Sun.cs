using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    private Vector3 _night = new Vector3(270, 0, 0);
    private Vector3 _morning = new Vector3(5, 90, 0);
    private Vector3 _day = new Vector3(90, 180, 0);
    private Vector3 _evening = new Vector3(5, 270, 0);
    private int _time = 0;
    private Light _direct = null;
    // Start is called before the first frame update
    void Start()
    {
        _direct = GetComponent<Light>();
    }

    void Update()
    {
        gameObject.transform.Rotate(0, 0.01f, 0, Space.Self);
        //Debug.Log(transform.localRotation.eulerAngles.x);
        if (transform.localRotation.eulerAngles.x > 0 && transform.localRotation.eulerAngles.x <180)
            _direct.intensity = 0.03f * transform.localRotation.eulerAngles.x;
        else _direct.intensity = 0;

    }
}
