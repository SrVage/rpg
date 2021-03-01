using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] GameObject _player = null;
    private Vector3 _offsetPos = new Vector3(0, 25, -25);
    private Vector3 _offsetRot = new Vector3 (45, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _player.transform.position+_offsetPos, 2f*Time.deltaTime);
        _offsetPos += new Vector3(0, -1*Input.GetAxis("Mouse ScrollWheel"), 0);
        _offsetRot += new Vector3(-1*Input.GetAxis("Mouse ScrollWheel")*5, 0, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(_offsetRot), Time.deltaTime);
    }
}
