using Code.Abstract.Interfaces;
using Code.Components;
using Leopotam.Ecs;
using Zenject;

namespace Code.Services
{
    internal sealed class GameplayCommandUIService:IGameplayCommandUIService
    {
        private readonly EcsWorld _world = null;

        [Inject]
        public GameplayCommandUIService(EcsWorld world) => 
            _world = world;

        public void ChangeRotateCamera() => 
            _world.NewEntity().Get<CameraRotate>();
    }
}