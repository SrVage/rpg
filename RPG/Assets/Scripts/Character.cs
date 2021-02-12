using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Vector3 _mousePos = Vector3.zero;
    private Vector3 _moveTarget = Vector3.zero;
    private Rigidbody rb = null;
    [SerializeField] GameObject _camera = null;
    [SerializeField] private float _speed = 0;
    private Vector3 _mult = new Vector3(1, 0, 1);
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
       var ray = _camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction*100, Color.green);
        if (Physics.Raycast(ray, out hit) && Input.GetKey(KeyCode.Mouse0))
        {
            
            if (hit.collider.gameObject.CompareTag("Terrain"))
            {
                _moveTarget = hit.point;
                transform.LookAt(_moveTarget);
            }
        }
        if ((transform.position - _moveTarget).magnitude >= 1.0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
        else if ((transform.position - _moveTarget).magnitude > 0.2 && (transform.position - _moveTarget).magnitude < 1.0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * (_speed * (transform.position - _moveTarget).magnitude));
        }
        else transform.Translate(0, 0, 0);
    }
}
