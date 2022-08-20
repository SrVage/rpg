using Code.Abstract;
using Code.Abstract.Interfaces;
using Code.Components;
using Code.Components.Common;
using Code.Components.Enemy;
using Leopotam.Ecs;

namespace Code.Gameplay.Battle
{
    internal sealed class EnemyDeathSystem:IEcsRunSystem
    {
        private readonly EcsFilter<GameObjectRef, Death, KillExperience> _death = null;
        private readonly EcsFilter<PlayerTag> _player = null;
        public void Run()
        {
            foreach (var ddx in _death)
            {
                var experience = _death.Get3(ddx).Value;
                foreach (var pdx in _player)
                {
                    _player.GetEntity(pdx).Get<AddExperience>().Value = experience;
                }
                ref var gameObject = ref _death.Get1(ddx).GameObject;
                gameObject.GetComponent<IDestroy>().Destroy();
                _death.GetEntity(ddx).Destroy();
            }
        }
    }
}