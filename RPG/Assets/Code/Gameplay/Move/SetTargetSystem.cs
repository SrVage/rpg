using Code.Components;
using Code.Components.Navigation;
using Leopotam.Ecs;

namespace Code.Gameplay.Move
{
    internal sealed class SetTargetSystem:IEcsRunSystem
    {
        private readonly EcsFilter<TargetPoint> _target = null;
        private readonly EcsFilter<NavigationAgent, PlayerTag> _player = null;
        public void Run()
        {
            foreach (var tdx in _target)
            {
                ref var targetPoint = ref _target.Get1(tdx).Value;
                foreach (var pdx in _player)
                {
                    ref var navigationAgent = ref _player.Get1(pdx).Value;
                    navigationAgent.destination = targetPoint;
                }
            }
        }
    }
}