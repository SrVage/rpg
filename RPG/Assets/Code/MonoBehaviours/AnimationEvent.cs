using Code.Components;
using Code.Components.Audio;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.MonoBehaviours
{
    public class AnimationEvent:MonoBehaviour
    {
        private EcsEntity _entity;

        public void Init(EcsEntity entity)
        {
            _entity = entity;
        }
        public void Step()
        {
            _entity.Get<StepAudio>();
            //Debug.Log("Step");
        }

        public void Punch()
        {
            _entity.Get<AttackAudio>();
            _entity.Get<Components.Animations.AnimationEvent>();
        }
    }
}