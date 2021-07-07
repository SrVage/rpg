using System;
using Code.Interface;
using UnityEngine;

namespace Code.Controller
{
    public class Eventer
    {
        public event Action<Vector3> Clicked;
        public event Action<GameObject> ClickedObject;

        public void RunClicked(Vector3 point)
        {
            Clicked(point);
        }
        public void RunClickedObject(GameObject clickedObject)
        {
            ClickedObject(clickedObject);
        }
    }
}