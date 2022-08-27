using Code.Abstract.Interfaces;
using Code.Components;
using Code.Components.Common;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Gameplay.ChestSystems
{
    internal sealed class ChestOpenSystem:IEcsRunSystem
    {
        private const int LuckChance = 100;
        private readonly EcsFilter<Chest, Doing, AnimatorComponent> _chest = null;
        private int _open = Animator.StringToHash("Open");
        private readonly IGetThingsFromChest _getThingsFromChest;

        public void Run()
        {
            foreach (var cdx in _chest)
            {
                ref var animator = ref _chest.Get3(cdx).Value;
                animator.SetTrigger(_open);
                _chest.GetEntity(cdx).Del<Chest>();
                var chance = Random.Range(0, 100);
                if (chance < LuckChance)
                {
                    _getThingsFromChest.GetPotion();
                }
            }
        }
    }
}