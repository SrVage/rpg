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
        private Eventer _eventer;
        private PlayerView _playerView;
        public CharacterController(Eventer eventer)
        {
            _eventer = eventer;
            eventer.Clicked += Move;
            _player = Object.FindObjectOfType<PlayerView>().gameObject.GetComponent<NavMeshAgent>();
            _playerPhysics = Object.FindObjectOfType<PlayerView>().gameObject.GetComponent<Rigidbody>();
            _playerView = Object.FindObjectOfType<PlayerView>();
        }

        private void Move(Vector3 point)
        {
            _player.SetDestination(point);
            _eventer.State(State.Walk);
        }
        
        public void Run(float deltaTime)
        {
            if ((_player.transform.position - _player.destination).magnitude < 1)
            {
                _playerView.PlayIdleAnimation();
            }
            else
            {
                _playerView.PlayWalkAnimation(_player.destination);
            }
        }
    }
}