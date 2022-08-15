using Code.Abstract;
using Code.Abstract.Interfaces;
using Code.Config;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Code.Services
{
    internal sealed class LoadLevelService:ILoadLevelService
    {
        private readonly LevelsConfig _levelsConfig = null;
        private readonly EcsWorld _world = null;
        private AsyncOperationHandle<GameObject> _level;

        [Inject]
        public LoadLevelService(LevelsConfig levelsConfig, EcsWorld world)
        {
            _levelsConfig = levelsConfig;
            _world = world;
        }
        
        public async void LoadMainLevel()
        {
            //UnloadLevel();   
            var level = Addressables.InstantiateAsync(_levelsConfig.Levels[0].Prefab);
            await level.Task;
            InitializeLevelObject(level.Result);
            _level = level;
        }

        public async void LoadCaveLevel()
        {
            var level = Addressables.InstantiateAsync(_levelsConfig.Levels[1].Prefab);
            await level.Task;
            InitializeLevelObject(level.Result);
            _level = level;
        }

        private void UnloadLevel()
        {
            if (_level.Result!=null)
                Addressables.Release(_level.Result);
        }
        
        private void InitializeLevelObject(GameObject level)
        {
            var levelObjects = level.GetComponentsInChildren<MonoBehaviourToEntity>();
            foreach (var levelObject in levelObjects)
            {
                levelObject.Initial(_world.NewEntity(), _world);
            }
        }
    }
}