using Code.Abstract;
using Code.Abstract.Enums;
using Code.Abstract.Interfaces;
using Code.Components.Common;
using Code.Components.Enemy;
using Code.Components.Navigation;
using Code.Config;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace Code.Services
{
    internal sealed class EnemySpawnService:IEnemySpawnService
    {
        private readonly EnemyConfig _enemyConfig = null;
        private readonly EcsWorld _world = null;
        private int _number = 0;

        [Inject]
        public EnemySpawnService(EnemyConfig enemyConfig, EcsWorld world)
        {
            _enemyConfig = enemyConfig;
            _world = world;
        }

        public async void Spawn(Vector3 spawnPoint, EnemyType type)
        {
            var enemyPrefab = _enemyConfig.Enemies[(int)type].Prefab;
            var enemyGameObject = enemyPrefab.InstantiateAsync(spawnPoint, Quaternion.identity);
            await enemyGameObject.Task;
            enemyGameObject.Result.name += _number;
            _number++;
            var enemyEntity = _world.NewEntity();
            enemyGameObject.Result.GetComponent<MonoBehaviourToEntity>().Initial(enemyEntity, _world);
            enemyEntity.Get<Health>().Value = _enemyConfig.Enemies[(int)type].Health;
            enemyEntity.Get<Health>().Maximum = _enemyConfig.Enemies[(int)type].Health;
            enemyEntity.Get<Damage>().Value = _enemyConfig.Enemies[(int)type].Damage;
            enemyEntity.Get<PatrolPoint>().Value = spawnPoint;
            enemyEntity.Get<KillExperience>().Value = _enemyConfig.Enemies[(int)type].KillExperience;
        }
    }
}