using System;
using Code.Abstract;
using Code.Components;
using Code.Components.Common;
using Code.Components.Input;
using Code.Components.Navigation;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Gameplay.Character
{
    internal sealed class PlayerAttackSystem:IEcsRunSystem
    {
        private const int AttackDistance = 9;
        private readonly EcsFilter<GameObjectRef, PlayerTag, Damage> _player = null;
        private readonly EcsFilter<GameObjectRef, AttackTarget> _enemy = null;
        private readonly EcsWorld _world = null;

        public void Run()
        {
            foreach (var edx in _enemy)
            {
                ref var enemyTransform = ref _enemy.Get1(edx).Transform;
                foreach (var pdx in _player)
                {
                    ref var playerTransform = ref _player.Get1(edx).Transform;
                    if (Vector3.SqrMagnitude(playerTransform.position - enemyTransform.position) > AttackDistance)
                    {
                        _world.NewEntity().Get<TargetPoint>().Value = enemyTransform.position;
                    }
                    else
                    {
                        ref var damage = ref _player.Get3(pdx).Value;
                        _enemy.GetEntity(edx).Get<Strike>().Value = damage;
                    }
                }
            }
        }
    }
}