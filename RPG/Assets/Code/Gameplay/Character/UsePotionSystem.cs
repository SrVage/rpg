using Code.Components;
using Code.Components.Common;
using Leopotam.Ecs;

namespace Code.Gameplay.Character
{
    internal sealed class UsePotionSystem:IEcsRunSystem
    {
        private const int RestoreHealth = 100;
        private readonly EcsFilter<UsePotion> _usePotion = null;
        private readonly EcsFilter<PlayerTag, Health> _player = null;
        
        public void Run()
        {
            if (_usePotion.IsEmpty())
                return;
            foreach (var pdx in _player)
            {
                ref var health = ref _player.Get2(pdx).Value;
                ref var maximum = ref _player.Get2(pdx).Maximum;
                health += RestoreHealth;
                if (health>maximum) 
                    health = maximum;
                var entity = _player.GetEntity(pdx);
                if (entity.Has<HealthNetworkRef>())
                {
                    ref var hnr = ref entity.Get<HealthNetworkRef>().Value;
                    hnr.SetHealth(health);
                }
            }
        }
    }
}