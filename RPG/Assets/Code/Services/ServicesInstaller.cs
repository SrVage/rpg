using Code.Abstract.Interfaces;
using Leopotam.Ecs;
using Zenject;

namespace Code.Services
{
    public class ServicesInstaller:MonoInstaller
    {
        private EcsWorld _world = new EcsWorld();
        public override void InstallBindings()
        {
            Container.Bind<EcsWorld>().FromInstance(_world).AsSingle();
            Container.Bind<ICreatePlayerService>().To<CreatePlayerService>().AsSingle().NonLazy();
            Container.Bind<ILoadLevelService>().To<LoadLevelService>().AsSingle();
            Container.Bind<IEnemySpawnService>().To<EnemySpawnService>().AsSingle();
            Container.Bind<IGameplayUIService>().To<GameplayUIService>().AsSingle();
        }
    }
}