using Code.Extensions;
using Code.Interface;
using Code.Pool;
using Code.ServiceLocator;
using Code.View;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Controller
{
    public class CharacterController:IRun, IFire
    {
        private NavMeshAgent _player;
        private Rigidbody _playerPhysics;
        private Eventer _eventer;
        private PlayerView _playerView;
        private BulletPool _pool;
        public CharacterController(Eventer eventer)
        {
            _eventer = eventer;
            eventer.Clicked += Move;
            eventer.Fire += Fire;
            _player = Object.FindObjectOfType<PlayerView>().gameObject.GetComponent<NavMeshAgent>();
            _playerPhysics = Object.FindObjectOfType<PlayerView>().gameObject.GetComponent<Rigidbody>();
            _playerView = Object.FindObjectOfType<PlayerView>();
            //_pool = new BulletPool(20);
        }

        private void Move(Vector3 point)
        {
            _player.SetDestination(point);
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

        public void Fire(Vector3 firePoint)
        {
            var bullet = ServiceLocator.ServiceLocator.Resolve<IService>().GetFireball();
            bullet.transform.position = _playerView.FirePoint.position;
            bullet.AddForce((firePoint - bullet.transform.position).normalized * 2);
        }
    }
}