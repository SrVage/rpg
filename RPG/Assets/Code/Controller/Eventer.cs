using System;
using Code.Interface;
using UnityEngine;

namespace Code.Controller
{
    public enum State
    {
        Idle,
        Walk,
        Punch,
        Kick,
        RoundKick
    }
    
    public class Eventer
    {
        public event Action<Vector3> Clicked;
        public event Action<GameObject> ClickedObject;

        public event Action<State> AnimationState; 

        public void RunClicked(Vector3 point)
        {
            Clicked(point);
        }
        public void RunClickedObject(GameObject clickedObject)
        {
            ClickedObject(clickedObject);
        }

        public void State(State state)
        {
            
        }
    }
}