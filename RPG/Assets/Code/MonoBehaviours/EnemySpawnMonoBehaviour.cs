using Code.Abstract;
using Code.Components.Enemy;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;

namespace Code.MonoBehaviours
{
    public class EnemySpawnMonoBehaviour:MonoBehaviourToEntity
    {
        public override void Initial(EcsEntity entity, EcsWorld world)
        {
            base.Initial(entity, world);
            entity.Get<EnemySpawnPoint>();
            GetComponent<TriggerListener>().Initial(world, entity);
        }
    }
}