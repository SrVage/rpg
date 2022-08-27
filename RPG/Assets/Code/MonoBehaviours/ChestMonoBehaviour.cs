using Code.Abstract;
using Code.Components;
using Code.Components.Common;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.MonoBehaviours
{
    public class ChestMonoBehaviour:MonoBehaviourToEntity
    {
        [SerializeField] private Animator _animator = null;
        public override void Initial(EcsEntity entity, EcsWorld world)
        {
            base.Initial(entity, world);
            entity.Get<AnimatorComponent>().Value = _animator;
            entity.Get<Chest>();
        }
    }
}