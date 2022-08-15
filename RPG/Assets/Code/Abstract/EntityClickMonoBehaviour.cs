using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Abstract
{
    public abstract class EntityClickMonoBehaviour:MonoBehaviour, IPointerClickHandler
    {
        protected EcsEntity _entity;
        public void Init(EcsEntity entity) => 
            _entity = entity;
        
        public virtual void OnPointerClick(PointerEventData eventData)
        {
            
        }
    }
}