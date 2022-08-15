using Code.Abstract;
using Code.Abstract.Enums;
using Code.Components.Create;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.MonoBehaviours
{
    public class SpawnPoint:MonoBehaviourToEntity
    {
        [SerializeField] private ConflictSide _conflictSide;
        public override void Initial(EcsEntity entity, EcsWorld world)
        {
            base.Initial(entity, world);
            switch (_conflictSide)
            {
                case ConflictSide.Player:
                    entity.Get<PlayerSpawn>().Value = transform.position;
                    break;
                case ConflictSide.Enemy:
                    break;
            }
        }
    }
}