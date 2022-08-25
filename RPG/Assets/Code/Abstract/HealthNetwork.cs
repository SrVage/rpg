using Code.Abstract.Interfaces;
using Code.Components.Common;
using Leopotam.Ecs;
using Photon.Pun;
using UnityEngine;

namespace Code.MonoBehaviours
{
    public class HealthNetwork:MonoBehaviourPunCallbacks, IPunObservable, IHealth
    {
        [SerializeField]private int _health;
        private EcsEntity _entity;

        public void SetEntity(EcsEntity entity) => _entity = entity;
        public int GetHealth() => _health;

        public void SetHealth(int health)
        {
            _health = health;
        }
        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
                stream.SendNext(_health);
            else
            {
                _health = (int)stream.ReceiveNext();
                SetEntityHealth();
            }
        }

        private void SetEntityHealth()
        {
            Debug.Log(_health);
            if (_entity.IsNull()||!_entity.IsAlive())
                return;
            _entity.Get<Health>().Value = _health;
        }
    }
}