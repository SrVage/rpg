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
            Container.Bind<ILoadLevelService>().To<LoadLevelService>().AsSingle().NonLazy();
        }
    }
}