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
            Debug.Log("Step");
        }

        public void Punch()
        {
            _entity.Get<Components.Animations.AnimationEvent>();
        }
    }
}