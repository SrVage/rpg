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
    [SerializeField] private GameObject _flashlight = null;
    private Animator _anim = null;
    private AudioSource _as = null;
    [SerializeField] private AudioClip[] ac = null;

    private void Awake()
    {
        _as = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        _moveTarget = transform.position;
        _anim = GetComponent<Animator>();

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
                _moveTarget = hit.point+new Vector3(0,1,0);
                transform.LookAt(_moveTarget);
            }
        }
        if ((transform.position - _moveTarget).magnitude >= 1)
        {
            _anim.SetBool("isWalking", true);
            rb.AddForceAtPosition(Vector3.ClampMagnitude(((_moveTarget-transform.position)*0.5f), 5f), _moveTarget, ForceMode.VelocityChange);
            _anim.SetFloat("Speed", Mathf.Clamp((_moveTarget - transform.position).magnitude*0.5f, 0, 10));
            //transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
        //else if ((transform.position - _moveTarget).magnitude > 0.1 && (transform.position - _moveTarget).magnitude < 1.0)
        //{
        //    _anim.SetBool("isWalking", true);
        //    rb.AddForceAtPosition((_moveTarget - transform.position).normalized * 1, _moveTarget, ForceMode.VelocityChange);
        //}
        else {
            rb.velocity = new Vector3(0, 0, 0);
            _moveTarget = transform.position;
            _anim.SetBool("isWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            _flashlight.SetActive(!_flashlight.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            int a = Random.Range(0, 3);
            Debug.Log(a);
            if (a == 0) _anim.SetTrigger("attack");
            else if (a==1) _anim.SetTrigger("kick");
            else _anim.SetTrigger("punch");
        }
            
    }

    public void Step()
    {
        _as.PlayOneShot(ac[0]);
    }

    public void Kick()
    {
        _as.PlayOneShot(ac[2]);
    }

    public void Punch()
    {
        _as.PlayOneShot(ac[1]);
    }

    public void Axe()
    {
        _as.PlayOneShot(ac[3]);
    }

}
