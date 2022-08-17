using System.Linq;
using Code.Abstract;
using Code.Abstract.Interfaces;
using Code.Components.Common;
using Code.Components.Create;
using Code.Config;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace Code.Services
{
    internal sealed class CreatePlayerService:ICreatePlayerService
    {
        private readonly EcsWorld _world = null;
        private readonly PlayersClassesConfig _playersClassesConfig = null;

        [Inject]
        public CreatePlayerService(EcsWorld world, PlayersClassesConfig playersClassesConfig)
        {
            _world = world;
            _playersClassesConfig = playersClassesConfig;
        }

        public async void CreatePlayer(PlayersClasses characterClass)
        {
            var playerPrefab = _playersClassesConfig.Players.First(c => c.Class == characterClass).Prefab;
            var playerGameObject = playerPrefab.InstantiateAsync();
            await playerGameObject.Task;
            var playerEntity = _world.NewEntity();
            playerGameObject.Result.GetComponent<MonoBehaviourToEntity>().Initial(playerEntity, _world);
            playerEntity.Get<Health>().Value =
                _playersClassesConfig.Players.First(c => c.Class == characterClass).InitialHealth;
            playerEntity.Get<Damage>().Value =
                _playersClassesConfig.Players.First(c => c.Class == characterClass).InitialDamage;
            var camera = GameObject.Instantiate(_playersClassesConfig.VirtualCamera);
            camera.GetComponent<MonoBehaviourToEntity>().Initial(_world.NewEntity(), _world);
            _world.NewEntity().Get<LoadLevelDone>();
        }
    }
}