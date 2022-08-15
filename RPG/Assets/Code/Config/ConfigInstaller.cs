using UnityEngine;
using Zenject;

namespace Code.Config
{
    public class ConfigInstaller:MonoInstaller
    {
        [SerializeField] private PlayersClassesConfig _playersClassesConfig;
        [SerializeField] private LevelsConfig _levelsConfig;
        public override void InstallBindings()
        {
            Container.Bind<PlayersClassesConfig>().FromInstance(_playersClassesConfig).AsSingle();
            Container.Bind<LevelsConfig>().FromInstance(_levelsConfig).AsSingle();
        }
    }
}