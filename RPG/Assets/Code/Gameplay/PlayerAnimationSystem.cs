using Code.Components.Animations;
using Code.Components.Common;
using Code.Components.Navigation;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Gameplay
{
    internal sealed class PlayerAnimationSystem:IEcsRunSystem
    {
        private int _walk = Animator.StringToHash("isWalking");
        private int _speed= Animator.StringToHash("Speed");
        private int _punch = Animator.StringToHash("punch");
        private EcsFilter<AnimatorComponent, NavigationAgent> _animator = null;

        public void Run()
        {
            foreach (var adx in _animator)
            {
                ref var animator = ref _animator.Get1(adx).Value;
                ref var navigation = ref _animator.Get2(adx).Value;
                ref var entity = ref _animator.GetEntity(adx);
                var speed = navigation.velocity.sqrMagnitude/5;
                animator.SetFloat(_speed, speed);
                if (entity.Has<StartMove>()) 
                    animator.SetBool(_walk, true);
                if (entity.Has<EndMove>()) 
                    animator.SetBool(_walk, false);
                if (entity.Has<Punch>()) 
                    animator.SetTrigger(_punch);
            }
        }
    }
}