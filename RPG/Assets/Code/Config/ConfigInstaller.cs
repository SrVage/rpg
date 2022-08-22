using UnityEngine;
using Zenject;

namespace Code.Config
{
    public class ConfigInstaller:MonoInstaller
    {
        [SerializeField] private PlayersClassesConfig _playersClassesConfig;
        [SerializeField] private LevelsConfig _levelsConfig;
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private PlayerExperienceOfLevelConfig _playerExperienceOfLevelConfig;
        [SerializeField] private SoundsConfig _soundsConfig;
        public override void InstallBindings()
        {
            Container.Bind<PlayersClassesConfig>().FromInstance(_playersClassesConfig).AsSingle();
            Container.Bind<LevelsConfig>().FromInstance(_levelsConfig).AsSingle();
            Container.Bind<EnemyConfig>().FromInstance(_enemyConfig).AsSingle();
            Container.Bind<PlayerExperienceOfLevelConfig>().FromInstance(_playerExperienceOfLevelConfig).AsSingle();
            Container.Bind<SoundsConfig>().FromInstance(_soundsConfig).AsSingle();
        }
    }
}