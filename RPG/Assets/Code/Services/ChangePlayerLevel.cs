using Code.Abstract.Interfaces;
using Code.Components.Common;
using Code.Components.Player;
using Code.Config;
using Leopotam.Ecs;

namespace Code.Services
{
    internal sealed class ChangePlayerLevel:IChangePlayerLevel
    {
        private readonly PlayerExperienceOfLevelConfig _experienceOfLevelConfig = null;
        private readonly IGameplayUIService _gameplayUIService = null;
        private readonly IChoosePlayerService _choosePlayerService = null;
        private readonly IPlayerSaveService _playerSaveService = null;
        private EcsEntity _player;

        public ChangePlayerLevel(PlayerExperienceOfLevelConfig playerExperienceOfLevelConfig, 
            IGameplayUIService gameplayUIService, IChoosePlayerService choosePlayerService)
        {
            _experienceOfLevelConfig = playerExperienceOfLevelConfig;
            _gameplayUIService = gameplayUIService;
            _choosePlayerService = choosePlayerService;
        }

        public void SetPlayer(EcsEntity entity) => 
            _player = entity;

        public void ChangeExperience(int change)
        {
            ref var experience = ref _player.Get<Experience>().Value;
            ref var level = ref _player.Get<Experience>().Level;
            experience += change;
            _choosePlayerService.GetPlayer.XP = experience;
            int maxLevelExperience = _experienceOfLevelConfig.Experience[level];
            if (experience >= maxLevelExperience)
            {
                level++;
                ChangePlayerCharacteristics(level);
                _gameplayUIService.ChangeLevel(level);
                _choosePlayerService.GetPlayer.Level = level;
                maxLevelExperience = _experienceOfLevelConfig.Experience[level];
            }
            int previousExperience = level > 0 ? _experienceOfLevelConfig.Experience[level - 1] : 0;
            int differenceExperience = maxLevelExperience - previousExperience;
            float percentExperience =
                (float)(experience - previousExperience) / (float)differenceExperience;
            _gameplayUIService.ChangeExperience(percentExperience);
        }

        private void ChangePlayerCharacteristics(int level)
        {
            _player.Get<Damage>().Value = _experienceOfLevelConfig.Damage[level];
            _player.Get<Health>().Value = _experienceOfLevelConfig.Health[level];
            _player.Get<Health>().Maximum = _experienceOfLevelConfig.Health[level];
            _choosePlayerService.GetPlayer.Health = _experienceOfLevelConfig.Health[level];
            _choosePlayerService.GetPlayer.Damage = _experienceOfLevelConfig.Damage[level];
            _gameplayUIService.ChangeHealth(1);
        }
    }
}