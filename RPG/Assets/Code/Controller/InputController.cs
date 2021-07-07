using System;
using Code.Interface;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Code.Controller
{
    public class InputController : IRun
    {
        private Camera _camera;
        private Eventer _eventer;

        public InputController(Eventer eventer)
        {
            _eventer = eventer;
            _camera = Object.FindObjectOfType<Cam>().gameObject.GetComponent<Camera>();
        }

        public void Run(float deltaTime)
        {
            RaycastHit hit;
            if (!Input.GetKey(KeyCode.Mouse0)) return;
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.collider.gameObject.CompareTag("Terrain"))
                {
                   _eventer.RunClicked(hit.point);
                }
                else if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                }
            }
        }
    }
}