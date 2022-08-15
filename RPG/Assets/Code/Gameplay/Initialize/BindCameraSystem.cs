using Code.Abstract;
using Code.Components;
using Code.Components.Create;
using Leopotam.Ecs;

namespace Code.Gameplay.Initialize
{
    internal sealed class BindCameraSystem:IEcsRunSystem
    {
        private readonly EcsFilter<LoadLevelDone> _signal = null;
        private readonly EcsFilter<GameObjectRef, PlayerTag> _player = null;
        private readonly EcsFilter<VirtualCamera> _camera= null;
        
        public void Run()
        {
            if (_signal.IsEmpty())
                return;
            foreach (var pdx in _player)
            {
                ref var playerTransform = ref _player.Get1(pdx).Transform;
                foreach (var cdx in _camera)
                {
                    ref var camera = ref _camera.Get1(cdx).Value;
                    camera.m_Follow = playerTransform;
                }
            }
        }
    }
}