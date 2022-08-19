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
                health -= damage;
                if (health <= 0)
                {
                    _attacked.GetEntity(adx).Get<Death>();
                }
            }
        }
    }
}