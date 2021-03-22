using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> _partsOfBody = null;
    private Animator _anim = null;
    private Rigidbody _rb = null;
    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _partsOfBody.AddRange(GetComponentsInChildren<Rigidbody>());
        isKinematicOn();
    }

    private void isKinematicOn()
    {
        _anim.enabled = true;
        foreach (var obj in _partsOfBody)
        {
            obj.isKinematic = true;
        }
    }

    public void Death()
    {
        _anim.enabled = false;
        foreach (var obj in _partsOfBody)
        {
            obj.isKinematic = false;
        }
        _rb.AddForce((gameObject.transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).normalized * 15, ForceMode.Impulse);
    }
}
