using System;
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
        }

        public Level[] Levels;
    }
}