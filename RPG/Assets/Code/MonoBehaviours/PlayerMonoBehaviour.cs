using Code.Abstract;
using Code.Components;
using Code.Components.Animations;
using Code.Components.Common;
using Code.Components.Navigation;
using Code.Gameplay;
using Leopotam.Ecs;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;

namespace Code.MonoBehaviours
{
    public class PlayerMonoBehaviour : MonoBehaviourToEntity
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Animator _animator;
        [SerializeField] private Rigidbody _rigidbody;

        public override void Initial(EcsEntity entity, EcsWorld world)
        {
            base.Initial(entity, world);
            if (TryGetComponent<PhotonView>(out var photon))
            {
                if (photon.IsMine) 
                    entity.Get<PlayerTag>();
                else
                {
                    entity.Get<OtherPlayerTag>();
                    entity.Get<Health>().Value = gameObject.GetComponent<HealthNetwork>().GetHealth();
                    entity.Get<Health>().Maximum = gameObject.GetComponent<HealthNetwork>().GetHealth();
                    entity.Get<Damage>().Value = 5;
                    gameObject.layer = LayerMask.NameToLayer("Default");
                }
                entity.Get<HealthNetworkRef>().Value = gameObject.GetComponent<HealthNetwork>();
                gameObject.GetComponent<HealthNetwork>().SetEntity(entity);
                entity.Get<DamageNetworkRef>().Value = gameObject.GetComponent<DamageNetwork>();
                gameObject.GetComponent<DamageNetwork>().SetEntity(entity);
            }
            else
                entity.Get<PlayerTag>();
            entity.Get<NavigationAgent>().Value = _navMeshAgent;
            entity.Get<AnimatorComponent>().Value = _animator;
            entity.Get<PhysicComponent>().Value = _rigidbody;
            entity.Get<Speed>().Value = 0;
            Debug.Log("Initial");
            GetComponent<AnimationEvent>().Init(entity);
        }
    }
}