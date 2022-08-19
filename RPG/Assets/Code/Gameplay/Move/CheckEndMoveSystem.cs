using System;
using Code.Components.Animations;
using Code.Components.Navigation;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Gameplay.Move
{
    internal sealed class CheckEndMoveSystem:IEcsRunSystem
    {
        private readonly EcsFilter<NavigationAgent> _navigation = null;
        
        public void Run()
        {
            foreach (var ndx in _navigation)
            {
                ref var navigation = ref _navigation.Get1(ndx).Value;
                if (navigation.isStopped)
                    return;
                if (Mathf.Abs((navigation.transform.position - navigation.destination).magnitude) <
                    navigation.stoppingDistance)
                {
                    navigation.isStopped = true;
                    _navigation.GetEntity(ndx).Get<EndMove>();
                }
            }
        }
    }
}