using Code.Abstract;
using Code.Abstract.Interfaces;
using Code.Components.Common;
using Code.Config;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace Code.Services
{
    internal sealed class EnemySpawnService:IEnemySpawnService
    {
        private readonly EnemyConfig _enemyConfig = null;
        private readonly EcsWorld _world;

        [Inject]
        public EnemySpawnService(EnemyConfig enemyConfig, EcsWorld world)
        {
            _enemyConfig = enemyConfig;
            _world = world;
        }

        public async void Spawn(Vector3 spawnPoint)
        {
            var enemyPrefab = _enemyConfig.Enemies[0].Prefab;
            var enemyGameObject = enemyPrefab.InstantiateAsync(spawnPoint, Quaternion.identity);
            await enemyGameObject.Task;
            var enemyEntity = _world.NewEntity();
            enemyGameObject.Result.GetComponent<MonoBehaviourToEntity>().Initial(enemyEntity, _world);
            enemyEntity.Get<Health>().Value = _enemyConfig.Enemies[0].Health;
            enemyEntity.Get<Damage>().Value = _enemyConfig.Enemies[0].Damage;
        }
    }
}