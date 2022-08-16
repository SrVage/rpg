using Code.Abstract;
using Code.Components.Enemy;
using Leopotam.Ecs;

namespace Code.MonoBehaviours
{
    public class EnemyMonoBehaviour:MonoBehaviourToEntity
    {
        public override void Initial(EcsEntity entity, EcsWorld world)
        {
            base.Initial(entity, world);
            entity.Get<EnemyTag>();
        }
    }
}