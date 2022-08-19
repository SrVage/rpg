using Code.Abstract;
using Code.Components.Common;
using Code.Components.Enemy;
using Code.Components.Navigation;
using Code.Components.UI;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Code.MonoBehaviours
{
    public class EnemyMonoBehaviour:MonoBehaviourToEntity
    {
        [SerializeField] private Image _health;
        [SerializeField] private Transform _healthTransform;
        [SerializeField] private NavMeshAgent _navigation;
        [SerializeField] private Animator _animator;

        public override void Initial(EcsEntity entity, EcsWorld world)
        {
            base.Initial(entity, world);
            entity.Get<EnemyTag>();
            entity.Get<HealthUI>().Value = _health;
            entity.Get<HealthUI>().Transform = _healthTransform;
            entity.Get<NavigationAgent>().Value = _navigation;
            entity.Get<AnimatorComponent>().Value = _animator;
            GetComponent<AnimationEvent>().Init(entity);
        }
    }
}