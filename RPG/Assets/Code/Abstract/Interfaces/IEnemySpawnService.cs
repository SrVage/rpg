using UnityEngine;

namespace Code.Abstract.Interfaces
{
    public interface IEnemySpawnService
    {
        void Spawn(Vector3 spawnPoint);
    }
}