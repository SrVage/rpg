using Code.Abstract;
using Code.Components;
using Code.Components.Navigation;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Gameplay.Input
{
    internal sealed class TargetHandlerSystem:IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, GameObjectRef, NavigationAgent> _player = null;
        private readonly EcsFilter<Target, GameObjectRef> _target = null;
        public void Run()
        {
            foreach (var pdx in _player)
            {
                ref var playerTransform = ref _player.Get2(pdx).Transform;
                foreach (var tdx in _target)
                {
                    ref var targetTransform = ref _target.Get2(tdx).Transform;
                    if (Vector3.Distance(playerTransform.position, targetTransform.position) > 4)
                    {
                        ref var navigation = ref _player.Get3(pdx).Value;
                        navigation.SetDestination(targetTransform.position);
                    }
                    else
                    {
                        _target.GetEntity(tdx).Get<Doing>();
                    }
                }
            }
        }
    }
}