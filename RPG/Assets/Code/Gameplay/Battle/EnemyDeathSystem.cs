using Code.Abstract;
using Code.Abstract.Interfaces;
using Code.Components.Common;
using Leopotam.Ecs;

namespace Code.Gameplay.Battle
{
    internal sealed class EnemyDeathSystem:IEcsRunSystem
    {
        private readonly EcsFilter<GameObjectRef, Death> _death = null;
        public void Run()
        {
            foreach (var ddx in _death)
            {
                ref var gameObject = ref _death.Get1(ddx).GameObject;
                gameObject.GetComponent<IDestroy>().Destroy();
                _death.GetEntity(ddx).Destroy();
            }
        }
    }
}