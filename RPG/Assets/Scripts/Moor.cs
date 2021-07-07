using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moor : MonoBehaviour
{
    private bool _playerOnMoor = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !_playerOnMoor)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<EffectsSettings>().EnterMoor();
            _playerOnMoor = !_playerOnMoor;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && _playerOnMoor)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<EffectsSettings>().ExitMoor();
            _playerOnMoor = !_playerOnMoor;
        }
    }
}
