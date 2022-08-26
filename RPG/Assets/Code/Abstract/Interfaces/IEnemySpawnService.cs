using Code.Abstract.Enums;
using UnityEngine;

namespace Code.Abstract.Interfaces
{
    public interface IEnemySpawnService
    {
        void Spawn(Vector3 spawnPoint, EnemyType type);
    }
}