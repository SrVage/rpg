using System.Linq;
using Code.Abstract;
using Code.Abstract.Interfaces;
using Code.Components.Common;
using Code.Components.Create;
using Code.Components.Player;
using Code.Config;
using Code.MonoBehaviours;
using Leopotam.Ecs;
using Photon.Pun;
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
        private readonly IPlayerSaveService _playerSaveService = null;
        private readonly IGameTypeService _gameTypeService = null;

        [Inject]
        public CreatePlayerService(EcsWorld world, PlayersClassesConfig playersClassesConfig,
            IChangePlayerLevel changePlayerLevel, IGameplayUIService gameplayUIService,
            IChoosePlayerService choosePlayerService, IPlayerSaveService playerSaveService,
            IGameTypeService gameTypeService)
        {
            _world = world;
            _playersClassesConfig = playersClassesConfig;
            _changePlayerLevel = changePlayerLevel;
            _gameplayUIService = gameplayUIService;
            _choosePlayerService = choosePlayerService;
            _playerSaveService = playerSaveService;
            _gameTypeService = gameTypeService;
        }

        public void CreatePlayer()
        {
            if (_gameTypeService.IsOnline)
                CreateNetworkPlayer();
            else
                CreateLocalPlayer();
        }

        private void CreateLocalPlayer()
        {
            PlayersClasses classes = _choosePlayerService.GetPlayer.Class;
            var playerPrefab = _playersClassesConfig.Players.First(c => c.Class == classes).Prefab;
            var playerGameObject = Object.Instantiate(playerPrefab);
            var playerEntity = _world.NewEntity();
            playerGameObject.GetComponent<MonoBehaviourToEntity>().Initial(playerEntity, _world);
            var health = _choosePlayerService.GetPlayer.Health;
            playerEntity.Get<Experience>().Level = _choosePlayerService.GetPlayer.Level;
            playerEntity.Get<Experience>().Value = _choosePlayerService.GetPlayer.XP;
            playerEntity.Get<Health>().Value = health;
            playerEntity.Get<Health>().Maximum = health;
            playerEntity.Get<Damage>().Value = _choosePlayerService.GetPlayer.Damage;
            _changePlayerLevel.SetPlayer(playerEntity);
            _playerSaveService.SetPlayer(playerEntity);
            var camera = GameObject.Instantiate(_playersClassesConfig.VirtualCamera);
            camera.GetComponent<MonoBehaviourToEntity>().Initial(_world.NewEntity(), _world);
            _world.NewEntity().Get<LoadLevelDone>();
            _gameplayUIService.ShowGamePlayUI();
            _gameplayUIService.ChangeLevel(_choosePlayerService.GetPlayer.Level);
            _changePlayerLevel.ChangeExperience(0);
        }
        private void CreateNetworkPlayer()
        {
            PlayersClasses classes = _choosePlayerService.GetPlayer.Class;
            var playerPrefab = _playersClassesConfig.Players.First(c => c.Class == classes).Prefab;
            var playerGameObject = PhotonNetwork.Instantiate(playerPrefab.name, playerPrefab.transform.position, Quaternion.identity);
            var playerEntity = _world.NewEntity();
            var health = _choosePlayerService.GetPlayer.Health;
            playerGameObject.GetComponent<HealthNetwork>().SetEntity(playerEntity);
            playerGameObject.GetComponent<HealthNetwork>().SetHealth(health);
            playerGameObject.GetComponent<MonoBehaviourToEntity>().Initial(playerEntity, _world);
            playerEntity.Get<Experience>().Level = _choosePlayerService.GetPlayer.Level;
            playerEntity.Get<Experience>().Value = _choosePlayerService.GetPlayer.XP;
            playerEntity.Get<Health>().Value = health;
            playerEntity.Get<Health>().Maximum = health;
            playerEntity.Get<Damage>().Value = _choosePlayerService.GetPlayer.Damage;
            _changePlayerLevel.SetPlayer(playerEntity);
            _playerSaveService.SetPlayer(playerEntity);
            var camera = GameObject.Instantiate(_playersClassesConfig.VirtualCamera);
            camera.GetComponent<MonoBehaviourToEntity>().Initial(_world.NewEntity(), _world);
            _world.NewEntity().Get<LoadLevelDone>();
            _gameplayUIService.ShowGamePlayUI();
            _gameplayUIService.ChangeLevel(_choosePlayerService.GetPlayer.Level);
            _changePlayerLevel.ChangeExperience(0);
        }
    }
}