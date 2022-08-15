using Code.Components.Input;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    internal sealed class ClickPointHandlerSystem:IEcsRunSystem
    {
        private const float RaycastMaxDistance = 100f;
        private readonly Camera _camera = null;
        private readonly EcsFilter<ClickPoint> _clickPoint = null;
        private readonly EcsWorld _world = null;

        public ClickPointHandlerSystem(Camera camera) => 
            _camera = camera;

        public void Run()
        {
            foreach (var cdx in _clickPoint)
            {
                ref var point = ref _clickPoint.Get1(cdx).Value;
                var ray = _camera.ScreenPointToRay(point);
                if (Physics.Raycast(ray, out var hit, RaycastMaxDistance))
                {
                    _world.NewEntity().Get<RaycastHits>().Value = hit;
                }
            }
        }
    }
}