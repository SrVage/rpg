using Code.Components.Navigation;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Gameplay.Enemy
{
    internal sealed class DelTargetSystem:IEcsRunSystem
    {
        private readonly EcsFilter<HasTarget> _target = null;
        
        public void Run()
        {
            foreach (var tdx in _target)
            {
                ref var time = ref _target.Get1(tdx).Time;
                time -= Time.deltaTime;
                if (time<=0)
                    _target.GetEntity(tdx).Del<HasTarget>();
            }
        }
    }
}