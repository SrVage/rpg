using Code.Abstract.Interfaces;
using Code.Components;
using Code.Components.Common;
using Leopotam.Ecs;

namespace Code.Gameplay.UI
{
    internal sealed class PlayerUIHealthSystem:IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, Health> _player = null;
        private readonly IGameplayUIService _gameplayUIService = null;
        
        public void Run()
        {
            foreach (var pdx in _player)
            {
                var health = _player.Get2(pdx).Percent;
                _gameplayUIService.ChangeHealth(health);
            }
        }
    }
}