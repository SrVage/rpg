using Code.Abstract;
using Code.Abstract.Interfaces;
using Code.Components.Common;
using Leopotam.Ecs;
using Photon.Pun;
using UnityEngine;

namespace Code.MonoBehaviours
{
    public class DamageNetwork:MonoBehaviourPunCallbacks, IPunObservable, IDamage
    {
        private int _damage;
        private EcsEntity _entity;

        public void SetEntity(EcsEntity entity) => _entity = entity;
        
        public int GetDamage() => _damage;

        public void SetDamage(int health)
        {
            _damage = health;
        }
        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(_damage);
                _damage = 0;
            }
            else
            {
                _damage = (int)stream.ReceiveNext();
                SetEntityDamage();
            }
        }

        private void SetEntityDamage()
        {
            if (_entity.IsNull()||!_entity.IsAlive())
                return;
            Debug.Log(_damage);
            if (_damage>0)
                _entity.Get<NetworkAttack>().Damage = _damage;
        }
    }
}