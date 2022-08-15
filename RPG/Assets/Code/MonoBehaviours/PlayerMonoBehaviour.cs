using Code.Abstract;
using Code.Components;
using Leopotam.Ecs;

namespace Code.MonoBehaviours
{
    public class PlayerMonoBehaviour:MonoBehaviourToEntity
    {
        public override void Initial(EcsEntity entity, EcsWorld world)
        {
            base.Initial(entity, world);
            entity.Get<PlayerTag>();
        }
    }
}