using Code.Abstract;
using Code.Components;
using Code.Components.Animations;
using Code.Components.Enemy;
using Code.Components.Input;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Gameplay.Systems
{
    internal sealed class ClickPointHandlerSystem:IEcsRunSystem
    {
        private const float RaycastMaxDistance = 400f;
        private readonly Camera _camera = null;
        private readonly EcsFilter<ClickPoint> _clickPoint = null;
        private readonly EcsFilter<PlayerTag, IsAnimation> _player = null;
        private readonly EcsWorld _world = null;

        public ClickPointHandlerSystem(Camera camera) => 
            _camera = camera;

        public void Run()
        {
            foreach (var cdx in _clickPoint)
            {
                if (!_player.IsEmpty())
                    return;
                ref var point = ref _clickPoint.Get1(cdx).Value;
                var ray = _camera.ScreenPointToRay(point);
                if (Physics.Raycast(ray, out var hit, RaycastMaxDistance))
                {
                    if (hit.collider.TryGetComponent<EntityRef>(out var entity))
                    {
                        if (entity.Entity.Has<EnemyTag>() || entity.Entity.Has<OtherPlayerTag>())
                        {
                            entity.Entity.Get<AttackTarget>();
                        }
                        if (entity.Entity.Has<Chest>())
                        {
                            entity.Entity.Get<Target>();
                        }
                    }
                    else
                    {
                        _world.NewEntity().Get<RaycastHits>().Value = hit;
                    }
                }
            }
        }
    }
}