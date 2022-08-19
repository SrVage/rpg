using Code.Abstract;
using Code.Components;
using Code.Components.Animations;
using Code.Components.Common;
using Code.Components.Navigation;
using Leopotam.Ecs;
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
            entity.Get<PlayerTag>();
            entity.Get<NavigationAgent>().Value = _navMeshAgent;
            entity.Get<AnimatorComponent>().Value = _animator;
            entity.Get<PhysicComponent>().Value = _rigidbody;
            entity.Get<Speed>().Value = 0;
            GetComponent<AnimationEvent>().Init(entity);
        }
    }
}