using Code.Abstract;
using Code.Abstract.Enums;
using Code.Components.Enemy;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.MonoBehaviours
{
    public class EnemySpawnMonoBehaviour:MonoBehaviourToEntity
    {
        [SerializeField] private EnemyType _type;

        public override void Initial(EcsEntity entity, EcsWorld world)
        {
            base.Initial(entity, world);
            entity.Get<EnemySpawnPoint>();
            entity.Get<SpawnType>().Value = _type;
            GetComponent<TriggerListener>().Initial(world, entity);
        }
    }
}