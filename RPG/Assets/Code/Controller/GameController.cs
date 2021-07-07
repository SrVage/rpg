using System.Collections;
using System.Collections.Generic;
using Code.Controller;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Controllers _controllers;
    // Start is called before the first frame update
    void Start()
    {
        _controllers = new Controllers();
        new GameInitialization(_controllers);
        _controllers.Init();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;
        _controllers.Run(deltaTime);
    }
}
