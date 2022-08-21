using System.Linq;
using Code.Abstract;
using Code.Abstract.Interfaces;
using Code.Components.Common;
using Code.Components.Create;
using Code.Components.Player;
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
        private readonly IChangePlayerLevel _changePlayerLevel = null;
        private readonly IGameplayUIService _gameplayUIService = null;
        private readonly IChoosePlayerService _choosePlayerService = null;

        [Inject]
        public CreatePlayerService(EcsWorld world, PlayersClassesConfig playersClassesConfig,
            IChangePlayerLevel changePlayerLevel, IGameplayUIService gameplayUIService,
            IChoosePlayerService choosePlayerService)
        {
            _world = world;
            _playersClassesConfig = playersClassesConfig;
            _changePlayerLevel = changePlayerLevel;
            _gameplayUIService = gameplayUIService;
            _choosePlayerService = choosePlayerService;
        }

        public async void CreatePlayer()
        {
            PlayersClasses classes = _choosePlayerService.GetPlayer.Class;
            var playerPrefab = _playersClassesConfig.Players.First(c => c.Class == classes).Prefab;
            var playerGameObject = playerPrefab.InstantiateAsync();
            await playerGameObject.Task;
            var playerEntity = _world.NewEntity();
            playerGameObject.Result.GetComponent<MonoBehaviourToEntity>().Initial(playerEntity, _world);
            var health = _choosePlayerService.GetPlayer.Health;
            playerEntity.Get<Experience>().Level = _choosePlayerService.GetPlayer.Level;
            playerEntity.Get<Experience>().Value = _choosePlayerService.GetPlayer.XP;
            playerEntity.Get<Health>().Value = health;
            playerEntity.Get<Health>().Maximum = health;
            playerEntity.Get<Damage>().Value = _choosePlayerService.GetPlayer.Damage;
            _changePlayerLevel.SetPlayer(playerEntity);
            var camera = GameObject.Instantiate(_playersClassesConfig.VirtualCamera);
            camera.GetComponent<MonoBehaviourToEntity>().Initial(_world.NewEntity(), _world);
            _world.NewEntity().Get<LoadLevelDone>();
            _gameplayUIService.ShowGamePlayUI();
        }
    }
}