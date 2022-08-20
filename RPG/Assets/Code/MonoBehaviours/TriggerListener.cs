using Code.Abstract;
using Code.Components;
using Code.Components.Enemy;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.MonoBehaviours
{
    public class TriggerListener : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsEntity _entity;

        public void Initial(EcsWorld world, EcsEntity entity)
        {
            _world = world;
            _entity = entity;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent<EntityRef>(out var entity))
            {
                if (entity.Entity.Has<PlayerTag>())
                {
                    if (_entity.Has<SpawnTimer>())
                        return;
                    _world.NewEntity().Get<SpawnSignal>().Value = transform.position;
                    _entity.Get<SpawnTimer>().Value = 20;
                }
                /*ref var entity = ref _world.NewEntity().Get<AttackTrigger>();
                entity.Entity = other.GetComponentInParent<EntityRef>().Entity;
                entity.Self = _entity;*/
            }
            else
            {
                /*ref var entity = ref _world.NewEntity().Get<AttackTrigger>();
                entity.Self = _entity;*/
            }
        }
    }
}