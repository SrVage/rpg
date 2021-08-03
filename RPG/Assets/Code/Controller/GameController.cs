using System.Collections;
using System.Collections.Generic;
using Code.Controller;
using DefaultNamespace;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private BulletConfig _bulletConfig;
    private Controllers _controllers;
    // Start is called before the first frame update
    void Start()
    {
        _controllers = new Controllers();
        new GameInitialization(_controllers);
        new BulletPool(_bulletConfig);
        _controllers.Init();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;
        _controllers.Run(deltaTime);
    }
}
