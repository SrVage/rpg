using System;
using Code.Abstract;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Config
{
    [CreateAssetMenu(menuName = "Configs/LevelCfg")]
    public class LevelsConfig:ScriptableObject
    {
        [Serializable]
        public class Level
        {
            public AssetReference Prefab;
            public Transform PlayerSpawnPoint;
            public Transform[] EnemySpawnPoints;
        }

        public Level[] Levels;
    }
}