using Code.Components.Common;
using Leopotam.Ecs;

namespace Code.Gameplay.Character
{
    internal sealed class DamageSystem:IEcsRunSystem
    {
        private readonly EcsFilter<Health, Strike> _attacked = null;
        public void Run()
        {
            foreach (var adx in _attacked)
            {
                ref var health = ref _attacked.Get1(adx).Value;
                ref var damage = ref _attacked.Get2(adx).Value;
                var entity = _attacked.GetEntity(adx);
                health -= damage;
                if (entity.Has<HealthNetworkRef>())
                {
                    ref var hnr = ref entity.Get<HealthNetworkRef>().Value;
                    hnr.SetHealth(health);
                }
                if (health <= 0)
                {
                    entity.Get<Death>();
                }
            }
        }
    }
}