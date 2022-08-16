using Code.Abstract;
using Code.Components;
using Code.Components.Navigation;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;

namespace Code.MonoBehaviours
{
    public class PlayerMonoBehaviour : MonoBehaviourToEntity
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;

        public override void Initial(EcsEntity entity, EcsWorld world)
        {
            base.Initial(entity, world);
            entity.Get<PlayerTag>();
            entity.Get<NavigationAgent>().Value = _navMeshAgent;
        }
    }
}