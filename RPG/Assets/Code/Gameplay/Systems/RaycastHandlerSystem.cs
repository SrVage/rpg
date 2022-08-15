using System;
using Code.Components.Input;
using Leopotam.Ecs;

namespace Client.Systems
{
    internal sealed class RaycastHandlerSystem:IEcsRunSystem
    {
        private readonly EcsFilter<RaycastHits> _raycast = null;
        public void Run()
        {
            foreach (var rdx in _raycast)
            {
                ref var raycastResults = ref _raycast.Get1(rdx).Value;
            }
        }
    }
}