using Code.Interface;
using Code.View;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Controller
{
    public class CharacterController:IRun
    {
        private NavMeshAgent _player;
        private Rigidbody _playerPhysics;
        public CharacterController(Eventer eventer)
        {
            eventer.Clicked += Move;
            _player = Object.FindObjectOfType<PlayerView>().gameObject.GetComponent<NavMeshAgent>();
            _playerPhysics = Object.FindObjectOfType<PlayerView>().gameObject.GetComponent<Rigidbody>();
        }

        private void Move(Vector3 point)
        {
            _player.SetDestination(point);
        }
        
        public void Run(float deltaTime)
        {

        }
    }
}