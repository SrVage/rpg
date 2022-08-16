using Code.Components.Enemy;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Gameplay.Enemy
{
    internal sealed class EnemySpawnTimerSystem:IEcsRunSystem
    {
        private readonly EcsFilter<SpawnTimer> _spawnTimer = null;
        public void Run()
        {
            foreach (var sdx in _spawnTimer)
            {
                ref var timer = ref _spawnTimer.Get1(sdx).Value;
                timer -= Time.deltaTime;
                if (timer<=0)
                    _spawnTimer.GetEntity(sdx).Del<SpawnTimer>();
            }
        }
    }
}