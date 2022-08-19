using System;
using Code.Abstract;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Config
{
    [CreateAssetMenu(menuName = "Configs/EnemyCfg")]
    public class EnemyConfig:ScriptableObject
    {
        [Serializable]
        public class Enemy
        {
            public AssetReference Prefab;
            public int Health;
            public int Damage;
            public int KillExperience;
        }
        public Enemy[] Enemies;
    }
}