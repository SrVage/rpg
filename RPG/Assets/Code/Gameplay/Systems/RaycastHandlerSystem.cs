using Code.Components.Input;
using Code.Components.Navigation;
using Leopotam.Ecs;

namespace Code.Gameplay.Systems
{
    internal sealed class RaycastHandlerSystem:IEcsRunSystem
    {
        private readonly EcsFilter<RaycastHits> _raycast = null;
        private readonly EcsWorld _world = null;
        public void Run()
        {
            foreach (var rdx in _raycast)
            {
                ref var raycastResults = ref _raycast.Get1(rdx).Value;
                var target = raycastResults.point;
                _world.NewEntity().Get<TargetPoint>().Value = target;
            }
        }
    }
}