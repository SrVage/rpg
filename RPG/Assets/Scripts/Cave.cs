using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cave : MonoBehaviour
{
    [SerializeField] private GameObject _terrain = null;
    [SerializeField] private GameObject _water = null;
    [SerializeField] private GameObject _cave = null;
    [SerializeField] private GameObject _sun = null;
    [SerializeField] private Transform _destination = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _terrain.SetActive(false);
            _water.SetActive(false);
            _sun.SetActive(false);
            _cave.SetActive(true);
            gameObject.SetActive(false);
            Invoke("Destination", 0.5f);
        }
    }

    private void Destination()
    {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Character>()._moveTarget = _destination.position;
    }
}
