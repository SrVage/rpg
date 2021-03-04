using UnityEngine;

public class Character : MonoBehaviour
{
    private int _health = 0;
    private int _attack = 0;
    [SerializeField] private ScriptableObjectData _data;
    private Vector3 _mousePos = Vector3.zero;
    private Vector3 _moveTarget = Vector3.zero;
    private Rigidbody rb = null;
    [SerializeField] GameObject _camera = null;
    [SerializeField] private float _speed = 0;
    private Vector3 _mult = new Vector3(1, 0, 1);
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _moveTarget = transform.position;  
    }
    // Start is called before the first frame update
    void Start()
    {
        Init(_data);
        
    }


    private void OnGUI()
    {
        GUI.Label(new Rect(Screen.width -110, 10, 100, 100), _health.ToString());
        if (GUI.Button(new Rect(10, Screen.height - 60, 100, 50), "Damage")) getDamage(10);
    }

    private void Init(ScriptableObjectData data)
    {
        _health = data.health;
        _attack = data.attack;
    }

    public void getDamage(int damage)
    {
        _health -= damage;
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
