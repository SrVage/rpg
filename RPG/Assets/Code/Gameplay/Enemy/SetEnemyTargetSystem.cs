using Code.Abstract;
using Code.Components;
using Code.Components.Animations;
using Code.Components.Enemy;
using Code.Components.Input;
using Code.Components.Navigation;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Gameplay.Enemy
{
    internal sealed class SetEnemyTargetSystem:IEcsRunSystem
    {
        private const int VisibleZone = 50;
        private const int AttackZone = 3;
        private const int PatrolZone = 150;
        private readonly EcsFilter<NavigationAgent, EnemyTag, PatrolPoint>.Exclude<HasTarget> _enemy = null;
        private readonly EcsFilter<GameObjectRef, PlayerTag> _player = null;
        
        public void Run()
        {
            foreach (var edx in _enemy)
            {
                ref var navigation = ref _enemy.Get1(edx).Value;
                ref var patrolPoint = ref _enemy.Get3(edx).Value;
                foreach (var pdx in _player)
                {
                    ref var playerTransform = ref _player.Get1(pdx).Transform;
                    if (Vector3.Distance(playerTransform.position, navigation.transform.position) < AttackZone)
                    {
                        navigation.isStopped = true;
                        _enemy.GetEntity(edx).Get<EndMove>();
                        _player.GetEntity(pdx).Get<AttackTarget>();
                        //_enemy.GetEntity(edx).Get<Punch>();
                        continue;
                    }
                    if (Vector3.Distance(playerTransform.position, navigation.transform.position) < VisibleZone &&
                        Vector3.Distance(patrolPoint, navigation.transform.position) < PatrolZone)
                    {
                        navigation.destination = playerTransform.position;
                        navigation.isStopped = false;
                    }
                    else
                    {
                        navigation.destination = patrolPoint;
                        navigation.isStopped = false;
                    }
                    _enemy.GetEntity(edx).Get<HasTarget>().Time = 1;
                    _enemy.GetEntity(edx).Get<StartMove>();
                }
            }
        }
    }
}