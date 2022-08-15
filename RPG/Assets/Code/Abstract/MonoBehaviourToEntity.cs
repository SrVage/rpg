using Leopotam.Ecs;
using UnityEngine;

namespace Code.Abstract
{
    public abstract class MonoBehaviourToEntity:MonoBehaviour
    {
        public virtual void Initial(EcsEntity entity, EcsWorld world)
        {
            gameObject.AddComponent<EntityRef>().Entity = entity;
            entity.Get<GameObjectRef>().GameObject = gameObject;
            entity.Get<GameObjectRef>().Transform = transform;
            Destroy(gameObject.GetComponent<MonoBehaviourToEntity>());
        }
    }
}