using Code.Abstract;
using Code.Components;
using Code.Components.Common;
using Leopotam.Ecs;

namespace Code.Gameplay.Network
{
    internal sealed class NetworkAttackSystem:IEcsRunSystem
    {
        private readonly EcsFilter<NetworkAttack> _networkAttack = null;
        private readonly EcsFilter<PlayerTag> _player = null;
        public void Run()
        {
            foreach (var ndx in _networkAttack)
            {
                var damage = _networkAttack.Get1(ndx).Damage;
                var entity = _networkAttack.GetEntity(ndx);
                foreach (var pdx in _player)
                {
                    _player.GetEntity(pdx).Get<Strike>().Value = damage;
                    entity.Del<NetworkAttack>();
                }
            }
        }
    }
}