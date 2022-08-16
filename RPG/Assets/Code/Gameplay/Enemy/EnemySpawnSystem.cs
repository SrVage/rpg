using Code.Abstract.Interfaces;
using Code.Components.Enemy;
using Leopotam.Ecs;

namespace Code.Gameplay.Enemy
{
    internal sealed class EnemySpawnSystem:IEcsRunSystem
    {
        private readonly EcsFilter<SpawnSignal> _spawnSignal = null;
        private readonly IEnemySpawnService _enemySpawnService = null;
        
        public void Run()
        {
            foreach (var sdx in _spawnSignal)
            {
                ref var spawnPoint = ref _spawnSignal.Get1(sdx).Value;
                _enemySpawnService.Spawn(spawnPoint);
            }
        }
    }
}